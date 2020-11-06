using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Grapecity.C1_EMenus
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
            

            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            C1.UWP.LicenseManager.Key =
            "AC4BLgIuB4dHAHIAYQBwAGUAYwBpAHQAeQAuAEMAMQBfAEUATQBlAG4AdQBzAGkL" +
            "X6np2uJD5sJkUycfK/++ImgY1dgo61k3wClmjNxNJ9etaiJFS3Nbcekpqlrb0Vio" +
            "DZwSGRF42oq/hMnen8pxOfTv/oovc7uz1vhq3u3Dk3uAx/ictePuWK+jG8BjHaCK" +
            "R/zK9uLjt/ReVlDOqNm9yycd76TfgrWIzd+TLe/f09bgd6NObSLHs7bACAbV5I0+" +
            "YE/rP8/F9KFQchAFNgEfPXPyRdIZ8MwaavaZPlYXw8IwsJczGrpdE96+3zT3SbEl" +
            "CXB6vaCEPiiOEA++KIbIWpPTq08AZm6TbCOaNhWCZjSSMrkfR1Gh0avcFLdjw2qx" +
            "nYqM7T9ClDUTtWgY1AoRZXaAU+QEpOeIk81fqbXdhvfncqNNxqRQ0FPsKUK5PuoI" +
            "N91cmJjFcdNBTPs6PQiiwbi2k2JYc0znNGWSjFnxgAxJ4e+FMO1BdhYlePFH0Ur/" +
            "nDIuvbGvdp87PgE9yE6/8GiizLWGdKVsZrMC+xnUu1qz40mxjfITWq2hIfhm6Ypa" +
            "Ulvn8BiruRczmgocLiBsnn5L2OPIkUbQXvYol6zWwvcovstzRJdZSYYa9KqurMqp" +
            "R7ZgTBTouSJaFTym3EIoahtMqUe1rBxjM0aN+JZ+GRIQmlhOnvvGjVJMuJq+XBOU" +
            "VwNK6bRwXiO0szKLRxFg/tUT5c+gnhDDIao34OHoMIIFVTCCBD2gAwIBAgIQQQN4" +
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
            "A1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjAeFw0xODA1MDMwOTUwNTZa" +
            "Fw0zODEyMzEwOTUwNTZaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZl" +
            "bG9wZXIwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCG035LvvHyYtjW" +
            "hC+XIlEUigJt76K1JLUsdkPmz8PJ+3P0WXd5u+R3arLyJH85d9kNAfBWZfQJnk+2" +
            "/af+dtG0n6lUtzAWXrmn0JAUWkmOlQSU0C3XuYmKDmdzcrVwVlIL3v3yKVmsJWhC" +
            "B8GxU7/ADUgOzgV6+UPazHjQuWq0Uyq0tZvgZNh80XV+TLBQAfkFXTnpHlRznwuV" +
            "uULqy/OVNxuf4m5wdwYB+HHvjUuZY4XK3Wv7E1rcY14QWFCBgdzIY+fq4M8P+1yn" +
            "SrWu1vwuIE8viYMvCIih4kvKGFZVU3a+9zs7y5e+8u2xJVLKSKC/lMJJHuZcjXDN" +
            "faFJR01/AgMBAAEwDQYJKoZIhvcNAQEFBQADggEBAEVvIv7NGCFoC3gSPQ6RRWTd" +
            "unah78XzdtiFQpzXswtVKvloWXck8FtoZSBldDbXs0UL/3cAnqhXgNxIhLEWuCFb" +
            "mmDn2Y5Npflx7K/KGFYnMt0SdbzqYxziWNtYT8KK/VEizGYjWHRD1OdpZSkRcc9V" +
            "wcLWMxpUij+EQ9PwjK1mOReY7a9FFHqRHoOu7B0w+4EWuF6vOCDoK1VsWj9HRmHm" +
            "rf1D8jMOMxtyh8QPyaDwZtV9l2zV/Wa+8/AYqRsYHWcXY6bA07yCAsHOolLWLbVF" +
            "JqM/u/lF0RAtZJFWb5CWBZoomRPCLpCMgY6PSjt90/0bFNL/IBCAqkHp1/gzi38=";
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

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
                rootFrame.Navigate(typeof(HomePage), e.Arguments);
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
