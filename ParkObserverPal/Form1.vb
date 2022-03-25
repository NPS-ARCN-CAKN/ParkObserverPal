Imports DevExpress.XtraGrid
Imports DevExpress.XtraMap
Imports SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters
Imports System.IO
Imports DevExpress.XtraGrid.Views.Layout

Public Class Form1

    Dim POZZipFile As String = "C:\Temp\Loons 2022-03-24 1230.poz"
    Dim POZDir As String = POZZipFile.Replace(".poz", "")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UnzipPOZFiles()
        'AddAlaskaShapefileToMap()
        LoadPOZCSVFilesIntoTabControl()




        'Dim MyVectorItemsLayer As VectorItemsLayer = Me.MapControl.Layers("GpsPoints")

        'Dim MyMapItemStorage As New MapItemStorage
        'Dim MyMapBubble As New MapBubble()
        'With MyMapBubble
        '    .Location = New GeoPoint(60, -150)
        '    .Value = 400
        '    .Argument = "TEST"
        '    .Size = 50
        '    .MarkerType = MarkerType.Triangle
        '    .Fill = Color.Red
        'End With
        'MyMapItemStorage.Items.Add(MyMapBubble)
        'Dim MyVectorItemsLayer As New VectorItemsLayer
        'MyVectorItemsLayer.Data = MyMapItemStorage
        'Me.MapControl.Layers.Add(MyVectorItemsLayer)

    End Sub

    Private Sub UnzipPOZFiles()
        If MsgBox("Directory " & POZDir & " exists. Blow it away?", MsgBoxStyle.YesNo, "POZ files directory exists.") = MsgBoxResult.Yes Then
            Try
                'My.Computer.FileSystem.DeleteDirectory(POZDir, FileIO.DeleteDirectoryOption.DeleteAllContents)
                'System.IO.Compression.ZipFile.ExtractToDirectory(POZZipFile, POZDir)
                'Process.Start(POZDir)
            Catch ex As Exception
                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
            End Try

        End If

    End Sub
    Private Sub LoadPOZCSVFilesIntoTabControl()

        Try
            If My.Computer.FileSystem.DirectoryExists(POZDir) = True Then


                'Loop through each CSV file in the POZ directory
                For Each CSVFIle As String In My.Computer.FileSystem.GetFiles(POZDir)
                    Dim CSVFileInfo As New FileInfo(CSVFIle)
                    Dim CSVName As String = CSVFileInfo.Name.Replace(".csv", "")
                    'Make sure the file is a CSV file
                    If CSVFileInfo.Extension = ".csv" Then
                        'Create a DataTable to hold the CSV data
                        Dim CSVDataTable As DataTable = GetDataTableFromCSV(CSVFileInfo, True, Format.Delimited)
                        CSVDataTable.TableName = CSVName

                        'Create a GridControl to display the CSVData
                        Dim CSVGridControl As New GridControl
                        With CSVGridControl
                            .DataSource = CSVDataTable
                            .Dock = DockStyle.Fill
                        End With

                        'Create a new tabpage to hold a grid showing the CSV datatable 
                        Dim CSVTabPage As New TabPage(CSVFileInfo.Name)
                        CSVTabPage.Controls.Add(CSVGridControl)

                        'Add the new tab page to the main TabControl
                        Me.MainTabControl.TabPages.Add(CSVTabPage)


                        'Load the CSV spatial data files into the map
                        'Find out if the data tables contain lat/lon columns
                        'Dim IsLatLonDataTable As Boolean = False 'Some tables have LatLon stored in columns named Latitude and Longitude
                        ' Dim IsFeature_LatLon_DataTable As Boolean = False 'Some tables have LatLon stored in columns named Feature_Latitude and Feature_Longitude
                        Dim LatColumnName As String = ""
                        Dim LonColumnName As String = ""
                        For Each Col As DataColumn In CSVDataTable.Columns
                            If Col.ColumnName.Trim = "Latitude" Then
                                LatColumnName = "Latitude"
                                LonColumnName = "Longitude"
                            ElseIf Col.ColumnName = "Feature_Latitude" Then
                                LatColumnName = "Feature_Latitude"
                                LonColumnName = "Feature_Longitude"
                            End If
                        Next

                        'Dim CSVLayer As VectorItemsLayer = GetWKTVectorItemsLayerFromPointsDataTable(CSVDataTable, LatColumnName, LonColumnName)
                        Dim Color As Color = Color.Gray
                        Dim PtSize As Integer = 4
                        If CSVName.ToLower = "loons" Then
                            Color = Color.Blue
                            PtSize = 20
                        ElseIf CSVName.ToLower = "gpspoints" Then
                            Color = Color.Green
                            PtSize = 6

                            'Draw a tracklog
                            DrawLine(CSVDataTable, "Latitude", "Longitude")

                        End If

                        Dim CSVLayer As VectorItemsLayer = GetMapBubbleVectorItemsLayerFromPointsDataTable(CSVDataTable, LatColumnName, LonColumnName, PtSize, LatColumnName, MarkerType.Circle, Color)
                        CSVLayer.Name = CSVName
                        Me.MapControl.Layers.Add(CSVLayer)
                        Me.MapControl.ZoomToFitLayerItems()
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try

    End Sub


    Private Sub DrawLine(PointsDataTable As DataTable, LatitudeColumnName As String, LongitudeColumnName As String)
        Dim MyLineVectorItemsLayer As New VectorItemsLayer
        Dim MyMapItemStorage As New MapItemStorage
        Dim MyMapPolyLine As New MapPolyline
        With MyMapPolyLine
            .Stroke = Color.Gray
            .StrokeWidth = 4
        End With

        For Each MyPointDataRow As DataRow In PointsDataTable.Rows
            If Not MyPointDataRow Is Nothing Then
                If Not IsDBNull(MyPointDataRow.Item(LatitudeColumnName)) And Not IsDBNull(MyPointDataRow.Item(LongitudeColumnName)) Then
                    Dim Lat As Double = CDbl(MyPointDataRow.Item(LatitudeColumnName))
                    Dim Lon As Double = CDbl(MyPointDataRow.Item(LongitudeColumnName))
                    Dim MyGeoPoint As New GeoPoint(Lat, Lon)
                    MyMapPolyLine.Points.Add(MyGeoPoint)
                End If
            End If
        Next
        MyMapItemStorage.Items.Add(MyMapPolyLine)
        MyLineVectorItemsLayer.Data = MyMapItemStorage
        Me.MapControl.Layers.Add(MyLineVectorItemsLayer)
    End Sub

    ''' <summary>
    ''' Returns a DevExpress VectorItemsLayer of MapBubble points derived a DataTable containing Lat/Lon pairs.
    ''' </summary>
    ''' <param name="PointsDataTable">DataTable containing points spatial data. DataTable</param>
    ''' <param name="LatitudeColumnName">Name of the latitude column. String.</param>
    ''' <param name="LongitudeColumnName">Name of the longitude column. String.</param>
    ''' <returns>VectorItemLayer of points from WKT.</returns>
    Public Function GetMapBubbleVectorItemsLayerFromPointsDataTable(PointsDataTable As DataTable, LatitudeColumnName As String, LongitudeColumnName As String, FeatureSize As Integer, ArgumentColumnName As String, MarkerType As MarkerType, FillColor As Color) As DevExpress.XtraMap.VectorItemsLayer
        Dim MyMapItemStorage As New MapItemStorage
        Dim MyPointsVectorItemsLayer As New VectorItemsLayer()
        If LatitudeColumnName.Trim <> "" And LongitudeColumnName.Trim <> "" Then
            For Each MyPointDataRow As DataRow In PointsDataTable.Rows
                If Not MyPointDataRow Is Nothing Then
                    If Not IsDBNull(MyPointDataRow.Item(LatitudeColumnName)) And Not IsDBNull(MyPointDataRow.Item(LongitudeColumnName)) Then
                        Dim Lat As Double = CDbl(MyPointDataRow.Item(LatitudeColumnName))
                        Dim Lon As Double = CDbl(MyPointDataRow.Item(LongitudeColumnName))
                        Dim MyMapBubble As New MapBubble()
                        With MyMapBubble
                            .Location = New GeoPoint(Lat, Lon)
                            .Value = 400
                            .Argument = ArgumentColumnName
                            .Size = FeatureSize
                            .MarkerType = MarkerType
                            .Fill = FillColor
                            .Value = Lat
                        End With
                        MyMapItemStorage.Items.Add(MyMapBubble)
                    End If
                End If
            Next
            With MyPointsVectorItemsLayer
                .Data = MyMapItemStorage
            End With
        End If
        Return MyPointsVectorItemsLayer
    End Function

    ''' <summary>
    ''' Returns a DevExpress VectorItemsLayer of points derived from WKT from a DataTable containing Lat/Lon pairs.
    ''' </summary>
    ''' <param name="PointsDataTable">DataTable containing points spatial data. DataTable</param>
    ''' <param name="LatitudeColumnName">Name of the latitude column. String.</param>
    ''' <param name="LongitudeColumnName">Name of the longitude column. String.</param>
    ''' <returns>VectorItemLayer of points from WKT.</returns>
    Public Function GetWKTVectorItemsLayerFromPointsDataTable(PointsDataTable As DataTable, LatitudeColumnName As String, LongitudeColumnName As String) As DevExpress.XtraMap.VectorItemsLayer
        Dim MyPointsVectorItemsLayer As New VectorItemsLayer()
        If LatitudeColumnName.Trim <> "" And LongitudeColumnName.Trim <> "" Then
            Dim MySqlGeometryItemStorage As New SqlGeometryItemStorage()
            For Each MyPointDataRow As DataRow In PointsDataTable.Rows
                If Not MyPointDataRow Is Nothing Then
                    If Not IsDBNull(MyPointDataRow.Item(LatitudeColumnName)) And Not IsDBNull(MyPointDataRow.Item(LongitudeColumnName)) Then
                        Dim Lat As Double = CDbl(MyPointDataRow.Item(LatitudeColumnName))
                        Dim Lon As Double = CDbl(MyPointDataRow.Item(LongitudeColumnName))
                        Dim WKT As String = "POINT(" & Lon & " " & Lat & ")"
                        MySqlGeometryItemStorage.Items.Add(SqlGeometryItem.FromWkt(WKT, 0))
                    End If
                End If
            Next


            With MyPointsVectorItemsLayer
                .Data = MySqlGeometryItemStorage
            End With
        End If
        Return MyPointsVectorItemsLayer
    End Function

    Private Sub AddAlaskaShapefileToMap()
        Dim Shp As String = "C:\Work\GIS Common Layers\alaska_arc.shp"
        Dim AKShpLayer As VectorItemsLayer = GetShapefileVectorItemsLayer(Shp)
        Me.MapControl.Layers.Add(AKShpLayer)
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
End Class
