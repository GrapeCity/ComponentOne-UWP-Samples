
Partial Public NotInheritable Class ucButtonGroup
    Inherits UserControl
    Public Sub New()
        Me.InitializeComponent()
    End Sub


#Region "DependencyProperty"
    Public Property SelectedIndex() As Integer
        Get
            Return CInt(Me.GetValue(SelectedIndexProperty))
        End Get
        Set
            Me.SetValue(SelectedIndexProperty, Value)
        End Set
    End Property

    Public Shared SelectedIndexProperty As DependencyProperty = DependencyProperty.Register("SelectedIndex", GetType(Integer), GetType(ucButtonGroup), New PropertyMetadata(0, New PropertyChangedCallback(Sub(o, e)
                                                                                                                                                                                                               Dim groups As ucButtonGroup = TryCast(o, ucButtonGroup)
                                                                                                                                                                                                               If groups IsNot Nothing Then
                                                                                                                                                                                                                   groups.SelectIndex()
                                                                                                                                                                                                               End If
                                                                                                                                                                                                           End Sub)))

#End Region

    Private Sub RadioButton_Checked(sender As Object, e As RoutedEventArgs)
        Dim index As Integer = -1
        For Each item As UIElement In Me.grid.Children
            index += 1
            If item.Equals(sender) Then
                Me.SelectedIndex = index
            End If
        Next
    End Sub

    Private Async Sub SelectIndex()
        If Me.grid.Children.Count > SelectedIndex AndAlso SelectedIndex >= 0 Then
            If Not Windows.ApplicationModel.DesignMode.DesignModeEnabled Then
                Await Me.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, Sub()
                                                                                                Dim rb = TryCast(Me.grid.Children(SelectedIndex), RadioButton)
                                                                                                If rb IsNot Nothing Then
                                                                                                    rb.IsChecked = True
                                                                                                End If
                                                                                            End Sub)
            End If
        End If
    End Sub
End Class
