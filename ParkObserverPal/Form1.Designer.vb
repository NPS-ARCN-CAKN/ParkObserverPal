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
        Me.RemoveAllLayersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveCurrentLayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreatePivotTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MapLayersToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PromoteLayerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DemoteLayerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AddDatasetToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MapControl = New DevExpress.XtraMap.MapControl()
        Me.MapContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MapPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MapToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ZoomToFitAllLayersToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MapLayerGridControl = New DevExpress.XtraGrid.GridControl()
        Me.MapLayerGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.VGridControl = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.MainDockManager = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.MapLayersDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.MapLayersDockPanel_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.MapLayerDataTableDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.MapLayerDataTableDockPanel_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.MapItemDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.MapItemDockPanel_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        CType(Me.MapLayersCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapLayerContextMenuStrip.SuspendLayout()
        Me.MapLayersToolStrip.SuspendLayout()
        CType(Me.MapControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapContextMenuStrip.SuspendLayout()
        Me.MapToolStrip.SuspendLayout()
        CType(Me.MapLayerGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapLayerGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainDockManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapLayersDockPanel.SuspendLayout()
        Me.MapLayersDockPanel_Container.SuspendLayout()
        Me.MapLayerDataTableDockPanel.SuspendLayout()
        Me.MapLayerDataTableDockPanel_Container.SuspendLayout()
        Me.MapItemDockPanel.SuspendLayout()
        Me.MapItemDockPanel_Container.SuspendLayout()
        Me.SuspendLayout()
        '
        'MapLayersCheckedListBoxControl
        '
        Me.MapLayersCheckedListBoxControl.ContextMenuStrip = Me.MapLayerContextMenuStrip
        Me.MapLayersCheckedListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayersCheckedListBoxControl.Location = New System.Drawing.Point(0, 25)
        Me.MapLayersCheckedListBoxControl.Name = "MapLayersCheckedListBoxControl"
        Me.MapLayersCheckedListBoxControl.Size = New System.Drawing.Size(193, 707)
        Me.MapLayersCheckedListBoxControl.TabIndex = 3
        '
        'MapLayerContextMenuStrip
        '
        Me.MapLayerContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddSpatialDataToolStripMenuItem, Me.ZoomToLayerToolStripMenuItem, Me.LayerPropertiesToolStripMenuItem, Me.ToolStripMenuItem1, Me.RemoveAllLayersToolStripMenuItem, Me.RemoveCurrentLayerToolStripMenuItem, Me.CreatePivotTableToolStripMenuItem})
        Me.MapLayerContextMenuStrip.Name = "MapLayerContextMenuStrip"
        Me.MapLayerContextMenuStrip.Size = New System.Drawing.Size(187, 158)
        '
        'AddSpatialDataToolStripMenuItem
        '
        Me.AddSpatialDataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CSVToolStripMenuItem, Me.ShapefileToolStripMenuItem1, Me.ParkObserverArchivepozToolStripMenuItem})
        Me.AddSpatialDataToolStripMenuItem.Name = "AddSpatialDataToolStripMenuItem"
        Me.AddSpatialDataToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
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
        Me.ZoomToLayerToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ZoomToLayerToolStripMenuItem.Text = "Zoom to layer"
        '
        'LayerPropertiesToolStripMenuItem
        '
        Me.LayerPropertiesToolStripMenuItem.Name = "LayerPropertiesToolStripMenuItem"
        Me.LayerPropertiesToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.LayerPropertiesToolStripMenuItem.Text = "Layer properties..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KMLToolStripMenuItem, Me.ShapefileToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(186, 22)
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
        'RemoveAllLayersToolStripMenuItem
        '
        Me.RemoveAllLayersToolStripMenuItem.Name = "RemoveAllLayersToolStripMenuItem"
        Me.RemoveAllLayersToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.RemoveAllLayersToolStripMenuItem.Text = "Remove all layers"
        '
        'RemoveCurrentLayerToolStripMenuItem
        '
        Me.RemoveCurrentLayerToolStripMenuItem.Name = "RemoveCurrentLayerToolStripMenuItem"
        Me.RemoveCurrentLayerToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.RemoveCurrentLayerToolStripMenuItem.Text = "Remove current layer"
        '
        'CreatePivotTableToolStripMenuItem
        '
        Me.CreatePivotTableToolStripMenuItem.Name = "CreatePivotTableToolStripMenuItem"
        Me.CreatePivotTableToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.CreatePivotTableToolStripMenuItem.Text = "Create pivot table..."
        '
        'MapLayersToolStrip
        '
        Me.MapLayersToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.PromoteLayerToolStripButton, Me.DemoteLayerToolStripButton, Me.AddDatasetToolStripButton})
        Me.MapLayersToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MapLayersToolStrip.Name = "MapLayersToolStrip"
        Me.MapLayersToolStrip.Size = New System.Drawing.Size(193, 25)
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
        'AddDatasetToolStripButton
        '
        Me.AddDatasetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddDatasetToolStripButton.Image = CType(resources.GetObject("AddDatasetToolStripButton.Image"), System.Drawing.Image)
        Me.AddDatasetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddDatasetToolStripButton.Name = "AddDatasetToolStripButton"
        Me.AddDatasetToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AddDatasetToolStripButton.Text = "Add spatial dataset"
        '
        'MapControl
        '
        Me.MapControl.BackColor = System.Drawing.Color.LightSteelBlue
        Me.MapControl.ContextMenuStrip = Me.MapContextMenuStrip
        Me.MapControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapControl.Location = New System.Drawing.Point(200, 25)
        Me.MapControl.Name = "MapControl"
        Me.MapControl.Size = New System.Drawing.Size(784, 536)
        Me.MapControl.TabIndex = 0
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
        Me.MapPropertiesToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.MapPropertiesToolStripMenuItem.Text = "Map properties..."
        '
        'MapToolStrip
        '
        Me.MapToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZoomToFitAllLayersToolStripButton, Me.ToolStripSeparator2})
        Me.MapToolStrip.Location = New System.Drawing.Point(200, 0)
        Me.MapToolStrip.Name = "MapToolStrip"
        Me.MapToolStrip.Size = New System.Drawing.Size(784, 25)
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
        Me.MapLayerGridControl.MainView = Me.MapLayerGridView
        Me.MapLayerGridControl.Name = "MapLayerGridControl"
        Me.MapLayerGridControl.Size = New System.Drawing.Size(978, 170)
        Me.MapLayerGridControl.TabIndex = 0
        Me.MapLayerGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MapLayerGridView})
        '
        'MapLayerGridView
        '
        Me.MapLayerGridView.GridControl = Me.MapLayerGridControl
        Me.MapLayerGridView.Name = "MapLayerGridView"
        Me.MapLayerGridView.OptionsView.ShowFooter = True
        '
        'VGridControl
        '
        Me.VGridControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.VGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VGridControl.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.VGridControl.Location = New System.Drawing.Point(0, 0)
        Me.VGridControl.Name = "VGridControl"
        Me.VGridControl.Size = New System.Drawing.Size(193, 532)
        Me.VGridControl.TabIndex = 2
        '
        'MainDockManager
        '
        Me.MainDockManager.Form = Me
        Me.MainDockManager.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.MapLayersDockPanel, Me.MapLayerDataTableDockPanel, Me.MapItemDockPanel})
        Me.MainDockManager.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'MapLayersDockPanel
        '
        Me.MapLayersDockPanel.Controls.Add(Me.MapLayersDockPanel_Container)
        Me.MapLayersDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.MapLayersDockPanel.ID = New System.Guid("fed6ed6f-7c07-468b-b258-6a4343f1c5ff")
        Me.MapLayersDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.MapLayersDockPanel.Name = "MapLayersDockPanel"
        Me.MapLayersDockPanel.OriginalSize = New System.Drawing.Size(200, 200)
        Me.MapLayersDockPanel.Size = New System.Drawing.Size(200, 761)
        Me.MapLayersDockPanel.Text = "Map layers"
        '
        'MapLayersDockPanel_Container
        '
        Me.MapLayersDockPanel_Container.Controls.Add(Me.MapLayersCheckedListBoxControl)
        Me.MapLayersDockPanel_Container.Controls.Add(Me.MapLayersToolStrip)
        Me.MapLayersDockPanel_Container.Location = New System.Drawing.Point(3, 26)
        Me.MapLayersDockPanel_Container.Name = "MapLayersDockPanel_Container"
        Me.MapLayersDockPanel_Container.Size = New System.Drawing.Size(193, 732)
        Me.MapLayersDockPanel_Container.TabIndex = 0
        '
        'MapLayerDataTableDockPanel
        '
        Me.MapLayerDataTableDockPanel.Controls.Add(Me.MapLayerDataTableDockPanel_Container)
        Me.MapLayerDataTableDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.MapLayerDataTableDockPanel.ID = New System.Guid("294e824f-f1cd-4e8d-a2fc-4e4e5db7295a")
        Me.MapLayerDataTableDockPanel.Location = New System.Drawing.Point(200, 561)
        Me.MapLayerDataTableDockPanel.Name = "MapLayerDataTableDockPanel"
        Me.MapLayerDataTableDockPanel.OriginalSize = New System.Drawing.Size(200, 200)
        Me.MapLayerDataTableDockPanel.Size = New System.Drawing.Size(984, 200)
        Me.MapLayerDataTableDockPanel.Text = "Dataset"
        '
        'MapLayerDataTableDockPanel_Container
        '
        Me.MapLayerDataTableDockPanel_Container.Controls.Add(Me.MapLayerGridControl)
        Me.MapLayerDataTableDockPanel_Container.Location = New System.Drawing.Point(3, 27)
        Me.MapLayerDataTableDockPanel_Container.Name = "MapLayerDataTableDockPanel_Container"
        Me.MapLayerDataTableDockPanel_Container.Size = New System.Drawing.Size(978, 170)
        Me.MapLayerDataTableDockPanel_Container.TabIndex = 0
        '
        'MapItemDockPanel
        '
        Me.MapItemDockPanel.Controls.Add(Me.MapItemDockPanel_Container)
        Me.MapItemDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right
        Me.MapItemDockPanel.ID = New System.Guid("3d6e2ddd-22a2-495f-b966-bb2fad16615c")
        Me.MapItemDockPanel.Location = New System.Drawing.Point(984, 0)
        Me.MapItemDockPanel.Name = "MapItemDockPanel"
        Me.MapItemDockPanel.OriginalSize = New System.Drawing.Size(200, 200)
        Me.MapItemDockPanel.Size = New System.Drawing.Size(200, 561)
        Me.MapItemDockPanel.Text = "Feature"
        '
        'MapItemDockPanel_Container
        '
        Me.MapItemDockPanel_Container.Controls.Add(Me.VGridControl)
        Me.MapItemDockPanel_Container.Location = New System.Drawing.Point(4, 26)
        Me.MapItemDockPanel_Container.Name = "MapItemDockPanel_Container"
        Me.MapItemDockPanel_Container.Size = New System.Drawing.Size(193, 532)
        Me.MapItemDockPanel_Container.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.MapControl)
        Me.Controls.Add(Me.MapToolStrip)
        Me.Controls.Add(Me.MapItemDockPanel)
        Me.Controls.Add(Me.MapLayerDataTableDockPanel)
        Me.Controls.Add(Me.MapLayersDockPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "NPS Data Ranger"
        CType(Me.MapLayersCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayerContextMenuStrip.ResumeLayout(False)
        Me.MapLayersToolStrip.ResumeLayout(False)
        Me.MapLayersToolStrip.PerformLayout()
        CType(Me.MapControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapContextMenuStrip.ResumeLayout(False)
        Me.MapToolStrip.ResumeLayout(False)
        Me.MapToolStrip.PerformLayout()
        CType(Me.MapLayerGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MapLayerGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainDockManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapLayersDockPanel.ResumeLayout(False)
        Me.MapLayersDockPanel_Container.ResumeLayout(False)
        Me.MapLayersDockPanel_Container.PerformLayout()
        Me.MapLayerDataTableDockPanel.ResumeLayout(False)
        Me.MapLayerDataTableDockPanel_Container.ResumeLayout(False)
        Me.MapItemDockPanel.ResumeLayout(False)
        Me.MapItemDockPanel_Container.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MapControl As DevExpress.XtraMap.MapControl
    Friend WithEvents MapLayersCheckedListBoxControl As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents MapLayerGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents MapLayerGridView As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents AddDatasetToolStripButton As ToolStripButton
    Friend WithEvents RemoveAllLayersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveCurrentLayerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreatePivotTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VGridControl As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents MainDockManager As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents MapItemDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents MapItemDockPanel_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents MapLayerDataTableDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents MapLayerDataTableDockPanel_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents MapLayersDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents MapLayersDockPanel_Container As DevExpress.XtraBars.Docking.ControlContainer
End Class
