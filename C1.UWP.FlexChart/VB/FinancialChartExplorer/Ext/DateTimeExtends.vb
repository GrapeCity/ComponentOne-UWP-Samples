
Public Module DateTimeExtends

    <Extension()>
    Public Function ToOADate([date] As DateTime) As Double
        Return TicksToOADate([date].Ticks)
    End Function

    <Extension()>
    Public Function FromOADate([date] As DateTime, val As Double) As DateTime
        Return New DateTime(DoubleDateToTicks(val), DateTimeKind.Unspecified)
    End Function


    Private Function TicksToOADate(value As Long) As Double
        If value = 0L Then
            Return 0.0
        End If
        If value < 864000000000L Then
            value += 599264352000000000L
        End If
        If value < 31241376000000000L Then
            Throw New OverflowException("Arg_OleAutDateInvalid")
        End If
        Dim num As Long = (value - 599264352000000000L) / 10000L
        If num < 0L Then
            Dim num2 As Long = num Mod 86400000L
            If num2 <> 0L Then
                num -= (86400000L + num2) * 2L
            End If
        End If
        Return CDbl(num) / 86400000.0
    End Function

    Friend Function DoubleDateToTicks(value As Double) As Long
        If value >= 2958466.0 OrElse value <= -657435.0 Then
            Throw New ArgumentException("Arg_OleAutDateInvalid")
        End If
        Dim num As Long = CLng(value * 86400000.0 + (If((value >= 0.0), 0.5, -0.5)))
        If num < 0L Then
            num -= (num Mod 86400000L) * 2L
        End If
        num += 59926435200000L
        If num < 0L OrElse num >= 315537897600000L Then
            Throw New ArgumentException("Arg_OleAutDateScale")
        End If
        Return num * 10000L
    End Function
End Module
