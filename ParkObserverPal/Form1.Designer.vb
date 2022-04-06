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
        Me.MapSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.MapLayersCheckedListBoxControl = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.MapLayerContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddSpatialDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShapefileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParkObserverArchivepozToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomToLayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LayerPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.KMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShapefileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MapLayersToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PromoteLayerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DemoteLayerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MapPanelSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.MapControl = New DevExpress.XtraMap.MapControl()
        Me.MapToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ZoomToFitAllLayersToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MapLayerGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.MapContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MapPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.MapSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapSplitContainer.Panel1.SuspendLayout()
        Me.MapSplitContainer.Panel2.SuspendLayout()
        Me.MapSplitContainer.SuspendLayout()
        CType(Me.MapLayersCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapLayerContextMenuStrip.SuspendLayout()
        Me.MapLayersToolStrip.SuspendLayout()
        CType(Me.MapPanelSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapPanelSplitContainer.Panel1.SuspendLayout()
        Me.MapPanelSplitContainer.Panel2.SuspendLayout()
        Me.MapPanelSplitContainer.SuspendLayout()
        CType(Me.MapControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapToolStrip.SuspendLayout()
        CType(Me.MapLayerGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MapSplitContainer
        '
        Me.MapSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.MapSplitContainer.Name = "MapSplitContainer"
        '
        'MapSplitContainer.Panel1
        '
        Me.MapSplitContainer.Panel1.Controls.Add(Me.MapLayersCheckedListBoxControl)
        Me.MapSplitContainer.Panel1.Controls.Add(Me.MapLayersToolStrip)
        '
        'MapSplitContainer.Panel2
        '
        Me.MapSplitContainer.Panel2.Controls.Add(Me.MapPanelSplitContainer)
        Me.MapSplitContainer.Size = New System.Drawing.Size(1169, 716)
        Me.MapSplitContainer.SplitterDistance = 243
        Me.MapSplitContainer.TabIndex = 1
        '
        'MapLayersCheckedListBoxControl
        '
        Me.MapLayersCheckedListBoxControl.ContextMenuStrip = Me.MapLayerContextMenuStrip
        Me.MapLayersCheckedListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayersCheckedListBoxControl.Location = New System.Drawing.Point(0, 25)
        Me.MapLayersCheckedListBoxControl.Name = "MapLayersCheckedListBoxControl"
        Me.MapLayersCheckedListBoxControl.Size = New System.Drawing.Size(243, 691)
        Me.MapLayersCheckedListBoxControl.TabIndex = 3
        '
        'MapLayerContextMenuStrip
        '
        Me.MapLayerContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddSpatialDataToolStripMenuItem, Me.ZoomToLayerToolStripMenuItem, Me.LayerPropertiesToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MapLayerContextMenuStrip.Name = "MapLayerContextMenuStrip"
        Me.MapLayerContextMenuStrip.Size = New System.Drawing.Size(168, 92)
        '
        'AddSpatialDataToolStripMenuItem
        '
        Me.AddSpatialDataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CSVToolStripMenuItem, Me.ShapefileToolStripMenuItem1, Me.ParkObserverArchivepozToolStripMenuItem})
        Me.AddSpatialDataToolStripMenuItem.Name = "AddSpatialDataToolStripMenuItem"
        Me.AddSpatialDataToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.AddSpatialDataToolStripMenuItem.Text = "Add data"
        '
        'CSVToolStripMenuItem
        '
        Me.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem"
        Me.CSVToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.CSVToolStripMenuItem.Text = "CSV..."
        '
        'ShapefileToolStripMenuItem1
        '
        Me.ShapefileToolStripMenuItem1.Name = "ShapefileToolStripMenuItem1"
        Me.ShapefileToolStripMenuItem1.Size = New System.Drawing.Size(230, 22)
        Me.ShapefileToolStripMenuItem1.Text = "Shapefile..."
        '
        'ParkObserverArchivepozToolStripMenuItem
        '
        Me.ParkObserverArchivepozToolStripMenuItem.Name = "ParkObserverArchivepozToolStripMenuItem"
        Me.ParkObserverArchivepozToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ParkObserverArchivepozToolStripMenuItem.Text = "Park Observer archive (.poz)..."
        '
        'ZoomToLayerToolStripMenuItem
        '
        Me.ZoomToLayerToolStripMenuItem.Name = "ZoomToLayerToolStripMenuItem"
        Me.ZoomToLayerToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ZoomToLayerToolStripMenuItem.Text = "Zoom to layer"
        '
        'LayerPropertiesToolStripMenuItem
        '
        Me.LayerPropertiesToolStripMenuItem.Name = "LayerPropertiesToolStripMenuItem"
        Me.LayerPropertiesToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.LayerPropertiesToolStripMenuItem.Text = "Layer properties..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KMLToolStripMenuItem, Me.ShapefileToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem1.Text = "Export data"
        '
        'KMLToolStripMenuItem
        '
        Me.KMLToolStripMenuItem.Name = "KMLToolStripMenuItem"
        Me.KMLToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.KMLToolStripMenuItem.Text = "KML"
        '
        'ShapefileToolStripMenuItem
        '
        Me.ShapefileToolStripMenuItem.Name = "ShapefileToolStripMenuItem"
        Me.ShapefileToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.ShapefileToolStripMenuItem.Text = "Shapefile"
        '
        'MapLayersToolStrip
        '
        Me.MapLayersToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.PromoteLayerToolStripButton, Me.DemoteLayerToolStripButton})
        Me.MapLayersToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MapLayersToolStrip.Name = "MapLayersToolStrip"
        Me.MapLayersToolStrip.Size = New System.Drawing.Size(243, 25)
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
        Me.MapPanelSplitContainer.Size = New System.Drawing.Size(922, 716)
        Me.MapPanelSplitContainer.SplitterDistance = 549
        Me.MapPanelSplitContainer.TabIndex = 1
        '
        'MapControl
        '
        Me.MapControl.BackColor = System.Drawing.Color.LightSteelBlue
        Me.MapControl.ContextMenuStrip = Me.MapContextMenuStrip
        Me.MapControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapControl.Location = New System.Drawing.Point(0, 25)
        Me.MapControl.Name = "MapControl"
        Me.MapControl.Size = New System.Drawing.Size(922, 524)
        Me.MapControl.TabIndex = 0
        '
        'MapToolStrip
        '
        Me.MapToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZoomToFitAllLayersToolStripButton, Me.ToolStripSeparator2})
        Me.MapToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MapToolStrip.Name = "MapToolStrip"
        Me.MapToolStrip.Size = New System.Drawing.Size(922, 25)
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
        'MapLayerGridControl
        '
        Me.MapLayerGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayerGridControl.Location = New System.Drawing.Point(0, 0)
        Me.MapLayerGridControl.MainView = Me.GridView1
        Me.MapLayerGridControl.Name = "MapLayerGridControl"
        Me.MapLayerGridControl.Size = New System.Drawing.Size(922, 163)
        Me.MapLayerGridControl.TabIndex = 0
        Me.MapLayerGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.MapLayerGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'MapContextMenuStrip
        '
        Me.MapContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MapPropertiesToolStripMenuItem})
        Me.MapContextMenuStrip.Name = "MapContextMenuStrip"
        Me.MapContextMenuStrip.Size = New System.Drawing.Size(164, 26)
        '
        'MapPropertiesToolStripMenuItem
        '
        Me.MapPropertiesToolStripMenuItem.Name = "MapPropertiesToolStripMenuItem"
        Me.MapPropertiesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MapPropertiesToolStripMenuItem.Text = "Map properties..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 716)
        Me.Controls.Add(Me.MapSplitContainer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "NPS Data Ranger"
        Me.MapSplitContainer.Panel1.ResumeLayout(False)
        Me.MapSplitContainer.Panel1.PerformLayout()
        Me.MapSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MapSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapSplitContainer.ResumeLayout(False)
        CType(Me.MapLayersCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayerContextMenuStrip.ResumeLayout(False)
        Me.MapLayersToolStrip.ResumeLayout(False)
        Me.MapLayersToolStrip.PerformLayout()
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
        Me.MapContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MapControl As DevExpress.XtraMap.MapControl
    Friend WithEvents MapSplitContainer As SplitContainer
    Friend WithEvents MapLayersCheckedListBoxControl As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents MapPanelSplitContainer As SplitContainer
    Friend WithEvents MapLayerGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MapToolStrip As ToolStrip
    Friend WithEvents ZoomToFitAllLayersToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MapLayersToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents PromoteLayerToolStripButton As ToolStripButton
    Friend WithEvents DemoteLayerToolStripButton As ToolStripButton
    Friend WithEvents MapLayerContextMenuStrip As ContextMenuStrip
    Friend WithEvents LayerPropertiesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddSpatialDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZoomToLayerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents KMLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShapefileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShapefileToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ParkObserverArchivepozToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MapContextMenuStrip As ContextMenuStrip
    Friend WithEvents MapPropertiesToolStripMenuItem As ToolStripMenuItem
End Class
