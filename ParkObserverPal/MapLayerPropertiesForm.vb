Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraMap



Public Class MapLayerPropertiesForm

    Dim MapLayer As VectorItemsLayer = Nothing

    ''' <summary>
    ''' Creates a new MapLayerPropertiesForm.
    ''' </summary>
    ''' <param name="VectorItemsLayer">VectorLayer to be edited.</param>
    Public Sub New(VectorItemsLayer As VectorItemsLayer)
        ' This call is required by the designer.
        InitializeComponent()

        Try
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

                'Determine if we have MapDots or MapBubbles
                Me.MarkerSymbolListBox.Items.Clear()

                If MapLayer.Data.Items.Count > 0 Then
                    Dim FirstLayerItem As MapItem = MapLayer.Data.Items(0)
                    Debug.Print(FirstLayerItem.GetType.Name)
                    If FirstLayerItem.GetType.Name = "MapBubble" Then
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
                    ElseIf FirstLayerItem.GetType.name = "MapDot" Then
                        'Load the mark type options into the selector list box
                        With Me.MarkerSymbolListBox.Items
                            .Add(MapDotShapeKind.Circle.ToString)
                            .Add(MapDotShapeKind.Rectangle.ToString)
                        End With
                    End If
                End If


            Else
                Dim Message As String = "Map layer not found."
                MsgBox(Message, MsgBoxStyle.Information)
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

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
        Try
            If Me.LabelsFontDialog.ShowDialog = DialogResult.OK Then
                MapLayer.ItemStyle.Font = LabelsFontDialog.Font
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub LabelsColorButton_Click(sender As Object, e As EventArgs) Handles LabelsColorButton.Click
        'Change the map layer's font color
        Try
            If Me.LabelsColorDialog.ShowDialog = DialogResult.OK Then
                MapLayer.ItemStyle.TextColor = LabelsColorDialog.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub HaloCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles HaloCheckBox.CheckedChanged
        'Show/hide the glow around text labels
        Try
            If Me.HaloCheckBox.Checked = True Then
                MapLayer.ItemStyle.TextGlowColor = Color.White
            Else
                MapLayer.ItemStyle.TextGlowColor = Color.Transparent
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub


    ''' <summary>
    ''' Returns the equivalent DevExpress MarkerType for the marker type selected in MarkerSymbolListBox
    ''' </summary>
    ''' <returns>MarkerType</returns>
    Private Function GetCurrentMarker() As MarkerType
        Dim Symbology As String = Me.MarkerSymbolListBox.Text.Trim
        Dim MarkerType As MarkerType = MarkerType.Circle
        Try
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
            ElseIf Symbology = "Square" Or Symbology = "Rectangle" Then
                MarkerType = MarkerType.Square
            ElseIf Symbology = "Star5" Then
                MarkerType = MarkerType.Star5
            ElseIf Symbology = "Star6" Then
                MarkerType = MarkerType.Star6
            ElseIf Symbology = "Star8" Then
                MarkerType = MarkerType.Star8
            ElseIf Symbology = "Triangle" Then
                MarkerType = MarkerType.Triangle
            ElseIf Symbology = "Rectangle" Then
                MarkerType = MarkerType.Square
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return MarkerType
    End Function

    ''' <summary>
    ''' Changes the symbology of the map layer
    ''' </summary>
    ''' <param name="MapLayer">Map layer. VectorItemsLayer.</param>
    Private Sub ChangeSymbology(MapLayer As VectorItemsLayer)
        Try
            'Make sure we have a map layer
            If Not MapLayer Is Nothing Then

                'Find out if we have a MapBubble or MapDot layer
                If MapLayer.Data.Items.Count > 0 Then

                    Dim ItemType As String = MapLayer.Data.Items(0).GetType.Name
                    MsgBox("itemtype: " & ItemType & " (ChangeSymbology)")

                    'Get the selected marker type
                    Dim CurrentMarkerType As MarkerType = GetCurrentMarker()
                    Dim CurrentShapeKind As MapDotShapeKind = MapDotShapeKind.Circle

                    'Loop through each map item and change the properties
                    For Each Item As MapItem In MapLayer.Data.Items

                        Item.Fill = Me.MarkerColorPickEdit.Color
                        Item.Stroke = Me.MarkerBorderColorPickEdit.Color
                        If Item.GetType.Name = "MapBubble" Then
                            Dim CurrentItem As MapBubble = TryCast(Item, MapBubble)
                            If Not CurrentItem Is Nothing Then
                                With CurrentItem

                                    .MarkerType = CurrentMarkerType
                                    .Size = Me.MarkerSizeNumericUpDown.Value
                                End With
                            End If
                        ElseIf Item.GetType.Name = "MapDot" Then
                            Dim CurrentItem As MapDot = TryCast(Item, MapDot)
                            If Not CurrentItem Is Nothing Then
                                If CurrentMarkerType = MarkerType.Square Then CurrentShapeKind = MapDotShapeKind.Rectangle
                                With CurrentItem
                                    .ShapeKind = CurrentShapeKind
                                    .Size = Me.MarkerSizeNumericUpDown.Value
                                End With
                            End If
                        End If
                    Next
                    'End If
                End If
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