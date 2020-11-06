Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Device
    Public Shared Function IsWindowsPhoneDevice() As Boolean
        If Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            Return True
        End If
        Return False
    End Function
End Class
