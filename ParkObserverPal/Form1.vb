Imports DevExpress.XtraGrid
Imports DevExpress.XtraMap
Imports SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPivotGrid

Public Class Form1

    Dim MapLayersDataTable As New DataTable("Layers")
    Dim POZDataSet As New DataSet
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Temporary holder for poz file
        Dim POZZipFile As String = "C:\Temp\Loons 2022-03-24 1230.poz"

        'Create a Dataset into which to dump the contents of all the CSV files in POZZipFile
        POZDataSet.Clear()
        POZDataSet = GetDatasetFromPOZFile(POZZipFile)
        Dim DSTabPage As New TabPage("Park Observer Dataset")
        Me.MainTabControl.TabPages.Add(DSTabPage)
        Dim DSPropertyGrid As New PropertyGrid
        DSPropertyGrid.Dock = DockStyle.Fill
        DSPropertyGrid.SelectedObject = POZDataSet
        DSTabPage.Controls.Add(DSPropertyGrid)

        LoadPOZDataset(POZDataSet)

        Me.MapControl.ZoomToFitLayerItems()
        With Me.MapControl
            .BackColor = Color.LightSteelBlue
        End With

        'Load the MapLayersCheckedListBoxControl with data table names
        For Each DT As DataTable In POZDataSet.Tables
            Me.MapLayersCheckedListBoxControl.Items.Add(DT.TableName, True)
        Next


    End Sub

    ''' <summary>
    ''' Loads a POZDataset into various grids, pivot grids and map controls on the main form
    ''' </summary>
    ''' <param name="POZDataset">Park Observer Dataset. POZDataset.</param>
    Private Sub LoadPOZDataset(POZDataset As DataSet)
        Try
            'Loop through each DataTable in POZDataset
            For Each CSVDataTable As DataTable In POZDataset.Tables
#Region "GridControl"

                'Create a GridControl to display the CSVData
                Dim CSVGridControl As New GridControl
                Dim CSVGridView As New GridView
                With CSVGridControl
                    .ViewCollection.Add(CSVGridView)
                    .DataSource = CSVDataTable
                    .Dock = DockStyle.Fill
                    .Name = CSVDataTable.TableName & "GridControl"
                End With
                SetUpGridControl(CSVGridControl)

                'Create a new tabpage to hold a grid showing the CSV datatable 
                Dim CSVTabPage As New TabPage(CSVDataTable.TableName & " Dataset")
                CSVTabPage.Controls.Add(CSVGridControl)

                'Add the new data grid tab page to the main TabControl
                Me.MainTabControl.TabPages.Add(CSVTabPage)
#End Region

#Region "PivotGrid"
                'Create a PivotGridControl and add it to the main tab control
                Dim CSVPivotGridTabPage As New TabPage(CSVDataTable.TableName & " Pivot Table")
                Dim CSVPivotGridControl As New PivotGridControl
                With CSVPivotGridControl
                    .DataSource = CSVDataTable
                    .RetrieveFields()
                End With
                SetUpPivotGridControl(CSVPivotGridControl)

                'Add the controls above to the main tab control
                CSVPivotGridTabPage.Controls.Add(CSVPivotGridControl)
                Me.MainTabControl.TabPages.Add(CSVPivotGridTabPage)

#End Region



