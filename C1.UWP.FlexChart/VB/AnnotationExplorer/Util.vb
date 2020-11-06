Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Module Util
    Public ReadOnly Property IsWindowsDevice() As Boolean
        Get
            Return Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")
        End Get
    End Property

    <Extension>
    Public Function ToOADate([date] As DateTime) As Double
        Return TicksToOADate([date].Ticks)
    End Function

    Private Function TicksToOADate(value As Long) As Double
        If value = 0L Then
            Return 0.0
        End If
        If value < 864000000000L Then
            value += 599264352000000000L
        End If
        Dim num As Long = (value - 599264352000000000L) / 10000L
        If num < 0L Then
            Dim num2 As Long = num Mod 86400000L
            If num2 <> 0L Then
                num -= (86400000L + num2) * 2L
            End If
        End If
        Return CType(num, Double) / 86400000.0
    End Function
End Module