Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports Microsoft.Toolkit.Uwp.Notifications
Imports Windows.UI.Notifications

Public Class AppHelper
    Friend Shared Function IsWindowsPhoneDevice() As Boolean
        If Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            Return True
        End If
        Return False
    End Function
End Class

Public Class ToastNotificationsHelper
    Public Shared Sub ShowToastNotification(subject As String, names As String())
        Dim toastInfomation As String = [String].Format(Strings.ToastSubjectFormat, subject)
        If names.Length < 5 Then
            toastInfomation += [String].Join(Strings.ToastJoinSeprator, names) + Strings.ToastPeriod
            Dim index As Integer = toastInfomation.LastIndexOf(Strings.ToastJoinSeprator)
            If index > 0 Then
                toastInfomation = toastInfomation.Remove(index, 1)
                toastInfomation = toastInfomation.Insert(index, Strings.ToastAnd)
            End If
        Else
            Dim others As Integer = names.Length - 4
            toastInfomation += [String].Format(Strings.ToastNamesFormat, names) + others.ToString() + Strings.ToastPeopleEnd
        End If

        Dim generic As ToastBindingGeneric = New ToastBindingGeneric()
        generic.Children.Add(New AdaptiveText() With {.Text = Strings.ToastTitle})
        generic.Children.Add(New AdaptiveText() With {.Text = toastInfomation})

        Dim content As New ToastContent() With {
            .Visual = New ToastVisual() With {
                .BindingGeneric = generic
            }
        }

        Dim toast As New ToastNotification(content.GetXml())
        ToastNotificationManager.CreateToastNotifier().Show(toast)
    End Sub
End Class