Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraMap
Imports DevExpress.XtraPivotGrid

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

End Module
