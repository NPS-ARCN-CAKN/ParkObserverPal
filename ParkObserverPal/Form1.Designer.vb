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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.MapTabPage = New System.Windows.Forms.TabPage()
        Me.MapSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.MapLayersSplitContainerControl = New DevExpress.XtraEditors.SplitContainerControl()
        Me.MapLayersCheckedListBoxControl = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.MapLayerContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToKMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToShapefileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MapLayersToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PromoteLayerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DemoteLayerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MapLayerTabControl = New System.Windows.Forms.TabControl()
        Me.MapLayerLabelingTabPage = New System.Windows.Forms.TabPage()
        Me.LayerLabelCheckedListBoxControl = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.MapLayerPropertiesTabPage = New System.Windows.Forms.TabPage()
        Me.MapLayerPropertyGridControl = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        Me.MapPropertiesTabPage = New System.Windows.Forms.TabPage()
        Me.MapControlPropertyGridControl = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        Me.MapPanelSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.MapControl = New DevExpress.XtraMap.MapControl()
        Me.MapToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ZoomToFitAllLayersToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddLayerToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MapLayerGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.OpenPOZFileToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.POZFileToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.LayerPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.MapLayerContextMenuStrip.SuspendLayout()
        Me.MapLayersToolStrip.SuspendLayout()
        Me.MapLayerTabControl.SuspendLayout()
        Me.MapLayerLabelingTabPage.SuspendLayout()
        CType(Me.LayerLabelCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapLayerPropertiesTabPage.SuspendLayout()
        CType(Me.MapLayerPropertyGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapPropertiesTabPage.SuspendLayout()
        CType(Me.MapControlPropertyGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapPanelSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapPanelSplitContainer.Panel1.SuspendLayout()
        Me.MapPanelSplitContainer.Panel2.SuspendLayout()
        Me.MapPanelSplitContainer.SuspendLayout()
        CType(Me.MapControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapToolStrip.SuspendLayout()
        CType(Me.MapLayerGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainToolStrip.SuspendLayout()
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
        Me.MapLayersSplitContainerControl.Panel1.Controls.Add(Me.MapLayersToolStrip)
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
        Me.MapLayersCheckedListBoxControl.ContextMenuStrip = Me.MapLayerContextMenuStrip
        Me.MapLayersCheckedListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayersCheckedListBoxControl.Location = New System.Drawing.Point(0, 25)
        Me.MapLayersCheckedListBoxControl.Name = "MapLayersCheckedListBoxControl"
        Me.MapLayersCheckedListBoxControl.Size = New System.Drawing.Size(242, 163)
        Me.MapLayersCheckedListBoxControl.TabIndex = 3
        '
        'MapLayerContextMenuStrip
        '
        Me.MapLayerContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToKMLToolStripMenuItem, Me.ExportToShapefileToolStripMenuItem, Me.LayerPropertiesToolStripMenuItem})
        Me.MapLayerContextMenuStrip.Name = "MapLayerContextMenuStrip"
        Me.MapLayerContextMenuStrip.Size = New System.Drawing.Size(182, 92)
        '
        'ExportToKMLToolStripMenuItem
        '
        Me.ExportToKMLToolStripMenuItem.Name = "ExportToKMLToolStripMenuItem"
        Me.ExportToKMLToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ExportToKMLToolStripMenuItem.Text = "Export to KML..."
        '
        'ExportToShapefileToolStripMenuItem
        '
        Me.ExportToShapefileToolStripMenuItem.Name = "ExportToShapefileToolStripMenuItem"
        Me.ExportToShapefileToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ExportToShapefileToolStripMenuItem.Text = "Export to shapefile..."
        '
        'MapLayersToolStrip
        '
        Me.MapLayersToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.PromoteLayerToolStripButton, Me.DemoteLayerToolStripButton})
        Me.MapLayersToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MapLayersToolStrip.Name = "MapLayersToolStrip"
        Me.MapLayersToolStrip.Size = New System.Drawing.Size(242, 25)
        Me.MapLayersToolStrip.TabIndex = 4
        Me.MapLayersToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripLabel1.Text = "Map layers"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'PromoteLayerToolStripButton
        '
        Me.PromoteLayerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PromoteLayerToolStripButton.Image = CType(resources.GetObject("PromoteLayerToolStripButton.Image"), System.Drawing.Image)
        Me.PromoteLayerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PromoteLayerToolStripButton.Name = "PromoteLayerToolStripButton"
        Me.PromoteLayerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PromoteLayerToolStripButton.Text = "Promote layer"
        '
        'DemoteLayerToolStripButton
        '
        Me.DemoteLayerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DemoteLayerToolStripButton.Image = CType(resources.GetObject("DemoteLayerToolStripButton.Image"), System.Drawing.Image)
        Me.DemoteLayerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DemoteLayerToolStripButton.Name = "DemoteLayerToolStripButton"
        Me.DemoteLayerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.DemoteLayerToolStripButton.Text = "Demote layer"
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
        'LayerLabelCheckedListBoxControl
        '
        Me.LayerLabelCheckedListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayerLabelCheckedListBoxControl.Location = New System.Drawing.Point(3, 3)
        Me.LayerLabelCheckedListBoxControl.Name = "LayerLabelCheckedListBoxControl"
        Me.LayerLabelCheckedListBoxControl.Size = New System.Drawing.Size(228, 435)
        Me.LayerLabelCheckedListBoxControl.TabIndex = 4
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
        'MapPanelSplitContainer
        '
        Me.MapPanelSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapPanelSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.MapPanelSplitContainer.Name = "MapPanelSplitContainer"
        Me.MapPanelSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'MapPanelSplitContainer.Panel1
        '
        Me.MapPanelSplitContainer.Panel1.Controls.Add(Me.MapControl)
        Me.MapPanelSplitContainer.Panel1.Controls.Add(Me.MapToolStrip)
        '
        'MapPanelSplitContainer.Panel2
        '
        Me.MapPanelSplitContainer.Panel2.Controls.Add(Me.MapLayerGridControl)
        Me.MapPanelSplitContainer.Size = New System.Drawing.Size(915, 665)
        Me.MapPanelSplitContainer.SplitterDistance = 444
        Me.MapPanelSplitContainer.TabIndex = 1
        '
        'MapControl
        '
        Me.MapControl.BackColor = System.Drawing.Color.LightSteelBlue
        Me.MapControl.Dock = System.Windows.Forms.DockStyle.Right
        Me.MapControl.Location = New System.Drawing.Point(0, 25)
        Me.MapControl.Name = "MapControl"
        Me.MapControl.Size = New System.Drawing.Size(915, 419)
        Me.MapControl.TabIndex = 0
        '
        'MapToolStrip
        '
        Me.MapToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZoomToFitAllLayersToolStripButton, Me.ToolStripSeparator2, Me.AddLayerToolStripLabel, Me.ToolStripSeparator1})
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'AddLayerToolStripLabel
        '
        Me.AddLayerToolStripLabel.Name = "AddLayerToolStripLabel"
        Me.AddLayerToolStripLabel.Size = New System.Drawing.Size(66, 22)
        Me.AddLayerToolStripLabel.Text = "Add layer..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'GridView1
        '
        Me.GridView1.GridControl = Me.MapLayerGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenPOZFileToolStripButton, Me.POZFileToolStripLabel})
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
        'POZFileToolStripLabel
        '
        Me.POZFileToolStripLabel.Name = "POZFileToolStripLabel"
        Me.POZFileToolStripLabel.Size = New System.Drawing.Size(48, 22)
        Me.POZFileToolStripLabel.Text = "POZFile"
        '
        'LayerPropertiesToolStripMenuItem
        '
        Me.LayerPropertiesToolStripMenuItem.Name = "LayerPropertiesToolStripMenuItem"
        Me.LayerPropertiesToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.LayerPropertiesToolStripMenuItem.Text = "Layer properties..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 716)
        Me.Controls.Add(Me.MainTabControl)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "NPS Data Ranger"
        Me.MainTabControl.ResumeLayout(False)
        Me.MapTabPage.ResumeLayout(False)
        Me.MapSplitContainer.Panel1.ResumeLayout(False)
        Me.MapSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MapSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapSplitContainer.ResumeLayout(False)
        CType(Me.MapLayersSplitContainerControl.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayersSplitContainerControl.Panel1.ResumeLayout(False)
        Me.MapLayersSplitContainerControl.Panel1.PerformLayout()
        CType(Me.MapLayersSplitContainerControl.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayersSplitContainerControl.Panel2.ResumeLayout(False)
        CType(Me.MapLayersSplitContainerControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayersSplitContainerControl.ResumeLayout(False)
        CType(Me.MapLayersCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayerContextMenuStrip.ResumeLayout(False)
        Me.MapLayersToolStrip.ResumeLayout(False)
        Me.MapLayersToolStrip.PerformLayout()
        Me.MapLayerTabControl.ResumeLayout(False)
        Me.MapLayerLabelingTabPage.ResumeLayout(False)
        CType(Me.LayerLabelCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayerPropertiesTabPage.ResumeLayout(False)
        CType(Me.MapLayerPropertyGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapPropertiesTabPage.ResumeLayout(False)
        CType(Me.MapControlPropertyGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapPanelSplitContainer.Panel1.ResumeLayout(False)
        Me.MapPanelSplitContainer.Panel1.PerformLayout()
        Me.MapPanelSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MapPanelSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapPanelSplitContainer.ResumeLayout(False)
        CType(Me.MapControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapToolStrip.ResumeLayout(False)
        Me.MapToolStrip.PerformLayout()
        CType(Me.MapLayerGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
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
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AddLayerToolStripLabel As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents POZFileToolStripLabel As ToolStripLabel
    Friend WithEvents MapLayersToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents PromoteLayerToolStripButton As ToolStripButton
    Friend WithEvents DemoteLayerToolStripButton As ToolStripButton
    Friend WithEvents MapLayerContextMenuStrip As ContextMenuStrip
    Friend WithEvents ExportToKMLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToShapefileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LayerPropertiesToolStripMenuItem As ToolStripMenuItem
End Class
