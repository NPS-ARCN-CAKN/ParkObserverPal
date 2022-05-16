<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MetadataForm
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
        Me.MetadataTabControl = New System.Windows.Forms.TabControl()
        Me.MetadataTabPage = New System.Windows.Forms.TabPage()
        Me.MetadataDataGridView = New System.Windows.Forms.DataGridView()
        Me.UniqueValuesTabPage = New System.Windows.Forms.TabPage()
        Me.UniqueValuesDataGridView = New System.Windows.Forms.DataGridView()
        Me.SourceDataTableTabPage = New System.Windows.Forms.TabPage()
        Me.SourceDatasetDataGridView = New System.Windows.Forms.DataGridView()
        Me.MetadataToolStrip = New System.Windows.Forms.ToolStrip()
        Me.MetadataTabControl.SuspendLayout()
        Me.MetadataTabPage.SuspendLayout()
        CType(Me.MetadataDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UniqueValuesTabPage.SuspendLayout()
        CType(Me.UniqueValuesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SourceDataTableTabPage.SuspendLayout()
        CType(Me.SourceDatasetDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetadataTabControl
        '
        Me.MetadataTabControl.Controls.Add(Me.MetadataTabPage)
        Me.MetadataTabControl.Controls.Add(Me.UniqueValuesTabPage)
        Me.MetadataTabControl.Controls.Add(Me.SourceDataTableTabPage)
        Me.MetadataTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetadataTabControl.Location = New System.Drawing.Point(0, 25)
        Me.MetadataTabControl.Name = "MetadataTabControl"
        Me.MetadataTabControl.SelectedIndex = 0
        Me.MetadataTabControl.Size = New System.Drawing.Size(1184, 736)
        Me.MetadataTabControl.TabIndex = 0
        '
        'MetadataTabPage
        '
        Me.MetadataTabPage.Controls.Add(Me.MetadataDataGridView)
        Me.MetadataTabPage.Location = New System.Drawing.Point(4, 22)
        Me.MetadataTabPage.Name = "MetadataTabPage"
        Me.MetadataTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.MetadataTabPage.Size = New System.Drawing.Size(792, 399)
        Me.MetadataTabPage.TabIndex = 0
        Me.MetadataTabPage.Text = "Metadata"
        Me.MetadataTabPage.UseVisualStyleBackColor = True
        '
        'MetadataDataGridView
        '
        Me.MetadataDataGridView.AllowUserToAddRows = False
        Me.MetadataDataGridView.AllowUserToDeleteRows = False
        Me.MetadataDataGridView.AllowUserToOrderColumns = True
        Me.MetadataDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MetadataDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetadataDataGridView.Location = New System.Drawing.Point(3, 3)
        Me.MetadataDataGridView.Name = "MetadataDataGridView"
        Me.MetadataDataGridView.ReadOnly = True
        Me.MetadataDataGridView.Size = New System.Drawing.Size(786, 393)
        Me.MetadataDataGridView.TabIndex = 0
        '
        'UniqueValuesTabPage
        '
        Me.UniqueValuesTabPage.Controls.Add(Me.UniqueValuesDataGridView)
        Me.UniqueValuesTabPage.Location = New System.Drawing.Point(4, 22)
        Me.UniqueValuesTabPage.Name = "UniqueValuesTabPage"
        Me.UniqueValuesTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.UniqueValuesTabPage.Size = New System.Drawing.Size(792, 399)
        Me.UniqueValuesTabPage.TabIndex = 1
        Me.UniqueValuesTabPage.Text = "Column unique values"
        Me.UniqueValuesTabPage.UseVisualStyleBackColor = True
        '
        'UniqueValuesDataGridView
        '
        Me.UniqueValuesDataGridView.AllowUserToAddRows = False
        Me.UniqueValuesDataGridView.AllowUserToDeleteRows = False
        Me.UniqueValuesDataGridView.AllowUserToOrderColumns = True
        Me.UniqueValuesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UniqueValuesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UniqueValuesDataGridView.Location = New System.Drawing.Point(3, 3)
        Me.UniqueValuesDataGridView.Name = "UniqueValuesDataGridView"
        Me.UniqueValuesDataGridView.ReadOnly = True
        Me.UniqueValuesDataGridView.Size = New System.Drawing.Size(786, 393)
        Me.UniqueValuesDataGridView.TabIndex = 0
        '
        'SourceDataTableTabPage
        '
        Me.SourceDataTableTabPage.Controls.Add(Me.SourceDatasetDataGridView)
        Me.SourceDataTableTabPage.Location = New System.Drawing.Point(4, 22)
        Me.SourceDataTableTabPage.Name = "SourceDataTableTabPage"
        Me.SourceDataTableTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SourceDataTableTabPage.Size = New System.Drawing.Size(1176, 710)
        Me.SourceDataTableTabPage.TabIndex = 2
        Me.SourceDataTableTabPage.Text = "Source dataset"
        Me.SourceDataTableTabPage.UseVisualStyleBackColor = True
        '
        'SourceDatasetDataGridView
        '
        Me.SourceDatasetDataGridView.AllowUserToAddRows = False
        Me.SourceDatasetDataGridView.AllowUserToDeleteRows = False
        Me.SourceDatasetDataGridView.AllowUserToOrderColumns = True
        Me.SourceDatasetDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SourceDatasetDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SourceDatasetDataGridView.Location = New System.Drawing.Point(3, 3)
        Me.SourceDatasetDataGridView.Name = "SourceDatasetDataGridView"
        Me.SourceDatasetDataGridView.ReadOnly = True
        Me.SourceDatasetDataGridView.Size = New System.Drawing.Size(1170, 704)
        Me.SourceDatasetDataGridView.TabIndex = 0
        '
        'MetadataToolStrip
        '
        Me.MetadataToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MetadataToolStrip.Name = "MetadataToolStrip"
        Me.MetadataToolStrip.Size = New System.Drawing.Size(1184, 25)
        Me.MetadataToolStrip.TabIndex = 1
        Me.MetadataToolStrip.Text = "ToolStrip1"
        '
        'MetadataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.MetadataTabControl)
        Me.Controls.Add(Me.MetadataToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "MetadataForm"
        Me.Text = "Metadata"
        Me.MetadataTabControl.ResumeLayout(False)
        Me.MetadataTabPage.ResumeLayout(False)
        CType(Me.MetadataDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UniqueValuesTabPage.ResumeLayout(False)
        CType(Me.UniqueValuesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SourceDataTableTabPage.ResumeLayout(False)
        CType(Me.SourceDatasetDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetadataTabControl As TabControl
    Friend WithEvents MetadataTabPage As TabPage
    Friend WithEvents UniqueValuesTabPage As TabPage
    Friend WithEvents MetadataToolStrip As ToolStrip
    Friend WithEvents MetadataDataGridView As DataGridView
    Friend WithEvents UniqueValuesDataGridView As DataGridView
    Friend WithEvents SourceDataTableTabPage As TabPage
    Friend WithEvents SourceDatasetDataGridView As DataGridView
End Class