#Region "Map"
                'Load the CSV spatial data into the map
                'Find out if the data tables contain lat/lon columns
                'Some tables have LatLon stored in columns named Latitude and Longitude
                'Some tables have LatLon stored in columns named Feature_Latitude and Feature_Longitude
                Dim LatColumnName As String = ""
                Dim LonColumnName As String = ""
                For Each Col As DataColumn In CSVDataTable.Columns
                    If Col.ColumnName.Trim = "Latitude" Then
                        LatColumnName = "Latitude"
                        LonColumnName = "Longitude"
                        Exit For
                    ElseIf Col.ColumnName = "Feature_Latitude" Then
                        LatColumnName = "Feature_Latitude"
                        LonColumnName = "Feature_Longitude"
                        Exit For
                    End If
                Next
                'Create a VectorItemsLayer to show the spatial data
                Dim LabelLayer As New VectorItemsLayer
                Dim Color As Color = Color.Gray
                Dim PtSize As Integer = 4

                'Add the tracklog to the map
                If CSVDataTable.TableName.ToLower = "gpspoints" Then
                    'Draw a tracklog as a line vector items layer
                    Dim TrackLogVectorItemsLayer As VectorItemsLayer = GetTracklogLineVectorItemsLayer(CSVDataTable, "Latitude", "Longitude", "Timestamp", Color.Gray, 1)
                    Me.MapControl.Layers.Add(TrackLogVectorItemsLayer)
                    Me.MapControl.ZoomToFitLayerItems()
                Else
                    'Draw the the layer as a points vector items layer
                    Color = Color.FromArgb(CInt(Int((255 * Rnd()) + 1)), CInt(Int((255 * Rnd()) + 1)), CInt(Int((255 * Rnd()) + 1)))
                    PtSize = 20

                    Dim CSVLayer As VectorItemsLayer = GetBubbleVectorItemsLayerFromPointsDataTable(CSVDataTable, LatColumnName, LonColumnName, PtSize, MarkerType.Circle, Color)
                    Me.MapControl.Layers.Add(CSVLayer)

                    'Dim CSVLabelLayer As VectorItemsLayer = GetLabelVectorItemsLayerFromPointsDataTable(CSVDataTable, LatColumnName, LonColumnName, CSVDataTable.Columns(0).ColumnName)
                    'Me.MapControl.Layers.Add(CSVLabelLayer)
                End If

