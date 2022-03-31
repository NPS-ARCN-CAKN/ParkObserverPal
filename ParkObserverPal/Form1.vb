﻿Imports DevExpress.XtraGrid
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
        Dim POZZipFile As String = "C:\Temp\Loons 2022-03-29.poz"

        'Create a Dataset into which to dump the contents of all the CSV files in POZZipFile
        POZDataSet.Clear()

        POZDataSet = GetDatasetFromPOZFile(POZZipFile)
        POZDataSet.DataSetName = POZZipFile

        'Dim DSTabPage As New TabPage("Park Observer Dataset")
        'Me.MainTabControl.TabPages.Add(DSTabPage)
        'Dim DSPropertyGrid As New PropertyGrid
        'DSPropertyGrid.Dock = DockStyle.Fill
        'DSPropertyGrid.SelectedObject = POZDataSet
        'DSTabPage.Controls.Add(DSPropertyGrid)

        'Load up the various grids and map with poz data
        LoadPOZDataset(POZDataSet)

        Me.MapControl.ZoomToFitLayerItems()
        With Me.MapControl
            .BackColor = Color.LightSteelBlue
        End With

        'Load the map layers into the list box selector
        LoadMapLayersListBox()

        Me.MapControlPropertyGridControl.SelectedObject = Me.MapControl
    End Sub

    ''' <summary>
    ''' Loads the main map control's layers into the MapLayersListBox
    ''' </summary>
    Private Sub LoadMapLayersListBox()
        Dim CurrentItem As String = Me.MapLayersCheckedListBoxControl.Text
        Me.MapLayersCheckedListBoxControl.Items.Clear()
        'Loop through the map layers
        For Each Layer As VectorItemsLayer In Me.MapControl.Layers ' i As Integer = 0 To Me.MapControl.Layers.Count - 1
            Me.MapLayersCheckedListBoxControl.Items.Add(Layer.Name)
            'This is weird but the layers in the map controls layers collection are not ordered by z index
            'so they don't show up in z order.
            'Add the layers to the listbox in z order 
            'For Each L As VectorItemsLayer In Me.MapControl.Layers
            '    If L.ZIndex = i Then Me.MapLayersCheckedListBoxControl.Items.Add(L.Name, True)
            'Next
        Next

        Me.MapLayersCheckedListBoxControl.SelectedItem = CurrentItem
    End Sub

    ''' <summary>
    ''' Loads a POZDataset into various grids, pivot grids and map controls on the main form
    ''' </summary>
    ''' <param name="POZDataset">Park Observer Dataset. POZDataset.</param>
    Private Sub LoadPOZDataset(POZDataset As DataSet)
        Try

            Me.POZFileToolStripLabel.Text = POZDataset.DataSetName

            'Loop through each DataTable in POZDataset
            Dim CSVDataTableCounter As Integer = 1
            For Each CSVDataTable As DataTable In POZDataset.Tables
                '#Region "GridControl"

                '                'Create a GridControl to display the CSVData
                '                Dim CSVGridControl As New GridControl
                '                Dim CSVGridView As New GridView
                '                With CSVGridControl
                '                    .ViewCollection.Add(CSVGridView)
                '                    .DataSource = CSVDataTable
                '                    .Dock = DockStyle.Fill
                '                    .Name = CSVDataTable.TableName & "GridControl"
                '                End With
                '                SetUpGridControl(CSVGridControl)

                '                'Create a new tabpage to hold a grid showing the CSV datatable 
                '                Dim CSVTabPage As New TabPage(CSVDataTable.TableName & " Dataset")
                '                CSVTabPage.Controls.Add(CSVGridControl)

                '                'Add the new data grid tab page to the main TabControl
                '                Me.MainTabControl.TabPages.Add(CSVTabPage)
                '#End Region

                '#Region "PivotGrid"
                '                'Create a PivotGridControl and add it to the main tab control
                '                Dim CSVPivotGridTabPage As New TabPage(CSVDataTable.TableName & " Pivot Table")
                '                Dim CSVPivotGridControl As New PivotGridControl
                '                With CSVPivotGridControl
                '                    .DataSource = CSVDataTable
                '                    .RetrieveFields()
                '                End With
                '                SetUpPivotGridControl(CSVPivotGridControl)

                '                'Add the controls above to the main tab control
                '                CSVPivotGridTabPage.Controls.Add(CSVPivotGridControl)
                '                Me.MainTabControl.TabPages.Add(CSVPivotGridTabPage)
                '#End Region



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
                Dim Marker As MarkerType = MarkerType.Circle
                'Mix up the marker symbols
                If CSVDataTableCounter = 2 Then
                    Marker = MarkerType.Cross
                ElseIf CSVDataTableCounter = 2 Then
                    Marker = MarkerType.Diamond
                ElseIf CSVDataTableCounter = 3 Then
                    Marker = MarkerType.Hexagon
                ElseIf CSVDataTableCounter = 4 Then
                    Marker = MarkerType.InvertedTriangle
                ElseIf CSVDataTableCounter = 5 Then
                    Marker = MarkerType.Pentagon
                ElseIf CSVDataTableCounter = 6 Then
                    Marker = MarkerType.Plus
                ElseIf CSVDataTableCounter = 7 Then
                    Marker = MarkerType.Square
                ElseIf CSVDataTableCounter = 8 Then
                    Marker = MarkerType.Star5
                ElseIf CSVDataTableCounter = 9 Then
                    Marker = MarkerType.Star6
                ElseIf CSVDataTableCounter = 10 Then
                    Marker = MarkerType.Star8
                ElseIf CSVDataTableCounter = 11 Then
                    Marker = MarkerType.Triangle
                End If


                'Add the tracklog to the map
                If CSVDataTable.TableName.ToLower = "gpspoints" Then
                    'Draw a tracklog as a line vector items layer
                    Dim TrackLogVectorItemsLayer As VectorItemsLayer = GetTracklogLineVectorItemsLayer(CSVDataTable, "Latitude", "Longitude", "Timestamp", Color.Gray, 1)
                    TrackLogVectorItemsLayer.Name = CSVDataTable.TableName
                    Me.MapControl.Layers.Add(TrackLogVectorItemsLayer)
                    Me.MapControl.ZoomToFitLayerItems()
                Else
                    'Draw the the layer as a points vector items layer
                    Color = Color.FromArgb(CInt(Int((255 * Rnd()) + 1)), CInt(Int((255 * Rnd()) + 1)), CInt(Int((255 * Rnd()) + 1)))
                    PtSize = 8
                    Dim CSVLayer As VectorItemsLayer = GetBubbleVectorItemsLayerFromPointsDataTable(CSVDataTable, LatColumnName, LonColumnName, PtSize, Marker, Color)
                    CSVLayer.Name = CSVDataTable.TableName
                    Me.MapControl.Layers.Add(CSVLayer)
                End If
#End Region
                CSVDataTableCounter = CSVDataTableCounter + 1
            Next

            'DevEx assigns all new layers a Z index of 100, not so useful for promoting and demoting layers later
            'Assign all the layers a reasonably z index to start with
            For i As Integer = 0 To Me.MapControl.Layers.Count - 1
                Dim VIL As VectorItemsLayer = Me.MapControl.Layers(i)
                VIL.ZIndex = i
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
                        Dim CSVName As String = CSVFileInfo.Name.Trim.Replace(".csv", "")

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
            MyLineVectorItemsLayer.Name = PointsDataTable.TableName
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
                Dim ShapefileFileInfo As New FileInfo(Shapefile)
                ShapefileVectorItemsLayer.Name = ShapefileFileInfo.Name

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
            'Get the name of the currently selected layer
            Dim LayerName As String = MapLayersCheckedListBoxControl.Text

            'Get a handle on the map layer with the name from above
            Dim MapLayer As VectorItemsLayer = MapControl.Layers(LayerName)

            'Load the map layer's properties into the map layer property grid
            Me.MapLayerPropertyGridControl.SelectedObject = MapLayer

            'Load the column names into the labeling columns listbox
            Me.LayerLabelCheckedListBoxControl.Items.Clear()
            If Not POZDataSet.Tables(LayerName) Is Nothing Then
                For Each Col As DataColumn In POZDataSet.Tables(LayerName).Columns
                    Me.LayerLabelCheckedListBoxControl.Items.Add(Col.ColumnName, False)
                Next
            End If

            'Show the data in the map layer grid control
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

    Private Sub ZoomToFitAllLayersToolStripButton_Click(sender As Object, e As EventArgs) Handles ZoomToFitAllLayersToolStripButton.Click
        'Zoom to fit all layers
        Me.MapControl.ZoomToFitLayerItems()
    End Sub

    Private Sub AddLayerToolStripLabel_Click(sender As Object, e As EventArgs) Handles AddLayerToolStripLabel.Click
        Try
            Dim ShpFile As FileInfo = SkeeterUtilities.DirectoryAndFile.DirectoryAndFileUtilities.GetFile("Shapefile|*.shp", "Choose a shapefile.", "")
            LoadShapefile(ShpFile.FullName, Me.MapControl)
            Me.MapControl.Layers(ShpFile.Name).ZIndex = Me.MapControl.Layers.Count - 1
            LoadMapLayersListBox()
        Catch ex As Exception
        MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub PromoteLayerToolStripButton_Click(sender As Object, e As EventArgs) Handles PromoteLayerToolStripButton.Click
        If Me.MapLayersCheckedListBoxControl.Text.Trim <> "" Then
            Dim LayerName As String = Me.MapLayersCheckedListBoxControl.Text.Trim
            Dim Lyr As VectorItemsLayer = Me.MapControl.Layers(LayerName)

            'Find the index of current layer
            Dim CurrentLayerIndex As Integer = -999
            For i As Integer = 0 To Me.MapControl.Layers.Count - 1
                If Me.MapControl.Layers(i).Name = LayerName Then CurrentLayerIndex = i
            Next
            If CurrentLayerIndex - 1 >= 0 Then
                Me.MapControl.Layers.Swap(CurrentLayerIndex, CurrentLayerIndex - 1)
            End If
        End If
        LoadMapLayersListBox()
    End Sub

    Private Sub DemoteLayerToolStripButton_Click(sender As Object, e As EventArgs) Handles DemoteLayerToolStripButton.Click
        If Me.MapLayersCheckedListBoxControl.Text.Trim <> "" Then
            Dim LayerName As String = Me.MapLayersCheckedListBoxControl.Text.Trim
            Dim Lyr As VectorItemsLayer = Me.MapControl.Layers(LayerName)

            'Find the index of current layer
            Dim CurrentLayerIndex As Integer = -999
            For i As Integer = 0 To Me.MapControl.Layers.Count - 1
                If Me.MapControl.Layers(i).Name = LayerName Then CurrentLayerIndex = i
            Next
            If CurrentLayerIndex + 1 >= Me.MapControl.Layers.Count - 1 Then
                Me.MapControl.Layers.Swap(CurrentLayerIndex, CurrentLayerIndex + 1)
            End If
        End If
        LoadMapLayersListBox()
    End Sub
End Class
