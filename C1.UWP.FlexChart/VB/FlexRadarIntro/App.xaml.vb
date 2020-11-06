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
Imports FlexRadarIntro.Common

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
            "ACQBJAIkB31GAGwAZQB4AFIAYQBkAGEAcgBJAG4AdAByAG8AM8ig148ljY3JgdYo" +
            "X+JKr7XBI7cE8F8cavU6z/THbv/FbqoKfAHfel0KB13bdzhk2PyK+DquGzKMpiX7" +
            "yXKppIHZSMDfuaiRF+XHgmjRF2JChbtQrAF/XEDphnRkH+M2v9BOz7cQKNw5GUGQ" +
            "BKfEQjcDF2mhCVu63da/Pxzdi0B6205bbb4vq69WPDdq8DrAnF1/2YAKlROUOwCl" +
            "3n5xnrK9MBNYuWljpOSfwe2W9+2ISdDcNtDV/HLYhQmUg7Ro/BqpQy82YYOe/z5W" +
            "zkPl6NURGATpu+JdM7SKwlAZummUT+KOTepul+8Mi4qUobxLvbbqHCmJVkB8UFIp" +
            "eifU335soRT0q8OHP3EwLj2yGfePqKxbb/rajwbxsrqBmg05/YVdJUWWWiiZFS62" +
            "zXHi8SyxfhjYpGi4Fss/P7COJwoqFb71UO1+9i/MspKND0FxV++L18u7nuwow9Bf" +
            "KTN1l98P+NJMs0JVhRwDMdXVtkhKw706QsCwJV1nuRyQ0Lz47rde83e8Kn9n1gUt" +
            "q2eSvrYTWcFxwj1twJGv5SVhnQppt2K/xMo7rmmVAGVn++eAi25ZLeRIQfpqBDRX" +
            "Ny7VE/btKXfM0evJ2gAb6duGmeXEA+D/zy5nd/aOM9EP9R/d9DVOPuShogZbZSbN" +
            "M29NzD7CD1gmki3+Z/3NAvBj2lYwggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9" +
            "EJSLMA0GCSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVy" +
            "aVNpZ24sIEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5" +
            "BgNVBAsTMlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20v" +
            "cnBhIChjKTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmlu" +
            "ZyAyMDEwIENBMB4XDTE0MTIxMTAwMDAwMFoXDTE1MTIyMjIzNTk1OVowgYYxCzAJ" +
            "BgNVBAYTAkpQMQ8wDQYDVQQIEwZNaXlhZ2kxGDAWBgNVBAcTD1NlbmRhaSBJenVt" +
            "aS1rdTEXMBUGA1UEChQOR3JhcGVDaXR5IGluYy4xGjAYBgNVBAsUEVRvb2xzIERl" +
            "dmVsb3BtZW50MRcwFQYDVQQDFA5HcmFwZUNpdHkgaW5jLjCCASIwDQYJKoZIhvcN" +
            "AQEBBQADggEPADCCAQoCggEBAMEC9splW7KVpAqRB6VVB7XJm8+a60x78HZWNmvA" +
            "js/ermp7pbh8M9HYuEVTRj8H4baXxFYq4i75e5kNr7s+nGbJ5UfM6CldqbeRsQ4z" +
            "vRb6npfrtcOBwfYOx0woeYQfI6VzLVzhPbGjUDK6qdHZLf/EcvSIKvRbu3ILOE3k" +
            "uux07gQkb++rrSBUyJKXU8nW8c+K+9sfWqHYPb8FF2IazWxhmfIdIoDNKyjr3r/w" +
            "In3jQejpqfamiHNsU/O26KS0EcvCS5CFOKDT6vvdnAkek3kyLWef+ca/cbFo74va" +
            "wYGtmw2wzw/hcwlANIQaCAxz+5JHQZ3SEg8LLSZ+C8E4T+8CAwEAAaOCAY0wggGJ" +
            "MAkGA1UdEwQCMAAwDgYDVR0PAQH/BAQDAgeAMCsGA1UdHwQkMCIwIKAeoByGGmh0" +
            "dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3JsMGYGA1UdIARfMF0wWwYLYIZIAYb4RQEH" +
            "FwMwTDAjBggrBgEFBQcCARYXaHR0cHM6Ly9kLnN5bWNiLmNvbS9jcHMwJQYIKwYB" +
            "BQUHAgIwGQwXaHR0cHM6Ly9kLnN5bWNiLmNvbS9ycGEwEwYDVR0lBAwwCgYIKwYB" +
            "BQUHAwMwVwYIKwYBBQUHAQEESzBJMB8GCCsGAQUFBzABhhNodHRwOi8vc2Yuc3lt" +
            "Y2QuY29tMCYGCCsGAQUFBzAChhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNydDAf" +
            "BgNVHSMEGDAWgBTPmanqeyb0S8mOj9fwBSbv49KnnTAdBgNVHQ4EFgQUAFrwraXU" +
            "eDX1hBKoLAUO+FYbjo4wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisGAQQBgjcCARsE" +
            "CDAGAQEAAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCIwphaN45b5ViKsRfCA6hbVeqM" +
            "hNCJmL64mqxdYvw3gsF4oOCDoiM6kWhy1NoUd2Lpcr9PjfGJ55ZX4sZlqoxeflTp" +
            "HgnX8MPJuKpDBsk7WkhiEu65fBwb+g9wQHMMfgY0gjHIAQ2ZEf2PJ6TTSFcvj24w" +
            "h73dsyqcmj290fpwDtHaF2jE5pq/tQBOJ8vDkN46wt4qMhG6nIpOgc9KngyLLdEO" +
            "7V34KM1Nb+sN9JkqTWXNoNqlOf7QjYHwlw7Ku7W3kIGK+f1kP1xqTBpXwsBE5sLl" +
            "nujP+JAqV8aKlBJDKRI3IhlrG9CJUmqFNhmZ2f5QE5jAvPQeXevLnMYiqJrgMIIC" +
            "xDCCAaygAwIBAgIEDu7u7jANBgkqhkiG9w0BAQUFADAkMSIwIAYDVQQDDBlHQy1V" +
            "V1AgSW50ZXJuYWwgRGV2ZWxvcGVyMB4XDTE3MDEwMTA5MjA1NloXDTM3MTIzMTA5" +
            "MjA1NlowJDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjCCASIw" +
            "DQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAJjGF6/L6kfBpXN2QmLDhRT7X4A2" +
            "CRrp8dh/nB6EaSoPcDCQkKefpXdxE0p9DFeWf83p+B5wQiXSpubfoc9R9pKiwAGw" +
            "FCmB66wlykqJcHHZH2LTCxKhVlbcqnBBDmgVLVT+hRZPW5Lb/SfRImWyJSShXGfU" +
            "T9Zt4A/dL+ieGsRxVEa3KtthAZCr5lSX0SMkBRWuEGHLCkZpcZmDQaH/YA0z0zr5" +
            "SV0+m21jeUsLfLjw9e3KjpjzOxHOgsEkVjqL0W+cw4kHftolNktHSltYH/mBpFeP" +
            "c0iUSU9V1JJp+VLz2nhhcDY9nsOckhKuWRsVvt86y2uRx+nY6ay3C6vyDNUCAwEA" +
            "ATANBgkqhkiG9w0BAQUFAAOCAQEAQ2r9Y658bAW1kxbS1SpfN/B3gA1Coku65VTq" +
            "U3Ro26FulpqdRLL6o+09CYdBnj3XfDwfef7onY6Km1w1puRqAKcQi4BNqYtGaz6D" +
            "KSkyizLdO2hzqQjiqtfPJEJIJ51AsH0IjT3/qbOM13aypxtsCTmWAVgEofa29qlP" +
            "CjEJKR4CbD3jwvRAcVjmXcrsBgZXo9S6W2Le85HPGioH+VwpI2ftTsQHPYhD6VCl" +
            "jnWcPsxCV19LdUSqeVVujzX1jAh9NQBc6BYoxHWcshch1Z2PwPI/BHAnGU4fyQzV" +
            "2KbHrHoTr7Grgl2tjhGRPuznOaPPDTdoVHTW14rjW+aFgNNdRg=="
        Me.InitializeComponent()
    End Sub

    ''' <summary>
    ''' Invoked when the application is launched normally by the end user.  Other entry points
    ''' will be used such as when the application is launched to open a specific file.
    ''' </summary>
    ''' <param name="e">Details about the launch request and process.</param>
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
    Private Async Sub OnSuspending(sender As Object, e As SuspendingEventArgs) Handles Me.Suspending
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        Await SuspensionManager.SaveAsync()
        deferral.Complete()
    End Sub
End Class