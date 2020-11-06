Imports TileSamples.Common

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
        Me.InitializeComponent()
        AddHandler Me.Suspending, AddressOf OnSuspending
        C1.UWP.LicenseManager.Key =
            "AB4BHgIeB3dUAGkAbABlAFMAYQBtAHAAbABlAHMAe912FVRaJ3cVm7hYHxCEd1Y7" +
            "C+2OB9VSB8hRL5E0tDzystuL+/WmLew3KOEPFS0YgN4W1kUllQvx7WXU+Sn7D7tj" +
            "8l76sQvHZ1fV75bm5cR1ZRfQp+NHxUUaPEUI4EnGFddG/zxZDFoSERZfLDevNFxt" +
            "v9RAG9p2qr5t485tPXdcwPNsuGrpY3qsIV/SNwi+xLg5oHsgWauKVRau09kHmh1T" +
            "PKy9R5ccdEHOma93lkiJpS5MabxHftx8dEELx0Fb9hJj9e5Wp5WyduiCUe+HaB1p" +
            "CpVX6nYt6TSPYmBlOOGbiEzq5hobCPtwIzEg58izce2tYr3pk8BZ8KyUn+2ulDXj" +
            "f3VzTqY3m8hZ/Yrm3/JGo7PbqjfbXGjQ/BPuJ7R969bexb2GA062wAw7ocMLl/GR" +
            "U+g+sjKr4dCPoRpA1vfCwA9t/rMUaN9sri9AAu8Miqf2pjVTKAL4mzqnP08AgGoW" +
            "YJjrITcVAsrlwbTsiCZRJxB4GuHN74fIEk/jC4xTBtGz0mqt+GXM3NhmrWU1ndA+" +
            "JalYZalNSdw9DXgzCJjS+90jcpR/D7N145hGRsCdT0D4/EYm5re8wz/xcw0gQpFf" +
            "nhql3g0vtHFsqBNB74kaLO8vPX5weO5nTrdE9Vc2ru0YhwqF2Y0ZXbgQuoS/biEY" +
            "3RLOzNicjCfllTabAxcwggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9EJSLMA0G" +
            "CSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVyaVNpZ24s" +
            "IEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5BgNVBAsT" +
            "MlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20vcnBhIChj" +
            "KTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmluZyAyMDEw" +
            "IENBMB4XDTE0MTIxMTAwMDAwMFoXDTE1MTIyMjIzNTk1OVowgYYxCzAJBgNVBAYT" +
            "AkpQMQ8wDQYDVQQIEwZNaXlhZ2kxGDAWBgNVBAcTD1NlbmRhaSBJenVtaS1rdTEX" +
            "MBUGA1UEChQOR3JhcGVDaXR5IGluYy4xGjAYBgNVBAsUEVRvb2xzIERldmVsb3Bt" +
            "ZW50MRcwFQYDVQQDFA5HcmFwZUNpdHkgaW5jLjCCASIwDQYJKoZIhvcNAQEBBQAD" +
            "ggEPADCCAQoCggEBAMEC9splW7KVpAqRB6VVB7XJm8+a60x78HZWNmvAjs/ermp7" +
            "pbh8M9HYuEVTRj8H4baXxFYq4i75e5kNr7s+nGbJ5UfM6CldqbeRsQ4zvRb6npfr" +
            "tcOBwfYOx0woeYQfI6VzLVzhPbGjUDK6qdHZLf/EcvSIKvRbu3ILOE3kuux07gQk" +
            "b++rrSBUyJKXU8nW8c+K+9sfWqHYPb8FF2IazWxhmfIdIoDNKyjr3r/wIn3jQejp" +
            "qfamiHNsU/O26KS0EcvCS5CFOKDT6vvdnAkek3kyLWef+ca/cbFo74vawYGtmw2w" +
            "zw/hcwlANIQaCAxz+5JHQZ3SEg8LLSZ+C8E4T+8CAwEAAaOCAY0wggGJMAkGA1Ud" +
            "EwQCMAAwDgYDVR0PAQH/BAQDAgeAMCsGA1UdHwQkMCIwIKAeoByGGmh0dHA6Ly9z" +
            "Zi5zeW1jYi5jb20vc2YuY3JsMGYGA1UdIARfMF0wWwYLYIZIAYb4RQEHFwMwTDAj" +
            "BggrBgEFBQcCARYXaHR0cHM6Ly9kLnN5bWNiLmNvbS9jcHMwJQYIKwYBBQUHAgIw" +
            "GQwXaHR0cHM6Ly9kLnN5bWNiLmNvbS9ycGEwEwYDVR0lBAwwCgYIKwYBBQUHAwMw" +
            "VwYIKwYBBQUHAQEESzBJMB8GCCsGAQUFBzABhhNodHRwOi8vc2Yuc3ltY2QuY29t" +
            "MCYGCCsGAQUFBzAChhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNydDAfBgNVHSME" +
            "GDAWgBTPmanqeyb0S8mOj9fwBSbv49KnnTAdBgNVHQ4EFgQUAFrwraXUeDX1hBKo" +
            "LAUO+FYbjo4wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisGAQQBgjcCARsECDAGAQEA" +
            "AQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCIwphaN45b5ViKsRfCA6hbVeqMhNCJmL64" +
            "mqxdYvw3gsF4oOCDoiM6kWhy1NoUd2Lpcr9PjfGJ55ZX4sZlqoxeflTpHgnX8MPJ" +
            "uKpDBsk7WkhiEu65fBwb+g9wQHMMfgY0gjHIAQ2ZEf2PJ6TTSFcvj24wh73dsyqc" +
            "mj290fpwDtHaF2jE5pq/tQBOJ8vDkN46wt4qMhG6nIpOgc9KngyLLdEO7V34KM1N" +
            "b+sN9JkqTWXNoNqlOf7QjYHwlw7Ku7W3kIGK+f1kP1xqTBpXwsBE5sLlnujP+JAq" +
            "V8aKlBJDKRI3IhlrG9CJUmqFNhmZ2f5QE5jAvPQeXevLnMYiqJrgMIICxDCCAayg" +
            "AwIBAgIEDu7u7jANBgkqhkiG9w0BAQUFADAkMSIwIAYDVQQDDBlHQy1VV1AgSW50" +
            "ZXJuYWwgRGV2ZWxvcGVyMB4XDTE3MDEwMTA5MjA1NloXDTM3MTIzMTA5MjA1Nlow" +
            "JDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjCCASIwDQYJKoZI" +
            "hvcNAQEBBQADggEPADCCAQoCggEBAI9Y07PB/L04j1y3LEnPrr6vcRaCSe8vBZM1" +
            "LcT9huadulbFgRivpsutA6HfaznH/m7IVteWZ/gkPTmq9m0jXvWuTu2E2gtRuOJe" +
            "aLhStosgSDYMKBw3YyLKBkO2vrglgCA1NrxEMfU9xBpergXtyWMWqVOLfxzFrLe/" +
            "+lGLOXdzDnXFaPdsrn1MJ13cfLDp9XGp63NxpoiPM5p+wm3qH3z2cyjcz3kPk4S2" +
            "RcOoIYhzoJiF58GVFFxRP8zO1tbAc+rLDhGghvFghameT/LYgAsTOWIWieLkf+Xd" +
            "S48Ffn6j5+nOWxe/5IPc3iCNhCg5RATPQqhpGsARUQ3U5lFJBBkCAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEAC5hCz3FKJ2auLLHA2zrHHkQKoLkU5E6nJ/ob0pR54yAx" +
            "N3G0Trek5dcVQXeyAQpPYSHc3DHTpHHxEJrC1LSTqH1VFhaw/Xqtv0Jz4Gi1nqar" +
            "ZWQGfRqQkMqmlLVZGyKRbu0caK/p0z/iLgu7uaBZPeFm1pcQYRajy2f8mB08HWNA" +
            "b+lCzaLB60uC9c7uO0O8VHghi+UcnDOfQpGn+ObbmKqIuIcWcAENG6MhlGrfNfro" +
            "yKQMOwgxM4UrFhytglEnAvczhk2Rv9HQ2o5aIz1Iq1PNLHfV8IbCwsX7dmISbWMQ" +
            "PbZeB6ww82BIg96SmNpsXq+TUH3USEpKcexMQhQApw=="
    End Sub

    ''' <summary>
    ''' Invoked when the application is launched normally by the end user.  Other entry points
    ''' will be used when the application is launched to open a specific file, to display
    ''' search results, and so forth.
    ''' </summary>
    ''' <param name="args">Details about the launch request and process.</param>
    Protected Overrides Async Sub OnLaunched(args As LaunchActivatedEventArgs)
        Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

        ' Do not repeat app initialization when the Window already has content,
        ' just ensure that the window is active

        If rootFrame Is Nothing Then
            ' Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = New Frame()
            'Associate the frame with a SuspensionManager key                                
            SuspensionManager.RegisterFrame(rootFrame, "AppFrame")

            If args.PreviousExecutionState = ApplicationExecutionState.Terminated Then
                ' Restore the saved session state only when appropriate
                Try
                    Await SuspensionManager.RestoreAsync()
                    'Something went wrong restoring state.
                    'Assume there is no state and continue
                Catch generatedExceptionName As SuspensionManagerException
                End Try
            End If

            ' Place the frame in the current Window
            Window.Current.Content = rootFrame
        End If
        If rootFrame.Content Is Nothing Then
            ' When the navigation stack isn't restored navigate to the first page,
            ' configuring the new page by passing required information as a navigation
            ' parameter
            If Not rootFrame.Navigate(GetType(MainPage), "AllItems") Then
                Throw New Exception(Strings.InitializationException)
            End If
        End If
        ' Ensure the current window is active
        Window.Current.Activate()
    End Sub

    ''' <summary>
    ''' Invoked when application execution is being suspended.  Application state is saved
    ''' without knowing whether the application will be terminated or resumed with the contents
    ''' of memory still intact.
    ''' </summary>
    ''' <param name="sender">The source of the suspend request.</param>
    ''' <param name="e">Details about the suspend request.</param>
    Private Async Sub OnSuspending(sender As Object, e As SuspendingEventArgs)
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        Await SuspensionManager.SaveAsync()
        deferral.Complete()
    End Sub
End Class
