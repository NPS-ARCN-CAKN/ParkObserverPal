Public Class PivotGridForm

    Private DataTableValue As DataTable
    Public Property DataTable() As DataTable
        Get
            Return DataTableValue
        End Get
        Set(ByVal value As DataTable)
            DataTableValue = value
        End Set
    End Property

    Public Sub New(DT As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataTable = DT
        Me.PivotGridControl1.DataSource = Me.DataTable
        Me.PivotGridControl1.RetrieveFields()
        SetUpPivotGridControl(Me.PivotGridControl1)
    End Sub
End Class