#End Region
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
    End Sub

    Private Function GetDatasetFromPOZFile(POZFile As String) As DataSet
        Dim POZDataset As New DataSet("Park Observer Dataset")
        Try
            If My.Computer.FileSystem.FileExists(POZFile) Then
                'Get the POZ file into a FileInfo to get at more information about it
                Dim POZFileInfo As New System.IO.FileInfo(POZFile)

                'I need to extract the files in the POZ zip arching into a directory
                'This directory will be in the same directory as the POZ file and will have the name
                'of the POZ file with the '.poz' part trimmed off
                Dim POZFilesDirectory As String = POZFileInfo.FullName.Replace(".poz", "").Trim

                'If the directory exists already blow away everything in it with permission
                Dim OKToProceed As Boolean = True
                If My.Computer.FileSystem.DirectoryExists(POZFilesDirectory) Then
                    If MsgBox("The application needs to delete all the files in directory " & POZFilesDirectory & ". Proceed?", MsgBoxStyle.YesNo, "Delete existing POZ files?") = MsgBoxResult.Yes Then
                        My.Computer.FileSystem.DeleteDirectory(POZFilesDirectory, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    Else
                        'I can't proceed
                        OKToProceed = False
                        MsgBox("The application can't proceed until the directory " & POZFilesDirectory & " is empty. Delete all the files and try again.")
                    End If
                End If

                'If the POZ files directory is cleared out and ready to use then extract the POZ files into it
                If OKToProceed = True Then
                    'Extract the files into the POZ files directory from above
                    System.IO.Compression.ZipFile.ExtractToDirectory(POZFile, POZFilesDirectory)

                    'Now cycle through the .csv files and load the contents into DataTables
                    For Each CSVFIle As String In My.Computer.FileSystem.GetFiles(POZFilesDirectory)
                        Dim CSVFileInfo As New FileInfo(CSVFIle)
                        Dim CSVName As String = CSVFileInfo.Name.Replace(".csv", "")

                        'Make sure the file is a CSV file
                        If CSVFileInfo.Extension = ".csv" Then
                            'Create a DataTable to hold the CSV data
                            Dim CSVDataTable As DataTable = GetDataTableFromCSV(CSVFileInfo, True, Format.Delimited)
                            CSVDataTable.TableName = CSVName


                            'Add the DataTable above to the POZDataset
                            POZDataset.Tables.Add(CSVDataTable)
                        End If
                    Next
                End If
            Else
                MsgBox("Park Observer file " & POZFile & " does not exist.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
        Return POZDataset
    End Function



    'Private Sub AddCustomElement()
    '    Dim VL As New VectorItemsLayer
    '    Dim mis As New MapItemStorage
    '    VL.Data = mis
    '    Dim customElement = New MapCustomElement() With {.Location = New GeoPoint(61.2108, -149.905121), .Text = "Sktr"}
    '    mis.Items.Add(customElement)
    '    Me.MapControl.Layers.Add(VL)
    'End Sub



    ''' <summary>
    ''' Returns a DevExpress VectorItemsLayer of MapBubble points derived a DataTable containing Lat/Lon pairs.
    ''' </summary>
    ''' <param name="PointsDataTable">DataTable containing points spatial data. DataTable</param>
    ''' <param name="LatitudeColumnName">Name of the latitude column. String.</param>
    ''' <param name="LongitudeColumnName">Name of the longitude column. String.</param>
    ''' <returns>VectorItemLayer of points from WKT.</returns>
    Public Function GetLabelVectorItemsLayerFromPointsDataTable(PointsDataTable As DataTable, LatitudeColumnName As String, LongitudeColumnName As String, TextColumnName As String) As DevExpress.XtraMap.VectorItemsLayer
        Dim MyMapItemStorage As New MapItemStorage
        Dim MyPointsVectorItemsLayer As New VectorItemsLayer()
        If LatitudeColumnName.Trim <> "" And LongitudeColumnName.Trim <> "" Then
            For Each MyPointDataRow As DataRow In PointsDataTable.Rows
                If Not MyPointDataRow Is Nothing Then
                    If Not IsDBNull(MyPointDataRow.Item(LatitudeColumnName)) And Not IsDBNull(MyPointDataRow.Item(LongitudeColumnName)) Then
                        Dim Lat As Double = CDbl(MyPointDataRow.Item(LatitudeColumnName))
                        Dim Lon As Double = CDbl(MyPointDataRow.Item(LongitudeColumnName))
                        Dim Label As String = MyPointDataRow.Item(TextColumnName)
                        Dim MyCustomElement As New MapCustomElement
                        'Dim MyImage = New Bitmap("C:\Work\Database and Web Development\icons and images\famfamfam_silk_icons_v013\icons\stop.png")

                        With MyCustomElement
                            .Location = New GeoPoint(Lat, Lon)
                            .Text = Label
                            .Fill = Color.DarkGoldenrod
                            '.Image = MyImage
                        End With
                        MyMapItemStorage.Items.Add(MyCustomElement)
                    End If
                End If
            Next
            With MyPointsVectorItemsLayer
                .Data = MyMapItemStorage
                .Name = PointsDataTable.TableName & "Labels"
            End With
        End If
        Return MyPointsVectorItemsLayer
    End Function

    Private Function GetTracklogLineVectorItemsLayer(PointsDataTable As DataTable, LatitudeColumnName As String, LongitudeColumnName As String, TimeColumnName As String, Color As Color, Width As Integer) As VectorItemsLayer
        'Create a VectorItemsLayer
        Dim MyLineVectorItemsLayer As New VectorItemsLayer

        Try
            'Create a DataView so that we can sort the rows by TimeStamp
            Dim DV As DataView = PointsDataTable.DefaultView
            DV.Sort = TimeColumnName

            'Create a MapItemStorage to hold the points
            Dim MyMapItemStorage As New MapItemStorage

            'Create a MapPolyLine
            Dim MyMapPolyLine As New MapPolyline
            With MyMapPolyLine
                .Stroke = Color
                .StrokeWidth = Width
                '.TitleOptions = MyShapeTitleOptions                
            End With

            'Loop through the points DataView and assemble a line from the time-sorted points, add them to the line's points collection
            For Each Row As DataRowView In DV
                If Not Row Is Nothing Then
                    Dim MyPointDataRow As DataRow = Row.Row
                    If Not IsDBNull(MyPointDataRow.Item(LatitudeColumnName)) And Not IsDBNull(MyPointDataRow.Item(LongitudeColumnName)) Then
                        Dim Lat As Double = CDbl(MyPointDataRow.Item(LatitudeColumnName))
                        Dim Lon As Double = CDbl(MyPointDataRow.Item(LongitudeColumnName))
                        Dim MyGeoPoint As New GeoPoint(Lat, Lon)
                        MyMapPolyLine.Points.Add(MyGeoPoint)
                    End If
                End If
            Next

            'Add the line to the MapItemStorage
            MyMapItemStorage.Items.Add(MyMapPolyLine)

            'Assign the items to the line VectorItemsLayer
            MyLineVectorItemsLayer.Data = MyMapItemStorage
            MyLineVectorItemsLayer.Name = "GpsPoints"
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try

        Return MyLineVectorItemsLayer
    End Function

    ''' <summary>
    ''' Returns a DevExpress VectorItemsLayer of MapBubble points derived a DataTable containing Lat/Lon pairs.
    ''' </summary>
    ''' <param name="PointsDataTable">DataTable containing points spatial data. DataTable</param>
    ''' <param name="LatitudeColumnName">Name of the latitude column. String.</param>
    ''' <param name="LongitudeColumnName">Name of the longitude column. String.</param>
    ''' <returns>VectorItemLayer of points from WKT.</returns>
    Public Function GetBubbleVectorItemsLayerFromPointsDataTable(PointsDataTable As DataTable, LatitudeColumnName As String, LongitudeColumnName As String, FeatureSize As Integer, MarkerType As MarkerType, FillColor As Color) As DevExpress.XtraMap.VectorItemsLayer
        'Create a MapItemStorage object (basically DevExpress's version of a spatial data table, stores MapItem objects which are like DataRows
        Dim MyMapItemStorage As New MapItemStorage

        'Create a new VectorItemsLayer which is essentially a map layer
        Dim MyPointsVectorItemsLayer As New VectorItemsLayer()

        'Make sure we have spatial column names
        If LatitudeColumnName.Trim <> "" And LongitudeColumnName.Trim <> "" Then

            'Convert .NET DataRows to MapBubbles
            For Each MyPointDataRow As DataRow In PointsDataTable.Rows
                'Make sure we have a valid row
                If Not MyPointDataRow Is Nothing Then
                    'Make sure the LatLon columns are not NULL
                    If Not IsDBNull(MyPointDataRow.Item(LatitudeColumnName)) And Not IsDBNull(MyPointDataRow.Item(LongitudeColumnName)) Then

                        'Get the Lat/Lon
                        Dim Lat As Double = CDbl(MyPointDataRow.Item(LatitudeColumnName))
                        Dim Lon As Double = CDbl(MyPointDataRow.Item(LongitudeColumnName))

                        'Make a new MapBubble
                        Dim MyMapBubble As New MapBubble()
                        With MyMapBubble
                            'Give the bubble a geo-location
                            .Location = New GeoPoint(Lat, Lon)

                            'Make the MapBubble object the same as the source DataRow (transfer DataTable model)
                            For Each Col As DataColumn In PointsDataTable.Columns
                                Dim MIA As New MapItemAttribute
                                With MIA
                                    .Name = Col.ColumnName 'The name of the column
                                    .Value = MyPointDataRow.Item(Col.ColumnName) 'The value at the Row/Column intersection
                                End With
                                'Add the attribute to the MapBubble
                                .Attributes.Add(MIA)
                            Next

                            'Give it styling
                            .MarkerType = MarkerType
                            .Fill = FillColor
                        End With

                        'Add the MapBubble to the MapItemStorage 
                        MyMapItemStorage.Items.Add(MyMapBubble)
                    End If
                End If
            Next

            'Configure the map layer from above
            With MyPointsVectorItemsLayer
                .Data = MyMapItemStorage
                .Name = PointsDataTable.TableName
            End With
        End If
        Return MyPointsVectorItemsLayer
    End Function



    ''' <summary>
    ''' Loads Shapefile into MapControl.
    ''' </summary>
    ''' <param name="Shapefile">Path to the shapefile to load into MapControl. String.</param>
    ''' <param name="MapControl">MapControl into which to load Shapefile. DevExpress XtraMap MapControl.</param>
    Private Sub LoadShapefile(Shapefile As String, MapControl As MapControl)
        'Imports DevExpress.XtraMap
        Try
            'Test shapefile existence.
            If My.Computer.FileSystem.FileExists(Shapefile) = True Then
                'Create a new shapefile VectorItemsLayer using Shapefile
                Dim ShapefileVectorItemsLayer As VectorItemsLayer = GetShapefileVectorItemsLayer(Shapefile)
                'Add the shapefile to the map.
                MapControl.Layers.Add(ShapefileVectorItemsLayer)
            Else
                MsgBox("Error loading the requested shapefile: " & Shapefile & " does not exist at the path submitted.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
    End Sub



    ''' <summary>
    ''' Returns a DevExpress
    ''' </summary>
    ''' <param name="ShapefilePath"></param>
    ''' <returns></returns>
    Private Function GetShapefileVectorItemsLayer(ShapefilePath As String) As DevExpress.XtraMap.VectorItemsLayer
        Dim MyVectorItemsLayer As New DevExpress.XtraMap.VectorItemsLayer
        Try
            'Don't know what this does but it's needed
            Dim MyBaseUri As New Uri(System.Reflection.Assembly.GetEntryAssembly().Location)

            'Make a DevEx ShapefileDataAdapter for the submitted shapefile
            Dim MyShapefileDataAdapter As New ShapefileDataAdapter() With {.FileUri = New Uri(MyBaseUri, ShapefilePath)}
            With MyVectorItemsLayer
                .Data = MyShapefileDataAdapter
            End With
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try

        Return MyVectorItemsLayer
    End Function

    ''' <summary>
    ''' Sets up a GridControl the way I like it
    ''' </summary>
    ''' <param name="GC">GridControl to configure. DevExpress GridControl.</param>
    Private Sub SetUpGridControl(GC As GridControl)
        Try
            GC.UseEmbeddedNavigator = True
            Dim GV As GridView = TryCast(GC.MainView, GridView)
            If Not GV Is Nothing Then
                GV.OptionsBehavior.AllowAddRows = True
                GV.OptionsBehavior.AllowDeleteRows = True
                GV.BestFitColumns(True)
                GV.OptionsView.BestFitMode = GridBestFitMode.Fast
                GV.OptionsView.ColumnAutoWidth = False
                GV.OptionsView.ShowFooter = True
                GV.OptionsDetail.EnableMasterViewMode = False 'True to show sub-tables                
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
    End Sub

    ''' <summary>
    ''' Sets up a PivotGridControl the way I like it
    ''' </summary>
    ''' <param name="PGC">PivotGridControl to set up.</param>
    Public Sub SetUpPivotGridControl(PGC As PivotGridControl)
        Try
            With PGC
                .RetrieveFields()
                .BestFit()
                .BestFitColumnArea()
                .BestFitDataHeaders(True)
                .BestFitRowArea()
                .OptionsBehavior.BestFitMode = PivotGridBestFitMode.FieldValue
                .OptionsMenu.EnableFieldValueMenu = True
                .OptionsMenu.EnableFormatRulesMenu = True
                .OptionsMenu.EnableHeaderAreaMenu = True
                .Text = "Pivot grid text"
            End With

            'Allow the user to change the summary they get; sum, avg, etc.
            For Each PGField As PivotGridField In PGC.Fields
                With PGField
                    .Options.AllowRunTimeSummaryChange = True
                    .BestFit()
                End With
            Next
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub MapLayersCheckedListBoxControl_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles MapLayersCheckedListBoxControl.ItemCheck
        Try
            Dim LayerName As String = MapLayersCheckedListBoxControl.Items(e.Index).Value
            Dim LabelLayer As VectorItemsLayer = Me.MapControl.Layers(LayerName & "Labels")
            Dim BubblesLayer As VectorItemsLayer = Me.MapControl.Layers(LayerName)
            If Not LabelLayer Is Nothing Then
                If LabelLayer.Visible = True Then LabelLayer.Visible = False Else LabelLayer.Visible = True
            End If

            If Not BubblesLayer Is Nothing Then
                If BubblesLayer.Visible = True Then BubblesLayer.Visible = False Else BubblesLayer.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub MapLayersCheckedListBoxControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MapLayersCheckedListBoxControl.SelectedIndexChanged
        Try

            Dim LayerName As String = MapLayersCheckedListBoxControl.Text

            'Load the column names into the second listbox
            Me.LayerLabelCheckedListBoxControl.Items.Clear()

            'Show the data
            Dim DT As DataTable
            Dim GV As GridView = TryCast(MapLayerGridControl.MainView, GridView)
            GV.Columns.Clear()
            Me.MapLayerGridControl.DataSource = Nothing


            If Not POZDataSet.Tables(LayerName) Is Nothing Then
                DT = POZDataSet.Tables(LayerName)
                With Me.MapLayerGridControl
                    .DataSource = DT
                    .Refresh()
                    .RefreshDataSource()
                End With
                SetUpGridControl(Me.MapLayerGridControl)
                Debug.Print(DT.TableName & vbTab & DT.Rows.Count)
            End If
            For Each Col As DataColumn In POZDataSet.Tables(LayerName).Columns
                Me.LayerLabelCheckedListBoxControl.Items.Add(Col.ColumnName, False)
            Next

            'Add the map layer to the property grid
            Dim MapLayer As VectorItemsLayer = MapControl.Layers(LayerName)
            Me.MapLayerPropertyGridControl.SelectedObject = MapLayer

            If Not MapLayer.Data Is Nothing Then
                Dim Sql As String = "-- Insert " & MapLayer.Name & vbNewLine
                Debug.Print("----------------------------------------------------")
                For Each MI As MapItem In MapLayer.Data.Items
                    'Build an Sql insert query
                    Sql = Sql & "INSERT INTO " & MapLayer.Name & "("
                    For i As Integer = 0 To MI.Attributes.Count - 1
                        Sql = Sql & MI.Attributes(i).Name & ","
                    Next
                    Sql = Sql & ") VALUES("
                    For i As Integer = 0 To MI.Attributes.Count - 1
                        Sql = Sql & IIf(Not IsNumeric(MI.Attributes(i).Value), "'", "") & MI.Attributes(i).Value & IIf(Not IsNumeric(MI.Attributes(i).Value), "'", "") & ","
                    Next
                    Sql = Sql & ");" & vbNewLine

                    'Loop through the key/value pairs and output
                    For i As Integer = 0 To MI.Attributes.Count - 1
                        Debug.Print(MapLayer.Name & vbTab & i & vbTab & MI.Attributes(i).Name & ": " & MI.Attributes(i).Value)
                    Next
                Next
                Debug.Print(Sql)
            End If


        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub LayerLabelCheckedListBoxControl_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles LayerLabelCheckedListBoxControl.ItemCheck
        'Loop through the column names in the LayerLabelCheckedListBoxControl's CheckedItems collection
        'create a labeling pattern and label the points in the map layer referenced by LayerName
        Try
            'Get the name of the layer from the MapLayersCheckedListBoxControl
            Dim LayerName As String = MapLayersCheckedListBoxControl.Text

            'Make a labeling pattern based on the columns selected in the child LayerLabelCheckedListBoxControl
            Dim LabelPattern As String = ""
            For Each SelectedItem As Object In Me.LayerLabelCheckedListBoxControl.CheckedItems
                'Append each column name to the pattern
                LabelPattern = LabelPattern & "{" & SelectedItem.ToString & "} "
            Next

            'Get a reference to the map layer referenced by LayerName
            Dim BubblesLayer As VectorItemsLayer = Me.MapControl.Layers(LayerName)

            'Submit the label pattern for labeling the points.
            If Not BubblesLayer Is Nothing Then
                With BubblesLayer
                    .ShapeTitlesPattern = LabelPattern.Trim
                    .ShapeTitlesVisibility = True
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub MapControl_DrawMapItem(sender As Object, e As DrawMapItemEventArgs) Handles MapControl.DrawMapItem
        'e.StrokeWidth = InputBox("Stroke", "Stroke", 10)
        'e.Layer.ShapeTitlesPattern = "{SpeciesAcronym}"
    End Sub
End Class
