Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports Windows.ApplicationModel.Activation
Imports Windows.ApplicationModel
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

''' <summary>
''' Provides application-specific behavior to supplement the default Application class.
''' </summary>
Partial NotInheritable Class App
    Inherits Application
    ''' <summary>
    ''' Initializes the singleton application object.  This is the first line of authored code
    ''' executed, and as such is the logical equivalent of main() or WinMain().
    ''' </summary>
    Public Sub New()
        C1.UWP.LicenseManager.Key =
            "ACgBKAIoB4FMAGkAbgBlAE0AYQByAGsAZQByAFMAYQBtAHAAbABlACTQtZjS3BS1" +
            "JYnK1U3mMdeAt6c62vzcZ1+GwZSUJf7Q4mqXuNdDFImq41aKeY+HxN+psY7uB7jC" +
            "afqr20Nqw5aDg5MLLJXFQmTxqK2C4ZwaBHCQ7CzLXHLjh2hURM1Es/l4/5aYBT1R" +
            "WjBpaLjUFaRk6/MOS5KXKLwmTJmDRIJcyITygjwTB6+Vl6oE6kmIHh/kGAx06Biz" +
            "DJwM/1HRsphxYd1WSRaRWGE77xwi54ZS16nbe0wHk1uGHfYQM4oUB3U9tdsiJ5nP" +
            "hSdxY/SlbTUL4wxcRPa6jYasfXB4Hd+mLWoNES8r6XffG2SLndyUZLjXNUfzK+R8" +
            "o7zzLvmMM3suGarni359hRUQwUNAZLDrYxyxwg4CdYEpg4I+lsl15uhvJkdr4rpq" +
            "quQ6bZSB+9IIptJKOGEsv1Emlm3BOk5pLxilLxcUVct+0wsz2XDJJGBOSGC4wyfK" +
            "2P7e5mpIN6n8MqiTKDUN5vfdFw7yoRdz8GMhUqBMBZVkamHJ1iYbdxiIWQss6LR6" +
            "xZB7zQ1ureFmMbBiQP90I5Zlz5xhnfxSSjMSFqgKu1WSkBMpYYifvbRge9oTZCM5" +
            "HGAdIlzSB6U8LAmfGi8vstv/BaoUlML5/Duxma1EGd3Newj0rVf0kcPipPoT1YD9" +
            "7jnK84nXTALn4TEcN/sCSTI7KVLd8vVKMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW" +
            "2ybGvRCUizANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoT" +
            "DlZlcmlTaWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3Jr" +
            "MTswOQYDVQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24u" +
            "Y29tL3JwYSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNp" +
            "Z25pbmcgMjAxMCBDQTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGG" +
            "MQswCQYDVQQGEwJKUDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkg" +
            "SXp1bWkta3UxFzAVBgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29s" +
            "cyBEZXZlbG9wbWVudDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqG" +
            "SIb3DQEBAQUAA4IBDwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2" +
            "VjZrwI7P3q5qe6W4fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3" +
            "kbEOM70W+p6X67XDgcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7ty" +
            "CzhN5LrsdO4EJG/vq60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso" +
            "696/8CJ940Ho6an2pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3Gx" +
            "aO+L2sGBrZsNsM8P4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGN" +
            "MIIBiTAJBgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAc" +
            "hhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG" +
            "+EUBBxcDMEwwIwYIKwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUG" +
            "CCsGAQUFBwICMBkMF2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoG" +
            "CCsGAQUFBwMDMFcGCCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3Nm" +
            "LnN5bWNkLmNvbTAmBggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5j" +
            "cnQwHwYDVR0jBBgwFoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa" +
            "8K2l1Hg19YQSqCwFDvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3" +
            "AgEbBAgwBgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOo" +
            "W1XqjITQiZi+uJqsXWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqM" +
            "Xn5U6R4J1/DDybiqQwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hX" +
            "L49uMIe93bMqnJo9vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4M" +
            "iy3RDu1d+CjNTW/rDfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LA" +
            "RObC5Z7oz/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia" +
            "4DCCAsQwggGsoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZ" +
            "R0MtVVdQIEludGVybmFsIERldmVsb3BlcjAeFw0xNzAxMDEwOTIwNTZaFw0zNzEy" +
            "MzEwOTIwNTZaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIw" +
            "ggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCFt5uOuJNsLZ4ZDa4IevbC" +
            "QSnWOiVhQJw5ISnEQ2IQ2FqifQ8OnvnbmMYgAd0EDk6TEgBrfj40boP0GrOatPld" +
            "kRtY/Uu0uIhCHzrlGqEIPzUQzz6RBtuMCr0gGM4LhOTjhqyGHg16c+/QHisfPCV9" +
            "YuvvtAKuI+KIlXN6/cOqwpUtnok8rgCjkt14ghoVm/ecAfFIxU19Rds+tp7Korg/" +
            "SLsQAYRlB8S1BZH4668D4qBzEe1sgydXyT9gx4pzZm9RwuOsvAT7sOmtpML7tpHu" +
            "0BMwmeB2eTbu43GAF0BFtfGXj6TJkUY8l2lGcM49hCOnQUk/c1ujjHUZxVpxyDOd" +
            "AgMBAAEwDQYJKoZIhvcNAQEFBQADggEBAGLqoZQU+jJRd+0oAaXnZkafayC3LvIv" +
            "hFnZUhnuLht3ahbzIuicEt5rh/cx83ySgdWiwYOt/Zb8d+J48aY5TElQOpuF5fVe" +
            "4dqqG4enqwDphZNLCCb3EmtYTBoP0G3hjmwlYxq1ewEv00R+OVqREVweBPfFb8sI" +
            "KceDSNM8GiZ9B2OTWtIFiNS9Z4Q+p2iZksnB4i4iEGP29EPJEU+wnrlhxBSlbyoX" +
            "sRv+H0qZJC3I7/XgkaS3LqRvZx+DDui8ZvdFof265w5oXyPZ3Q82sRYydnYvvhSD" +
            "sKp2bEhdjMqKwpKAi53eDNii/nBEKWDvDeLj5ysB4VuDoNhLzuLTm40="
        Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(Microsoft.ApplicationInsights.WindowsCollectors.Metadata Or Microsoft.ApplicationInsights.WindowsCollectors.Session)
        Me.InitializeComponent()
    End Sub

    ''' <summary>
    ''' Invoked when the application is launched normally by the end user.  Other entry points
    ''' will be used such as when the application is launched to open a specific file.
    ''' </summary>
    ''' <param name="e">Details about the launch request and process.</param>
    Protected Overrides Sub OnLaunched(e As LaunchActivatedEventArgs)
        Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

        ' Do not repeat app initialization when the Window already has content,
        ' just ensure that the window is active
        If rootFrame Is Nothing Then
            ' Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = New Frame()

            AddHandler rootFrame.NavigationFailed, AddressOf OnNavigationFailed

            'TODO: Load state from previously suspended application
            If e.PreviousExecutionState = ApplicationExecutionState.Terminated Then
            End If

            ' Place the frame in the current Window
            Window.Current.Content = rootFrame
        End If

        If e.PrelaunchActivated = False Then
            If rootFrame.Content Is Nothing Then
                ' When the navigation stack isn't restored navigate to the first page,
                ' configuring the new page by passing required information as a navigation
                ' parameter
                rootFrame.Navigate(GetType(MainPage), e.Arguments)
            End If
            ' Ensure the current window is active
            Window.Current.Activate()
        End If
    End Sub

    ''' <summary>
    ''' Invoked when Navigation to a certain page fails
    ''' </summary>
    ''' <param name="sender">The Frame which failed navigation</param>
    ''' <param name="e">Details about the navigation failure</param>
    Sub OnNavigationFailed(sender As Object, e As NavigationFailedEventArgs)
        Throw New Exception("Failed to load Page " + e.SourcePageType.FullName)
    End Sub

    ''' <summary>
    ''' Invoked when application execution is being suspended.  Application state is saved
    ''' without knowing whether the application will be terminated or resumed with the contents
    ''' of memory still intact.
    ''' </summary>
    ''' <param name="sender">The source of the suspend request.</param>
    ''' <param name="e">Details about the suspend request.</param>
    Private Sub OnSuspending(sender As Object, e As SuspendingEventArgs) Handles Me.Suspending
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        'TODO: Save application state and stop any background activity
        deferral.Complete()
    End Sub
End Class