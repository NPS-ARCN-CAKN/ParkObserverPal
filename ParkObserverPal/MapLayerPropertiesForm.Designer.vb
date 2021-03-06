<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MapLayerPropertiesForm
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
        Me.LayerNameLabel = New System.Windows.Forms.Label()
        Me.LabelsFontDialog = New System.Windows.Forms.FontDialog()
        Me.LabelsColorDialog = New System.Windows.Forms.ColorDialog()
        Me.MapLayerColumnsCheckedListBoxControl = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.ShapeTitlesPatternTextBox = New System.Windows.Forms.TextBox()
        Me.LabelsFontButton = New System.Windows.Forms.Button()
        Me.LabelsColorButton = New System.Windows.Forms.Button()
        Me.HaloCheckBox = New System.Windows.Forms.CheckBox()
        Me.LayerTabControl = New System.Windows.Forms.TabControl()
        Me.LabelsTabPage = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SymbologyTabPage = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MarkerBorderColorPickEdit = New DevExpress.XtraEditors.ColorPickEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MarkerColorPickEdit = New DevExpress.XtraEditors.ColorPickEdit()
        Me.MarkerSizeNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.MarkerSymbolListBox = New System.Windows.Forms.ListBox()
        Me.LayerPropertiesTabPage = New System.Windows.Forms.TabPage()
        Me.MapLayerPropertyGridControl = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        CType(Me.MapLayerColumnsCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayerTabControl.SuspendLayout()
        Me.LabelsTabPage.SuspendLayout()
        Me.SymbologyTabPage.SuspendLayout()
        CType(Me.MarkerBorderColorPickEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MarkerColorPickEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MarkerSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayerPropertiesTabPage.SuspendLayout()
        CType(Me.MapLayerPropertyGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayerNameLabel
        '
        Me.LayerNameLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayerNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayerNameLabel.Location = New System.Drawing.Point(0, 0)
        Me.LayerNameLabel.Name = "LayerNameLabel"
        Me.LayerNameLabel.Size = New System.Drawing.Size(251, 20)
        Me.LayerNameLabel.TabIndex = 1
        Me.LayerNameLabel.Text = "Layer name"
        '
        'MapLayerColumnsCheckedListBoxControl
        '
        Me.MapLayerColumnsCheckedListBoxControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MapLayerColumnsCheckedListBoxControl.Location = New System.Drawing.Point(8, 38)
        Me.MapLayerColumnsCheckedListBoxControl.Name = "MapLayerColumnsCheckedListBoxControl"
        Me.MapLayerColumnsCheckedListBoxControl.Size = New System.Drawing.Size(225, 214)
        Me.MapLayerColumnsCheckedListBoxControl.TabIndex = 0
        '
        'ShapeTitlesPatternTextBox
        '
        Me.ShapeTitlesPatternTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShapeTitlesPatternTextBox.Location = New System.Drawing.Point(6, 280)
        Me.ShapeTitlesPatternTextBox.Multiline = True
        Me.ShapeTitlesPatternTextBox.Name = "ShapeTitlesPatternTextBox"
        Me.ShapeTitlesPatternTextBox.Size = New System.Drawing.Size(225, 62)
        Me.ShapeTitlesPatternTextBox.TabIndex = 2
        '
        'LabelsFontButton
        '
        Me.LabelsFontButton.Location = New System.Drawing.Point(8, 9)
        Me.LabelsFontButton.Name = "LabelsFontButton"
        Me.LabelsFontButton.Size = New System.Drawing.Size(78, 23)
        Me.LabelsFontButton.TabIndex = 3
        Me.LabelsFontButton.Text = "Labels font..."
        Me.LabelsFontButton.UseVisualStyleBackColor = True
        '
        'LabelsColorButton
        '
        Me.LabelsColorButton.Location = New System.Drawing.Point(92, 9)
        Me.LabelsColorButton.Name = "LabelsColorButton"
        Me.LabelsColorButton.Size = New System.Drawing.Size(87, 23)
        Me.LabelsColorButton.TabIndex = 5
        Me.LabelsColorButton.Text = "Labels color..."
        Me.LabelsColorButton.UseVisualStyleBackColor = True
        '
        'HaloCheckBox
        '
        Me.HaloCheckBox.AutoSize = True
        Me.HaloCheckBox.Location = New System.Drawing.Point(185, 13)
        Me.HaloCheckBox.Name = "HaloCheckBox"
        Me.HaloCheckBox.Size = New System.Drawing.Size(48, 17)
        Me.HaloCheckBox.TabIndex = 6
        Me.HaloCheckBox.Text = "Halo"
        Me.HaloCheckBox.UseVisualStyleBackColor = True
        '
        'LayerTabControl
        '
        Me.LayerTabControl.Controls.Add(Me.LabelsTabPage)
        Me.LayerTabControl.Controls.Add(Me.SymbologyTabPage)
        Me.LayerTabControl.Controls.Add(Me.LayerPropertiesTabPage)
        Me.LayerTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayerTabControl.Location = New System.Drawing.Point(0, 20)
        Me.LayerTabControl.Name = "LayerTabControl"
        Me.LayerTabControl.SelectedIndex = 0
        Me.LayerTabControl.Size = New System.Drawing.Size(251, 380)
        Me.LayerTabControl.TabIndex = 7
        '
        'LabelsTabPage
        '
        Me.LabelsTabPage.Controls.Add(Me.Label1)
        Me.LabelsTabPage.Controls.Add(Me.HaloCheckBox)
        Me.LabelsTabPage.Controls.Add(Me.LabelsColorButton)
        Me.LabelsTabPage.Controls.Add(Me.LabelsFontButton)
        Me.LabelsTabPage.Controls.Add(Me.MapLayerColumnsCheckedListBoxControl)
        Me.LabelsTabPage.Controls.Add(Me.ShapeTitlesPatternTextBox)
        Me.LabelsTabPage.Location = New System.Drawing.Point(4, 22)
        Me.LabelsTabPage.Name = "LabelsTabPage"
        Me.LabelsTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.LabelsTabPage.Size = New System.Drawing.Size(243, 354)
        Me.LabelsTabPage.TabIndex = 0
        Me.LabelsTabPage.Text = "Labels"
        Me.LabelsTabPage.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 264)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Labels pattern editor"
        '
        'SymbologyTabPage
        '
        Me.SymbologyTabPage.Controls.Add(Me.Label5)
        Me.SymbologyTabPage.Controls.Add(Me.MarkerBorderColorPickEdit)
        Me.SymbologyTabPage.Controls.Add(Me.Label4)
        Me.SymbologyTabPage.Controls.Add(Me.Label3)
        Me.SymbologyTabPage.Controls.Add(Me.Label2)
        Me.SymbologyTabPage.Controls.Add(Me.MarkerColorPickEdit)
        Me.SymbologyTabPage.Controls.Add(Me.MarkerSizeNumericUpDown)
        Me.SymbologyTabPage.Controls.Add(Me.MarkerSymbolListBox)
        Me.SymbologyTabPage.Location = New System.Drawing.Point(4, 22)
        Me.SymbologyTabPage.Name = "SymbologyTabPage"
        Me.SymbologyTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SymbologyTabPage.Size = New System.Drawing.Size(243, 354)
        Me.SymbologyTabPage.TabIndex = 1
        Me.SymbologyTabPage.Text = "Symbology"
        Me.SymbologyTabPage.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 307)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Marker stroke color:"
        '
        'MarkerBorderColorPickEdit
        '
        Me.MarkerBorderColorPickEdit.EditValue = System.Drawing.Color.Empty
        Me.MarkerBorderColorPickEdit.Location = New System.Drawing.Point(8, 323)
        Me.MarkerBorderColorPickEdit.Name = "MarkerBorderColorPickEdit"
        Me.MarkerBorderColorPickEdit.Properties.AutomaticColor = System.Drawing.Color.Black
        Me.MarkerBorderColorPickEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MarkerBorderColorPickEdit.Properties.ShowWebSafeColors = True
        Me.MarkerBorderColorPickEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.MarkerBorderColorPickEdit.Size = New System.Drawing.Size(227, 20)
        Me.MarkerBorderColorPickEdit.TabIndex = 6
        Me.MarkerBorderColorPickEdit.ToolTip = "Select a color for the map layer's items."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Marker size:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 258)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Marker color:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Marker symbol:"
        '
        'MarkerColorPickEdit
        '
        Me.MarkerColorPickEdit.EditValue = System.Drawing.Color.Empty
        Me.MarkerColorPickEdit.Location = New System.Drawing.Point(8, 274)
        Me.MarkerColorPickEdit.Name = "MarkerColorPickEdit"
        Me.MarkerColorPickEdit.Properties.AutomaticColor = System.Drawing.Color.Black
        Me.MarkerColorPickEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MarkerColorPickEdit.Properties.ShowWebSafeColors = True
        Me.MarkerColorPickEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.MarkerColorPickEdit.Size = New System.Drawing.Size(227, 20)
        Me.MarkerColorPickEdit.TabIndex = 2
        Me.MarkerColorPickEdit.ToolTip = "Select a color for the map layer's items."
        '
        'MarkerSizeNumericUpDown
        '
        Me.MarkerSizeNumericUpDown.Location = New System.Drawing.Point(115, 225)
        Me.MarkerSizeNumericUpDown.Name = "MarkerSizeNumericUpDown"
        Me.MarkerSizeNumericUpDown.Size = New System.Drawing.Size(120, 20)
        Me.MarkerSizeNumericUpDown.TabIndex = 1
        Me.MarkerSizeNumericUpDown.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'MarkerSymbolListBox
        '
        Me.MarkerSymbolListBox.FormattingEnabled = True
        Me.MarkerSymbolListBox.Location = New System.Drawing.Point(8, 34)
        Me.MarkerSymbolListBox.Name = "MarkerSymbolListBox"
        Me.MarkerSymbolListBox.Size = New System.Drawing.Size(227, 173)
        Me.MarkerSymbolListBox.TabIndex = 0
        '
        'LayerPropertiesTabPage
        '
        Me.LayerPropertiesTabPage.Controls.Add(Me.MapLayerPropertyGridControl)
        Me.LayerPropertiesTabPage.Location = New System.Drawing.Point(4, 22)
        Me.LayerPropertiesTabPage.Name = "LayerPropertiesTabPage"
        Me.LayerPropertiesTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.LayerPropertiesTabPage.Size = New System.Drawing.Size(243, 354)
        Me.LayerPropertiesTabPage.TabIndex = 2
        Me.LayerPropertiesTabPage.Text = "Properties"
        Me.LayerPropertiesTabPage.UseVisualStyleBackColor = True
        '
        'MapLayerPropertyGridControl
        '
        Me.MapLayerPropertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapLayerPropertyGridControl.Location = New System.Drawing.Point(3, 3)
        Me.MapLayerPropertyGridControl.Name = "MapLayerPropertyGridControl"
        Me.MapLayerPropertyGridControl.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.[True]
        Me.MapLayerPropertyGridControl.Size = New System.Drawing.Size(237, 348)
        Me.MapLayerPropertyGridControl.TabIndex = 0
        '
        'MapLayerPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(251, 400)
        Me.Controls.Add(Me.LayerTabControl)
        Me.Controls.Add(Me.LayerNameLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "MapLayerPropertiesForm"
        Me.Text = "Map layer properties"
        Me.TopMost = True
        CType(Me.MapLayerColumnsCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayerTabControl.ResumeLayout(False)
        Me.LabelsTabPage.ResumeLayout(False)
        Me.LabelsTabPage.PerformLayout()
        Me.SymbologyTabPage.ResumeLayout(False)
        Me.SymbologyTabPage.PerformLayout()
        CType(Me.MarkerBorderColorPickEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MarkerColorPickEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MarkerSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayerPropertiesTabPage.ResumeLayout(False)
        CType(Me.MapLayerPropertyGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayerNameLabel As Label
    Friend WithEvents LabelsFontDialog As FontDialog
    Friend WithEvents LabelsColorDialog As ColorDialog
    Friend WithEvents MapLayerColumnsCheckedListBoxControl As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents ShapeTitlesPatternTextBox As TextBox
    Friend WithEvents LabelsFontButton As Button
    Friend WithEvents LabelsColorButton As Button
    Friend WithEvents HaloCheckBox As CheckBox
    Friend WithEvents LayerTabControl As TabControl
    Friend WithEvents LabelsTabPage As TabPage
    Friend WithEvents SymbologyTabPage As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents LayerPropertiesTabPage As TabPage
    Friend WithEvents MapLayerPropertyGridControl As DevExpress.XtraVerticalGrid.PropertyGridControl
    Friend WithEvents MarkerSymbolListBox As ListBox
    Friend WithEvents MarkerColorPickEdit As DevExpress.XtraEditors.ColorPickEdit
    Friend WithEvents MarkerSizeNumericUpDown As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents MarkerBorderColorPickEdit As DevExpress.XtraEditors.ColorPickEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
