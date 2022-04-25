<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportCSVForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CSVDataGridView = New System.Windows.Forms.DataGridView()
        Me.FooterPanel = New System.Windows.Forms.Panel()
        Me.ValidationLabel = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LatitudeColumnNameListBox = New System.Windows.Forms.ListBox()
        Me.LongitudeColumnNameListBox = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ValidationTextBox = New System.Windows.Forms.TextBox()
        Me.ValidationTextBoxLabel = New System.Windows.Forms.Label()
        CType(Me.CSVDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FooterPanel.SuspendLayout()
        Me.HeaderPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'CSVDataGridView
        '
        Me.CSVDataGridView.AllowUserToAddRows = False
        Me.CSVDataGridView.AllowUserToDeleteRows = False
        Me.CSVDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CSVDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CSVDataGridView.Enabled = False
        Me.CSVDataGridView.Location = New System.Drawing.Point(324, 46)
        Me.CSVDataGridView.MultiSelect = False
        Me.CSVDataGridView.Name = "CSVDataGridView"
        Me.CSVDataGridView.ReadOnly = True
        Me.CSVDataGridView.Size = New System.Drawing.Size(476, 167)
        Me.CSVDataGridView.TabIndex = 0
        '
        'FooterPanel
        '
        Me.FooterPanel.Controls.Add(Me.ValidationLabel)
        Me.FooterPanel.Controls.Add(Me.OKButton)
        Me.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FooterPanel.Location = New System.Drawing.Point(0, 361)
        Me.FooterPanel.Name = "FooterPanel"
        Me.FooterPanel.Size = New System.Drawing.Size(800, 46)
        Me.FooterPanel.TabIndex = 2
        '
        'ValidationLabel
        '
        Me.ValidationLabel.AutoEllipsis = True
        Me.ValidationLabel.Location = New System.Drawing.Point(3, 11)
        Me.ValidationLabel.Name = "ValidationLabel"
        Me.ValidationLabel.Size = New System.Drawing.Size(704, 23)
        Me.ValidationLabel.TabIndex = 1
        Me.ValidationLabel.Text = "Select valid latitude and longitude columns."
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(713, 11)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'HeaderPanel
        '
        Me.HeaderPanel.Controls.Add(Me.Label1)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(800, 31)
        Me.HeaderPanel.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(4)
        Me.Label1.Size = New System.Drawing.Size(800, 31)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "To import your CSV file as a spatial layer you must identify the latitude and lon" &
    "gitude columns:"
        '
        'LatitudeColumnNameListBox
        '
        Me.LatitudeColumnNameListBox.FormattingEnabled = True
        Me.LatitudeColumnNameListBox.Location = New System.Drawing.Point(12, 46)
        Me.LatitudeColumnNameListBox.Name = "LatitudeColumnNameListBox"
        Me.LatitudeColumnNameListBox.Size = New System.Drawing.Size(150, 303)
        Me.LatitudeColumnNameListBox.TabIndex = 3
        '
        'LongitudeColumnNameListBox
        '
        Me.LongitudeColumnNameListBox.FormattingEnabled = True
        Me.LongitudeColumnNameListBox.Location = New System.Drawing.Point(168, 46)
        Me.LongitudeColumnNameListBox.Name = "LongitudeColumnNameListBox"
        Me.LongitudeColumnNameListBox.Size = New System.Drawing.Size(150, 303)
        Me.LongitudeColumnNameListBox.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Latitude column:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(165, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Longitude column:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(321, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Data source:"
        '
        'ValidationTextBox
        '
        Me.ValidationTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ValidationTextBox.Location = New System.Drawing.Point(324, 237)
        Me.ValidationTextBox.Multiline = True
        Me.ValidationTextBox.Name = "ValidationTextBox"
        Me.ValidationTextBox.ReadOnly = True
        Me.ValidationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ValidationTextBox.Size = New System.Drawing.Size(476, 112)
        Me.ValidationTextBox.TabIndex = 8
        Me.ValidationTextBox.Text = "Select latitude and longitude columns to begin validation."
        '
        'ValidationTextBoxLabel
        '
        Me.ValidationTextBoxLabel.AutoSize = True
        Me.ValidationTextBoxLabel.Location = New System.Drawing.Point(321, 221)
        Me.ValidationTextBoxLabel.Name = "ValidationTextBoxLabel"
        Me.ValidationTextBoxLabel.Size = New System.Drawing.Size(53, 13)
        Me.ValidationTextBoxLabel.TabIndex = 9
        Me.ValidationTextBoxLabel.Text = "Validation"
        '
        'ImportCSVForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 407)
        Me.Controls.Add(Me.ValidationTextBoxLabel)
        Me.Controls.Add(Me.ValidationTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LongitudeColumnNameListBox)
        Me.Controls.Add(Me.LatitudeColumnNameListBox)
        Me.Controls.Add(Me.CSVDataGridView)
        Me.Controls.Add(Me.HeaderPanel)
        Me.Controls.Add(Me.FooterPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "ImportCSVForm"
        Me.Text = "Import comma separated values data file"
        CType(Me.CSVDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FooterPanel.ResumeLayout(False)
        Me.HeaderPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CSVDataGridView As DataGridView
    Friend WithEvents FooterPanel As Panel
    Friend WithEvents OKButton As Button
    Friend WithEvents HeaderPanel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LatitudeColumnNameListBox As ListBox
    Friend WithEvents LongitudeColumnNameListBox As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ValidationLabel As Label
    Friend WithEvents ValidationTextBox As TextBox
    Friend WithEvents ValidationTextBoxLabel As Label
End Class
