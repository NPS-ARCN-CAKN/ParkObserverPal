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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelsColorButton = New System.Windows.Forms.Button()
        Me.HaloCheckBox = New System.Windows.Forms.CheckBox()
        CType(Me.MapLayerColumnsCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayerNameLabel
        '
        Me.LayerNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayerNameLabel.Location = New System.Drawing.Point(9, 9)
        Me.LayerNameLabel.Name = "LayerNameLabel"
        Me.LayerNameLabel.Size = New System.Drawing.Size(535, 20)
        Me.LayerNameLabel.TabIndex = 1
        Me.LayerNameLabel.Text = "Layer name"
        '
        'MapLayerColumnsCheckedListBoxControl
        '
        Me.MapLayerColumnsCheckedListBoxControl.Location = New System.Drawing.Point(12, 84)
        Me.MapLayerColumnsCheckedListBoxControl.Name = "MapLayerColumnsCheckedListBoxControl"
        Me.MapLayerColumnsCheckedListBoxControl.Size = New System.Drawing.Size(233, 214)
        Me.MapLayerColumnsCheckedListBoxControl.TabIndex = 0
        '
        'ShapeTitlesPatternTextBox
        '
        Me.ShapeTitlesPatternTextBox.Location = New System.Drawing.Point(12, 304)
        Me.ShapeTitlesPatternTextBox.Multiline = True
        Me.ShapeTitlesPatternTextBox.Name = "ShapeTitlesPatternTextBox"
        Me.ShapeTitlesPatternTextBox.Size = New System.Drawing.Size(233, 62)
        Me.ShapeTitlesPatternTextBox.TabIndex = 2
        '
        'LabelsFontButton
        '
        Me.LabelsFontButton.Location = New System.Drawing.Point(12, 55)
        Me.LabelsFontButton.Name = "LabelsFontButton"
        Me.LabelsFontButton.Size = New System.Drawing.Size(78, 23)
        Me.LabelsFontButton.TabIndex = 3
        Me.LabelsFontButton.Text = "Labels font..."
        Me.LabelsFontButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Labels"
        '
        'LabelsColorButton
        '
        Me.LabelsColorButton.Location = New System.Drawing.Point(96, 55)
        Me.LabelsColorButton.Name = "LabelsColorButton"
        Me.LabelsColorButton.Size = New System.Drawing.Size(87, 23)
        Me.LabelsColorButton.TabIndex = 5
        Me.LabelsColorButton.Text = "Labels color..."
        Me.LabelsColorButton.UseVisualStyleBackColor = True
        '
        'HaloCheckBox
        '
        Me.HaloCheckBox.AutoSize = True
        Me.HaloCheckBox.Location = New System.Drawing.Point(189, 59)
        Me.HaloCheckBox.Name = "HaloCheckBox"
        Me.HaloCheckBox.Size = New System.Drawing.Size(48, 17)
        Me.HaloCheckBox.TabIndex = 6
        Me.HaloCheckBox.Text = "Halo"
        Me.HaloCheckBox.UseVisualStyleBackColor = True
        '
        'MapLayerPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 482)
        Me.Controls.Add(Me.HaloCheckBox)
        Me.Controls.Add(Me.LabelsColorButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelsFontButton)
        Me.Controls.Add(Me.ShapeTitlesPatternTextBox)
        Me.Controls.Add(Me.LayerNameLabel)
        Me.Controls.Add(Me.MapLayerColumnsCheckedListBoxControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MapLayerPropertiesForm"
        Me.Text = "Map layer properties"
        CType(Me.MapLayerColumnsCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LayerNameLabel As Label
    Friend WithEvents LabelsFontDialog As FontDialog
    Friend WithEvents LabelsColorDialog As ColorDialog
    Friend WithEvents MapLayerColumnsCheckedListBoxControl As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents ShapeTitlesPatternTextBox As TextBox
    Friend WithEvents LabelsFontButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelsColorButton As Button
    Friend WithEvents HaloCheckBox As CheckBox
End Class
