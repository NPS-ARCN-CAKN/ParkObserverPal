<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.MapTabPage = New System.Windows.Forms.TabPage()
        Me.MapSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.MapLayersCheckedListBoxControl = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.MapControl = New DevExpress.XtraMap.MapControl()
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.OpenPOZFileToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MapLayersSplitContainerControl = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LayerLabelCheckedListBoxControl = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.MainTabControl.SuspendLayout()
        Me.MapTabPage.SuspendLayout()
        CType(Me.MapSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapSplitContainer.Panel1.SuspendLayout()
        Me.MapSplitContainer.Panel2.SuspendLayout()
        Me.MapSplitContainer.SuspendLayout()
        CType(Me.MapLayersCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainToolStrip.SuspendLayout()
        CType(Me.MapLayersSplitContainerControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapLayersSplitContainerControl.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapLayersSplitContainerControl.Panel1.SuspendLayout()
        CType(Me.MapLayersSplitContainerControl.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapLayersSplitContainerControl.Panel2.SuspendLayout()
        Me.MapLayersSplitContainerControl.SuspendLayout()
        CType(Me.LayerLabelCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.MapTabPage)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.Location = New System.Drawing.Point(0, 25)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(1169, 691)
        Me.MainTabControl.TabIndex = 0
        '
        'MapTabPage
        '
        Me.MapTabPage.Controls.Add(Me.MapSplitContainer)
        Me.MapTabPage.Location = New System.Drawing.Point(4, 22)
        Me.MapTabPage.Name = "MapTabPage"
        Me.MapTabPage.Size = New System.Drawing.Size(1161, 665)
        Me.MapTabPage.TabIndex = 0
        Me.MapTabPage.Text = "Map"
        Me.MapTabPage.UseVisualStyleBackColor = True
        '
        'MapSplitContainer
        '
        Me.MapSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.MapSplitContainer.Name = "MapSplitContainer"
        '
        'MapSplitContainer.Panel1
        '
        Me.MapSplitContainer.Panel1.Controls.Add(Me.MapLayersSplitContainerControl)
        '
        'MapSplitContainer.Panel2
        '
        Me.MapSplitContainer.Panel2.Controls.Add(Me.MapControl)
        Me.MapSplitContainer.Size = New System.Drawing.Size(1161, 665)
        Me.MapSplitContainer.SplitterDistance = 242
        Me.MapSplitContainer.TabIndex = 1
        '
        'MapLayersCheckedListBoxControl
        '
        Me.MapLayersCheckedListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayersCheckedListBoxControl.Location = New System.Drawing.Point(0, 0)
        Me.MapLayersCheckedListBoxControl.Name = "MapLayersCheckedListBoxControl"
        Me.MapLayersCheckedListBoxControl.Size = New System.Drawing.Size(242, 188)
        Me.MapLayersCheckedListBoxControl.TabIndex = 3
        '
        'MapControl
        '
        Me.MapControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapControl.Location = New System.Drawing.Point(0, 0)
        Me.MapControl.Name = "MapControl"
        Me.MapControl.Size = New System.Drawing.Size(915, 665)
        Me.MapControl.TabIndex = 0
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenPOZFileToolStripButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(1169, 25)
        Me.MainToolStrip.TabIndex = 2
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'OpenPOZFileToolStripButton
        '
        Me.OpenPOZFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.OpenPOZFileToolStripButton.Image = CType(resources.GetObject("OpenPOZFileToolStripButton.Image"), System.Drawing.Image)
        Me.OpenPOZFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenPOZFileToolStripButton.Name = "OpenPOZFileToolStripButton"
        Me.OpenPOZFileToolStripButton.Size = New System.Drawing.Size(144, 22)
        Me.OpenPOZFileToolStripButton.Text = "Open Park Observer file..."
        '
        'MapLayersSplitContainerControl
        '
        Me.MapLayersSplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayersSplitContainerControl.Horizontal = False
        Me.MapLayersSplitContainerControl.Location = New System.Drawing.Point(0, 0)
        Me.MapLayersSplitContainerControl.Name = "MapLayersSplitContainerControl"
        '
        'MapLayersSplitContainerControl.MapLayersSplitContainerControl_Panel1
        '
        Me.MapLayersSplitContainerControl.Panel1.Controls.Add(Me.MapLayersCheckedListBoxControl)
        Me.MapLayersSplitContainerControl.Panel1.Text = "Panel1"
        '
        'MapLayersSplitContainerControl.MapLayersSplitContainerControl_Panel2
        '
        Me.MapLayersSplitContainerControl.Panel2.Controls.Add(Me.LayerLabelCheckedListBoxControl)
        Me.MapLayersSplitContainerControl.Panel2.Text = "Panel2"
        Me.MapLayersSplitContainerControl.Size = New System.Drawing.Size(242, 665)
        Me.MapLayersSplitContainerControl.SplitterPosition = 188
        Me.MapLayersSplitContainerControl.TabIndex = 4
        '
        'LayerLabelCheckedListBoxControl
        '
        Me.LayerLabelCheckedListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayerLabelCheckedListBoxControl.Location = New System.Drawing.Point(0, 0)
        Me.LayerLabelCheckedListBoxControl.Name = "LayerLabelCheckedListBoxControl"
        Me.LayerLabelCheckedListBoxControl.Size = New System.Drawing.Size(242, 467)
        Me.LayerLabelCheckedListBoxControl.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 716)
        Me.Controls.Add(Me.MainTabControl)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Name = "Form1"
        Me.Text = "Park Observer Pal"
        Me.MainTabControl.ResumeLayout(False)
        Me.MapTabPage.ResumeLayout(False)
        Me.MapSplitContainer.Panel1.ResumeLayout(False)
        Me.MapSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MapSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapSplitContainer.ResumeLayout(False)
        CType(Me.MapLayersCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MapControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        CType(Me.MapLayersSplitContainerControl.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayersSplitContainerControl.Panel1.ResumeLayout(False)
        CType(Me.MapLayersSplitContainerControl.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayersSplitContainerControl.Panel2.ResumeLayout(False)
        CType(Me.MapLayersSplitContainerControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayersSplitContainerControl.ResumeLayout(False)
        CType(Me.LayerLabelCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainTabControl As TabControl
    Friend WithEvents MapTabPage As TabPage
    Friend WithEvents MapControl As DevExpress.XtraMap.MapControl
    Friend WithEvents MapSplitContainer As SplitContainer
    Friend WithEvents MainToolStrip As ToolStrip
    Friend WithEvents OpenPOZFileToolStripButton As ToolStripButton
    Friend WithEvents MapLayersCheckedListBoxControl As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents MapLayersSplitContainerControl As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LayerLabelCheckedListBoxControl As DevExpress.XtraEditors.CheckedListBoxControl
End Class
