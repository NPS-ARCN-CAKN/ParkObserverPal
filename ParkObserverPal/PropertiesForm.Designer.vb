<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropertiesForm
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
        Me.MainPropertyGridControl = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        CType(Me.MainPropertyGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainPropertyGridControl
        '
        Me.MainPropertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPropertyGridControl.Location = New System.Drawing.Point(0, 0)
        Me.MainPropertyGridControl.Name = "MainPropertyGridControl"
        Me.MainPropertyGridControl.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.[True]
        Me.MainPropertyGridControl.Size = New System.Drawing.Size(712, 562)
        Me.MainPropertyGridControl.TabIndex = 0
        '
        'PropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 562)
        Me.Controls.Add(Me.MainPropertyGridControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "PropertiesForm"
        Me.Text = "Properties "
        CType(Me.MainPropertyGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainPropertyGridControl As DevExpress.XtraVerticalGrid.PropertyGridControl
End Class
