Public Class PropertiesForm
    Public Sub New(ObjectToView As Object)

        ' This call is required by the designer.
        InitializeComponent()

        Me.MainPropertyGridControl.SelectedObject = ObjectToView
    End Sub
End Class