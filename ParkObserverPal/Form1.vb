Imports DevExpress.XtraGrid
Imports SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters
Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim POZZipFile As String = "C:\Temp\Loons 2022-03-24 1230.poz"
        Dim POZDir As String = POZZipFile.Replace(".poz", "")

        If My.Computer.FileSystem.DirectoryExists(POZDir) = True Then
            'If MsgBox("Directory " & POZDir & " exists. Blow it away?", MsgBoxStyle.YesNo, "POZ files directory exists.") = MsgBoxResult.Yes Then
            Try
                'My.Computer.FileSystem.DeleteDirectory(POZDir, FileIO.DeleteDirectoryOption.DeleteAllContents)
                'System.IO.Compression.ZipFile.ExtractToDirectory(POZZipFile, POZDir)
                'Process.Start(POZDir)

                'Loop through each CSV file in the POZ directory
                For Each CSVFIle As String In My.Computer.FileSystem.GetFiles(POZDir)
                    Dim CSVFileInfo As New FileInfo(CSVFIle)

                    'Make sure the file is a CSV file
                    If CSVFileInfo.Extension = ".csv" Then
                        'Create a DataTable to hold the CSV data
                        Dim CSVDataTable As DataTable = GetDataTableFromCSV(CSVFileInfo, True, Format.Delimited)

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

                    End If


                Next



                'Dim LoonsCSVFile As String = POZDir & "\" & "Loons.csv"
                '    Dim LoonsCSVFileInfo As New FileInfo(LoonsCSVFile)
                '    Dim LoonsDataTable As DataTable = GetDataTableFromCSV(LoonsCSVFileInfo, True, Format.Delimited)
                '    Me.LoonsGridControl.DataSource = LoonsDataTable
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Else
            'MsgBox("POZ file extraction aborted.")
            'End If

        End If

    End Sub


End Class
