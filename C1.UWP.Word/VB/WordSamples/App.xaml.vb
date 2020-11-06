Imports WordSamples.Common

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
            "AB4BHgIeB3dXAG8AcgBkAFMAYQBtAHAAbABlAHMAGMSneWa3Sg5EAJoWeZJPEGdR" +
            "aQUkqkLpmIWfW8e22R9M38+sJG+C/cGnKQOtaVhMbTJq+S+H0BIvjdcaIzE9J94M" +
            "JAm2uP4IIklFD97ffw+LpE41JxzKZiH6o/QznomsZzsQKG+q7ROaPw4uyhpHzZz3" +
            "jOf6LzePKR0PQL9CLbBqTPbY37gObGvDsTY8JbP3U5GIjbgtWTG4dxaVgxhV1yrQ" +
            "KsO42VZnoPKBbCAS9ERjZ1pc7qHQRHkDaTWgPqIJdOmBVhfWYJmVolFZ4yemQG8+" +
            "aEmOQNjK2ro3EMswCvrSfQTz6I7230h5y/AjsjtsdVeA8K+DI8Pf/Yzj+ZEkO0qR" +
            "SWTx0ra+P8sP1jz+AeShDWB3B/ScKGsHkj6vlq/fk874d3OHreCDGQ1380phmy2l" +
            "SLAwNpavu/QdZbPKmTEMj+HDkRNhV4nxcVrkxnJ3F8uDP207Amk4vDS2IHGYYsTH" +
            "fBWPhGsg5+UzyhebOpd5riTz2ML4t1+cZ45foi5FTdtyhTA/jugilmd1irHvnQo4" +
            "WblqBqJbvGNqSMmQR8uNGVGddNbO5AiSFs0pUD3DR8ZX+x7fpjjAQY5r2tBViqEX" +
            "AjbE6jbZBlfpL/5BeOHJFebMvVGZkr3E+fcFsomPIFvAwbfBdS01Mx1w+iHCocvv" +
            "gclOWFC1afU+FnolubgwggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9EJSLMA0G" +
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
            "hvcNAQEBBQADggEPADCCAQoCggEBAKv/3+2dXwDVSTHZYcECPBdMwPOf0yoOpgwl" +
            "tZpuViX+0C9jFA7G6cykPf9AefJrcBdqgg5Z+QUvQ+JVOFMfqypkNp4ssjiWPdKP" +
            "yr97vTtsx3TTG1fFvakhYngXM3+k/1YhkziIOFbj9qNJdi9Nv5NtOWjmjhza3ZAf" +
            "GMcgOVP99ieU7exkyp8xZRNPYPADwV9iiHPAEgBH6YKU1p5pwWnmG6S0x62HGXiM" +
            "BJu/aRsGcH9Po9r19fdPdcEvFDQoQsRdP1iTzPqWfO6J1m+FJSia4Lw3vRWafioM" +
            "6RoLS7BOaPeInyeZCDtJ4m5OTilGCgSRBnBgBRq+LeR0YzQQ2ecCAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEADlDj0d0cij7JZ7XXEUBA5dmrcHj4wcC1ue52cipjZiDR" +
            "32yiATxSUh7iLRxtAQ2oa2psWVv//IFYPUQjHc5oA7Raa9h60UmoAADuVptR8N7t" +
            "gM509EmWBqhKlrIs6S9/gb3yvCkH8gC/PNBB2KAFjdL2x1QfXKOHnxZDL+mDHI5P" +
            "VcMVcxcV8iS7g0nEvnnjY5kix6pXmIv/UD8GjV7M5SIeU8h1Gaz4C1dISU7sAeBP" +
            "guBSzkxGnr2XjGW0K34YC0chL9fP5VevKhWJs+81/XPejCDJ64BbaKAZk6sOrMgu" +
            "eEsBx6LFTDYFziNylE3VWKFLODvDIFX5mmEq1YihRQ=="
        Me.InitializeComponent()
        AddHandler Me.Suspending, AddressOf OnSuspending
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
