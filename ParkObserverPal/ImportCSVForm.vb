Public Class ImportCSVForm

    Private LatitudeColumnNameValue As String
    Public Property LatitudeColumnName() As String
        Get
            Return LatitudeColumnNameValue
        End Get
        Set(ByVal value As String)
            LatitudeColumnNameValue = value
        End Set
    End Property

    Private LongitudeColumnNameValue As String
    Public Property LongitudeColumnName() As String
        Get
            Return LongitudeColumnNameValue
        End Get
        Set(ByVal value As String)
            LongitudeColumnNameValue = value
        End Set
    End Property

    Public Sub New(CSVDataTable As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.CSVDataGridView.DataSource = CSVDataTable

        For Each Col As DataColumn In CSVDataTable.Columns
            Me.LatitudeToolStripComboBox.Items.Add(Col.ColumnName)
            Me.LongitudeToolStripComboBox.Items.Add(Col.ColumnName)
        Next
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub ImportCSVForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.OKButton.Enabled = False
    End Sub

    Private Sub ValidateForm()
        Me.OKButton.Enabled = Me.LatitudeToolStripComboBox.Text.Trim <> "" And Me.LongitudeToolStripComboBox.Text.Trim <> ""
    End Sub

    Private Sub LatitudeToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LatitudeToolStripComboBox.SelectedIndexChanged
        Me.LatitudeColumnName = Me.LatitudeToolStripComboBox.Text
        ValidateForm()
    End Sub

    Private Sub LongitudeToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LongitudeToolStripComboBox.SelectedIndexChanged
        Me.LongitudeColumnName = Me.LongitudeToolStripComboBox.Text
        ValidateForm()
    End Sub
End Class