Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CSVMapLayerImportForm
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
        Me.ImportButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CSVGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.SourceFileLabel = New System.Windows.Forms.ToolStripLabel()
        Me.LatitudeColumnToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.LongitudeColumnToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.Panel1.SuspendLayout()
        CType(Me.CSVGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImportButton
        '
        Me.ImportButton.Enabled = False
        Me.ImportButton.Location = New System.Drawing.Point(372, 431)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(75, 23)
        Me.ImportButton.TabIndex = 2
        Me.ImportButton.Text = "Import"
        Me.ImportButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ImportButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 416)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(769, 50)
        Me.Panel1.TabIndex = 3
        '
        'CSVGridControl
        '
        Me.CSVGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CSVGridControl.Location = New System.Drawing.Point(0, 25)
        Me.CSVGridControl.MainView = Me.GridView1
        Me.CSVGridControl.Name = "CSVGridControl"
        Me.CSVGridControl.Size = New System.Drawing.Size(769, 391)
        Me.CSVGridControl.TabIndex = 4
        Me.CSVGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.CSVGridControl
        Me.GridView1.Name = "GridView1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SourceFileLabel, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.LatitudeColumnToolStripComboBox, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.LongitudeColumnToolStripComboBox})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(769, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'SourceFileLabel
        '
        Me.SourceFileLabel.Name = "SourceFileLabel"
        Me.SourceFileLabel.Size = New System.Drawing.Size(93, 22)
        Me.SourceFileLabel.Text = "Import CSV data"
        '
        'LatitudeColumnToolStripComboBox
        '
        Me.LatitudeColumnToolStripComboBox.Name = "LatitudeColumnToolStripComboBox"
        Me.LatitudeColumnToolStripComboBox.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripLabel1.Text = "Latitude column:"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripLabel2.Text = "Longitude column:"
        '
        'LongitudeColumnToolStripComboBox
        '
        Me.LongitudeColumnToolStripComboBox.Name = "LongitudeColumnToolStripComboBox"
        Me.LongitudeColumnToolStripComboBox.Size = New System.Drawing.Size(121, 25)
        '
        'CSVMapLayerImportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 466)
        Me.Controls.Add(Me.CSVGridControl)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "CSVMapLayerImportForm"
        Me.Text = "CSVMapLayerImportForm"
        Me.Panel1.ResumeLayout(False)
        CType(Me.CSVGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImportButton As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents SourceFileLabel As ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents LatitudeColumnToolStripComboBox As ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents LongitudeColumnToolStripComboBox As ToolStripComboBox
    Friend WithEvents CSVGridControl As GridControl
    Friend WithEvents GridView1 As GridView
End Class
