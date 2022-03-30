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
        Me.MapLayersSplitContainerControl = New DevExpress.XtraEditors.SplitContainerControl()
        Me.MapLayersCheckedListBoxControl = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.LayerLabelCheckedListBoxControl = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.MapControl = New DevExpress.XtraMap.MapControl()
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.OpenPOZFileToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MapLayerTabControl = New System.Windows.Forms.TabControl()
        Me.MapLayerLabelingTabPage = New System.Windows.Forms.TabPage()
        Me.MapLayerPropertiesTabPage = New System.Windows.Forms.TabPage()
        Me.MapLayerPropertyGridControl = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        Me.MapPanelSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.MapLayerGridControl = New DevExpress.XtraGrid.GridControl()
        Me.MapControlPropertyGridControl = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        Me.MapPropertiesTabPage = New System.Windows.Forms.TabPage()
        Me.MapToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ZoomToFitAllLayersToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MainTabControl.SuspendLayout()
        Me.MapTabPage.SuspendLayout()
        CType(Me.MapSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapSplitContainer.Panel1.SuspendLayout()
        Me.MapSplitContainer.Panel2.SuspendLayout()
        Me.MapSplitContainer.SuspendLayout()
        CType(Me.MapLayersSplitContainerControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapLayersSplitContainerControl.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapLayersSplitContainerControl.Panel1.SuspendLayout()
        CType(Me.MapLayersSplitContainerControl.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapLayersSplitContainerControl.Panel2.SuspendLayout()
        Me.MapLayersSplitContainerControl.SuspendLayout()
        CType(Me.MapLayersCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayerLabelCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainToolStrip.SuspendLayout()
        Me.MapLayerTabControl.SuspendLayout()
        Me.MapLayerLabelingTabPage.SuspendLayout()
        Me.MapLayerPropertiesTabPage.SuspendLayout()
        CType(Me.MapLayerPropertyGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapPanelSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapPanelSplitContainer.Panel1.SuspendLayout()
        Me.MapPanelSplitContainer.Panel2.SuspendLayout()
        Me.MapPanelSplitContainer.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapLayerGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapControlPropertyGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapPropertiesTabPage.SuspendLayout()
        Me.MapToolStrip.SuspendLayout()
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
        Me.MapSplitContainer.Panel2.Controls.Add(Me.MapPanelSplitContainer)
        Me.MapSplitContainer.Size = New System.Drawing.Size(1161, 665)
        Me.MapSplitContainer.SplitterDistance = 242
        Me.MapSplitContainer.TabIndex = 1
        '
        'MapLayersSplitContainerControl
        '
        Me.MapLayersSplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayersSplitContainerControl.Horizontal = False
        Me.MapLayersSplitContainerControl.Location = New System.Drawing.Point(0, 0)
        Me.MapLayersSplitContainerControl.Name = "MapLayersSplitContainerControl"
        '
        'MapLayersSplitContainerControl.Panel1
        '
        Me.MapLayersSplitContainerControl.Panel1.Controls.Add(Me.MapLayersCheckedListBoxControl)
        Me.MapLayersSplitContainerControl.Panel1.Text = "Panel1"
        '
        'MapLayersSplitContainerControl.Panel2
        '
        Me.MapLayersSplitContainerControl.Panel2.Controls.Add(Me.MapLayerTabControl)
        Me.MapLayersSplitContainerControl.Panel2.Text = "Panel2"
        Me.MapLayersSplitContainerControl.Size = New System.Drawing.Size(242, 665)
        Me.MapLayersSplitContainerControl.SplitterPosition = 188
        Me.MapLayersSplitContainerControl.TabIndex = 4
        '
        'MapLayersCheckedListBoxControl
        '
        Me.MapLayersCheckedListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayersCheckedListBoxControl.Location = New System.Drawing.Point(0, 0)
        Me.MapLayersCheckedListBoxControl.Name = "MapLayersCheckedListBoxControl"
        Me.MapLayersCheckedListBoxControl.Size = New System.Drawing.Size(242, 188)
        Me.MapLayersCheckedListBoxControl.TabIndex = 3
        '
        'LayerLabelCheckedListBoxControl
        '
        Me.LayerLabelCheckedListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayerLabelCheckedListBoxControl.Location = New System.Drawing.Point(3, 3)
        Me.LayerLabelCheckedListBoxControl.Name = "LayerLabelCheckedListBoxControl"
        Me.LayerLabelCheckedListBoxControl.Size = New System.Drawing.Size(228, 435)
        Me.LayerLabelCheckedListBoxControl.TabIndex = 4
        '
        'MapControl
        '
        Me.MapControl.BackColor = System.Drawing.Color.LightSteelBlue
        Me.MapControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapControl.Location = New System.Drawing.Point(0, 0)
        Me.MapControl.Name = "MapControl"
        Me.MapControl.Size = New System.Drawing.Size(915, 444)
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
        'MapLayerTabControl
        '
        Me.MapLayerTabControl.Controls.Add(Me.MapLayerLabelingTabPage)
        Me.MapLayerTabControl.Controls.Add(Me.MapLayerPropertiesTabPage)
        Me.MapLayerTabControl.Controls.Add(Me.MapPropertiesTabPage)
        Me.MapLayerTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayerTabControl.Location = New System.Drawing.Point(0, 0)
        Me.MapLayerTabControl.Name = "MapLayerTabControl"
        Me.MapLayerTabControl.SelectedIndex = 0
        Me.MapLayerTabControl.Size = New System.Drawing.Size(242, 467)
        Me.MapLayerTabControl.TabIndex = 5
        '
        'MapLayerLabelingTabPage
        '
        Me.MapLayerLabelingTabPage.Controls.Add(Me.LayerLabelCheckedListBoxControl)
        Me.MapLayerLabelingTabPage.Location = New System.Drawing.Point(4, 22)
        Me.MapLayerLabelingTabPage.Name = "MapLayerLabelingTabPage"
        Me.MapLayerLabelingTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.MapLayerLabelingTabPage.Size = New System.Drawing.Size(234, 441)
        Me.MapLayerLabelingTabPage.TabIndex = 0
        Me.MapLayerLabelingTabPage.Text = "Choose map labels"
        Me.MapLayerLabelingTabPage.UseVisualStyleBackColor = True
        '
        'MapLayerPropertiesTabPage
        '
        Me.MapLayerPropertiesTabPage.Controls.Add(Me.MapLayerPropertyGridControl)
        Me.MapLayerPropertiesTabPage.Location = New System.Drawing.Point(4, 22)
        Me.MapLayerPropertiesTabPage.Name = "MapLayerPropertiesTabPage"
        Me.MapLayerPropertiesTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.MapLayerPropertiesTabPage.Size = New System.Drawing.Size(234, 441)
        Me.MapLayerPropertiesTabPage.TabIndex = 1
        Me.MapLayerPropertiesTabPage.Text = "Layer properties"
        Me.MapLayerPropertiesTabPage.UseVisualStyleBackColor = True
        '
        'MapLayerPropertyGridControl
        '
        Me.MapLayerPropertyGridControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MapLayerPropertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayerPropertyGridControl.Location = New System.Drawing.Point(3, 3)
        Me.MapLayerPropertyGridControl.Name = "MapLayerPropertyGridControl"
        Me.MapLayerPropertyGridControl.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.[True]
        Me.MapLayerPropertyGridControl.Size = New System.Drawing.Size(228, 435)
        Me.MapLayerPropertyGridControl.TabIndex = 0
        '
        'MapPanelSplitContainer
        '
        Me.MapPanelSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapPanelSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.MapPanelSplitContainer.Name = "MapPanelSplitContainer"
        Me.MapPanelSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'MapPanelSplitContainer.Panel1
        '
        Me.MapPanelSplitContainer.Panel1.Controls.Add(Me.MapToolStrip)
        Me.MapPanelSplitContainer.Panel1.Controls.Add(Me.MapControl)
        '
        'MapPanelSplitContainer.Panel2
        '
        Me.MapPanelSplitContainer.Panel2.Controls.Add(Me.MapLayerGridControl)
        Me.MapPanelSplitContainer.Size = New System.Drawing.Size(915, 665)
        Me.MapPanelSplitContainer.SplitterDistance = 444
        Me.MapPanelSplitContainer.TabIndex = 1
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.MapLayerGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'MapLayerGridControl
        '
        Me.MapLayerGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayerGridControl.Location = New System.Drawing.Point(0, 0)
        Me.MapLayerGridControl.MainView = Me.GridView1
        Me.MapLayerGridControl.Name = "MapLayerGridControl"
        Me.MapLayerGridControl.Size = New System.Drawing.Size(915, 217)
        Me.MapLayerGridControl.TabIndex = 0
        Me.MapLayerGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'MapControlPropertyGridControl
        '
        Me.MapControlPropertyGridControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MapControlPropertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapControlPropertyGridControl.Location = New System.Drawing.Point(3, 3)
        Me.MapControlPropertyGridControl.Name = "MapControlPropertyGridControl"
        Me.MapControlPropertyGridControl.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.[True]
        Me.MapControlPropertyGridControl.Size = New System.Drawing.Size(228, 435)
        Me.MapControlPropertyGridControl.TabIndex = 1
        '
        'MapPropertiesTabPage
        '
        Me.MapPropertiesTabPage.Controls.Add(Me.MapControlPropertyGridControl)
        Me.MapPropertiesTabPage.Location = New System.Drawing.Point(4, 22)
        Me.MapPropertiesTabPage.Name = "MapPropertiesTabPage"
        Me.MapPropertiesTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.MapPropertiesTabPage.Size = New System.Drawing.Size(234, 441)
        Me.MapPropertiesTabPage.TabIndex = 2
        Me.MapPropertiesTabPage.Text = "Map properties"
        Me.MapPropertiesTabPage.UseVisualStyleBackColor = True
        '
        'MapToolStrip
        '
        Me.MapToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZoomToFitAllLayersToolStripButton})
        Me.MapToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MapToolStrip.Name = "MapToolStrip"
        Me.MapToolStrip.Size = New System.Drawing.Size(915, 25)
        Me.MapToolStrip.TabIndex = 1
        Me.MapToolStrip.Text = "ToolStrip1"
        '
        'ZoomToFitAllLayersToolStripButton
        '
        Me.ZoomToFitAllLayersToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ZoomToFitAllLayersToolStripButton.Image = CType(resources.GetObject("ZoomToFitAllLayersToolStripButton.Image"), System.Drawing.Image)
        Me.ZoomToFitAllLayersToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ZoomToFitAllLayersToolStripButton.Name = "ZoomToFitAllLayersToolStripButton"
        Me.ZoomToFitAllLayersToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ZoomToFitAllLayersToolStripButton.Text = "Zoom to fit all layers"
        Me.ZoomToFitAllLayersToolStripButton.ToolTipText = "Zoom to fit all layers"
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
        CType(Me.MapLayersSplitContainerControl.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayersSplitContainerControl.Panel1.ResumeLayout(False)
        CType(Me.MapLayersSplitContainerControl.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayersSplitContainerControl.Panel2.ResumeLayout(False)
        CType(Me.MapLayersSplitContainerControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayersSplitContainerControl.ResumeLayout(False)
        CType(Me.MapLayersCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayerLabelCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MapControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.MapLayerTabControl.ResumeLayout(False)
        Me.MapLayerLabelingTabPage.ResumeLayout(False)
        Me.MapLayerPropertiesTabPage.ResumeLayout(False)
        CType(Me.MapLayerPropertyGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapPanelSplitContainer.Panel1.ResumeLayout(False)
        Me.MapPanelSplitContainer.Panel1.PerformLayout()
        Me.MapPanelSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MapPanelSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapPanelSplitContainer.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MapLayerGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MapControlPropertyGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapPropertiesTabPage.ResumeLayout(False)
        Me.MapToolStrip.ResumeLayout(False)
        Me.MapToolStrip.PerformLayout()
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
    Friend WithEvents MapLayerTabControl As TabControl
    Friend WithEvents MapLayerLabelingTabPage As TabPage
    Friend WithEvents MapLayerPropertiesTabPage As TabPage
    Friend WithEvents MapLayerPropertyGridControl As DevExpress.XtraVerticalGrid.PropertyGridControl
    Friend WithEvents MapPanelSplitContainer As SplitContainer
    Friend WithEvents MapLayerGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MapControlPropertyGridControl As DevExpress.XtraVerticalGrid.PropertyGridControl
    Friend WithEvents MapPropertiesTabPage As TabPage
    Friend WithEvents MapToolStrip As ToolStrip
    Friend WithEvents ZoomToFitAllLayersToolStripButton As ToolStripButton
End Class
