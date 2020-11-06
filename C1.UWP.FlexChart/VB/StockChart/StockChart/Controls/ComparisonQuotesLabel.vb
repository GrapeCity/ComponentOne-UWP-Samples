
Imports Windows.UI
Imports Windows.UI.Xaml.Documents

Class ComparisonQuotesLabel
    Inherits ContentControl
    Public Sub New()
    End Sub

    Public Property QuotesInfo() As IEnumerable(Of QuoteInfo)
        Get
            Return DirectCast(Me.GetValue(QuotesInfoProperty), IEnumerable(Of QuoteInfo))
        End Get
        Set
            Me.SetValue(QuotesInfoProperty, Value)
        End Set
    End Property


    Public Shared ReadOnly QuotesInfoProperty As DependencyProperty = DependencyProperty.Register("QuotesInfo", GetType(IEnumerable(Of QuoteInfo)), GetType(ComparisonQuotesLabel), New PropertyMetadata(Nothing, Sub(o, e)
                                                                                                                                                                                                                      Dim cql As ComparisonQuotesLabel = TryCast(o, ComparisonQuotesLabel)
                                                                                                                                                                                                                      If cql IsNot Nothing Then
                                                                                                                                                                                                                          cql.UpdateLabels()
                                                                                                                                                                                                                      End If
                                                                                                                                                                                                                  End Sub))

    Public Property DisplayMode() As DisplayMode
        Get
            Return DirectCast(Me.GetValue(DisplayModeProperty), DisplayMode)
        End Get
        Set
            Me.SetValue(DisplayModeProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly DisplayModeProperty As DependencyProperty = DependencyProperty.Register("DisplayMode", GetType(DisplayMode), GetType(ComparisonQuotesLabel), New PropertyMetadata(DisplayMode.Independent, Sub(o, e)
                                                                                                                                                                                                                          Dim cql As ComparisonQuotesLabel = TryCast(o, ComparisonQuotesLabel)
                                                                                                                                                                                                                          If cql IsNot Nothing Then
                                                                                                                                                                                                                              cql.UpdateLabels()
                                                                                                                                                                                                                          End If
                                                                                                                                                                                                                      End Sub))
    Private Sub UpdateLabels()
        If Me.QuotesInfo Is Nothing OrElse Me.QuotesInfo.Count() = 0 Then
            Me.Content = Nothing
            Return
        End If
        Dim text As New TextBlock()
        text.VerticalAlignment = VerticalAlignment.Stretch
        text.HorizontalAlignment = HorizontalAlignment.Right
        'text.FlowDirection = FlowDirection.RightToLeft;
        text.FontSize = Me.FontSize

        If Me.DisplayMode = DisplayMode.Comparison Then
            For Each quote As QuoteInfo In Me.QuotesInfo
                Dim format = String.Format((If(quote.Value >= 0, "+{0:P2}", "{0:P2}")), quote.Value)
                If quote.Value = 0 Then
                    format = "{0:P2}"
                End If

                Dim price As String = String.Format(format, quote.Value)

                Dim priceRun As New Run()
                priceRun.Text = price & Convert.ToString("  ")
                priceRun.Foreground = If(quote.Value >= 0, New SolidColorBrush(Color.FromArgb(255, 18, 155, 20)), New SolidColorBrush(Color.FromArgb(255, 255, 30, 0)))

                Dim codeRun As New Run()
                codeRun.Text = quote.Code + "  "
                codeRun.Foreground = New SolidColorBrush(quote.Color)

                text.Inlines.Add(codeRun)

                text.Inlines.Add(priceRun)
            Next
        Else
            Dim brush As Brush = New SolidColorBrush(Color.FromArgb(255, 136, 136, 136))

            Dim quote = Me.QuotesInfo.FirstOrDefault()

            If quote IsNot Nothing Then
                Dim volume As String = String.Format("Volume: {0:D0}", quote.Volume)
                Dim volumeRun As New Run()
                volumeRun.Text = volume & Convert.ToString("  ")
                volumeRun.Foreground = brush


                Dim price As String = String.Format("Price: {0:.##}", quote.Value)
                Dim priceRun As New Run()
                priceRun.Text = price & Convert.ToString("  ")
                priceRun.Foreground = brush


                Dim [date] As String = String.Format("{0:MMM dd, yyyy}", quote.[Date])
                Dim dateRun As New Run()
                dateRun.Text = [date] & Convert.ToString("  ")
                dateRun.Foreground = brush


                text.Inlines.Add(dateRun)
                text.Inlines.Add(priceRun)


                text.Inlines.Add(volumeRun)
            End If
        End If

        Me.Content = text
    End Sub


End Class
