Imports Windows.UI
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System


Module StringExtension

    <Extension()>
    Public Function ToColor(ByVal webColor As String) As Color
        Return New Color() With {
                .A = Convert.ToByte(webColor.Substring(1, 2), 16),
                .R = Convert.ToByte(webColor.Substring(3, 2), 16),
                .G = Convert.ToByte(webColor.Substring(5, 2), 16),
                .B = Convert.ToByte(webColor.Substring(7, 2), 16)
            }
    End Function

    <Extension()>
    Public Function PickOne(Of T)(ByVal rnd As Random, array As T()) As T
        Return array(rnd.[Next](array.Length))
    End Function

End Module
