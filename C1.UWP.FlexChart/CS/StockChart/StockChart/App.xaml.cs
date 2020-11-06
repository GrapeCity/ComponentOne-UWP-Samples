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

namespace StockChart
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
            C1.UWP.LicenseManager.Key=
            "ABwBHAIcB3VTAHQAbwBjAGsAQwBoAGEAcgB0ACTAtMPTJqvyr3UObFh7A1vfIR2J" +
            "8hP6P2zAAgFLVg4gJKCjGOvlRJkAZkUE9mPN8qzXhaNDgewonmRpBFRrBzio70k/" +
            "QVBXNpZrz0Dd/Vxlh1wcYfKxRkbvhi6+jIeGVMCX4IRog3AQVVdvfur60+LpWGTi" +
            "KjbNbN8DqJ1Ci9IUeutVH4dxEcjnFikv2RUBTuuk3L4lPDQ9qdU+on9qj2wD+9wR" +
            "WGaFcRBHzQDPHU35l5KIoSUtrK+ghVuqCgX7azydKk02Njzaw0z82RZgyerucHxb" +
            "f2a5VISQICIX4aqJuEmZEr/s4MsBe6BhYS5bKZQNBQQApmmywu/rzhz69y+ECb+l" +
            "io8uOILn/kz4kBMzeWajlCRHNe6TtHImJh+7++Va2shKVOBqGpJ/AR/PrLuw4Pw2" +
            "CSz4c75yrJGEikXjCnZATJu7D9C+4J6YETZKrsa1UsUh6dHhZrIpBH8y1Z21P8oF" +
            "fM6+PWT27MDuHxbmZhuTn7VotskPfWwInL+77W6075x47XH5cEwotScBfCloRxP6" +
            "NFyWd25ifsTTyeoIZ0zisVJgbfxy4eUCn16pIGcDyJtHTUcPWRzhSk4vtuoIcvSU" +
            "Fwwj2SwHocYGQcFzz85vY7NOtHVCjnFImfS/dlvvCJ319DCPD4enm1wpxq7n26Gh" +
            "/BfWMub6B/A798W8MIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkq" +
            "hkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlTaWduLCBJ" +
            "bmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYDVQQLEzJU" +
            "ZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYSAoYykx" +
            "MDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcgMjAxMCBD" +
            "QTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYDVQQGEwJK" +
            "UDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkta3UxFzAV" +
            "BgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZlbG9wbWVu" +
            "dDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEBAQUAA4IB" +
            "DwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P3q5qe6W4" +
            "fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W+p6X67XD" +
            "gcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5LrsdO4EJG/v" +
            "q60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ940Ho6an2" +
            "pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGBrZsNsM8P" +
            "4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJBgNVHRME" +
            "AjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRwOi8vc2Yu" +
            "c3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcDMEwwIwYI" +
            "KwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUFBwICMBkM" +
            "F2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUFBwMDMFcG" +
            "CCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNkLmNvbTAm" +
            "BggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYDVR0jBBgw" +
            "FoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg19YQSqCwF" +
            "DvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgwBgEBAAEB" +
            "/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQiZi+uJqs" +
            "XWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J1/DDybiq" +
            "QwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe93bMqnJo9" +
            "vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d+CjNTW/r" +
            "DfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7oz/iQKlfG" +
            "ipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsQwggGsoAMC" +
            "AQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZR0MtVVdQIEludGVy" +
            "bmFsIERldmVsb3BlcjAeFw0xNzA2MTQxMzUzMzBaFw0zNzA2MTQxMzUzMzBaMCQx" +
            "IjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0GCSqGSIb3" +
            "DQEBAQUAA4IBDwAwggEKAoIBAQCS9Byny47bwV8tkZRwDvn8Qp9rQBXqtIWUNDiC" +
            "1B2xg9jgcz/xIoxWmqTxbzMUF1wHyI/p5QgJYktYdFdhRzMiNBUHQ+xIQXNc4h9B" +
            "4cUXIUv26qQzBP2DqOMiWLmbXJAPI6delmVptlu2fnU2h2DzKRkqZ6CTutu+ReP6" +
            "oyGy41inc3GBuPIddGRkzH1IbQylXavfLEMa8j7Lq8M5ZN9F/YRD4mbF46l1feou" +
            "gk7PzDCsgSiktz1lZzc3t3ei/RpEZM5JyFKlksgFmcb2zSfrDd+aVkHWPbAx3Z6+" +
            "teP111uG9VSOEXrJWseMrdD9C/I5b+dW4eK5W1GxCEF5qOZ1AgMBAAEwDQYJKoZI" +
            "hvcNAQEFBQADggEBABRyPCVqMBo+uZMjLG0CCXoTpsoVNeDXWdnujy/JtyaTnOuZ" +
            "z20zwcwF55XIlZrHncb1TmntLQK0+HiJt9qRE4wqy+D/KZ+xj7khajObMwpmqqHA" +
            "gqhOmFtOJauviVgB57GdiawSkweojLx+NRSMZGoCwLFmFLPxDRKIvbwLOzi8Laap" +
            "23hmbaDDqVBDzJQRi9MLAPabvqCthLTYr/xHMeCaMoF/GfU3Ae1vvHbS/lZ/vT1e" +
            "buENM/RIzYJKg1kX/7C02t2Peu8RNWBZYVaJXEkU7G7QtgRU/HHyAHky3EZ+ZeZ5" +
            "kAaZhPRoy5GuwYtRvo8Kl+rLQaywJjbhgtHzbLI=";

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
