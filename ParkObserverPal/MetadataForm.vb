Imports SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters

Public Class MetadataForm



    Public Sub New(DT As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim MetadataDataset As DataSet = GetMetadataDatasetFromDataTable(DT, DT.TableName, DT.TableName)
        Me.MetadataGridControl.DataSource = MetadataDataset.Tables(0)

    End Sub

    Private Sub MetadataForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class