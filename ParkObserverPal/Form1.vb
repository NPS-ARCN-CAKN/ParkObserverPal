Imports DevExpress.XtraGrid
Imports DevExpress.XtraMap
Imports SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPivotGrid
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json

Public Class Form1

    Dim MapLayersDataTable As New DataTable("Layers") 'The data table that will show the current layer's data
    'Dim POZDataSet As New DataSet 'Park Observer data set

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        'My.Settings.BackgroundLayers = "C:\Work\GIS Common Layers\AlaskaSimplified_1km.shp"
        'LoadBackgroundLayers()

    End Sub



    ''' <summary>
    ''' Loads the background shapefiles in My.Settings.BackgroundLayers into the application
    ''' </summary>
    Private Sub LoadBackgroundLayers()
        Try
            Dim BackgroundShapefiles As String() = My.Settings.BackgroundLayers.Split("|")
            For Each ShpFile As String In BackgroundShapefiles
                If My.Computer.FileSystem.FileExists(ShpFile) Then
                    LoadShapefile(ShpFile, Me.MapControl)
                    'Else
                    '    If MsgBox(ShpFile & " no longer exists. Remove it from the list of background layers?", MsgBoxStyle.YesNo, "Error") = MsgBoxResult.Yes Then
                    '        'Get rid of the shapefile from the list of pipe | separated values.
                    '        Debug.Print("current bg layers: " & My.Settings.BackgroundLayers)
                    '        My.Settings.BackgroundLayers = My.Settings.BackgroundLayers.Replace(ShpFile, "")
                    '        Debug.Print("got rid of " & ShpFile & " now it's " & My.Settings.BackgroundLayers)
                    '    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
    End Sub

    ''' <summary>
    ''' Converts a VectorItemsLayer_NPS.Data.Items name/value pair collection items into a DataTable.
    ''' </summary>
    ''' <param name="VIL">VectorItemsLayer_NPS to convert to DataTable. VectorItemsLayer_NPS.</param>
    ''' <param name="TableName">TableName. String. Optional. Defaults to the name of VectorItemsLayer_NPS.</param>
    ''' <returns></returns>
    Private Function GetDataTableFromVectorItemsLayer_NPS(VIL As VectorItemsLayer_NPS, Optional TableName As String = "") As DataTable
        'Make a DataTable
        Dim DT As New DataTable()

        Try
            'Make sure we have a VectorItemsLayer_NPS
            If Not VIL Is Nothing Then

                'Set the returned DataTable's name.
                If TableName.Trim <> "" Then
                    DT.TableName = TableName
                Else
                    DT.TableName = VIL.Name
                End If

                'The data in a VectorItemsLayer_NPS are stored as Name/Value pairs, we need to convert them to a DataTable.
                If VIL.Data.Items.Count > 0 Then

                    'Get a handle on the first item in the list so we can use it as a model to create DataColumns for DT.
                    Dim FirstMapItem As MapItem = VIL.Data.Items(0)

                    'Make sure the first map item is something
                    If Not FirstMapItem Is Nothing Then

                        'Make sure the first map item has attributes
                        If FirstMapItem.Attributes.Count > 0 Then

                            'Create a DataColumn for each map item's Name attribute and add it to the data table.
                            For Each FirstMapItemAttributes As MapItemAttribute In FirstMapItem.Attributes
                                Dim ColumnName As String = FirstMapItemAttributes.Name

                                'Create a new DataColumn based on the map item's name and value
                                Dim NewColumn As New DataColumn(ColumnName)

                                'MapItem attribute's data type is set to DBNull for NULL or empty rows. In such cases the equivalent DataColumn DataType cannot be determined.
                                'This problem led to errors when the DataTable.NewRow function was called to create a new row.
                                'Set such columns data type to String since it doesn't really matter anyway because there is no data for those cells
                                If FirstMapItemAttributes.Value.GetType.Name = "DBNull" Then
                                    NewColumn.DataType = GetType(String)
                                Else
                                    NewColumn.DataType = FirstMapItemAttributes.Value.GetType
                                End If

                                'Add the new column to DT DataTable
                                DT.Columns.Add(NewColumn)
                            Next

                            'Now go through each item, create an equivalent DataRow and add it to DT.Rows.
                            If VIL.Data.Items.Count > 0 Then
                                For Each MapItem As MapItem In VIL.Data.Items

                                    'Create a new DataRow and populate it with the map item's attributes
                                    Dim NewRow As DataRow = DT.NewRow
                                    For Each Mapitemattribute In MapItem.Attributes
                                        'If the value is not null, add it to the new row
                                        If Not IsDBNull(Mapitemattribute.Value) = True Then
                                            Dim AttributeName As String = Mapitemattribute.Name
                                            Dim AttributeValue As String = Mapitemattribute.Value
                                            NewRow.Item(AttributeName) = AttributeValue
                                        End If
                                    Next
                                    DT.Rows.Add(NewRow)
                                Next
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
        Return DT
    End Function

    Private Sub OpenPOZArchive(POZArchive As FileInfo)
        'Temporary holder for poz file
        Dim POZZipFile As String = POZArchive.FullName '"C:\Temp\Loons 2022-03-29.poz"

        'Create a Dataset into which to dump the contents of all the CSV files in POZZipFile
        'POZDataSet.Clear()
        'POZDataSet = GetDatasetFromPOZFile(POZZipFile)
        'POZDataSet.DataSetName = POZZipFile


        'Load up the various grids and map with poz data
        LoadPOZArchive(POZZipFile)


        Me.MapControl.ZoomToFitLayerItems()
        With Me.MapControl
            .BackColor = Color.LightSteelBlue
        End With

        'Load the map layers into the list box selector
        LoadMapLayersListBox()
    End Sub

    ''' <summary>
    ''' Loads the main map control's layers into the MapLayersListBox
    ''' </summary>
    Private Sub LoadMapLayersListBox()

        'Now set the z order
        Dim ZIndex As Integer = 0
        For Each Layer As VectorItemsLayer_NPS In Me.MapControl.Layers
            Layer.ZIndex = ZIndex
            ZIndex = ZIndex + 1
        Next

        'Get the currently selected item so we can come back to it later
        Dim CurrentItem As String = Me.MapLayersCheckedListBoxControl.Text

        'Loop through the map layers and add them as listbox items
        Me.MapLayersCheckedListBoxControl.Items.Clear()
        For Each Layer As VectorItemsLayer_NPS In Me.MapControl.Layers ' i As Integer = 0 To Me.MapControl.Layers.Count - 1
            Dim MapLayerCheckedListBoxItem As New DevExpress.XtraEditors.Controls.CheckedListBoxItem()
            With MapLayerCheckedListBoxItem
                .CheckState = CheckState.Checked
                .Description = Layer.Name
                .Value = Layer.Name
            End With
            Me.MapLayersCheckedListBoxControl.Items.Add(MapLayerCheckedListBoxItem)
        Next

        'Reset the currently selected layer
        Me.MapLayersCheckedListBoxControl.SelectedItem = CurrentItem
    End Sub

    '    ''' <summary>
    '    ''' Loads a POZDataset into various grids, pivot grids and map controls on the main form
    '    ''' </summary>
    '    Private Sub LoadPOZDataset()
    '        Try

    '            'Loop through each DataTable in POZDataset
    '            Dim CSVDataTableCounter As Integer = 1
    '            For Each CSVDataTable As DataTable In POZDataset.Tables

    '#Region "Map"
    '                'Load the CSV spatial data into the map
    '                'Find out if the data tables contain lat/lon columns
    '                'Some tables have LatLon stored in columns named Latitude and Longitude
    '                'Some tables have LatLon stored in columns named Feature_Latitude and Feature_Longitude
    '                Dim LatColumnName As String = ""
    '                Dim LonColumnName As String = ""
    '                For Each Col As DataColumn In CSVDataTable.Columns
    '                    If Col.ColumnName.Trim = "Latitude" Then
    '                        LatColumnName = "Latitude"
    '                        LonColumnName = "Longitude"
    '                        Exit For
    '                    ElseIf Col.ColumnName = "Feature_Latitude" Then
    '                        LatColumnName = "Feature_Latitude"
    '                        LonColumnName = "Feature_Longitude"
    '                        Exit For
    '                    End If
    '                Next

    '                'Add WKT and Geography columns and data to the data table
    '                AddWKTAndGeographyColumnsToDataTable(CSVDataTable, LatColumnName, LonColumnName)

    '                'Create a VectorItemsLayer to show the spatial data
    '                Dim LabelLayer As New VectorItemsLayer
    '                Dim Color As Color = Color.Gray
    '                Dim PtSize As Integer = 4
    '                Dim Marker As MarkerType = MarkerType.Circle

    '                'Mix up the marker symbols
    '                If CSVDataTableCounter = 2 Then
    '                    Marker = MarkerType.Cross
    '                ElseIf CSVDataTableCounter = 2 Then
    '                    Marker = MarkerType.Diamond
    '                ElseIf CSVDataTableCounter = 3 Then
    '                    Marker = MarkerType.Hexagon
    '                ElseIf CSVDataTableCounter = 4 Then
    '                    Marker = MarkerType.InvertedTriangle
    '                ElseIf CSVDataTableCounter = 5 Then
    '                    Marker = MarkerType.Pentagon
    '                ElseIf CSVDataTableCounter = 6 Then
    '                    Marker = MarkerType.Plus
    '                ElseIf CSVDataTableCounter = 7 Then
    '                    Marker = MarkerType.Square
    '                ElseIf CSVDataTableCounter = 8 Then
    '                    Marker = MarkerType.Star5
    '                ElseIf CSVDataTableCounter = 9 Then
    '                    Marker = MarkerType.Star6
    '                ElseIf CSVDataTableCounter = 10 Then
    '                    Marker = MarkerType.Star8
    '                ElseIf CSVDataTableCounter = 11 Then
    '                    Marker = MarkerType.Triangle
    '                End If


    '                'Add the tracklog to the map
    '                If CSVDataTable.TableName.ToLower = "gpspoints" Then
    '                    'Draw a tracklog as a line vector items layer
    '                    Dim TrackLogVectorItemsLayer As VectorItemsLayer = GetLineVectorItemsLayer(CSVDataTable, "Latitude", "Longitude", "Timestamp", Color.Gray, 1)
    '                    TrackLogVectorItemsLayer.Name = CSVDataTable.TableName
    '                    Me.MapControl.Layers.Add(TrackLogVectorItemsLayer)
    '                    Me.MapControl.ZoomToFitLayerItems()
    '                Else
    '                    'Draw the the layer as a points vector items layer
    '                    Color = Color.FromArgb(CInt(Int((255 * Rnd()) + 1)), CInt(Int((255 * Rnd()) + 1)), CInt(Int((255 * Rnd()) + 1)))
    '                    PtSize = 8
    '                    Dim CSVLayer As VectorItemsLayer = GetBubbleVectorItemsLayerFromPointsDataTable(CSVDataTable, LatColumnName, LonColumnName, PtSize, Marker, Color)
    '                    CSVLayer.Name = CSVDataTable.TableName
    '                    Me.MapControl.Layers.Add(CSVLayer)
    '                End If
    '#End Region
    '                CSVDataTableCounter = CSVDataTableCounter + 1
    '            Next

    '            'DevEx assigns all new layers a Z index of 100, not so useful for promoting and demoting layers later
    '            'Assign all the layers a reasonably z index to start with
    '            For i As Integer = 0 To Me.MapControl.Layers.Count - 1
    '                Dim VIL As VectorItemsLayer = Me.MapControl.Layers(i)
    '                VIL.ZIndex = i
    '            Next
    '        Catch ex As Exception
    '            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
    '        End Try
    '    End Sub

    ''' <summary>
    ''' Unzips a Park Observer file archive (.poz) into the same directory and loads each .csv file within into the returned Dataset
    ''' </summary>
    ''' <param name="POZFile">Park Observer archive (.poz). String.</param>
    Private Sub LoadPOZArchive(POZFile As String)
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

                    'The directory where the app should decompress the .poz archive exists, ask user to clear it 
                    Dim Result As MsgBoxResult = MsgBox("In order to decompress the Park Observer archive you have selected the application needs to delete the existing files in " & POZFilesDirectory & ". Proceed?", MsgBoxStyle.Information, "Directory exists")
                    If Result = MsgBoxResult.Ok Then
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

                            'Load the CSV into the application
                            LoadCSVFile(CSVFileInfo)

                        End If
                    Next
                End If
            Else
                MsgBox("Park Observer file " & POZFile & " does not exist.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
    End Sub








    ''' <summary>
    ''' Returns a DevExpress VectorItemsLayer_NPS of MapBubble points derived a DataTable containing Lat/Lon pairs.
    ''' </summary>
    ''' <param name="PointsDataTable">DataTable containing points spatial data. DataTable</param>
    ''' <param name="LatitudeColumnName">Name of the latitude column. String.</param>
    ''' <param name="LongitudeColumnName">Name of the longitude column. String.</param>
    ''' <returns>VectorItemLayer of points.</returns>
    Public Function GetBubbleVectorItemsLayerFromPointsDataTable(PointsDataTable As DataTable, LatitudeColumnName As String, LongitudeColumnName As String, FeatureSize As Integer, MarkerType As MarkerType, FillColor As Color) As DevExpress.XtraMap.VectorItemsLayer

        'Create a new VectorItemsLayer_NPS which is essentially a map layer
        Dim MyPointsVectorItemsLayer_NPS As New VectorItemsLayer_NPS()

        Try
            'Create a MapItemStorage object (basically DevExpress's version of a spatial data table, stores MapItem objects which are like DataRows
            Dim MyMapItemStorage As New MapItemStorage

            'Count up NULL or empty or non-numeric rows
            Dim NullSpatialRowsCount As Integer = 0
            Dim NonNumericSpatialRowsCount As Integer = 0

            'Make sure we have spatial column names
            If LatitudeColumnName.Trim <> "" And LongitudeColumnName.Trim <> "" Then

                'Convert .NET DataRows to MapBubbles
                For Each MyPointDataRow As DataRow In PointsDataTable.Rows
                    'Make sure we have a valid row
                    If Not MyPointDataRow Is Nothing Then
                        'Make sure the LatLon columns are not NULL
                        If Not IsDBNull(MyPointDataRow.Item(LatitudeColumnName)) And Not IsDBNull(MyPointDataRow.Item(LongitudeColumnName)) Then
                            'Make sure the column is numeric
                            If IsNumeric(MyPointDataRow.Item(LatitudeColumnName)) And IsNumeric(MyPointDataRow.Item(LongitudeColumnName)) Then

                                'Get the Lat/Lon
                                Dim Lat As Double = CDbl(MyPointDataRow.Item(LatitudeColumnName))
                                Dim Lon As Double = CDbl(MyPointDataRow.Item(LongitudeColumnName))

                                'Make a new point for the map
                                Dim MyMapPoint As New MapBubble()
                                'Dim MyMapPoint As New MapDot

                                With MyMapPoint
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
                                    .Size = 20
                                    .MarkerType = MarkerType
                                    .Fill = FillColor
                                End With

                                'Add the MapBubble to the MapItemStorage 
                                MyMapItemStorage.Items.Add(MyMapPoint)

                            Else
                                'Increment the non numeric row counter
                                NonNumericSpatialRowsCount = NonNumericSpatialRowsCount + 1
                            End If
                        Else
                            'Increment the null rows counter
                            NullSpatialRowsCount = NullSpatialRowsCount + 1
                        End If
                    End If
                Next

                'Configure the map layer from above
                With MyPointsVectorItemsLayer_NPS
                    .Data = MyMapItemStorage
                    .Name = PointsDataTable.TableName
                    .DataTable = PointsDataTable
                End With

                'Alert user if they don't have a full dataset
                If NullSpatialRowsCount > 0 Or NonNumericSpatialRowsCount > 0 Then
                    MsgBox("Warning: " & NullSpatialRowsCount & " rows were omitted because the spatial columns contained null values and " & NonNumericSpatialRowsCount & " rows were omitted because the spatial data was non-numeric.", MsgBoxStyle.Information, "Warning")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
        Return MyPointsVectorItemsLayer_NPS
    End Function



    ''' <summary>
    ''' Loads Shapefile into MapControl.
    ''' </summary>
    ''' <param name="Shapefile">Path to the shapefile to load into MapControl. String.</param>
    ''' <param name="MapControl">MapControl into which to load Shapefile. DevExpress XtraMap MapControl.</param>
    Public Sub LoadShapefile(Shapefile As String, MapControl As MapControl)
        'Imports DevExpress.XtraMap
        Try
            'Test shapefile existence.
            If My.Computer.FileSystem.FileExists(Shapefile) = True Then

                'Create a new shapefile VectorItemsLayer using Shapefile
                Dim ShapefileVectorItemsLayer_NPS As VectorItemsLayer_NPS = GetShapefileVectorItemsLayer_NPS(Shapefile)
                Dim ShapefileFileInfo As New FileInfo(Shapefile)
                ShapefileVectorItemsLayer_NPS.Name = ShapefileFileInfo.Name

                'Add the shapefile to the map.
                MapControl.Layers.Add(ShapefileVectorItemsLayer_NPS)
                LoadMapLayersListBox()

            Else
                MsgBox("Error loading the requested shapefile: " & Shapefile & " does not exist at the path submitted.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
    End Sub



    ''' <summary>
    ''' Returns a VectorItemsLayer_NPS for a shapefile.
    ''' </summary>
    ''' <param name="ShapefilePath">Path to the shapefile to load.</param>
    ''' <returns></returns>
    Private Function GetShapefileVectorItemsLayer_NPS(ShapefilePath As String) As DevExpress.XtraMap.VectorItemsLayer
        Dim MyVectorItemsLayer_NPS As New VectorItemsLayer_NPS
        Try
            'Don't know what this does but it's needed
            Dim MyBaseUri As New Uri(System.Reflection.Assembly.GetEntryAssembly().Location)

            'Make a DevEx ShapefileDataAdapter for the submitted shapefile
            Dim MyShapefileDataAdapter As New ShapefileDataAdapter() With {.FileUri = New Uri(MyBaseUri, ShapefilePath)}

            'Add a handler so that we can access the data when it is loaded
            AddHandler MyShapefileDataAdapter.ItemsLoaded, AddressOf ShapefileDataAdapterItemsLoaded
            MyVectorItemsLayer_NPS.Data = MyShapefileDataAdapter
            MyVectorItemsLayer_NPS.DataTable = GetDataTableFromVectorItemsLayer_NPS(MyVectorItemsLayer_NPS)

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try

        Return MyVectorItemsLayer_NPS
    End Function

    ''' <summary>
    ''' Handles ShapefileDataAdapterItemsLoaded event.
    ''' </summary>
    ''' <param name="sender">ShapefileDataAdapter.</param>
    ''' <param name="e">ItemsLoadedEventArgs.</param>
    Private Sub ShapefileDataAdapterItemsLoaded(sender As Object, e As ItemsLoadedEventArgs)
        Try
            'Get a handle on the ShapefileDataAdapter that sent the event
            Dim MyShapefileDataAdapter As ShapefileDataAdapter = sender

            'Make a DataTable
            Dim DT As New DataTable()

            'Get a name for the data table same as the file name
            Dim TableName As String = ""
            Dim FilePath As String = MyShapefileDataAdapter.FileUri.ToString
            Dim FI As New FileInfo(FilePath.Replace("file:///", ""))
            TableName = FI.Name
            DT.TableName = TableName

            'The Data In a VectorItemsLayer are stored As Name/Value pairs, we need to convert them to a DataTable
            If e.Items.Count > 0 Then
                'Get a handle on the first item in the list
                Dim FirstMapItem As MapItem = e.Items(0)

                'Create a DataColumn for each map item's Name attribute and add it to the data table
                For Each FirstMapItemAttributes As MapItemAttribute In FirstMapItem.Attributes
                    Dim ColumnName As String = FirstMapItemAttributes.Name
                    Dim NewColumn As New DataColumn(ColumnName, FirstMapItemAttributes.Value.GetType)
                    DT.Columns.Add(NewColumn)
                Next

                'Now go through each item and transfer the values to the datatable
                For Each MI As MapItem In e.Items
                    Dim NewRow As DataRow = DT.NewRow
                    For Each Mapitemattribute In MI.Attributes
                        NewRow.Item(Mapitemattribute.Name) = Mapitemattribute.Value
                    Next
                    DT.Rows.Add(NewRow)
                Next

            End If
            'Add the DataTable to a Dataset
            'If POZDataSet.Tables(TableName) Is Nothing Then
            '    POZDataSet.Tables.Add(DT)
            'Else
            '    POZDataSet.Tables.Remove(POZDataSet.Tables(TableName))
            '    POZDataSet.Tables.Add(DT)
            'End If

            Me.MapLayerGridControl.DataSource = DT
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
    End Sub



    Private Sub MapLayersCheckedListBoxControl_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles MapLayersCheckedListBoxControl.ItemCheck
        Try
            Dim LayerName As String = MapLayersCheckedListBoxControl.Items(e.Index).Value
            Dim LabelLayer As VectorItemsLayer_NPS = Me.MapControl.Layers(LayerName & "Labels")
            Dim BubblesLayer As VectorItemsLayer_NPS = Me.MapControl.Layers(LayerName)
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
            Dim MapLayer As VectorItemsLayer_NPS = MapControl.Layers(LayerName)

            'Show the data in the map layer grid control
            Dim DT As DataTable = GetDataTableFromVectorItemsLayer_NPS(MapLayer, LayerName)
            Dim GV As GridView = TryCast(MapLayerGridControl.MainView, GridView)
            GV.Columns.Clear()
            Me.MapLayerGridControl.DataSource = Nothing
            If Not DT Is Nothing Then
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

    Private Sub ZoomToFitAllLayersToolStripButton_Click(sender As Object, e As EventArgs) Handles ZoomToFitAllLayersToolStripButton.Click
        'Zoom to fit all layers
        Me.MapControl.ZoomToFitLayerItems()
    End Sub

    Private Sub AddLayerToolStripLabel_Click(sender As Object, e As EventArgs)
        Try
            Dim ShpFile As FileInfo = SkeeterUtilities.DirectoryAndFile.DirectoryAndFileUtilities.GetFile("Shapefile|*.shp", "Choose a shapefile.", "")
            If Not ShpFile Is Nothing Then LoadShapefile(ShpFile.FullName, Me.MapControl)
            Me.MapControl.Layers(ShpFile.Name).ZIndex = Me.MapControl.Layers.Count - 1
            LoadMapLayersListBox()
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub PromoteLayerToolStripButton_Click(sender As Object, e As EventArgs) Handles PromoteLayerToolStripButton.Click

        If Me.MapLayersCheckedListBoxControl.Text.Trim <> "" Then

            'Get a handle on the current layer name
            Dim LayerName As String = Me.MapLayersCheckedListBoxControl.Text.Trim
            Dim Lyr As VectorItemsLayer = Me.MapControl.Layers(LayerName)

            'Find the index of current layer
            Dim CurrentLayerIndex As Integer = -999
            For i As Integer = 0 To Me.MapControl.Layers.Count - 1
                If Me.MapControl.Layers(i).Name = LayerName Then CurrentLayerIndex = i
            Next

            'Swap the current layer with the layer above it
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

            'Make sure we don't exceed the maximum count of map layers
            If CurrentLayerIndex + 1 <= Me.MapControl.Layers.Count - 1 Then
                Me.MapControl.Layers.Swap(CurrentLayerIndex, CurrentLayerIndex + 1)
            End If
        End If
        LoadMapLayersListBox()
    End Sub

    Private Sub ExportToKMLToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Export the currently selected map layer to KML
        Try
            'Make sure we have a layer selected
            If Me.MapLayersCheckedListBoxControl.Text.Trim <> "" Then

                'Get the name of the currently selected layer
                Dim LayerName As String = Me.MapLayersCheckedListBoxControl.Text.Trim

                'Get a handle on the current map layer
                Dim CurrentMapLayer As VectorItemsLayer = Me.MapControl.Layers(LayerName)

                'Prepare the file filter
                Dim FileFilter As String = "Keyhole Markup Language (*.kml)|(*.kml)"
                Dim FileExtension As String = ".kml"

                'Open a save file dialog to allow the user to save the file someplace
                Dim SFD As New SaveFileDialog
                With SFD
                    .AddExtension = True
                    .DefaultExt = FileExtension
                    .FileName = LayerName.Trim & "." & FileExtension
                    .Filter = FileFilter
                End With

                'Show the dialog
                If SFD.ShowDialog = DialogResult.OK Then
                    CurrentMapLayer.ExportToKml(SFD.FileName)
                End If


                'Export the file
                CurrentMapLayer.ExportToKml(SFD.FileName)

                'Ask if user wants to open the exported file
                If My.Computer.FileSystem.FileExists(SFD.FileName) = True Then
                    If MsgBox("Open the exported file?", MsgBoxStyle.YesNo, "Open the exported file?") = MsgBoxResult.Yes Then
                        Process.Start(SFD.FileName)
                    End If
                Else
                    MsgBox("Cannot locate the exported file: " & SFD.FileName, MsgBoxStyle.Information, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Map layer export formats
    ''' </summary>
    Enum MapLayerExportFormat
        KML = 0
        Shapefile = 1
        Excel = 2
        CSV = 3
    End Enum

    ''' <summary>
    ''' Exports a Park Observer Pal map layer to ExportFormat.
    ''' </summary>
    ''' <param name="LayerName">Name of the layer to export in MapControl's layers collection. String.</param>
    ''' <param name="MapControl">MapControl.</param>
    ''' <param name="ExportFormat">Export format. MapLayerExportFormat.</param>
    Private Sub ExportMapLayer(LayerName As String, MapControl As MapControl, ExportFormat As MapLayerExportFormat)
        'Export the currently selected map layer to KML
        Try
            'Make sure we have a layer selected
            If Me.MapLayersCheckedListBoxControl.Text.Trim <> "" Then

                'Get a handle on the current map layer
                Dim CurrentMapLayer As VectorItemsLayer = Me.MapControl.Layers(LayerName)

                'Prepare the file filter
                Dim FileFilter As String = ""
                Dim FileExtension As String = ""
                If ExportFormat = 0 Then
                    FileFilter = "Keyhole Markup Language (*.kml)|(*.kml)"
                    FileExtension = ".kml"
                ElseIf ExportFormat = 1 Then
                    FileFilter = "Shapefile (*.shp)|(*.shp)"
                    FileExtension = ".shp"
                ElseIf ExportFormat = 2 Then
                    FileFilter = "Excel (*.xlsx)|(*.xlsx)"
                    FileExtension = ".xlsx"
                ElseIf ExportFormat = 3 Then
                    FileFilter = "Comma separated values text files (*.csv)|(*.csv)"
                    FileExtension = ".csv"
                End If

                'If we have an export format, export the file
                If FileFilter.Trim <> "" And FileExtension.Trim <> "" Then

                    'Open a save file dialog to allow the user to save the file someplace
                    Dim SFD As New SaveFileDialog
                    With SFD
                        .AddExtension = True
                        .DefaultExt = FileExtension
                        .FileName = LayerName.Trim & FileExtension
                        .Filter = FileFilter
                    End With

                    'Show the dialog
                    If SFD.ShowDialog = DialogResult.OK Then

                        If ExportFormat = 0 Then
                            CurrentMapLayer.ExportToKml(SFD.FileName)
                        ElseIf ExportFormat = 1 Then
                            Dim SEO As New ShpExportOptions
                            With SEO
                                .ExportToDbf = True
                                .ExportToShx = True
                                .ShapeType = ShapeType.Point
                            End With
                            CurrentMapLayer.ExportToShp(SFD.FileName, SEO)
                        ElseIf ExportFormat = 2 Then
                            MsgBox("Export to Excel is not yet implemented")
                        ElseIf ExportFormat = 3 Then
                            MsgBox("Export to CSV is not yet implemented")
                        End If
                    End If

                    'Ask if user wants to open the exported file
                    If My.Computer.FileSystem.FileExists(SFD.FileName) = True Then
                        If MsgBox("Open the exported file?", MsgBoxStyle.YesNo, "Open the exported file?") = MsgBoxResult.Yes Then
                            Process.Start(SFD.FileName)
                        End If
                    Else
                        MsgBox("Cannot locate the exported file: " & SFD.FileName, MsgBoxStyle.Information, "Error")
                    End If
                End If
            Else
                MsgBox("Missing file format.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub ExportToShapefileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ExportMapLayer(Me.MapLayersCheckedListBoxControl.Text, Me.MapControl, MapLayerExportFormat.Shapefile)

    End Sub

    ''' <summary>
    ''' Show the map layer's properties in a PropertyGrid in a Form.
    ''' </summary>
    ''' <param name="LayerName">Name of the layer for which properties should be shown.</param>
    Private Sub ShowLayerPropertiesForm(LayerName As String)
        Try
            If Not LayerName = "" Then
                Dim VIL As VectorItemsLayer = Me.MapControl.Layers(LayerName)
                If Not VIL Is Nothing Then
                    Dim MapLayerPropertiesForm As New MapLayerPropertiesForm(VIL)
                    MapLayerPropertiesForm.Show()
                End If

            End If
        Catch ex As Exception
            MsgBox("Properties for this layer cannot be shown: " & ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub LayerPropertiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LayerPropertiesToolStripMenuItem.Click
        'Show the properties for the selected layer.
        Dim LayerName As String = Me.MapLayersCheckedListBoxControl.Text.Trim
        ShowLayerPropertiesForm(LayerName)
    End Sub

    ''' <summary>
    ''' Opens a file open dialog allowing the user to select a comma separated values text file to load into the main interface. Opens a selector dialog to let the user
    ''' select any lat/lon fields, if desired.
    ''' </summary>
    Private Sub LoadCSVFile(CSVFileInfo As FileInfo)
        Try
            'Convert the CSV to a DataTable
            Dim CSVDataTable As DataTable = SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters.GetDataTableFromCSV(CSVFileInfo, True, Format.Delimited)
            CSVDataTable.TableName = CSVFileInfo.Name

            If Not CSVDataTable Is Nothing Then
                If CSVDataTable.Rows.Count > 0 Then

                    'Ask the user to supply the lat/lon column names
                    Dim ImportForm As New ImportCSVForm(CSVDataTable)
                    ImportForm.ShowDialog()

                    'Make sure we get lat lon column names
                    If Not ImportForm.LatitudeColumnName Is Nothing And Not ImportForm.LongitudeColumnName Is Nothing Then
                        If ImportForm.LatitudeColumnName.Trim <> "" And ImportForm.LongitudeColumnName.Trim <> "" Then
                            Dim LatColumnName As String = ImportForm.LatitudeColumnName.Trim
                            Dim LonColumnName As String = ImportForm.LongitudeColumnName.Trim

                            'Add WKT and Geography columns to the CSVDataTable and generate the values
                            AddWKTAndGeographyColumnsToDataTable(CSVDataTable, LatColumnName, LonColumnName)

                            'Add SourceFile column to the data table
                            Dim SourceFileColumn As New DataColumn("SourceFile", GetType(String))
                            CSVDataTable.Columns.Add(SourceFileColumn)
                            For Each Row As DataRow In CSVDataTable.Rows
                                Row.Item("SourceFile") = CSVFileInfo.Name
                            Next



                            'Add DataExtractedDate column to the data table
                            Dim DataExtractedDateColumn As New DataColumn("DateRecordExtracted", GetType(DateTime))
                            CSVDataTable.Columns.Add(DataExtractedDateColumn)

                            'Add DataExtractedBy column to the data table
                            Dim DataExtractedByColumn As New DataColumn("DataExtractedBy", GetType(String))
                            CSVDataTable.Columns.Add(DataExtractedByColumn)

                            'Load the metadata columns from above
                            For Each Row As DataRow In CSVDataTable.Rows
                                Debug.Print(Now)
                                Row.Item("DateRecordExtracted") = Now
                                Row.Item("DataExtractedBy") = My.User.Name
                            Next

                            'Add Park Observer - specific columns to the dataset
                            Dim ProtocolFile As String = CSVFileInfo.DirectoryName & "\protocol.obsprot"

                            'If an obsprot exists
                            If My.Computer.FileSystem.FileExists(ProtocolFile) Then
                                Try
                                    'Variables to hold obsprot attributes
                                    Dim ProtocolName As String = ""
                                    Dim ProtocolVersion As String = ""
                                    Dim ProtocolDate As String = ""
                                    Dim ProtocolDescription As String = ""

                                    'Get the protocol attributes out of the obsprot's json
                                    Dim ProtocolText As String = My.Computer.FileSystem.ReadAllText(ProtocolFile)
                                    ProtocolName = GetJSONValue(ProtocolText, "name")
                                    ProtocolVersion = GetJSONValue(ProtocolText, "version")
                                    ProtocolDate = GetJSONValue(ProtocolText, "date")
                                    ProtocolDescription = GetJSONValue(ProtocolText, "description")

                                    'Get the obsprot into a fileinfo
                                    Dim ProtocolFileInfo As New FileInfo(ProtocolFile)

                                    'Add ProtocolFile column to the data table
                                    Dim ProtocolFileColumn As New DataColumn("ProtocolFile", GetType(String))
                                    CSVDataTable.Columns.Add(ProtocolFileColumn)

                                    'Add ProtocolName column to the data table
                                    Dim ProtocolNameColumn As New DataColumn("ProtocolName", GetType(String))
                                    CSVDataTable.Columns.Add(ProtocolNameColumn)

                                    'Add ProtocolVersion column to the data table
                                    Dim ProtocolVersionColumn As New DataColumn("ProtocolVersion", GetType(Double))
                                    CSVDataTable.Columns.Add(ProtocolVersionColumn)

                                    'Add ProtocolDate column to the data table
                                    Dim ProtocolDateColumn As New DataColumn("ProtocolDate", GetType(Date))
                                    CSVDataTable.Columns.Add(ProtocolDateColumn)

                                    'Add ProtocolDescription column to the data table
                                    Dim ProtocolDescriptionColumn As New DataColumn("ProtocolDescription", GetType(String))
                                    CSVDataTable.Columns.Add(ProtocolDescriptionColumn)

                                    'Add the protocol attributes to the data table
                                    For Each Row As DataRow In CSVDataTable.Rows
                                        Try
                                            Row.Item("ProtocolFile") = ProtocolFileInfo.FullName
                                            Row.Item("ProtocolName") = ProtocolName
                                            If IsNumeric(ProtocolVersion) = True Then Row.Item("ProtocolVersion") = CDbl(ProtocolVersion)
                                            If IsDate(ProtocolDate) Then Row.Item("ProtocolDate") = CDate(ProtocolDate)
                                            Row.Item("ProtocolDescription") = ProtocolDescription
                                        Catch RowUpdateException As Exception
                                            Debug.Print(RowUpdateException.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
                                        End Try

                                    Next
                                Catch ProtocolProcessingException As Exception
                                    MsgBox(ProtocolProcessingException.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
                                End Try
                            End If


                            'Create a VectorItemsLayer_NPS for the CSVDataTable
                            Dim CSVLayer As VectorItemsLayer_NPS = GetBubbleVectorItemsLayerFromPointsDataTable(CSVDataTable, LatColumnName, LonColumnName, 12, MarkerType.Circle, Color.GreenYellow)
                            CSVLayer.ProtocolFile = New FileInfo(ProtocolFile)
                            CSVLayer.DataTable = CSVDataTable

                            'Load the Protocol file into the VectorItemsLayer_NPS.ProtocolFile

                            If My.Computer.FileSystem.FileExists(ProtocolFile) Then
                                CSVLayer.ProtocolFile = New FileInfo(ProtocolFile)
                            End If


                            Me.MapControl.Layers.Add(CSVLayer)

                        End If

                        'Refresh the map layers list box
                        LoadMapLayersListBox()
                    End If

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub



    ''' <summary>
    ''' Adds a WKT and a Geography DataColumn to the submitted DataTable, then populates these new columns with the Well-Known Text and Geography representations of the submitted
    ''' Lat/Lon columns.
    ''' </summary>
    ''' <param name="DT"></param>
    ''' <param name="LatColumnName"></param>
    ''' <param name="LonColumnName"></param>
    Private Sub AddWKTAndGeographyColumnsToDataTable(DT As DataTable, LatColumnName As String, LonColumnName As String)
        'Add a WKT and Geography column to the data table
        Dim WKTColumn As New DataColumn("WKT", GetType(String))
        DT.Columns.Add(WKTColumn)
        Dim GeogColumn As New DataColumn("Geography", GetType(String))
        DT.Columns.Add(GeogColumn)
        For Each Row As DataRow In DT.Rows
            Dim Lat As String = Row.Item(LatColumnName)
            Dim Lon As String = Row.Item(LonColumnName)
            Dim WKT As String = "POINT(" & Lon.Trim & " " & Lat.Trim & ",4326)"
            Dim Geog As String = "geography::Point (" & WKT & ")"
            Row.Item("WKT") = WKT
            Row.Item("Geography") = Geog
        Next
    End Sub


    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click

        'Get the CSV file to import
        Dim CSVFileInfo As FileInfo = SkeeterUtilities.DirectoryAndFile.DirectoryAndFileUtilities.GetFile("Comma separated values text files|*.csv", "Select a CSV file to import.", "")
        'Load a CSV file into the tool.
        LoadCSVFile(CSVFileInfo)
    End Sub

    ''' <summary>
    ''' Zooms the main map control to the extent of the map layer named LayerName.
    ''' </summary>
    ''' <param name="LayerName">Name of the map layer to which to zoom.</param>
    Private Sub ZoomToLayer(LayerName As String)
        'Zoom to the extent of the currently selected layer.
        Try
            'Get the currently selected layer as a VectorItemsLayer
            Dim CurrentLayer As VectorItemsLayer_NPS = Me.MapControl.Layers(LayerName)
            If Not CurrentLayer Is Nothing Then
                'Zoom the map to the selected layer
                Me.MapControl.ZoomToFit(CurrentLayer.Data.Items)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub ZoomToLayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomToLayerToolStripMenuItem.Click
        'Zoom to the currently selected layer.
        Dim LayerName As String = Me.MapLayersCheckedListBoxControl.Text.Trim
        ZoomToLayer(LayerName)
    End Sub

    Private Sub KMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KMLToolStripMenuItem.Click
        'Export the map to Keyhole Markup Language (Google Earth) file.
        ExportMapLayer(Me.MapLayersCheckedListBoxControl.Text, Me.MapControl, MapLayerExportFormat.KML)
    End Sub

    Private Sub ShapefileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShapefileToolStripMenuItem.Click
        'Export the map layer to shapefile
        ExportMapLayer(Me.MapLayersCheckedListBoxControl.Text, Me.MapControl, MapLayerExportFormat.Shapefile)
    End Sub

    Private Sub ShapefileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ShapefileToolStripMenuItem1.Click
        'Allow the user to select a shapefile to load into the interface
        Try
            Dim ShpFile As FileInfo = SkeeterUtilities.DirectoryAndFile.DirectoryAndFileUtilities.GetFile("Shapefile|*.shp", "Choose a shapefile.", "")
            If Not ShpFile Is Nothing Then LoadShapefile(ShpFile.FullName, Me.MapControl)
            Me.MapControl.Layers(ShpFile.Name).ZIndex = Me.MapControl.Layers.Count - 1
            LoadMapLayersListBox()
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub ParkObserverArchivepozToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParkObserverArchivepozToolStripMenuItem.Click
        'Allow the user to select a Park Observer file archive to load into the layers list.
        Dim POZFile As FileInfo = SkeeterUtilities.DirectoryAndFile.DirectoryAndFileUtilities.GetFile("Park Observer File (*.poz)|*.poz", "Select a Park Observer File (.poz)", "")
        OpenPOZArchive(POZFile)
    End Sub

    Private Sub MapControl_MapItemClick(sender As Object, e As MapItemClickEventArgs) Handles MapControl.MapItemClick
        If Not e.Item Is Nothing Then
            'Show the selected item in a form
            Dim ItemForm As Form = GetObjectPropertiesForm(e.Item)
            ItemForm.ShowDialog()
        End If
    End Sub

    ''' <summary>
    ''' Returns a Form with OjectToShow in a PropertyGrid.
    ''' </summary>
    ''' <param name="ObjectToShow">Object whose properties should be shown. Object.</param>
    ''' <param name="Title">A title for the form. String. Optional</param>
    ''' <returns></returns>
    Private Function GetObjectPropertiesForm(ObjectToShow As Object, Optional Title As String = "") As Form
        Dim ObjectForm As New Form
        Try
            Dim PG As New PropertyGrid
            PG.Dock = DockStyle.Fill
            PG.SelectedObject = ObjectToShow
            With ObjectForm
                .Controls.Add(PG)
                .Text = Title
                .FormBorderStyle = FormBorderStyle.SizableToolWindow
            End With
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return ObjectForm
    End Function

    Private Sub AddDatasetToolStripButton_Click(sender As Object, e As EventArgs) Handles AddDatasetToolStripButton.Click
        Try
            Dim Filter As String = "Spatial data file|*.poz;*.csv;*.shp" 'Filter to multiple file types
            Dim OFD As New OpenFileDialog
            With OFD
                '.ShowHelp = True
                '.AddExtension = True
                '.CheckFileExists = True
                .Filter = Filter
                .Multiselect = True
                .Title = "Select a spatial dataset"
            End With

            'show the ofd and get the filename and path
            If OFD.ShowDialog = DialogResult.OK Then
                For Each SelectedFile In OFD.FileNames
                    Dim SelectedFileInfo As New FileInfo(SelectedFile)
                    If SelectedFileInfo.Extension = ".shp" Then
                        LoadShapefile(SelectedFileInfo.FullName, Me.MapControl)
                    ElseIf SelectedFileInfo.Extension = ".poz" Then
                        OpenPOZArchive(SelectedFileInfo)
                    ElseIf SelectedFileInfo.Extension = ".csv" Then
                        LoadCSVFile(SelectedFileInfo)
                    End If
                Next
                'Dim SelectedFile As String = OFD.FileName
                'Debug.Print(SelectedFile)
                'add clear datasets and clear dataset button/checkbockxes
                'add tabcontrol and pivot table
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub RemoveAllLayersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveAllLayersToolStripMenuItem.Click
        Try
            Me.MapControl.Layers.Clear()
            'POZDataSet.Tables.Clear()
            LoadMapLayersListBox()
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

    End Sub

    Private Sub RemoveCurrentLayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveCurrentLayerToolStripMenuItem.Click
        Try
            Dim CurrentLayerName As String = Me.MapLayersCheckedListBoxControl.Text.Trim
            Dim CurrentLayer As VectorItemsLayer_NPS = Me.MapControl.Layers(CurrentLayerName)
            If Not CurrentLayer Is Nothing Then
                Me.MapControl.Layers.Remove(CurrentLayer)
                'POZDataSet.Tables.Remove(POZDataSet.Tables(CurrentLayerName))
            End If
            LoadMapLayersListBox()
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub CreatePivotTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreatePivotTableToolStripMenuItem.Click
        Try
            Dim CurrentLayer As VectorItemsLayer_NPS = Me.MapControl.Layers(Me.MapLayersCheckedListBoxControl.Text.Trim)
            Dim DT As DataTable = GetDataTableFromVectorItemsLayer_NPS(CurrentLayer, Me.MapLayersCheckedListBoxControl.Text)
            Dim PivotGridForm As New PivotGridForm(DT)
            PivotGridForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

End Class
