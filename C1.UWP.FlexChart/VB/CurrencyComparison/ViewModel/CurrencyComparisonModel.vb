Imports Windows.UI
Imports System.Collections.Generic
Imports System.Linq
Imports Windows.UI.Xaml.Markup

Class CurrencyComparisonModel
    Private _dictMeasureMode As Dictionary(Of String, MeasureMode)
    Private _dictTimeFrame As Dictionary(Of String, TimeFrame)
    Private _currencies As List(Of Currency)
    Private _chartColors As List(Of Color)

    Public ReadOnly Property DictMeasureMode() As Dictionary(Of String, MeasureMode)
        Get
            If _dictMeasureMode Is Nothing Then
                _dictMeasureMode = New Dictionary(Of String, MeasureMode)()
                _dictMeasureMode.Add(Strings.ExchangeRate, MeasureMode.ExchangeRate)
                _dictMeasureMode.Add(Strings.PercentageChange, MeasureMode.PercentageChange)
                _dictMeasureMode.Add(Strings.Both, MeasureMode.Both)
            End If

            Return _dictMeasureMode
        End Get
    End Property

    Public ReadOnly Property Currencies() As List(Of Currency)
        Get
            If _currencies Is Nothing Then
                Dim c As String() = Strings.Currencies.Split(","c)
                _currencies = New List(Of Currency)()
                c.ToList().ForEach(Sub(cr)
                                       _currencies.Add(New Currency() With {
                                                    .DisplayName = cr.Split("-"c)(0).Trim(),
                                                    .Symbol = cr.Split("-"c)(1).Trim()
                                                })

                                   End Sub)
            End If

            Return _currencies
        End Get
    End Property

    Public ReadOnly Property ChartColors() As List(Of Color)
        Get
            If _chartColors Is Nothing Then
                _chartColors = New List(Of Color)()
                _chartColors.Add(CType(XamlBindingHelper.ConvertValue(GetType(Color), "#2a9fd6"), Color))
                _chartColors.Add(CType(XamlBindingHelper.ConvertValue(GetType(Color), "#77b300"), Color))
                _chartColors.Add(CType(XamlBindingHelper.ConvertValue(GetType(Color), "#9933cc"), Color))
                _chartColors.Add(CType(XamlBindingHelper.ConvertValue(GetType(Color), "#ff8800"), Color))
                _chartColors.Add(CType(XamlBindingHelper.ConvertValue(GetType(Color), "#cc0000"), Color))
                _chartColors.Add(CType(XamlBindingHelper.ConvertValue(GetType(Color), "#00cca3"), Color))
                _chartColors.Add(CType(XamlBindingHelper.ConvertValue(GetType(Color), "#3d6dcc"), Color))
                _chartColors.Add(CType(XamlBindingHelper.ConvertValue(GetType(Color), "#525252"), Color))
                _chartColors.Add(CType(XamlBindingHelper.ConvertValue(GetType(Color), "#323232"), Color))
            End If

            Return _chartColors
        End Get
    End Property

    Public ReadOnly Property DictTimeFrame() As Dictionary(Of String, TimeFrame)
        Get
            If _dictTimeFrame Is Nothing Then
                _dictTimeFrame = New Dictionary(Of String, TimeFrame)()
                _dictTimeFrame.Add("5D", TimeFrame.FiveDays)
                _dictTimeFrame.Add("10D", TimeFrame.TenDays)
                _dictTimeFrame.Add("1M", TimeFrame.OneMonth)
                _dictTimeFrame.Add("6M", TimeFrame.SixMonths)
                _dictTimeFrame.Add("1Y", TimeFrame.OneYear)
                _dictTimeFrame.Add("5Y", TimeFrame.FiveYears)
                _dictTimeFrame.Add("10Y", TimeFrame.TenYears)
            End If

            Return _dictTimeFrame
        End Get
    End Property

End Class