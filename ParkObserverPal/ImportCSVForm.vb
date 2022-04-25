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

    Private DataTableValue As DataTable
    Public Property DataTable() As DataTable
        Get
            Return DataTableValue
        End Get
        Set(ByVal value As DataTable)
            DataTableValue = value
        End Set
    End Property

    Private CoordinateColumnsAreValidValue As Boolean
    Public Property CoordinateColumnsAreValid() As Boolean
        Get
            Return CoordinateColumnsAreValidValue
        End Get
        Set(ByVal value As Boolean)
            CoordinateColumnsAreValidValue = value
        End Set
    End Property

    Public Sub New(CSVDataTable As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.LatitudeColumnName = ""
        Me.LongitudeColumnName = ""

        'Disable the OK button until QC checks are done
        OKButton.Enabled = False

        'Test the datatable, make sure it's valid for use
        If Not CSVDataTable Is Nothing Then 'Not nothing
            If CSVDataTable.Rows.Count > 0 Then 'Has rows
                Me.DataTable = CSVDataTable 'Make it globally accessible
                Me.CSVDataGridView.DataSource = Me.DataTable


                'Load the column names into the selector listboxes
                ValidationTextBox.Text = "Imported data summary" & vbNewLine
                For Each Col As DataColumn In Me.DataTable.Columns


                    'Summarize the imported data for the user
                    Dim ColumnDataType As String = Col.DataType.ToString.Replace("System.", "")

                    ValidationTextBox.AppendText(vbTab & Col.ColumnName & vbTab & Col.DataType.ToString & vbNewLine)

                    ''Load any numeric data columns into the selector listboxes
                    If ColumnDataType <> "String" And ColumnDataType <> "Date" And ColumnDataType <> "Char" And ColumnDataType <> "Boolean" Then '& ColumnDataType <> "Object"Then
                        Me.LatitudeColumnNameListBox.Items.Add(Col.ColumnName)
                        Me.LongitudeColumnNameListBox.Items.Add(Col.ColumnName)
                    End If
                Next
            Else
                MsgBox("Data table is not valid or has now rows.", MsgBoxStyle.Information, "Error")
                Me.Close()
            End If
        End If

    End Sub



    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub


    ''' <summary>
    ''' Validates the selections on the form
    ''' </summary>
    Private Sub ValidateForm()
        Try
            'Build an initial validation message
            Me.ValidationTextBox.Text = "Validating..." & vbNewLine

            'Various data validity metrics and counters
            Dim LatitudeNULLValuesCount As Integer = 0
            Dim LatitudeInvalidGCSValuesCount As Integer = 0
            Dim LatitudeNonNumericValuesCount As Integer = 0
            Dim LongitudeNULLValuesCount As Integer = 0
            Dim LongitudeInvalidGCSValuesCount As Integer = 0
            Dim LongitudeNonNumericValuesCount As Integer = 0



            'Ensure we have column names selected
            If Not Me.LatitudeColumnName.Trim = Me.LongitudeColumnName.Trim Then

                If Me.LatitudeColumnName.Trim.Length > 0 And Me.LongitudeColumnName.Trim.Length > 0 Then

                    'Test the column names exist in the data table
                    If Not Me.DataTable.Columns(Me.LatitudeColumnName) Is Nothing And Not Me.DataTable.Columns(Me.LongitudeColumnName) Is Nothing Then


                        'LATITUDE QC CHECKS
                        Dim RowNumber As Integer = 1
                        For Each Row As DataRow In Me.DataTable.Rows

                            'Ensure we have a good row
                            If Not Row Is Nothing Then

                                'Validate the Latitude data
                                'Ensure the Latitude column value is not null
                                If IsDBNull(Row.Item(Me.LatitudeColumnName)) = False Then

                                    'Get a handle on the row's Latitude value
                                    Dim LatitudeValue As Double = Row.Item(Me.LatitudeColumnName)

                                    'Latitude value is blank
                                    If LatitudeValue.ToString.Trim = "" Then
                                        LatitudeNULLValuesCount = LatitudeNULLValuesCount + 1
                                    End If

                                    'Latitude value is numeric
                                    If IsNumeric(LatitudeValue) = False Then
                                        'Latitude is not numeric
                                        LatitudeNonNumericValuesCount = LatitudeNonNumericValuesCount + 1
                                        Me.ValidationTextBox.AppendText("FAIL: Row " & RowNumber & ". " & LatitudeValue & " value is not numeric." & vbNewLine)
                                    End If

                                    'Latitude value fits in a globe
                                    If LatitudeValue < -90 Or LatitudeValue > 90 Then
                                        'Latitude is not GCS
                                        LatitudeInvalidGCSValuesCount = LatitudeInvalidGCSValuesCount + 1
                                        Me.ValidationTextBox.AppendText("FAIL: Row " & RowNumber & ". " & LatitudeValue & " value exceeds maximum/minimum latitude constraints." & vbNewLine)
                                    End If
                                Else
                                    'Value is NULL
                                    LatitudeNULLValuesCount = LatitudeNULLValuesCount + 1
                                    Me.ValidationTextBox.AppendText("WARNING: Row " & RowNumber & ". " & " Latitude value is NULL or blank." & vbNewLine)
                                End If

                            End If

                            'Increment the row counter
                            RowNumber = RowNumber + 1
                        Next



                        'LONGITUDE QC CHECKS
                        RowNumber = 1
                        For Each Row As DataRow In Me.DataTable.Rows

                            'Ensure we have a good row
                            If Not Row Is Nothing Then

                                'Validate the Longitude data
                                'Ensure the Longitude column value is not null
                                If IsDBNull(Row.Item(Me.LongitudeColumnName)) = False Then

                                    'Get a handle on the row's Longitude value
                                    Dim LongitudeValue As Double = Row.Item(Me.LongitudeColumnName)

                                    'Longitude value is blank
                                    If LongitudeValue.ToString.Trim = "" Then
                                        LongitudeNULLValuesCount = LongitudeNULLValuesCount + 1
                                    End If

                                    'Longitude value is numeric
                                    If IsNumeric(LongitudeValue) = False Then
                                        'Longitude is not numeric
                                        LongitudeNonNumericValuesCount = LongitudeNonNumericValuesCount + 1
                                        Me.ValidationTextBox.AppendText("FAIL: Row " & RowNumber & ". " & LongitudeValue & " value is not numeric." & vbNewLine)
                                    End If

                                    'Longitude value fits in a globe
                                    If LongitudeValue < -180 Or LongitudeValue > 180 Then
                                        'Longitude is not GCS
                                        LongitudeInvalidGCSValuesCount = LongitudeInvalidGCSValuesCount + 1
                                        Me.ValidationTextBox.AppendText("FAIL: Row " & RowNumber & ". " & LongitudeValue & " value exceeds maximum/minimum longitude constraints." & vbNewLine)
                                    End If
                                Else
                                    'Value is NULL
                                    LongitudeNULLValuesCount = LongitudeNULLValuesCount + 1
                                    Me.ValidationTextBox.AppendText("WARNING: Row " & RowNumber & ". " & " Longitude value is NULL or blank." & vbNewLine)
                                End If

                            End If

                            'Increment the row counter
                            RowNumber = RowNumber + 1
                        Next


                        'Report QC results
                        Me.ValidationTextBox.AppendText(vbNewLine & "QC Checks: LATITUDE" & vbNewLine & vbTab & "NULLS: " & LatitudeNULLValuesCount & vbNewLine & vbTab & "Non-numeric: " & LatitudeNonNumericValuesCount & vbNewLine & vbTab & " Invalid CRS: " & LatitudeInvalidGCSValuesCount & vbNewLine)
                        Me.ValidationTextBox.AppendText(vbNewLine & "QC Checks: LONGITUDE" & vbNewLine & vbTab & "NULLS: " & LongitudeNULLValuesCount & vbNewLine & vbTab & "Non-numeric: " & LongitudeNonNumericValuesCount & vbNewLine & vbTab & " Invalid CRS: " & LongitudeInvalidGCSValuesCount & vbNewLine)

                        'Disable the ok button because we have garbage data
                        If LatitudeInvalidGCSValuesCount > 0 Or LatitudeNonNumericValuesCount > 0 Or LatitudeNULLValuesCount > 0 Or
                                 LongitudeInvalidGCSValuesCount > 0 Or LongitudeNonNumericValuesCount > 0 Or LongitudeNULLValuesCount > 0 Then
                            Me.ValidationTextBox.AppendText(vbNewLine & "The dataset cannot be loaded. Please fix the data quality issues and re-load the dataset.")
                            Me.OKButton.Enabled = False
                        Else
                            Me.ValidationTextBox.AppendText(vbNewLine & "Click OK to continue")
                            Me.OKButton.Enabled = True
                        End If
                    Else
                        Me.ValidationTextBox.AppendText("Select valid latitude and longitude column names." & vbNewLine)
                    End If

                Else
                    Me.ValidationTextBox.Text = " Select valid lat/lon columns" & vbNewLine
                End If
            Else
                Me.ValidationTextBox.Text = "Latitude column name cannot be the same as the longitude column name."
            End If
        Catch ex As Exception
            Me.ValidationTextBox.Text = "Validation error: " & ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name
        End Try
    End Sub


    Private Sub LongitudeColumnNameListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LongitudeColumnNameListBox.SelectedIndexChanged
        Me.LongitudeColumnName = Me.LongitudeColumnNameListBox.Text
        ValidateForm()
    End Sub

    Private Sub LatitudeColumnNameListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LatitudeColumnNameListBox.SelectedIndexChanged
        Me.LatitudeColumnName = Me.LatitudeColumnNameListBox.Text
        ValidateForm()
    End Sub
End Class