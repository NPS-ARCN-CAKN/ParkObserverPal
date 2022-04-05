Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraMap



Public Class MapLayerPropertiesForm

    Dim MapLayer As VectorItemsLayer = Nothing

    Public Sub New(VectorItemsLayer As VectorItemsLayer)
        ' This call is required by the designer.
        InitializeComponent()

        MapLayer = VectorItemsLayer 'Make the private VectorItemsLayer available to other functions as a global MapLayer

        'Make sure we have a valid layer
        If Not MapLayer Is Nothing Then
            Me.Text = MapLayer.Name & " Properties"

            'Declare the map layer to work with
            MapLayer = VectorItemsLayer

            'DevEx sets the shape titles pattern by default to {NAME}, clear it so we can use our own
            MapLayer.ShapeTitlesPattern = ""

            'Show the map layers name in the text box
            Me.LayerNameLabel.Text = MapLayer.Name

            'Load the columns into the chooser listbox so user can choose columns for labels
            LoadMapItemAttributesIntoListBox(MapLayer)

            'Load the map layer into the advanced map layer property grid control
            Me.MapLayerPropertyGridControl.SelectedObject = MapLayer

            'Load the mark type options into the selector list box
            With Me.MarkerSymbolListBox.Items
                .Add(MarkerType.Circle.ToString)
                .Add(MarkerType.Cross.ToString)
                .Add(MarkerType.Diamond.ToString)
                .Add(MarkerType.Hexagon.ToString)
                .Add(MarkerType.InvertedTriangle.ToString)
                .Add(MarkerType.Pentagon.ToString)
                .Add(MarkerType.Plus.ToString)
                .Add(MarkerType.Square.ToString)
                .Add(MarkerType.Star5.ToString)
                .Add(MarkerType.Star6.ToString)
                .Add(MarkerType.Star8.ToString)
                .Add(MarkerType.Triangle.ToString)
            End With




        Else
            Dim Message As String = "Map layer is nothing."
            MsgBox(Message, MsgBoxStyle.Information)
            Me.Close()
        End If


    End Sub

    ''' <summary>
    ''' Loads the map layers column names into the list box so the user can check off column names for labeling
    ''' </summary>
    ''' <param name="MapLayer"></param>
    Private Sub LoadMapItemAttributesIntoListBox(MapLayer As VectorItemsLayer)
        Try
            'Make sure we have a map layer to work with
            If Not MapLayer Is Nothing Then
                'Make sure there is map layer data
                If Not MapLayer.Data Is Nothing Then
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



    Private Function GetCurrentMarker() As MarkerType
        Dim Symbology As String = Me.MarkerSymbolListBox.Text.Trim
        Dim MarkerType As MarkerType = MarkerType.Circle
        If Symbology = "Circle" Then
            MarkerType = MarkerType.Circle
        ElseIf Symbology = "Cross" Then
            MarkerType = MarkerType.Cross
        ElseIf Symbology = "Diamond" Then
            MarkerType = MarkerType.Diamond
        ElseIf Symbology = "Hexagon" Then
            MarkerType = MarkerType.Hexagon
        ElseIf Symbology = "InvertedTriangle" Then
            MarkerType = MarkerType.InvertedTriangle
        ElseIf Symbology = "Pentagon" Then
            MarkerType = MarkerType.Pentagon
        ElseIf Symbology = "Plus" Then
            MarkerType = MarkerType.Plus
        ElseIf Symbology = "Square" Then
            MarkerType = MarkerType.Square
        ElseIf Symbology = "Star5" Then
            MarkerType = MarkerType.Star5
        ElseIf Symbology = "Star6" Then
            MarkerType = MarkerType.Star6
        ElseIf Symbology = "Star8" Then
            MarkerType = MarkerType.Star8
        ElseIf Symbology = "Triangle" Then
            MarkerType = MarkerType.Triangle
        End If
        Return MarkerType
    End Function

    ''' <summary>
    ''' Changes the symbology of the map layer
    ''' </summary>
    ''' <param name="MapLayer">Map layer. VectorItemsLayer.</param>
    Private Sub ChangeSymbology(MapLayer As VectorItemsLayer)
        Try
            If Not MapLayer Is Nothing Then

                'If Not MapLayer.Data Is Nothing Then
                Dim CurrentMarkerType As MarkerType = GetCurrentMarker()

                'Loop through each map item and change the properties
                For Each Item As MapBubble In MapLayer.Data.Items
                    Item.MarkerType = CurrentMarkerType
                    Item.Fill = Me.MarkerColorPickEdit.Color
                    Item.Stroke = Me.MarkerBorderColorPickEdit.Color
                    Item.Size = Me.MarkerSizeNumericUpDown.Value
                Next
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub MarkerSizeNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles MarkerSizeNumericUpDown.ValueChanged
        ChangeSymbology(MapLayer)
    End Sub

    Private Sub MarkerColorPickEdit_TextChanged(sender As Object, e As EventArgs) Handles MarkerColorPickEdit.TextChanged
        ChangeSymbology(MapLayer)
    End Sub
    Private Sub MarkerSymbolListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MarkerSymbolListBox.SelectedIndexChanged
        ChangeSymbology(MapLayer)
    End Sub

    Private Sub MarkerBorderColorPickEdit_TextChanged(sender As Object, e As EventArgs) Handles MarkerBorderColorPickEdit.TextChanged
        ChangeSymbology(MapLayer)
    End Sub
End Class