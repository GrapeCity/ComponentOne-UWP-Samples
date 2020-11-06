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

namespace StockAnalysis
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public static class License
        {
            public const string Key =
                "ACIBIgIiB3tTAHQAbwBjAGsAQQBuAGEAbAB5AHMAaQBzAFT9BWDg2dI7Ss2NPl/2" +
                "XOQjhV/3+gddjiQm8vbFd1sUFHkwUHVMwS4kT/SE65HryM/qbOyTB1rUSLntp0id" +
                "0LtI3ywWWn9Glxkn26l3MKd25hddXSZBp1Ia4Y9TxRNldGy5Zk+i96DfT3VToSLF" +
                "bEoeiZTjGmVcRZvQ4Sd6CyeEjaZ+hrj5lR0JCKOK2YoANxFh30sPCznTMkWwVIKc" +
                "FPgZhrgF4KNlmgojRY5+pGs7XS4hRE6buvllw3nrbvl5bSRto9pvPI1fpoWz37u7" +
                "aFSWXkGQgr8nvGyzKaWCogVCqrQfUxLt7q0o+caGgiW2ztrypRUCmKGcOiZILAUn" +
                "CX+3UzEfJ5Q5Je9H0dA8kDsx4H7PtRiXZ+iIvuskBDo7PAfaNV95OkGu0ScSNcyX" +
                "/sb8PhdrjCf3ZU1X/UKH+e+04gqoLOvgwzEywSeSXz7oVzEpymrArC3xYFbVQpsY" +
                "cTrsk7U+JdALInTOYvQOIsrpqRnOWklkiw+/mzufUoi8LCuD+GpLUbk1eyvSTto3" +
                "TbaYMgoakjldECHqC06xgCXda8QrUpqrBkNztMeI8DZc5DeOntLDlJS3XUoHJh8N" +
                "xMWA2sIbGfeHFcy2CK96yxrjndCLA4mzrRv4/yccZX7bcRsh7WcqK+9gJuU/X+Tw" +
                "iolLqemD3emeH+c+lX2UK2MpMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCU" +
                "izANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlT" +
                "aWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYD" +
                "VQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3Jw" +
                "YSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcg" +
                "MjAxMCBDQTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYD" +
                "VQQGEwJKUDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkt" +
                "a3UxFzAVBgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZl" +
                "bG9wbWVudDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEB" +
                "AQUAA4IBDwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P" +
                "3q5qe6W4fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W" +
                "+p6X67XDgcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5Lrs" +
                "dO4EJG/vq60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ9" +
                "40Ho6an2pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGB" +
                "rZsNsM8P4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJ" +
                "BgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRw" +
                "Oi8vc2Yuc3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcD" +
                "MEwwIwYIKwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUF" +
                "BwICMBkMF2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUF" +
                "BwMDMFcGCCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNk" +
                "LmNvbTAmBggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYD" +
                "VR0jBBgwFoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg1" +
                "9YQSqCwFDvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgw" +
                "BgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQ" +
                "iZi+uJqsXWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J" +
                "1/DDybiqQwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe9" +
                "3bMqnJo9vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d" +
                "+CjNTW/rDfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7o" +
                "z/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsQw" +
                "ggGsoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZR0MtVVdQ" +
                "IEludGVybmFsIERldmVsb3BlcjAeFw0xODAyMDYxMDM1MzZaFw0zODAyMDYxMDM1" +
                "MzZaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0G" +
                "CSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCz3D0nFCyalZg5IN10NjknQ5WtJQk+" +
                "pCRXkxpI3JMQKWiiLZHGzkLLNlE56YqTS3Gz0Zkmbf7kGxir4wEythjDjRDu0y8d" +
                "1Y2tRBCo2WSh+OTQVuN7BjhnhaEamfE4iZy1XjNhLJvcLEi0VdkYe1dI/X/ogmw9" +
                "F/XLrhuHU8EMLkbeHRfPjM/hmf5AgCUwjVlsD/2CzZTdCpd75a4cqqWOjrZUAGTg" +
                "owFkii+TOflpd8w83PhB5VuAVhfkAawGgyf0P/MHk4vFCA4y0GEyy8qNOPkROwEm" +
                "K2HFchDkqtRmMqs4+7DHa0qmCt2A+A19A5y1Xok8vcEsLCuSrWNDZx73AgMBAAEw" +
                "DQYJKoZIhvcNAQEFBQADggEBAAkSKZVDkXQyTQ83Ij0mm3otFX6uboDgxXR7/5+I" +
                "Vfxv8qOFy2MHiwNhaLY+FGSBacBqp2ocZ9PGgfQTB7ATIvRLDWjYBhkdYIfsLmLf" +
                "nWPVJV3wPedz1fsqffDm0zN71KCPi24Mk/gz5vr2YJ4n+MSwHVh5ib6zvNj6xAJR" +
                "p84hSAH0M3IH8UoH3pwUR/gklHT5pRKlDyxwF0WW4e78VaRF1NdFRgzDpHUXaBYx" +
                "utVN3BznmQID1LDm4nyiuV53d2rVKQJooSoWyAPHbyyew2eQWMaU8Fva2XnrwJiJ" +
                "Z/ktrluA8ONUHP2dAh+GxQNZTCdJ/rL6u+eVWahP+e0/As8=";
        }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            C1.UWP.LicenseManager.Key = License.Key;
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
