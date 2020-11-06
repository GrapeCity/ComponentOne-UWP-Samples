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

namespace OfflineMaps
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
                "AB4BHgIeB3dPAGYAZgBsAGkAbgBlAE0AYQBwAHMAGULe8pCPDYb4TMIQrlEf1pye" +
                "TsfwKyDnnGTsZ3yQX2lAb+vsKu6f/IF4/R1jrSbz1wha9FLJC34yfUBGkm5SKazS" +
                "dYMMjQBROzvJ3JSdpkQb1nFBtNc0Lz0qqmMuTiin41P0qMyMDfKRUj9tvUre5cF0" +
                "XtnNg3TAXJwrPy8YUn0DqXUoAm2hzgvBVtKMeJ1jt0SQrNuvmOtvkb6UB7Q8dO08" +
                "yer/dYOq7JpYwYyMDwEeZsW0z+N98H0QMtafQJYKWhFP4wAJGJFblJtx66SO7wZC" +
                "AHOXvrJwEMWizm4Bs55sZoV+xPwLPyxxH1hzHCm7AfgaSmz7SuxnjU+W2WSXyIcV" +
                "8B3BokGYd+UiwoL0poywvjkNPtDVoS+sAZaCiyqyI85YRnNeLhocKts1segaIKKG" +
                "7/TPgpAxEToWEdeOvPT0w1mIeuPVm9c432PuUmVLFkblVidH2TWpHJC1X7lRr1MW" +
                "T/xwE72SFOsj0vXzKN49uvaOKF+MESV6gbjr+OTh0wOWFnlPXkLafoCUagCT/TKh" +
                "uChGxlderG2Ad5yxkwzxNQ1VSZmXHMFiNT2Z0Mw85FKUiK7n4G46XvinSphh0FGV" +
                "A4lVEIUs/zWzE4VgCcn+uXD5hw8NDqA2SlSnKygv1ahfj6dNNvmQw6uMUlpZrOoV" +
                "nvX2P7pq5Bcn7Y7o3mswggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9EJSLMA0G" +
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
                "ZXJuYWwgRGV2ZWxvcGVyMB4XDTE4MDcxNjEzMzMzMVoXDTM4MDcxNjEzMzMzMVow" +
                "JDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjCCASIwDQYJKoZI" +
                "hvcNAQEBBQADggEPADCCAQoCggEBALLE2j3sUmzfFYO9NPoNhnkMrhtMu1V2ND/n" +
                "ev47QN77rq2xE+BYOI9kpk5YaAmB9L7x+Vh+0OjYo+criQg5wsgoBveH4SjWls9v" +
                "XEz8Cj+OCXL0qtBbyF6Sd+ua5B5f5fi8KBDqWMCKYG6y8mX9Ny7E8Otsj2T+Fyk0" +
                "qOC36SQXOpE0WTw+/I82kSpdOGstI9D+k7d9W6le6FKs/1fbfrOX9cK6pfyEiDOy" +
                "9DM+qcJM/VN2ebTV+44/TH653geXKRY4dzvvaNRsYnjcsTOUCpc9SmKIriIiCXGL" +
                "0Hcjt+Rz+cQi3r33Dte58JAd2pRUjORR3rorDjyx/mtGQIR0Tp0CAwEAATANBgkq" +
                "hkiG9w0BAQUFAAOCAQEATuGz8mXXueY7OOEaHQUuOfI7X6fdoikZfnr/+sJF6Dsr" +
                "3+HP5RvOXJkxO2rlfelPldXVJ+CGzW1vyTtuvp5C/+uuZTgufcGS+1AZwekk/HlX" +
                "Z3SBRtDMgLHGoZP+xIQcTwtUUaXbo724ShNd8TpMLF0zg0ZUnxkKEuM2YwZL5j+l" +
                "+Gfceje+G3I92/tmKn68qu48dbR//fB8kHllh+N53BxWuaEzNbW8wQ/aXtcW4zYQ" +
                "5zomF3wLmVKq8a2xpro3nAhDDS4itHRngQsGYX5fjUKIVqqBgKi/1UlIB1nWD5Eo" +
                "whgZpwn9Wldb5O0hFK9DLRK41BY4V7VND1ajG1g+XQ==";
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

            if (e.PrelaunchActivated == false)
            {
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
