Imports System.Reflection
Imports System.IO
Imports C1.Chart

Class Utils
    Public Shared Function IsVisible(series As ChartSeries) As Boolean
        Return (series.Visibility = SeriesVisibility.Plot OrElse series.Visibility = SeriesVisibility.Visible)
    End Function

    Public Shared Function Read(fileName As String) As String
        Dim text As String
        Dim csv As String = String.Format("CurrencyComparison.{0}", fileName)
        Dim asm As Assembly = GetType(CurrencyComparisonDemo).GetTypeInfo().Assembly
        Dim stream As Stream = asm.GetManifestResourceStream(csv)
        If stream IsNot Nothing Then
            Using reader As New StreamReader(stream)
                text = reader.ReadToEnd()
            End Using
        Else
            Dim filePath As String = String.Format("../../{0}", fileName)
            text = File.ReadAllText(filePath)
        End If
        Return text
    End Function
End Class