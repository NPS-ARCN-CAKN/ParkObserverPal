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
        Me.InstructionsLabel = New System.Windows.Forms.Label()
        Me.DataSourceLabel = New System.Windows.Forms.Label()
        Me.LatitudeColumnNameListBox = New System.Windows.Forms.ListBox()
        Me.LongitudeColumnNameListBox = New System.Windows.Forms.ListBox()
        Me.LatitudeLabel = New System.Windows.Forms.Label()
        Me.LongitudeLabel = New System.Windows.Forms.Label()
        Me.DataGridLabel = New System.Windows.Forms.Label()
        Me.ValidationTextBox = New System.Windows.Forms.TextBox()
        Me.ValidationTextBoxLabel = New System.Windows.Forms.Label()
        Me.MainPanel = New System.Windows.Forms.Panel()
        CType(Me.CSVDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FooterPanel.SuspendLayout()
        Me.HeaderPanel.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'CSVDataGridView
        '
        Me.CSVDataGridView.AllowUserToAddRows = False
        Me.CSVDataGridView.AllowUserToDeleteRows = False
        Me.CSVDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CSVDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CSVDataGridView.Location = New System.Drawing.Point(321, 33)
        Me.CSVDataGridView.MultiSelect = False
        Me.CSVDataGridView.Name = "CSVDataGridView"
        Me.CSVDataGridView.ReadOnly = True
        Me.CSVDataGridView.Size = New System.Drawing.Size(860, 146)
        Me.CSVDataGridView.TabIndex = 0
        '
        'FooterPanel
        '
        Me.FooterPanel.Controls.Add(Me.ValidationLabel)
        Me.FooterPanel.Controls.Add(Me.OKButton)
        Me.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FooterPanel.Location = New System.Drawing.Point(0, 715)
        Me.FooterPanel.Name = "FooterPanel"
        Me.FooterPanel.Size = New System.Drawing.Size(1184, 46)
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
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(1097, 11)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'HeaderPanel
        '
        Me.HeaderPanel.Controls.Add(Me.InstructionsLabel)
        Me.HeaderPanel.Controls.Add(Me.DataSourceLabel)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(1184, 58)
        Me.HeaderPanel.TabIndex = 3
        '
        'InstructionsLabel
        '
        Me.InstructionsLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.InstructionsLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstructionsLabel.Location = New System.Drawing.Point(0, 27)
        Me.InstructionsLabel.Name = "InstructionsLabel"
        Me.InstructionsLabel.Padding = New System.Windows.Forms.Padding(4)
        Me.InstructionsLabel.Size = New System.Drawing.Size(1184, 31)
        Me.InstructionsLabel.TabIndex = 3
        Me.InstructionsLabel.Text = "To import your CSV file as a spatial layer you must identify the latitude and lon" &
    "gitude columns:"
        '
        'DataSourceLabel
        '
        Me.DataSourceLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataSourceLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataSourceLabel.Location = New System.Drawing.Point(0, 0)
        Me.DataSourceLabel.Name = "DataSourceLabel"
        Me.DataSourceLabel.Padding = New System.Windows.Forms.Padding(4)
        Me.DataSourceLabel.Size = New System.Drawing.Size(1184, 31)
        Me.DataSourceLabel.TabIndex = 2
        Me.DataSourceLabel.Text = "Data source"
        '
        'LatitudeColumnNameListBox
        '
        Me.LatitudeColumnNameListBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LatitudeColumnNameListBox.FormattingEnabled = True
        Me.LatitudeColumnNameListBox.Location = New System.Drawing.Point(15, 33)
        Me.LatitudeColumnNameListBox.Name = "LatitudeColumnNameListBox"
        Me.LatitudeColumnNameListBox.Size = New System.Drawing.Size(150, 615)
        Me.LatitudeColumnNameListBox.TabIndex = 3
        '
        'LongitudeColumnNameListBox
        '
        Me.LongitudeColumnNameListBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LongitudeColumnNameListBox.FormattingEnabled = True
        Me.LongitudeColumnNameListBox.Location = New System.Drawing.Point(168, 33)
        Me.LongitudeColumnNameListBox.Name = "LongitudeColumnNameListBox"
        Me.LongitudeColumnNameListBox.Size = New System.Drawing.Size(150, 615)
        Me.LongitudeColumnNameListBox.TabIndex = 4
        '
        'LatitudeLabel
        '
        Me.LatitudeLabel.AutoSize = True
        Me.LatitudeLabel.Location = New System.Drawing.Point(12, 14)
        Me.LatitudeLabel.Name = "LatitudeLabel"
        Me.LatitudeLabel.Size = New System.Drawing.Size(114, 13)
        Me.LatitudeLabel.TabIndex = 5
        Me.LatitudeLabel.Text = "Select latitude column:"
        '
        'LongitudeLabel
        '
        Me.LongitudeLabel.AutoSize = True
        Me.LongitudeLabel.Location = New System.Drawing.Point(165, 17)
        Me.LongitudeLabel.Name = "LongitudeLabel"
        Me.LongitudeLabel.Size = New System.Drawing.Size(123, 13)
        Me.LongitudeLabel.TabIndex = 6
        Me.LongitudeLabel.Text = "Select longitude column:"
        '
        'DataGridLabel
        '
        Me.DataGridLabel.AutoSize = True
        Me.DataGridLabel.Location = New System.Drawing.Point(321, 14)
        Me.DataGridLabel.Name = "DataGridLabel"
        Me.DataGridLabel.Size = New System.Drawing.Size(68, 13)
        Me.DataGridLabel.TabIndex = 7
        Me.DataGridLabel.Text = "Data source:"
        '
        'ValidationTextBox
        '
        Me.ValidationTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ValidationTextBox.Location = New System.Drawing.Point(321, 199)
        Me.ValidationTextBox.Multiline = True
        Me.ValidationTextBox.Name = "ValidationTextBox"
        Me.ValidationTextBox.ReadOnly = True
        Me.ValidationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ValidationTextBox.Size = New System.Drawing.Size(860, 452)
        Me.ValidationTextBox.TabIndex = 8
        Me.ValidationTextBox.Text = "Select latitude and longitude columns to begin validation."
        '
        'ValidationTextBoxLabel
        '
        Me.ValidationTextBoxLabel.AutoSize = True
        Me.ValidationTextBoxLabel.Location = New System.Drawing.Point(321, 182)
        Me.ValidationTextBoxLabel.Name = "ValidationTextBoxLabel"
        Me.ValidationTextBoxLabel.Size = New System.Drawing.Size(53, 13)
        Me.ValidationTextBoxLabel.TabIndex = 9
        Me.ValidationTextBoxLabel.Text = "Validation"
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.LatitudeLabel)
        Me.MainPanel.Controls.Add(Me.LongitudeLabel)
        Me.MainPanel.Controls.Add(Me.DataGridLabel)
        Me.MainPanel.Controls.Add(Me.LongitudeColumnNameListBox)
        Me.MainPanel.Controls.Add(Me.LatitudeColumnNameListBox)
        Me.MainPanel.Controls.Add(Me.CSVDataGridView)
        Me.MainPanel.Controls.Add(Me.ValidationTextBox)
        Me.MainPanel.Controls.Add(Me.ValidationTextBoxLabel)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(0, 58)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(1184, 657)
        Me.MainPanel.TabIndex = 10
        '
        'ImportCSVForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.HeaderPanel)
        Me.Controls.Add(Me.FooterPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "ImportCSVForm"
        CType(Me.CSVDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FooterPanel.ResumeLayout(False)
        Me.HeaderPanel.ResumeLayout(False)
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CSVDataGridView As DataGridView
    Friend WithEvents FooterPanel As Panel
    Friend WithEvents OKButton As Button
    Friend WithEvents HeaderPanel As Panel
    Friend WithEvents DataSourceLabel As Label
    Friend WithEvents LatitudeColumnNameListBox As ListBox
    Friend WithEvents LongitudeColumnNameListBox As ListBox
    Friend WithEvents LatitudeLabel As Label
    Friend WithEvents LongitudeLabel As Label
    Friend WithEvents DataGridLabel As Label
    Friend WithEvents ValidationLabel As Label
    Friend WithEvents ValidationTextBox As TextBox
    Friend WithEvents ValidationTextBoxLabel As Label
    Friend WithEvents InstructionsLabel As Label
    Friend WithEvents MainPanel As Panel
End Class
