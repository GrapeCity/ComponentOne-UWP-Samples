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

namespace LightViews
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
            "ABwBHAIcB3VMAGkAZwBoAHQAVgBpAGUAdwBzAGxMMcc03m3qRA1jBqSrZ8hiCxHi" +
            "QkE6yOeT979ExLdI4fNYzGAO+8nWEC4ujSM1QHMqQP1cbACm5zhBbz5cFy7dBmBE" +
            "ZRm3z+Wwhx7RjatwTw5dPF9B0GcX4qm1hkzwVbzth6aE1Nr2Y5cJVk9McdPYAUnU" +
            "wN2uvxRYi/QKtLCevQUQFUHjxg0fxsgS1seg2KjhwgXQp3vELG7vppDsw21Otw4i" +
            "SpGjjhP2nK3sYAiT63j7bKrtr52GkvYg+SaKXIKvXCm0EqFhXX18dX0jIT4g8Pk2" +
            "P7hFeSaGpY/+gOc0cTjkSWABmqBXZD/B8jdQjOdZKwx4Qy5w4fT/HL94JS0o6d1Y" +
            "K54C73H7jhS4BMIukVs3KXudbmmJ/ptF0VzKEpgVSQXk32+98B7lSCNG+vgBQwjj" +
            "WW1zYnb8t741Za+d8708MXTep9x3ePDsy637da5y/ClmgCAyrzBPZ3YCOElxAQG6" +
            "rfZj77Ss4fZi34MLuw4yUA0DYYNVdU/jsfqac+AXelNxrAFlNW0JmIaVZX32fyWY" +
            "WOOJ+kqz0y6UOkJlmMqxGJvndKNhh8nwkv8VtegkibBoedzhLLS0BbWOcznYzs1/" +
            "hCyRjILbwpKjosKL7/j/XSNNlU/9cMse4CoB4c+9D0/6bRyCRF3wVORg0mRFYElg" +
            "2I/eraZAb4UPQjakMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkq" +
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
            "bmFsIERldmVsb3BlcjAeFw0xNzAxMTMwODU3NDlaFw0zNzEyMzEwODU3NDlaMCQx" +
            "IjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0GCSqGSIb3" +
            "DQEBAQUAA4IBDwAwggEKAoIBAQCpAnohVaPJavRhqFSRp9YRCT3MHtYr5Jv5q+l6" +
            "37Pv98Zq6s2FcJfVbtYD1sLeOagkLzskdEfu9ZoL335OueMOdK+ZaR2vNm4bA0Xf" +
            "br63ZZ1fmlqvYlyCN2E6uDuclIAw9ju5ViSFoBGtvS9fouaPSsKV5XaQv2VLXwlY" +
            "RJOiDbSzf5AE2spmjKq9CGKdndPXxzQHL00SBxajvcI4HsR/xsW8sqeP2gZCM4eC" +
            "fj4ZreBIrcG9cpwJ5gFAlFCVJV8U/Mq/BkkcVPdx7JGXSIV1zAqWy5psap5BcH2I" +
            "5bjzBUCe2nyJWTHp4lrfJz1L/ITeHypwGNd9EG3AELreb89nAgMBAAEwDQYJKoZI" +
            "hvcNAQEFBQADggEBAAFD1AD6aMzPxRirsMVAzOyWSO/TNKs01MEOtwrfHzAHYmZL" +
            "3l+RQxa30kXRJw/XSdVG7hf34aKua6bc9nQm2yx1TU5CiwZJxkBrb8vZGCt9f7rM" +
            "bHkJFhpHXzAHoghHBTwYNKH+eDGCQYnlK+lRe396spWYCyHpVyKGKpP3h3BRIqkD" +
            "xUrR9YUi64/Hh47OH8NEZBzj2nXaTbYRC0yEDcynqoJqihtjqQvpalCkwHoc0XCD" +
            "GR8lqBwQYLfdzfBCgKPkRaTnhnKuPBhQRt6cEkPXASp8+yHSHdDIe/5O+7ycRoiX" +
            "NfDwvFmmX8DiC6upV5eR9+pX4Z/3qrympFNjxnw=";
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
