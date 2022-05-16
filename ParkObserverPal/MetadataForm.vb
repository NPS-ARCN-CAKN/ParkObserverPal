Imports SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters

Public Class MetadataForm

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
        Me.Text = "Metadata: " & DT.TableName

        LoadDataGrids()
    End Sub

    Private Sub LoadDataGrids()
        Try
            If Not Me.DataTable Is Nothing Then
                'Load the source data table into the data grid
                Me.SourceDatasetDataGridView.DataSource = Me.DataTable

                'Load Me.DataTable's metadata into the metadata grid
                Dim MetadataDataset As DataSet = GetMetadataDatasetFromDataTable(Me.DataTable, Me.DataTable.TableName, Me.DataTable.TableName)

                If Not MetadataDataset.Tables("Metadata") Is Nothing Then
                    Dim MetadataDataTable As DataTable = MetadataDataset.Tables("Metadata")
                    Me.MetadataDataGridView.DataSource = MetadataDataTable
                End If

                If Not MetadataDataset.Tables("Unique values") Is Nothing Then
                    Dim UniqueValuesDataTable As DataTable = MetadataDataset.Tables("Unique values")
                    Me.UniqueValuesDataGridView.DataSource = UniqueValuesDataTable
                End If

                For Each T As DataTable In MetadataDataset.Tables
                        Debug.Print(T.TableName)
                    Next
                End If

        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
End Class