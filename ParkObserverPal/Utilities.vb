Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraMap
Imports DevExpress.XtraPivotGrid
Imports Newtonsoft.Json

Module Utilities

    Public Class VectorItemsLayer_NPS
        Inherits VectorItemsLayer

        ''' <summary>
        ''' Park Observer protocol file (obsprot) used to generate the dataset.
        ''' </summary>
        Private ProtocolFileValue As FileInfo
        Public Property ProtocolFile() As FileInfo
            Get
                Return ProtocolFileValue
            End Get
            Set(ByVal value As FileInfo)
                ProtocolFileValue = value
            End Set
        End Property

        ''' <summary>
        ''' DataTable of the VectorItemLayer
        ''' </summary>
        Private newDataTable As DataTable
        Public Property DataTable() As DataTable
            Get
                Return newDataTable
            End Get
            Set(ByVal value As DataTable)
                newDataTable = value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Returns the first occurrence of TagName in JSONToLookIn as a String.
    ''' </summary>
    ''' <param name="JSONToLookIn">The JSON text in which to look. String.</param>
    ''' <param name="TagName">JSON tag name to look for. String.</param>
    ''' <returns>String.</returns>
    Public Function GetJSONValue(JSONToLookIn As String, TagName As String) As String
        'Imports Newtonsoft.Json
        Dim ReturnValue As String = ""
        Try
            Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(JSONToLookIn)
            ReturnValue = jsonResulttodict.Item(TagName)
        Catch ex As Exception
            Dim Msg As String = "Warning: " & TagName & " not found in the submitted JSON"
            MsgBox(Msg & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
        Return ReturnValue
    End Function


    ''' <summary>
    ''' Sets up a GridControl the way I like it
    ''' </summary>
    ''' <param name="GC">GridControl to configure. DevExpress GridControl.</param>
    Public Sub SetUpGridControl(GC As GridControl)
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

    ''' <summary>
    ''' Converts PointsDataTable into a line VectorItemsLayer.
    ''' </summary>
    ''' <param name="PointsDataTable">DataTable of Lat/Lon points. DataTable.</param>
    ''' <param name="LatitudeColumnName">Name of the latitude column. String.</param>
    ''' <param name="LongitudeColumnName">Name of the Longitude column. String.</param>
    ''' <param name="TimeColumnName">Name of the time column. String.</param>
    ''' <param name="Color">Line color. Color.</param>
    ''' <param name="Width">Line width. Integer.</param>
    ''' <returns></returns>
    Public Function GetLineVectorItemsLayerFromPoints(PointsDataTable As DataTable, LatitudeColumnName As String, LongitudeColumnName As String, TimeColumnName As String, Color As Color, Width As Integer) As VectorItemsLayer_NPS
        'Create a VectorItemsLayer_NPS
        Dim MyLineVectorItemsLayer_NPS As New VectorItemsLayer_NPS

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

            'Assign the items to the line VectorItemsLayer_NPS
            MyLineVectorItemsLayer_NPS.Data = MyMapItemStorage
            MyLineVectorItemsLayer_NPS.Name = PointsDataTable.TableName
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try

        Return MyLineVectorItemsLayer_NPS
    End Function

    ''' <summary>
    ''' Returns a Form with OjectToShow in a PropertyGrid.
    ''' </summary>
    ''' <param name="ObjectToShow">Object whose properties should be shown. Object.</param>
    ''' <param name="Title">A title for the form. String. Optional</param>
    ''' <returns></returns>
    Public Function GetObjectPropertiesForm(ObjectToShow As Object, Optional Title As String = "") As Form
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

    ''' <summary>
    ''' Converts a VectorItemsLayer_NPS.Data.Items name/value pair collection items into a DataTable.
    ''' </summary>
    ''' <param name="VIL">VectorItemsLayer_NPS to convert to DataTable. VectorItemsLayer_NPS.</param>
    ''' <param name="TableName">TableName. String. Optional. Defaults to the name of VectorItemsLayer_NPS.</param>
    ''' <returns></returns>
    Public Function GetDataTableFromVectorItemsLayer_NPS(VIL As VectorItemsLayer_NPS, Optional TableName As String = "") As DataTable
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


    Public Function GetDataTableFromMapItemAttributes(MI As MapItem) As DataTable
        'Make a DataTable
        Dim DT As New DataTable()

        Try
            'Make sure we have a MapItem to work with
            If Not MI Is Nothing Then

                'The data in a MapItem are stored as Name/Value pairs, we need to convert them to a DataTable.
                If MI.Attributes.Count > 0 Then

                    'Create a DataColumn for each map item's Name attribute and add it to the data table.
                    For Each Attribute As MapItemAttribute In MI.Attributes

                        'Make a new DataColumn
                        Dim ColumnName As String = Attribute.Name

                        'Create a new DataColumn based on the map item's name and value
                        Dim NewColumn As New DataColumn(ColumnName)

                        'MapItem attribute's data type is set to DBNull for NULL or empty rows. In such cases the equivalent DataColumn DataType cannot be determined.
                        'This problem led to errors when the DataTable.NewRow function was called to create a new row.
                        'Set such columns data type to String since it doesn't really matter anyway because there is no data for those cells
                        If Attribute.Value.GetType.Name = "DBNull" Then
                            NewColumn.DataType = GetType(String)
                        Else
                            NewColumn.DataType = Attribute.Value.GetType
                        End If

                        'Add the new column to DT DataTable
                        DT.Columns.Add(NewColumn)
                    Next

                    'Make a single new DataRow to hold the MapItem's Attribute's value
                    Dim NewRow As DataRow = DT.NewRow
                    For Each Attribute As MapItemAttribute In MI.Attributes
                        'Set each column's value in the new row
                        NewRow.Item(Attribute.Name) = Attribute.Value
                    Next

                    'Add the new row to the DataTable
                    DT.Rows.Add(newrow)

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ").")
        End Try
        Return DT
    End Function

    ''' <summary>
    ''' Adds a WKT and a Geography DataColumn to the submitted DataTable, then populates these new columns with the Well-Known Text and Geography representations of the submitted
    ''' Lat/Lon columns.
    ''' </summary>
    ''' <param name="DT"></param>
    ''' <param name="LatColumnName"></param>
    ''' <param name="LonColumnName"></param>
    Public Sub AddWKTAndGeographyColumnsToDataTable(DT As DataTable, LatColumnName As String, LonColumnName As String)
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

    ''' <summary>
    ''' Loads a DataTable with lat/lon coordinate pairs into MC (MapControl).
    ''' </summary>
    ''' <param name="SpatialDataTable"></param>
    ''' <param name="MC"></param>
    ''' <param name="SourceFile"></param>
    ''' <param name="ProtocolFile"></param>
    Public Sub LoadSpatialDataTable(SpatialDataTable As DataTable, MC As MapControl, Optional SourceFile As String = "", Optional ProtocolFile As String = "")
        Try

            If Not SpatialDataTable Is Nothing Then
                If SpatialDataTable.Rows.Count > 0 Then

                    'Ask the user to supply the lat/lon column names
                    Dim ImportForm As New ImportCSVForm(SpatialDataTable)
                    ImportForm.ShowDialog()

                    'Make sure we get lat lon column names
                    If Not ImportForm.LatitudeColumnName Is Nothing And Not ImportForm.LongitudeColumnName Is Nothing Then
                        If ImportForm.LatitudeColumnName.Trim <> "" And ImportForm.LongitudeColumnName.Trim <> "" Then
                            Dim LatColumnName As String = ImportForm.LatitudeColumnName.Trim
                            Dim LonColumnName As String = ImportForm.LongitudeColumnName.Trim

                            'Add WKT and Geography columns to the SpatialDataTable and generate the values
                            AddWKTAndGeographyColumnsToDataTable(SpatialDataTable, LatColumnName, LonColumnName)

                            'Add SourceFile column to the data table
                            Dim SourceFileColumn As New DataColumn("SourceFile", GetType(String))
                            SpatialDataTable.Columns.Add(SourceFileColumn)
                            For Each Row As DataRow In SpatialDataTable.Rows
                                Row.Item("SourceFile") = SourceFile
                            Next

                            'Add DataExtractedDate column to the data table
                            Dim DataExtractedDateColumn As New DataColumn("DateRecordExtracted", GetType(DateTime))
                            SpatialDataTable.Columns.Add(DataExtractedDateColumn)

                            'Add DataExtractedBy column to the data table
                            Dim DataExtractedByColumn As New DataColumn("DataExtractedBy", GetType(String))
                            SpatialDataTable.Columns.Add(DataExtractedByColumn)

                            'Add Unique ID column to the data table
                            Dim NPS_GUIDColumn As New DataColumn("NPS_GUID", GetType(String))
                            SpatialDataTable.Columns.Add(NPS_GUIDColumn)

                            'Load the metadata columns from above
                            For Each Row As DataRow In SpatialDataTable.Rows
                                Row.Item("NPS_GUID") = Guid.NewGuid.ToString
                                Row.Item("DateRecordExtracted") = Now
                                Row.Item("DataExtractedBy") = My.User.Name
                            Next

                            'Add Park Observer - specific columns to the dataset
                            'Dim ProtocolFile As String = CSVFileInfo.DirectoryName & "\protocol.obsprot"

                            'If an obsprot exists
                            If ProtocolFile.Trim <> "" Then
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
                                        SpatialDataTable.Columns.Add(ProtocolFileColumn)

                                        'Add ProtocolName column to the data table
                                        Dim ProtocolNameColumn As New DataColumn("ProtocolName", GetType(String))
                                        SpatialDataTable.Columns.Add(ProtocolNameColumn)

                                        'Add ProtocolVersion column to the data table
                                        Dim ProtocolVersionColumn As New DataColumn("ProtocolVersion", GetType(Double))
                                        SpatialDataTable.Columns.Add(ProtocolVersionColumn)

                                        'Add ProtocolDate column to the data table
                                        Dim ProtocolDateColumn As New DataColumn("ProtocolDate", GetType(Date))
                                        SpatialDataTable.Columns.Add(ProtocolDateColumn)

                                        'Add ProtocolDescription column to the data table
                                        Dim ProtocolDescriptionColumn As New DataColumn("ProtocolDescription", GetType(String))
                                        SpatialDataTable.Columns.Add(ProtocolDescriptionColumn)



                                        'Add the protocol attributes to the data table
                                        For Each Row As DataRow In SpatialDataTable.Rows
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
                            End If

                            'Create a VectorItemsLayer_NPS for the SpatialDataTable
                            Dim CSVLayer As VectorItemsLayer_NPS = GetBubbleVectorItemsLayerFromPointsDataTable(SpatialDataTable, LatColumnName, LonColumnName, 10, MarkerType.Circle, Color.FromArgb(CInt(Math.Ceiling(Rnd() * 255)) + 1, CInt(Math.Ceiling(Rnd() * 255)) + 1, CInt(Math.Ceiling(Rnd() * 255)) + 1))
                            CSVLayer.DataTable = SpatialDataTable

                            'Load the Protocol file into the VectorItemsLayer_NPS.ProtocolFile
                            If ProtocolFile.Trim <> "" Then
                                If My.Computer.FileSystem.FileExists(ProtocolFile) Then
                                    CSVLayer.ProtocolFile = New FileInfo(ProtocolFile)
                                End If
                            End If

                            MC.Layers.Add(CSVLayer)

                            End If
                        End If

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Opens a file open dialog allowing the user to select a comma separated values text file to load into the main interface. Opens a selector dialog to let the user
    ''' select any lat/lon fields, if desired.
    ''' </summary>
    Public Sub LoadCSVFile(CSVFileInfo As FileInfo, MC As MapControl)
        Try
            If Not CSVFileInfo Is Nothing Then
                'Convert the CSV to a DataTable
                Dim CSVDataTable As DataTable = SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters.GetDataTableFromCSV(CSVFileInfo, True, SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters.Format.Delimited)
                CSVDataTable.TableName = CSVFileInfo.Name

                LoadSpatialDataTable(CSVDataTable, MC)

            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
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

        'Configure the map layer
        With MyPointsVectorItemsLayer_NPS
            .EnableHighlighting = True
            .EnableSelection = True
        End With

        Try
            'Create a MapItemStorage object (basically DevExpress's version of a spatial data table, stores MapItem objects which are like DataRows
            Dim MyMapItemStorage As New MapItemStorage

            'Count up NULL or empty or non-numeric rows
            Dim NullSpatialRowsCount As Integer = 0
            Dim NonNumericSpatialRowsCount As Integer = 0

            'Make sure we have spatial column names
            If LatitudeColumnName.Trim <> "" And LongitudeColumnName.Trim <> "" Then

                'Convert .NET DataRows to MapBubbles
                Dim i As Double = 1 'i will be used as an identifier
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
                                    .Argument = PointsDataTable.TableName.Trim
                                    .Value = i
                                    .Tag = MyPointDataRow.Item("NPS_GUID")

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
                                    '.SelectedFill = Color.AliceBlue
                                    .SelectedStroke = Color.AliceBlue
                                    .SelectedStrokeWidth = 4
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
                    i = i + 1
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

End Module
