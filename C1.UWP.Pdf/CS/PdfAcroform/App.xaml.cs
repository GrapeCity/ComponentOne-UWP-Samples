using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PdfAcroform
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            C1.UWP.LicenseManager.Key =
            "AB4BHgIeB3dQAGQAZgBBAGMAcgBvAGYAbwByAG0AVs2oddFf2YD2nxcWmtJH9WWT" +
            "pdOKmW5j7CWwYzNSL1Av3gSVH0OhdWh6DrMCpN2iQUubSEHVAIchYDTTHntvSXgt" +
            "qpwge7HR4N2BNvPPGdVARLzdvipvw6zbwo4UwJo7d2HHrurS+3z3H79k5GyMv8SU" +
            "nTanYhx3sFla5PTuymlDPLIE7iAy7fRHiLvNmS/3peHxbaH1qPHN09OrC4cwAmgB" +
            "htvM/P2HaMB3cs+gucXh6sSA14vQXSTBl4iOtCfdfKGmMHag4nb9VWk3b3IOklDv" +
            "1OMP8Qj3WNoshHw7+c+0VeMOAqqY6nxL8CcFGzBYpxuXBZxTLw5IG8u4zW9fMLSx" +
            "zGcDw4dq1Ii2WQ3Nz9g69bAbG66SuLxLvkIwvXdiaBOsvDiqjdG2ljZHWS8D2nTg" +
            "YAqRmVCxxr6jKs2pbtP323c+C4qRbPHQ2HqoF2C9Nv4Pcr7qVlJwX8s4CT/M6dJo" +
            "vH0NBvHivhhu4CEAKRwejKwIcPeqfg7OOCwJuN7gbdKAnXXiZ0o7QWZHjJFEkyg9" +
            "mCvzmbdNiVmv+KTM7crHysktJW/29FSG8JY4cYvRADUgizsAEikR6CIeQirK7zHz" +
            "xjAhf/OAV1X8fBJ6OQuNMiRR6zekn7qfQIZs6rdNny/bnxw3bXI8MpdRG0nEwpCe" +
            "e9btNTGeDzjE7kSxQBgwggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9EJSLMA0G" +
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
            "hvcNAQEBBQADggEPADCCAQoCggEBAJ8rZzQgK5DeFQtzEC6Cjs4EqfLd5xIolLg5" +
            "qe9X6UVa3KeMnUpYA4WRZ8DO32Dp4vj6Q7IopvRIK3jl1L01rQLZal5ZIzUhADbO" +
            "tr01D159X3SVQTN1/E6PvWOg/ItEzYDu3ADrBkjE2wIEMFX+pRQZz4D+F1HsEWL0" +
            "n1xFPDaJWpZminDv23SoALDjN59GvabB1s6Zf+p+RB0jJoq1ZoKbQ5MFU+qeszwJ" +
            "ZGZq498EJPllPxGR4kcx7FalLe5RuqGcMS/C03Q3Qcbnh/LmAnxo7yrlZFQJ6jMH" +
            "qW28OHezMZDj3qu5zB4/9WgRHWb7cpXGY0RBPMq21EfiPrHQfDsCAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEAjIukg0DN7DmDMSxWu35Nlnet8A35U8PwzKTh8IV66kBB" +
            "eKvvRp5i6ldo5KwjV9huAXDefDCUkaa8OJnHugaPsf/ChELcpJ5SL9Geq6AmRqDF" +
            "k5FFgQW2qAZRRp8md1FRB5gBhzi6dzy3S2jQBAHgcgrTr00sycq6vGIio+5Td094" +
            "t1iXTLEqGh9WXQJKfV0vCxGXBUJPP6zARZJidnPLwDgetvwdUXrLH7kH/MCdGrJV" +
            "tAoEpDCr+uIjk+0ptCdVH4t5hBeOMMTNHqZbY9gfCU6/jr7jYn5YM/9DlT+iv9Gd" +
            "pWcm76kdwC7eqKlIPUZcg8cCgh/WpIRuGYgTqsKU6Q==";
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

//#if DEBUG
//            if (System.Diagnostics.Debugger.IsAttached)
//            {
//                this.DebugSettings.EnableFrameRateCounter = true;
//            }
//#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
