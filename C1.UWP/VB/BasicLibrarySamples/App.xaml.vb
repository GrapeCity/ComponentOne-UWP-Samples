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
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports BasicLibrarySamples.Common

''' <summary>
''' Provides application-specific behavior to supplement the default Application class.
''' </summary>
Partial NotInheritable Class App
    Inherits Application
    ''' <summary>
    ''' Initializes the singleton Application object.  This is the first line of authored code
    ''' executed, and as such is the logical equivalent of main() or WinMain().
    ''' </summary>
    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Suspending, AddressOf OnSuspending

        C1.UWP.LicenseManager.Key =
            "AC4BLgIuB4dCAGEAcwBpAGMATABpAGIAcgBhAHIAeQBTAGEAbQBwAGwAZQBzACOU" +
            "MCrLZ/8tIiII7PR9g6dBVrFmjBxujzoiz18SCFBAkVenjz0p1vOS8lk/lmAX5pB9" +
            "0J6W3Ij6lMPL5BLx0CzsT6gS3+QfrgwlweDgKLjtnKJn9OOb6DRfcXAPrSAdR6SW" +
            "Tw8gZyMUWpzqFabBNIafXMLWESh8SCLaPU3W1gngyar4EpQQB2n2fSiEXtxki02S" +
            "4JjBFCLzrtIf/JVc5jGnhD5ntQoDGgSfXkcdTrTVDR9S6LEdkxd0zv0mtm2v0Wge" +
            "5C7WBZBGAI0uSZBvbv6/5mRYMCYQeCsudyFnEyOhf4N3NWwUDZIfPnbMH7XSvxYQ" +
            "invqNIgsfGlneS+UsUgydqxvJSpCs9KRPTfLt23utkr5uKV31UxLbKcEOge/BnDj" +
            "YEbYE2/x4JBVjBDilVCxpxzYC3e9trPP/h8S/vkfBkBsFGHAeRQ4MeNfsQzeKYlc" +
            "lRnAQ99h2uQuIoaXhVl+8LUNKN7OcekgIIkJDo10n0El8T+3gGbsRAV70R8ks4tO" +
            "XKUvM8cGGlTPyll7BKAMB2InrlBxYX6usnePSOBfua8h4rTSBN2vsS4BB8GD8DPI" +
            "rJeO1ZGMV6j/gn4t5u6wBVX4fA5wAtQPBi9hHNApT62rYYuq1Mk5/2SQ8N4jrjTP" +
            "7skp24l8Lngc+PnyM3+Kdb8utMw1Ivq/fTAfUTBEMIIFVTCCBD2gAwIBAgIQQQN4" +
            "0iY2WXoW2ybGvRCUizANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAV" +
            "BgNVBAoTDlZlcmlTaWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBO" +
            "ZXR3b3JrMTswOQYDVQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVy" +
            "aXNpZ24uY29tL3JwYSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBD" +
            "b2RlIFNpZ25pbmcgMjAxMCBDQTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5" +
            "NTlaMIGGMQswCQYDVQQGEwJKUDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9T" +
            "ZW5kYWkgSXp1bWkta3UxFzAVBgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQL" +
            "FBFUb29scyBEZXZlbG9wbWVudDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEi" +
            "MA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvP" +
            "mutMe/B2VjZrwI7P3q5qe6W4fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVH" +
            "zOgpXam3kbEOM70W+p6X67XDgcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0" +
            "iCr0W7tyCzhN5LrsdO4EJG/vq60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZny" +
            "HSKAzSso696/8CJ940Ho6an2pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1n" +
            "n/nGv3GxaO+L2sGBrZsNsM8P4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMB" +
            "AAGjggGNMIIBiTAJBgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAi" +
            "MCCgHqAchhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsG" +
            "C2CGSAGG+EUBBxcDMEwwIwYIKwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20v" +
            "Y3BzMCUGCCsGAQUFBwICMBkMF2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1Ud" +
            "JQQMMAoGCCsGAQUFBwMDMFcGCCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0" +
            "cDovL3NmLnN5bWNkLmNvbTAmBggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNv" +
            "bS9zZi5jcnQwHwYDVR0jBBgwFoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0O" +
            "BBYEFABa8K2l1Hg19YQSqCwFDvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgor" +
            "BgEEAYI3AgEbBAgwBgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VY" +
            "irEXwgOoW1XqjITQiZi+uJqsXWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeW" +
            "V+LGZaqMXn5U6R4J1/DDybiqQwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9" +
            "jyek00hXL49uMIe93bMqnJo9vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyK" +
            "ToHPSp4Miy3RDu1d+CjNTW/rDfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9c" +
            "akwaV8LARObC5Z7oz/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3r" +
            "y5zGIqia4DCCAsQwggGsoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAG" +
            "A1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjAeFw0xNzAxMDEwOTIwNTZa" +
            "Fw0zNzEyMzEwOTIwNTZaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZl" +
            "bG9wZXIwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCOLJLKec9YnJHO" +
            "kPGpeuJRLGAwUGv/Anvy8nNmzYbX0u/+Umc+rX3gMojT85GuAnp33tdsmXnskJJJ" +
            "mS+EBcy/Nfz2M0lQ3hws1VwVB/tSLo6RR0++Ht+p+N6J3Dq/pYPiDWTiw3lnsg59" +
            "EYHgJAGRwNmMFJ0hDue1GkJRtTXPUxomaZJzOWEMSxEz89Og0836PjvEZdHoMYm+" +
            "2qGL3/1EsfLYYm2AbrhkGZo08Cr2Hl/Kf1dSLZOQQWA5S//TNuNa0sych9zuOGPE" +
            "9qyXibT+siEJvJqpOUe1/1C4baUpExLK28u/lENBaake8IfZJ+FMpQieeMhG6Wvg" +
            "6lZdLodJAgMBAAEwDQYJKoZIhvcNAQEFBQADggEBAFiw2F1YX0LU5RFzJ9I3u1AC" +
            "smKth/xnvKZXolNFE9NX0TafTAxlH7aUREqrsGQGnz2q2H6KTyNIPDxfSy6oKulS" +
            "lRBaLeVuQievREyOUdKWGRtysVibOKWgsdCXmOgkjv5vNXs02dchf071cTHiKP2T" +
            "iao+18IPK3ctqCBA2RoE9jqPmVpbYS8I1NoJ0IQTe9vrFLzE2gi6SDVvQ7vhWiQE" +
            "EVGl/uwV+nAXqn3SDDN0aKi/rszCwVZP23kihVNdg7jNctPXuqvkIbQRvwzffZA4" +
            "y66xvUeVcYM+DgKPlTqc5tus7sAr/nR6x/Dt6JlQEtbOW6TL5xUUkiWHQ4TLwxM="
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