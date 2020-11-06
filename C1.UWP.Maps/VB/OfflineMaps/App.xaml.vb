Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.ApplicationModel
Imports Windows.ApplicationModel.Activation
Imports Windows.Foundation
Imports Windows.Foundation.Collections
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Navigation

Partial NotInheritable Class App
    Inherits Application

    Public Sub New()
        C1.UWP.LicenseManager.Key = "AB4BHgIeB3dPAGYAZgBsAGkAbgBlAE0AYQBwAHMAGULe8pCPDYb4TMIQrlEf1pye" & "TsfwKyDnnGTsZ3yQX2lAb+vsKu6f/IF4/R1jrSbz1wha9FLJC34yfUBGkm5SKazS" & "dYMMjQBROzvJ3JSdpkQb1nFBtNc0Lz0qqmMuTiin41P0qMyMDfKRUj9tvUre5cF0" & "XtnNg3TAXJwrPy8YUn0DqXUoAm2hzgvBVtKMeJ1jt0SQrNuvmOtvkb6UB7Q8dO08" & "yer/dYOq7JpYwYyMDwEeZsW0z+N98H0QMtafQJYKWhFP4wAJGJFblJtx66SO7wZC" & "AHOXvrJwEMWizm4Bs55sZoV+xPwLPyxxH1hzHCm7AfgaSmz7SuxnjU+W2WSXyIcV" & "8B3BokGYd+UiwoL0poywvjkNPtDVoS+sAZaCiyqyI85YRnNeLhocKts1segaIKKG" & "7/TPgpAxEToWEdeOvPT0w1mIeuPVm9c432PuUmVLFkblVidH2TWpHJC1X7lRr1MW" & "T/xwE72SFOsj0vXzKN49uvaOKF+MESV6gbjr+OTh0wOWFnlPXkLafoCUagCT/TKh" & "uChGxlderG2Ad5yxkwzxNQ1VSZmXHMFiNT2Z0Mw85FKUiK7n4G46XvinSphh0FGV" & "A4lVEIUs/zWzE4VgCcn+uXD5hw8NDqA2SlSnKygv1ahfj6dNNvmQw6uMUlpZrOoV" & "nvX2P7pq5Bcn7Y7o3mswggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9EJSLMA0G" & "CSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVyaVNpZ24s" & "IEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5BgNVBAsT" & "MlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20vcnBhIChj" & "KTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmluZyAyMDEw" & "IENBMB4XDTE0MTIxMTAwMDAwMFoXDTE1MTIyMjIzNTk1OVowgYYxCzAJBgNVBAYT" & "AkpQMQ8wDQYDVQQIEwZNaXlhZ2kxGDAWBgNVBAcTD1NlbmRhaSBJenVtaS1rdTEX" & "MBUGA1UEChQOR3JhcGVDaXR5IGluYy4xGjAYBgNVBAsUEVRvb2xzIERldmVsb3Bt" & "ZW50MRcwFQYDVQQDFA5HcmFwZUNpdHkgaW5jLjCCASIwDQYJKoZIhvcNAQEBBQAD" & "ggEPADCCAQoCggEBAMEC9splW7KVpAqRB6VVB7XJm8+a60x78HZWNmvAjs/ermp7" & "pbh8M9HYuEVTRj8H4baXxFYq4i75e5kNr7s+nGbJ5UfM6CldqbeRsQ4zvRb6npfr" & "tcOBwfYOx0woeYQfI6VzLVzhPbGjUDK6qdHZLf/EcvSIKvRbu3ILOE3kuux07gQk" & "b++rrSBUyJKXU8nW8c+K+9sfWqHYPb8FF2IazWxhmfIdIoDNKyjr3r/wIn3jQejp" & "qfamiHNsU/O26KS0EcvCS5CFOKDT6vvdnAkek3kyLWef+ca/cbFo74vawYGtmw2w" & "zw/hcwlANIQaCAxz+5JHQZ3SEg8LLSZ+C8E4T+8CAwEAAaOCAY0wggGJMAkGA1Ud" & "EwQCMAAwDgYDVR0PAQH/BAQDAgeAMCsGA1UdHwQkMCIwIKAeoByGGmh0dHA6Ly9z" & "Zi5zeW1jYi5jb20vc2YuY3JsMGYGA1UdIARfMF0wWwYLYIZIAYb4RQEHFwMwTDAj" & "BggrBgEFBQcCARYXaHR0cHM6Ly9kLnN5bWNiLmNvbS9jcHMwJQYIKwYBBQUHAgIw" & "GQwXaHR0cHM6Ly9kLnN5bWNiLmNvbS9ycGEwEwYDVR0lBAwwCgYIKwYBBQUHAwMw" & "VwYIKwYBBQUHAQEESzBJMB8GCCsGAQUFBzABhhNodHRwOi8vc2Yuc3ltY2QuY29t" & "MCYGCCsGAQUFBzAChhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNydDAfBgNVHSME" & "GDAWgBTPmanqeyb0S8mOj9fwBSbv49KnnTAdBgNVHQ4EFgQUAFrwraXUeDX1hBKo" & "LAUO+FYbjo4wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisGAQQBgjcCARsECDAGAQEA" & "AQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCIwphaN45b5ViKsRfCA6hbVeqMhNCJmL64" & "mqxdYvw3gsF4oOCDoiM6kWhy1NoUd2Lpcr9PjfGJ55ZX4sZlqoxeflTpHgnX8MPJ" & "uKpDBsk7WkhiEu65fBwb+g9wQHMMfgY0gjHIAQ2ZEf2PJ6TTSFcvj24wh73dsyqc" & "mj290fpwDtHaF2jE5pq/tQBOJ8vDkN46wt4qMhG6nIpOgc9KngyLLdEO7V34KM1N" & "b+sN9JkqTWXNoNqlOf7QjYHwlw7Ku7W3kIGK+f1kP1xqTBpXwsBE5sLlnujP+JAq" & "V8aKlBJDKRI3IhlrG9CJUmqFNhmZ2f5QE5jAvPQeXevLnMYiqJrgMIICxDCCAayg" & "AwIBAgIEDu7u7jANBgkqhkiG9w0BAQUFADAkMSIwIAYDVQQDDBlHQy1VV1AgSW50" & "ZXJuYWwgRGV2ZWxvcGVyMB4XDTE4MDcxNjEzMzMzMVoXDTM4MDcxNjEzMzMzMVow" & "JDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjCCASIwDQYJKoZI" & "hvcNAQEBBQADggEPADCCAQoCggEBALLE2j3sUmzfFYO9NPoNhnkMrhtMu1V2ND/n" & "ev47QN77rq2xE+BYOI9kpk5YaAmB9L7x+Vh+0OjYo+criQg5wsgoBveH4SjWls9v" & "XEz8Cj+OCXL0qtBbyF6Sd+ua5B5f5fi8KBDqWMCKYG6y8mX9Ny7E8Otsj2T+Fyk0" & "qOC36SQXOpE0WTw+/I82kSpdOGstI9D+k7d9W6le6FKs/1fbfrOX9cK6pfyEiDOy" & "9DM+qcJM/VN2ebTV+44/TH653geXKRY4dzvvaNRsYnjcsTOUCpc9SmKIriIiCXGL" & "0Hcjt+Rz+cQi3r33Dte58JAd2pRUjORR3rorDjyx/mtGQIR0Tp0CAwEAATANBgkq" & "hkiG9w0BAQUFAAOCAQEATuGz8mXXueY7OOEaHQUuOfI7X6fdoikZfnr/+sJF6Dsr" & "3+HP5RvOXJkxO2rlfelPldXVJ+CGzW1vyTtuvp5C/+uuZTgufcGS+1AZwekk/HlX" & "Z3SBRtDMgLHGoZP+xIQcTwtUUaXbo724ShNd8TpMLF0zg0ZUnxkKEuM2YwZL5j+l" & "+Gfceje+G3I92/tmKn68qu48dbR//fB8kHllh+N53BxWuaEzNbW8wQ/aXtcW4zYQ" & "5zomF3wLmVKq8a2xpro3nAhDDS4itHRngQsGYX5fjUKIVqqBgKi/1UlIB1nWD5Eo" & "whgZpwn9Wldb5O0hFK9DLRK41BY4V7VND1ajG1g+XQ=="
        Me.InitializeComponent()
        AddHandler Me.Suspending, AddressOf OnSuspending
    End Sub

    Protected Overrides Sub OnLaunched(ByVal e As LaunchActivatedEventArgs)
        Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

        If rootFrame Is Nothing Then
            rootFrame = New Frame()
            AddHandler rootFrame.NavigationFailed, AddressOf OnNavigationFailed

            If e.PreviousExecutionState = ApplicationExecutionState.Terminated Then
            End If

            Window.Current.Content = rootFrame
        End If

        If e.PrelaunchActivated = False Then

            If rootFrame.Content Is Nothing Then
                rootFrame.Navigate(GetType(MainPage), e.Arguments)
            End If

            Window.Current.Activate()
        End If
    End Sub

    Private Sub OnNavigationFailed(ByVal sender As Object, ByVal e As NavigationFailedEventArgs)
        Throw New Exception("Failed to load Page " & e.SourcePageType.FullName)
    End Sub

    Private Sub OnSuspending(ByVal sender As Object, ByVal e As SuspendingEventArgs)
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        deferral.Complete()
    End Sub
End Class
