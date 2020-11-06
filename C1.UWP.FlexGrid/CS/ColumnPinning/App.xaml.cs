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

namespace ColumnPinning
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
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            C1.UWP.LicenseManager.Key =
            "ACIBIgIiB3tDAG8AbAB1AG0AbgBQAGkAbgBuAGkAbgBnACMSZHEX7ORY4UOwsp9z" +
            "FgHs9+ZUK2/mvptGXBLdfrNkbRu925CCJWBt8L8zZdaxYuxDgxApVA0tH7UGvg62" +
            "+XXY+6ypXoigND97S917uJUXV8bWK1pYzV1BFpnUSRqUyEzAO6Vv+WKwrucgPReK" +
            "gzcr97NSeENY/qEKLcqnFefncldPxoF2Tj890rWfPEJZ455v0HaaqHdnQJOmoB/V" +
            "4wEmRQT2otV5NF+JiQbOUJnh2zR1SlcqIUu2HmJsZECjLuF9YMiThePoW5Y4isIJ" +
            "WDNGDZc9kgScC0BGAB1BQwdQv8zO9DAsrZmoVpPPya0BdEwNfozrj3yTuuGmOjfw" +
            "I2ukqFh0Ay5MUJ8S7c4CBIeCdJ2mCz9kLqgqt3M8HFvMSCL0ZWkf3mryvzGmexW5" +
            "FOQj24YDLwsP+t2HCqt+ShbLPeoEexGXH3vhcFjbxMhCxAp6pJIiB8cn5wBqZw8p" +
            "mdrcgdV5YTF4EPAco6sAL+bLza81fpmmMtquOXW36yZSx16Y385IsGaw5y/oM07V" +
            "hFRl/eyxotNtLfoFD1l7tvLATyNhz2bb/4efzJM/zYM9Xkjk82ErSArdr1q9sh5y" +
            "fCsYZYfa2804Mfx2VB0/YBEBli04zPUUCWo9c2XQpAiZaBI/A6rUTyxH8Hnehses" +
            "UR69NPDMVp3vfJ+5r7Eia4gUMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCU" +
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
            "z/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCArQw" +
            "ggGcoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwHDEaMBgGA1UEAwwRR0MtU1Uy" +
            "MTkwMC03NTYwMjEwHhcNMTkwNTAxMDAwMDAwWhcNMjQwNTAxMDAwMDAwWjAcMRow" +
            "GAYDVQQDDBFHQy1TVTIxOTAwLTc1NjAyMTCCASIwDQYJKoZIhvcNAQEBBQADggEP" +
            "ADCCAQoCggEBAMTOLX9UMm38RH/yGNj9PRNHU2sHJZyd8KgvOVWlP3PMDpAYYpH1" +
            "whvmOciwig3BH1JWovyjAw08UqiBVg+dAF0W24GaSpTVPaIunIhoy3IA6Cc9v3YL" +
            "UqFkbL9wMixn3/7ZUvvUqaGZ7rapYpgDvgoS/IDexwa/tINpgYXQquk9Ezkjpzyr" +
            "KlynwbHdP/N3xKi+ozKITtUKw5BVYn7UqMQg8Q0hO6k5xO2CBOodCLnwH3dVqGH7" +
            "p0QeMQGqlc78yI2SQE7VkKeKDvknoANPsIvoguGN1ZWccGuSncy8bzsq6b+uYnhu" +
            "KbSyj6Jepa4ioCOLKgCvNZSK+yAxLyqT8QsCAwEAATANBgkqhkiG9w0BAQUFAAOC" +
            "AQEAPtORCWEsqA0EN03WGSnr8ZkfbC4YJnsxIsIm+WjvbjUf+Hc1AAaNRbHAZ6T8" +
            "VkT7F8GV/DLZ756gGIvrQth9v/hD3RZ/wASNGrY3z5khpOuEGb+PbjfKvbACvyVX" +
            "VM7csY1T5aMo9nVEnf5vMYrl2Xa/tqd0peTAkhuN6M5YTbJU2YTp9mC1b5G6XTAo" +
            "rHS85JqY0KQ5feMrCFdrFFzFt7uuap+r0F5qFHU0CI/0GWxBy5CpNX4at7yUfcXH" +
            "OhBPxkDVNn0+D4lshPZw4BD41VE3LTOGa3YEMRhExgO9ZRyHHfZy/7+S8Ls4jsur" +
            "Lg3ck5XVJ/4KdrtKcgMl3d0F+g==";
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
