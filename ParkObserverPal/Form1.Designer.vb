<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.MapTabPage = New System.Windows.Forms.TabPage()
        Me.MapControl = New DevExpress.XtraMap.MapControl()
        Me.MainTabControl.SuspendLayout()
        Me.MapTabPage.SuspendLayout()
        CType(Me.MapControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.MapTabPage)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.Location = New System.Drawing.Point(0, 0)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(1169, 716)
        Me.MainTabControl.TabIndex = 0
        '
        'MapTabPage
        '
        Me.MapTabPage.Controls.Add(Me.MapControl)
        Me.MapTabPage.Location = New System.Drawing.Point(4, 22)
        Me.MapTabPage.Name = "MapTabPage"
        Me.MapTabPage.Size = New System.Drawing.Size(1161, 690)
        Me.MapTabPage.TabIndex = 0
        Me.MapTabPage.Text = "Map"
        Me.MapTabPage.UseVisualStyleBackColor = True
        '
        'MapControl
        '
        Me.MapControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapControl.Location = New System.Drawing.Point(0, 0)
        Me.MapControl.Name = "MapControl"
        Me.MapControl.Size = New System.Drawing.Size(1161, 690)
        Me.MapControl.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 716)
        Me.Controls.Add(Me.MainTabControl)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MainTabControl.ResumeLayout(False)
        Me.MapTabPage.ResumeLayout(False)
        CType(Me.MapControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainTabControl As TabControl
    Friend WithEvents MapTabPage As TabPage
    Friend WithEvents MapControl As DevExpress.XtraMap.MapControl
End Class
