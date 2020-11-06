﻿Imports CalendarData.Common

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
            "ACABIAIgB3lDAGEAbABlAG4AZABhAHIARABhAHQAYQA6osaGG+0n4uB1qmrTxa5i" +
            "0aMNy9J6PUA2e4EiNC2WF85GNfrY8LUngNSc9EpW8Q/GIjQAqNVbxDSJJSGoMICf" +
            "wqfJea6Zp6H1H3JaqbPgaLfuhslA2Ar+He1n3DG4ZC9zLl3OvalwJH54Z/vZgvYR" +
            "y7pMZr2XdTTYi4zfU/el1rgxsqBKzYC5kdKGXdXwoSF96Cc8lifzO03PX5fI+8cn" +
            "RDHQ8wyRCSq0Xh9XKDyjjHHDVk37FrV9lFmeuyBpH0tC1pyi99YgHsfYectpVdnk" +
            "BV/Iw+4s6u9ljGAVxFvZGZy2u77zl4VCRPCznVYXBjCU2p7elhEEDvsPIPo4R4kU" +
            "l45YWlQx4ECbThUPzcDFnR99ll3cyosTsDn7ebfLiUtDYUFav8ScWP4kCMYF1/SF" +
            "STbOmpvYa2oIIYo+852AYypxDim3PIGBDSjKLgvAU8D595Pmc7CqtFlUw39/Eldo" +
            "xt1voi/XMBiOECUTBbqV2LFklBMwaRWCKNDJJmeHLVSTxd6Jr/lsdGkKR+qHY3lp" +
            "Ydtt3ZDDVxQpVBNfjypdN6tB8OWPG/e1RvtTm+lkxmZkxEAN5qaz0yAlw/BNZJVb" +
            "qHzzI5+RjswwEcAl7VQ//ITS6vB5EMyp/Mn0zKbK56BBD2LaCUFoUHXl3daRpNrg" +
            "NUn1ZoVRKnAB9akWBSaP+DCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsmxr0QlIsw" +
            "DQYJKoZIhvcNAQEFBQAwgbQxCzAJBgNVBAYTAlVTMRcwFQYDVQQKEw5WZXJpU2ln" +
            "biwgSW5jLjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0d29yazE7MDkGA1UE" +
            "CxMyVGVybXMgb2YgdXNlIGF0IGh0dHBzOi8vd3d3LnZlcmlzaWduLmNvbS9ycGEg" +
            "KGMpMTAxLjAsBgNVBAMTJVZlcmlTaWduIENsYXNzIDMgQ29kZSBTaWduaW5nIDIw" +
            "MTAgQ0EwHhcNMTQxMjExMDAwMDAwWhcNMTUxMjIyMjM1OTU5WjCBhjELMAkGA1UE" +
            "BhMCSlAxDzANBgNVBAgTBk1peWFnaTEYMBYGA1UEBxMPU2VuZGFpIEl6dW1pLWt1" +
            "MRcwFQYDVQQKFA5HcmFwZUNpdHkgaW5jLjEaMBgGA1UECxQRVG9vbHMgRGV2ZWxv" +
            "cG1lbnQxFzAVBgNVBAMUDkdyYXBlQ2l0eSBpbmMuMIIBIjANBgkqhkiG9w0BAQEF" +
            "AAOCAQ8AMIIBCgKCAQEAwQL2ymVbspWkCpEHpVUHtcmbz5rrTHvwdlY2a8COz96u" +
            "anuluHwz0di4RVNGPwfhtpfEViriLvl7mQ2vuz6cZsnlR8zoKV2pt5GxDjO9Fvqe" +
            "l+u1w4HB9g7HTCh5hB8jpXMtXOE9saNQMrqp0dkt/8Ry9Igq9Fu7cgs4TeS67HTu" +
            "BCRv76utIFTIkpdTydbxz4r72x9aodg9vwUXYhrNbGGZ8h0igM0rKOvev/AifeNB" +
            "6Omp9qaIc2xT87bopLQRy8JLkIU4oNPq+92cCR6TeTItZ5/5xr9xsWjvi9rBga2b" +
            "DbDPD+FzCUA0hBoIDHP7kkdBndISDwstJn4LwThP7wIDAQABo4IBjTCCAYkwCQYD" +
            "VR0TBAIwADAOBgNVHQ8BAf8EBAMCB4AwKwYDVR0fBCQwIjAgoB6gHIYaaHR0cDov" +
            "L3NmLnN5bWNiLmNvbS9zZi5jcmwwZgYDVR0gBF8wXTBbBgtghkgBhvhFAQcXAzBM" +
            "MCMGCCsGAQUFBwIBFhdodHRwczovL2Quc3ltY2IuY29tL2NwczAlBggrBgEFBQcC" +
            "AjAZDBdodHRwczovL2Quc3ltY2IuY29tL3JwYTATBgNVHSUEDDAKBggrBgEFBQcD" +
            "AzBXBggrBgEFBQcBAQRLMEkwHwYIKwYBBQUHMAGGE2h0dHA6Ly9zZi5zeW1jZC5j" +
            "b20wJgYIKwYBBQUHMAKGGmh0dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3J0MB8GA1Ud" +
            "IwQYMBaAFM+Zqep7JvRLyY6P1/AFJu/j0qedMB0GA1UdDgQWBBQAWvCtpdR4NfWE" +
            "EqgsBQ74VhuOjjARBglghkgBhvhCAQEEBAMCBBAwFgYKKwYBBAGCNwIBGwQIMAYB" +
            "AQABAf8wDQYJKoZIhvcNAQEFBQADggEBAIjCmFo3jlvlWIqxF8IDqFtV6oyE0ImY" +
            "vriarF1i/DeCwXig4IOiIzqRaHLU2hR3Yulyv0+N8YnnllfixmWqjF5+VOkeCdfw" +
            "w8m4qkMGyTtaSGIS7rl8HBv6D3BAcwx+BjSCMcgBDZkR/Y8npNNIVy+PbjCHvd2z" +
            "KpyaPb3R+nAO0doXaMTmmr+1AE4ny8OQ3jrC3ioyEbqcik6Bz0qeDIst0Q7tXfgo" +
            "zU1v6w30mSpNZc2g2qU5/tCNgfCXDsq7tbeQgYr5/WQ/XGpMGlfCwETmwuWe6M/4" +
            "kCpXxoqUEkMpEjciGWsb0IlSaoU2GZnZ/lATmMC89B5d68ucxiKomuAwggLEMIIB" +
            "rKADAgECAgQO7u7uMA0GCSqGSIb3DQEBBQUAMCQxIjAgBgNVBAMMGUdDLVVXUCBJ" +
            "bnRlcm5hbCBEZXZlbG9wZXIwHhcNMTcwMTAxMDkyMDU2WhcNMzcxMjMxMDkyMDU2" +
            "WjAkMSIwIAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxvcGVyMIIBIjANBgkq" +
            "hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgIDG+j0SrSAgawIE2pBYj5Za6PgzCrBA" +
            "eRUSQdkFXR048FBE598xgTm6t6JQyFwyGlru5rPCD24rKYU2zYEO7MNf46PgIC1H" +
            "D81hhDz1fFZZgIgGhV1kvm4SFCRS86VGzvMHwt/NtnUu10NVwC09C/hCUe2eYNTz" +
            "Tp/v3AB5mwTHOGvJDGQQk91CEhDYKrKPFVvPZddwZC9mnwCUk2tlPoHmvjMAku02" +
            "86PzAg0sNG/CE2kFeU3Uhe7dTTd2SOW2EJ3WTznEFSQXZGuDC+B4+iUNrCl4cXpt" +
            "zP5bjlS2npjfk2ocwcpIuwwgS6E3r5unUnsGP0M2uwivahk/hwMdVwIDAQABMA0G" +
            "CSqGSIb3DQEBBQUAA4IBAQBIAvAAGIjW6JQVwYMo5HqLyhPJQIelQ6p0FaWdyUs9" +
            "uPKAHwKwR4bDJ80hk6Uez27Yd5wCqzAIGb4BuLWr+Txm/DHduViFgBRpTh+dhI2z" +
            "yahQHPXLXRf1SFlMRraw9egTDAcHafE9epYglaglcZky6OElhw9xDnqCbd12G49w" +
            "D+KmFIzBOMAxNjPiR9o8Ovo8R7WZs2DLhfFxnvnHDM+ZgeZrnsU0bg7eju03IK8D" +
            "mNoUtDzVxRO4isUxq1/XihUs5MsuZcDvf1bY05smXb/isv4vJSVq1TVwRWrcfTX5" +
            "6Zf7sJRIYAZ4H1hphTm5CySkVClQUdBWyEzyzNFF5u6t"
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
