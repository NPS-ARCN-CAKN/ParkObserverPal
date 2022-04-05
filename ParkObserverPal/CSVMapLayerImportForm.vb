Imports DevExpress.XtraGrid

Public Class CSVMapLayerImportForm

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

    Dim DT As New DataTable

    Public Sub New(CSVDataTable As DataTable)
        DT = CSVDataTable
        ' This call is required by the designer.
        InitializeComponent()

        Me.CSVGridControl.datasource = DT

        'Load the latlon column names selector dropdowns in the maint toolstrip
        If Not DT Is Nothing Then
            ' Load up the column names into the lan/lon column names selectors
            For Each Column As DataColumn In DT.Columns
                Me.LatitudeColumnToolStripComboBox.Items.Add(Column.ColumnName)
                Me.LongitudeColumnToolStripComboBox.Items.Add(Column.ColumnName)
            Next
        End If

    End Sub



    'Private Sub EnableForm()
    '    If Not DT Is Nothing Then
    '        If DT.Rows.Count >= 1 Then
    '            Me.ImportButton.Enabled = IsNumeric(DT.Rows(0).Item(Me.LatitudeColumnName)) And IsNumeric(DT.Rows(0).Item(Me.LatitudeColumnName))
    '        Else
    '            Me.ImportButton.Name = False
    '        End If
    '    End If
    'End Sub

    Private Sub ImportButton_Click(sender As Object, e As EventArgs) Handles ImportButton.Click
        Me.Close()
    End Sub

    Private Sub LatitudeColumnToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LatitudeColumnToolStripComboBox.SelectedIndexChanged
        Me.LatitudeColumnName = Me.LatitudeColumnToolStripComboBox.Text
    End Sub

    Private Sub LongitudeColumnToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LongitudeColumnToolStripComboBox.SelectedIndexChanged
        Me.LongitudeColumnName = Me.LongitudeColumnToolStripComboBox.Text
    End Sub
End Class