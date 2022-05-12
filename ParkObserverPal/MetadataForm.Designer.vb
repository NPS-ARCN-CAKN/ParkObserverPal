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
        Me.UniqueValuesTabPage = New System.Windows.Forms.TabPage()
        Me.MetadataGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.MetadataToolStrip = New System.Windows.Forms.ToolStrip()
        Me.MetadataTabControl.SuspendLayout()
        Me.MetadataTabPage.SuspendLayout()
        CType(Me.MetadataGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetadataTabControl
        '
        Me.MetadataTabControl.Controls.Add(Me.MetadataTabPage)
        Me.MetadataTabControl.Controls.Add(Me.UniqueValuesTabPage)
        Me.MetadataTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetadataTabControl.Location = New System.Drawing.Point(0, 25)
        Me.MetadataTabControl.Name = "MetadataTabControl"
        Me.MetadataTabControl.SelectedIndex = 0
        Me.MetadataTabControl.Size = New System.Drawing.Size(800, 425)
        Me.MetadataTabControl.TabIndex = 0
        '
        'MetadataTabPage
        '
        Me.MetadataTabPage.Controls.Add(Me.MetadataGridControl)
        Me.MetadataTabPage.Location = New System.Drawing.Point(4, 22)
        Me.MetadataTabPage.Name = "MetadataTabPage"
        Me.MetadataTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.MetadataTabPage.Size = New System.Drawing.Size(792, 399)
        Me.MetadataTabPage.TabIndex = 0
        Me.MetadataTabPage.Text = "Metadata"
        Me.MetadataTabPage.UseVisualStyleBackColor = True
        '
        'UniqueValuesTabPage
        '
        Me.UniqueValuesTabPage.Location = New System.Drawing.Point(4, 22)
        Me.UniqueValuesTabPage.Name = "UniqueValuesTabPage"
        Me.UniqueValuesTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.UniqueValuesTabPage.Size = New System.Drawing.Size(792, 424)
        Me.UniqueValuesTabPage.TabIndex = 1
        Me.UniqueValuesTabPage.Text = "Column unique values"
        Me.UniqueValuesTabPage.UseVisualStyleBackColor = True
        '
        'MetadataGridControl
        '
        Me.MetadataGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetadataGridControl.Location = New System.Drawing.Point(3, 3)
        Me.MetadataGridControl.MainView = Me.GridView1
        Me.MetadataGridControl.Name = "MetadataGridControl"
        Me.MetadataGridControl.Size = New System.Drawing.Size(786, 393)
        Me.MetadataGridControl.TabIndex = 0
        Me.MetadataGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.MetadataGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        '
        'MetadataToolStrip
        '
        Me.MetadataToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MetadataToolStrip.Name = "MetadataToolStrip"
        Me.MetadataToolStrip.Size = New System.Drawing.Size(800, 25)
        Me.MetadataToolStrip.TabIndex = 1
        Me.MetadataToolStrip.Text = "ToolStrip1"
        '
        'MetadataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MetadataTabControl)
        Me.Controls.Add(Me.MetadataToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "MetadataForm"
        Me.Text = "Metadata"
        Me.MetadataTabControl.ResumeLayout(False)
        Me.MetadataTabPage.ResumeLayout(False)
        CType(Me.MetadataGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetadataTabControl As TabControl
    Friend WithEvents MetadataTabPage As TabPage
    Friend WithEvents UniqueValuesTabPage As TabPage
    Friend WithEvents MetadataGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MetadataToolStrip As ToolStrip
End Class
