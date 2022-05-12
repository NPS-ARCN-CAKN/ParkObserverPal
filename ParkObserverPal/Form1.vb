Imports DevExpress.XtraGrid
Imports DevExpress.XtraMap
Imports SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPivotGrid
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json
Imports DevExpress.XtraEditors
Imports DevExpress.DataAccess.Sql
Imports DevExpress.DataAccess.Sql.DataApi

Public Class Form1

    Dim MapLayersDataTable As New DataTable("Layers") 'The data table that will show the current layer's data
    'Dim POZDataSet As New DataSet 'Park Observer data set

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadCSVFile(New FileInfo("C:\temp\zSpatialData.csv"), Me.MapControl)
        '        LoadCSVFile(New FileInfo("C:\temp\ARCN_LakeChemistry_2013-2018.csv"), Me.MapControl)
        'Refresh the map layers list box
        LoadMapLayersListBox()

        'My.Settings.BackgroundLayers = "C:\Work\GIS Common Layers\AlaskaSimplified_1km.shp"
        'LoadBackgroundLayers()


        For Each GV As GridView In Me.MapLayerGridControl.Views
            GV.OptionsBehavior.ReadOnly = True
            GV.OptionsSelection.MultiSelect = True
            GV.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
        Next


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

        'Reset various controls
        ResetInterface()


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
                            LoadCSVFile(CSVFileInfo, Me.MapControl)

                            'Refresh the map layers list box
                            LoadMapLayersListBox()

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

            'Start by clearing things
            ResetInterface()

            'Get the name of the currently selected layer
            Dim LayerName As String = MapLayersCheckedListBoxControl.Text

            'Get a handle on the map layer with the name from above
            Dim MapLayer As VectorItemsLayer_NPS = MapControl.Layers(LayerName)

            If Not MapLayer Is Nothing Then
                'Show the data in the map layer grid control
                Dim GV As GridView = TryCast(MapLayerGridControl.MainView, GridView)
                GV.Columns.Clear()
                Me.MapLayerGridControl.DataSource = Nothing
                If Not MapLayer.DataTable Is Nothing Then
                    With Me.MapLayerGridControl
                        .DataSource = MapLayer.DataTable
                        .Refresh()
                        .RefreshDataSource()
                    End With
                    SetUpGridControl(Me.MapLayerGridControl)
                End If
            End If

            'Change the context menu item title to reflect the layer name, make it more obvious which layer is to be removed.
            Me.RemoveCurrentLayerToolStripMenuItem.Text = "Remove " & LayerName
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
    Private Sub LoadExcelFile(ExcelFileInfo As FileInfo)
        Try
            'Convert the CSV to a DataTable
            Dim ExcelConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ExcelFileInfo.FullName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
            Dim ExcelDataset As DataSet = SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters.GetDatasetFromExcelWorkbook(ExcelConnectionString)
            ExcelDataset.DataSetName = ExcelFileInfo.Name
            Dim ExcelForm As New ImportExcelForm(ExcelDataset, Me.MapControl)
            ExcelForm.ShowDialog()

            'If Not ExcelDataset Is Nothing Then
            '    If ExcelDataset.Tables.Count > 0 Then
            '        For Each ExcelDataTable As DataTable In ExcelDataset.Tables

            '        Next


            '        'Refresh the map layers list box
            '        LoadMapLayersListBox()
            '        End If

            '    End If

        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub





    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click

        'Get the CSV file to import
        Dim CSVFileInfo As FileInfo = SkeeterUtilities.DirectoryAndFile.DirectoryAndFileUtilities.GetFile("Comma separated values text files|*.csv", "Select a CSV file to import.", "")
        'Load a CSV file into the tool.
        LoadCSVFile(CSVFileInfo, Me.MapControl)

        'Refresh the map layers list box
        LoadMapLayersListBox()
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
        Try
            Dim POZFile As FileInfo = SkeeterUtilities.DirectoryAndFile.DirectoryAndFileUtilities.GetFile("Park Observer File (*.poz)|*.poz", "Select a Park Observer File (.poz)", "")
            OpenPOZArchive(POZFile)
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub





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
                        LoadCSVFile(SelectedFileInfo, Me.MapControl)

                        'Refresh the map layers list box
                        LoadMapLayersListBox()
                    End If
                Next
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
            ResetInterface()
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

    End Sub

    Private Sub RemoveCurrentLayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveCurrentLayerToolStripMenuItem.Click
        Try
            Dim CurrentLayerName As String = Me.MapLayersCheckedListBoxControl.Text.Trim
            If MsgBox("Remove " & CurrentLayerName & " from the map?", MsgBoxStyle.YesNo, "Remove map layer") = MsgBoxResult.Yes Then
                Dim CurrentLayer As VectorItemsLayer_NPS = Me.MapControl.Layers(CurrentLayerName)
                If Not CurrentLayer Is Nothing Then
                    Me.MapControl.Layers.Remove(CurrentLayer)
                End If
                LoadMapLayersListBox()
                ResetInterface()
            End If
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

    Private Sub MapControl_MapItemClick(sender As Object, e As MapItemClickEventArgs) Handles MapControl.MapItemClick
        'Explanation of what goes on when a user clicks an item on the map:
        'User clicked a MapItem on the map highlighting it. MapItem data is stored as name/value pairs natively. This is not super useful.
        'I wanted each layer (VectorItemLayer) to have an accompanying DataTable the same way a shapefile has a dbf. I did this by
        'extending VectorItemLayer as NPS_VectorItemLayer with .DataTable among other attributes. This DataTable is what is shown in the GridControl.
        'So the trick here is relating each MapItem with its DataTable.DataRow object.
        'This is done using a Globally Unique ID called NPS_GUID that is shared between each MapItem (stored in its .Tag attribute) and its
        'equivalent DataRow (NPS_GUID DataColumn) in its DataTable.
        'What the code below does is to match the clicked MapItem to its DataRow to populate the VGridControl with its DataRow and to highlight its
        'DataRow in the GridControl.

        'Clear the interface and reset controls
        'ResetInterface()

        Try
            'Make sure we have a clicked MapItem
            If Not e.Item Is Nothing Then

                'Get a handle on the clicked MapItem
                Dim ClickedItem As MapItem = e.Item

                'Load the clicked MapItem into the FeaturePropertyGrid so user can see its data and attributes
                Me.FeaturePropertyGrid.SelectedObject = ClickedItem

                'Start by highlighting the clicked item's data in the MapLayerGridControl so the user can see it
                'Clear all formatting rules in the main GridControl's GridView
                Me.MapLayerGridView.FormatRules.Clear()

                'Some map layers have .Tag defined with a GUID, if they do then treat separately
                If Not ClickedItem.Tag Is Nothing Then

                    'Make sure .Tag has data
                    If ClickedItem.Tag.ToString.Trim <> "" Then

                        If Not Me.MapLayerGridView.Columns("NPS_GUID") Is Nothing Then
                            'Build a filtering string based on the clicked MapItem.Tag which stores NPS_GUID, a unique identifier
                            Dim Filter As String = "NPS_GUID = '" & ClickedItem.Tag.ToString.Trim & "'"

                            'Now build a conditional formatting rule and filter
                            'This will be used to highlight the MapItem's DataRow in the main GridControl using a conditional formatting style
                            Dim MyFormatConditionRuleExpression As New FormatConditionRuleExpression
                            With MyFormatConditionRuleExpression
                                .Expression = Filter
                                .Appearance.BackColor = Color.AliceBlue
                            End With

                            'Apply the formatting rule
                            Me.MapLayerGridView.FormatRules.Add(Me.MapLayerGridView.Columns("NPS_GUID"), MyFormatConditionRuleExpression)
                            Me.MapLayerGridView.FormatRules(0).ApplyToRow = True

                            'Now isolate the DataRow that belongs to the clicked MapItem and show its data in the VGridControl

                            Dim ClickedItemDataTable As DataTable = GetDataTableFromMapItemAttributes(ClickedItem)
                            Me.VGridControl.DataSource = ClickedItemDataTable

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

    End Sub

    ''' <summary>
    ''' Clears all the controls of data; property grids, VGridControls, etc. Used after layers are selected or map items clicked so residual data does not show up 
    ''' confusing the user
    ''' </summary>
    Private Sub ResetInterface()
        'Start by clearing things
        Me.MapLayerGridView.FormatRules.Clear()
        Me.VGridControl.DataSource = Nothing
        Me.VGridControl.RetrieveFields()
        Me.FeaturePropertyGrid.SelectedObject = Nothing
    End Sub

    Private Sub MapControl_Click(sender As Object, e As EventArgs) Handles MapControl.Click
        ResetInterface()
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        'Figure out the kind of file(s) dropped on the main form and try to open it (them)
        Try
            Dim DraggedFiles() As String = e.Data.GetData(DataFormats.FileDrop)
            For Each DraggedFile In DraggedFiles

                Dim DraggedFileInfo As New FileInfo(DraggedFile)
                Select Case DraggedFileInfo.Extension
                    Case ".shp"
                        LoadShapefile(DraggedFileInfo.FullName, Me.MapControl)
                    Case ".csv"
                        LoadCSVFile(DraggedFileInfo, Me.MapControl)
                    Case ".poz"
                        LoadPOZArchive(DraggedFileInfo.FullName)
                    Case Else
                        MsgBox("The file type *" & DraggedFileInfo.Extension & " is not supported.", MsgBoxStyle.Information, "File type not supported")
                End Select

                'Refresh the map layers list box
                LoadMapLayersListBox()
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub MapLayerGridView_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles MapLayerGridView.SelectionChanged
        Try

            Dim VIL As VectorItemsLayer = Me.MapControl.Layers(Me.MapLayersCheckedListBoxControl.Text.Trim)
            VIL.SelectedItems.Clear()


            Dim GV As GridView = sender
            For Each RowIndex As Integer In GV.GetSelectedRows
                Dim NPS_GUID As String = GV.GetRowCellValue(RowIndex, "NPS_GUID")
                For Each MI As MapItem In VIL.Data.Items
                    If MI.Tag = NPS_GUID Then
                        VIL.SelectedItems.Add(MI)
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
End Class
