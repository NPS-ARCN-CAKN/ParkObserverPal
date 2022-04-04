Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraMap



Public Class MapLayerPropertiesForm

    'Private VectorItemsLayerValue As VectorItemsLayer
    'Public Property VectorItemsLayer() As VectorItemsLayer
    '    Get
    '        Return VectorItemsLayerValue
    '    End Get
    '    Set(ByVal value As VectorItemsLayer)
    '        VectorItemsLayerValue = VectorItemsLayer
    '    End Set
    'End Property
    Dim MapLayer As VectorItemsLayer = Nothing

    Public Sub New(VectorItemsLayer As VectorItemsLayer)
        ' This call is required by the designer.
        InitializeComponent()

        'Declare the map layer to work with
        MapLayer = VectorItemsLayer

        'DevEx sets the shape titles pattern by default to {NAME}, clear it so we can use our own
        MapLayer.ShapeTitlesPattern = ""

        'Show the map layers name in the text box
        Me.LayerNameLabel.Text = MapLayer.Name

        'Load the columns into the chooser listbox so user can choose columns for labels
        LoadMapItemAttributesIntoListBox(MapLayer)

        'Load the map layer into the advanced map layer property grid control
        'Me.PropertyGridControl1.SelectedObject = MapLayer
    End Sub

    ''' <summary>
    ''' Loads the map layers column names into the list box so the user can check off column names for labeling
    ''' </summary>
    ''' <param name="MapLayer"></param>
    Private Sub LoadMapItemAttributesIntoListBox(MapLayer As VectorItemsLayer)
        Try
            'Make sure we have a map layer to work with
            If Not MapLayer Is Nothing Then
                'Make sure there is at least one row of data
                If MapLayer.Data.Items.Count >= 0 Then

                    'Clear out the existing items in the list box of column names
                    Me.MapLayerColumnsCheckedListBoxControl.Items.Clear()

                    'Get a handle on the first map item (row) in the layer
                    Dim MI As MapItem = MapLayer.Data.Items(0)

                    'Loop through the column names and add them to the listbox of column names
                    For i As Integer = 0 To MI.Attributes.Count - 1
                        Me.MapLayerColumnsCheckedListBoxControl.Items.Add(MI.Attributes(i).Name)
                    Next
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub MapLayerColumnsCheckedListBoxControl_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles MapLayerColumnsCheckedListBoxControl.ItemCheck
        Try
            'Clear the current labels pattern
            MapLayer.ShapeTitlesPattern = ""

            'Loop through the checked column names and build a labeling pattern for the layer
            For Each Item As CheckedListBoxItem In MapLayerColumnsCheckedListBoxControl.CheckedItems
                MapLayer.ShapeTitlesPattern = MapLayer.ShapeTitlesPattern.Trim & " {" & Item.Value.trim & "}"
            Next

            'Load the current pattern into the pattern text box
            Me.ShapeTitlesPatternTextBox.Text = MapLayer.ShapeTitlesPattern
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub ShapeTitlesPatternTextBox_TextChanged(sender As Object, e As EventArgs) Handles ShapeTitlesPatternTextBox.TextChanged
        'Alter the layer's labeling pattern
        MapLayer.ShapeTitlesPattern = Me.ShapeTitlesPatternTextBox.Text
    End Sub

    Private Sub LabelsFontButton_Click(sender As Object, e As EventArgs) Handles LabelsFontButton.Click
        'Change the layer's font
        If Me.LabelsFontDialog.ShowDialog = DialogResult.OK Then
            MapLayer.ItemStyle.Font = LabelsFontDialog.Font
        End If
    End Sub

    Private Sub LabelsColorButton_Click(sender As Object, e As EventArgs) Handles LabelsColorButton.Click
        'Change the map layer's font color
        If Me.LabelsColorDialog.ShowDialog = DialogResult.OK Then
            MapLayer.ItemStyle.TextColor = LabelsColorDialog.Color
        End If
    End Sub

    Private Sub HaloCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles HaloCheckBox.CheckedChanged
        'Show/hide the glow around text labels
        If Me.HaloCheckBox.Checked = True Then
            MapLayer.ItemStyle.TextGlowColor = Color.White
        Else
            MapLayer.ItemStyle.TextGlowColor = Color.Transparent
        End If
    End Sub
End Class