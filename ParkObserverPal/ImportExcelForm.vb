Imports DevExpress.XtraMap

Public Class ImportExcelForm

    Dim XlDataset As DataSet

    Public Sub New(ExcelDataset As DataSet, MainMapControl As MapControl)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        XlDataset = ExcelDataset
    End Sub

    Private Sub ImportExcelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each ExcelDataTable As DataTable In XlDataset.Tables
            Me.WorksheetsCheckedListBox.Items.Add(ExcelDataTable.TableName)
        Next
    End Sub
End Class