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

End Module
