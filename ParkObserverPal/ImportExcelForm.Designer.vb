<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportExcelForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.WorksheetsCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.LoadDatasetsButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'WorksheetsCheckedListBox
        '
        Me.WorksheetsCheckedListBox.FormattingEnabled = True
        Me.WorksheetsCheckedListBox.Location = New System.Drawing.Point(12, 54)
        Me.WorksheetsCheckedListBox.Name = "WorksheetsCheckedListBox"
        Me.WorksheetsCheckedListBox.Size = New System.Drawing.Size(170, 379)
        Me.WorksheetsCheckedListBox.TabIndex = 1
        '
        'LoadDatasetsButton
        '
        Me.LoadDatasetsButton.Location = New System.Drawing.Point(605, 420)
        Me.LoadDatasetsButton.Name = "LoadDatasetsButton"
        Me.LoadDatasetsButton.Size = New System.Drawing.Size(159, 23)
        Me.LoadDatasetsButton.TabIndex = 2
        Me.LoadDatasetsButton.Text = "Load worksheets into map"
        Me.LoadDatasetsButton.UseVisualStyleBackColor = True
        '
        'ImportExcelForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LoadDatasetsButton)
        Me.Controls.Add(Me.WorksheetsCheckedListBox)
        Me.Name = "ImportExcelForm"
        Me.Text = "ImportExcelForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WorksheetsCheckedListBox As CheckedListBox
    Friend WithEvents LoadDatasetsButton As Button
End Class
