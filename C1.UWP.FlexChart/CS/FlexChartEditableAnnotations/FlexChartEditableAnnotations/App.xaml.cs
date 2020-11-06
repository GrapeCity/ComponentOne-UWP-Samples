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

namespace FlexChartEditableAnnotations
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
            "AEABQAJAB5lGAGwAZQB4AEMAaABhAHIAdABFAGQAaQB0AGEAYgBsAGUAQQBuAG4A" +
            "bwB0AGEAdABpAG8AbgBzAHDn4yfVXNWw/EObh2a040ibQ2f+GkazXOck318uYohV" +
            "RTbFFbDrIUCoKbCmIT6XkAPbmdEU9pih+JwE3vMORjGDABz5E0LpdPzV3QS17l7U" +
            "kCw0kiMSGRoyj3HFPWVN+ZM8Q9dzXks8cSqyXHLFuqrYTWZTSO/15oSAIRAL9ArP" +
            "n3stB/a+SjvhXzdYV/Ru6DIZTuM2Z+dJThz+6niPaehV6CXSJSRezAqUze/kakfa" +
            "zP3hfs9QgHrqIlKzThsAqiGmJ2IwoKkiB+dnZgGWZzEo2WvJx3B4ubUvAWxHA1BK" +
            "rWxams5SbhMFT6b9rDT+xbgmNUu5DQ1l2RBm6vf6GKEFEctiLhjAw3qSIRSzDFJk" +
            "DB91ZxiKR/z3DXqO8vzlqZX9qUi1n7JbRp0zHVEQvLiLv3iqq9ulj7rk7irl3oAv" +
            "NJRBq+DUFwK8boHxyJUqJDh20gQomeib/peVylZuF55U5B+pepxSf8avpX4liel4" +
            "VKtwLORu2TKHZZipBNgg6y2Xo4SZ0Y1vi2TCxXljRFBRKv26VLIj2JFKXo5csBfw" +
            "nEStvzJr4TeGC9wsbg4XcuK28d+4SI7lA87KdjwXbScOe7sEahFbLTswnhEGFBfQ" +
            "O4Van63OV1P1y0cv8De3Z3Wz9WXhoznDwYWL1TNaEB5vswxIw7owKBll7UiTK2gd" +
            "MIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkqhkiG9w0BAQUFADCB" +
            "tDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlTaWduLCBJbmMuMR8wHQYDVQQL" +
            "ExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYDVQQLEzJUZXJtcyBvZiB1c2Ug" +
            "YXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYSAoYykxMDEuMCwGA1UEAxMl" +
            "VmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcgMjAxMCBDQTAeFw0xNDEyMTEw" +
            "MDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYDVQQGEwJKUDEPMA0GA1UECBMG" +
            "TWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkta3UxFzAVBgNVBAoUDkdyYXBl" +
            "Q2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZlbG9wbWVudDEXMBUGA1UEAxQO" +
            "R3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDB" +
            "AvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P3q5qe6W4fDPR2LhFU0Y/B+G2" +
            "l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W+p6X67XDgcH2DsdMKHmEHyOl" +
            "cy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5LrsdO4EJG/vq60gVMiSl1PJ1vHP" +
            "ivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ940Ho6an2pohzbFPztuiktBHL" +
            "wkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGBrZsNsM8P4XMJQDSEGggMc/uS" +
            "R0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJBgNVHRMEAjAAMA4GA1UdDwEB" +
            "/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRwOi8vc2Yuc3ltY2IuY29tL3Nm" +
            "LmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcDMEwwIwYIKwYBBQUHAgEWF2h0" +
            "dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUFBwICMBkMF2h0dHBzOi8vZC5z" +
            "eW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUFBwMDMFcGCCsGAQUFBwEBBEsw" +
            "STAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNkLmNvbTAmBggrBgEFBQcwAoYa" +
            "aHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYDVR0jBBgwFoAUz5mp6nsm9EvJ" +
            "jo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg19YQSqCwFDvhWG46OMBEGCWCG" +
            "SAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgwBgEBAAEB/zANBgkqhkiG9w0B" +
            "AQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQiZi+uJqsXWL8N4LBeKDgg6Ij" +
            "OpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J1/DDybiqQwbJO1pIYhLuuXwc" +
            "G/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe93bMqnJo9vdH6cA7R2hdoxOaa" +
            "v7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d+CjNTW/rDfSZKk1lzaDapTn+" +
            "0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7oz/iQKlfGipQSQykSNyIZaxvQ" +
            "iVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsQwggGsoAMCAQICBA7u7u4wDQYJ" +
            "KoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3Bl" +
            "cjAeFw0xODAyMDkxNDAzMjFaFw0zODAyMDkxNDAzMjFaMCQxIjAgBgNVBAMMGUdD" +
            "LVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAw" +
            "ggEKAoIBAQC2ip5pS2jIQ5U3xohPEZoZlYuNMyblbEED1ZHu4tFIqnIzbwKGJblM" +
            "Ijzz0ePFIHv5DAeBiEz5Uac4H+dZyQZRkZJypaOTHJfwFoxiUuq5LsTZo1MbmdiF" +
            "0KahxVdkvBGBXSRbfiBUzCCFjx0UX8d+S//60SsagR5lS09H5SGbxKBgWUEzNZJq" +
            "fqkUkfZlMRaqpcpBJehD82z6O2UxrNyLGX+gYAwVZaoUqIlCfPMGcfb3PipNrn2e" +
            "hKzZSHzMkMg0N10maWrxdy0FcQ+tKjxCxf9rHZ1S/LlyLlo1kA3wuZTVl3Q9WXK/" +
            "q8jjbPyQTIqR8wUDtLGzjiL8RTuYR1Z5AgMBAAEwDQYJKoZIhvcNAQEFBQADggEB" +
            "ABC3Q5pDrrnAL9cCGrghNs73QbSPmAnFv9U269g4NcUdiap0pBg7DWKQOfXBa+p2" +
            "vZj+jrNjnQUHwGC4krUCXASTiUGNAHb7IyNVAMv1OcuA2ZUtE0QGdTwhAjz0e6PJ" +
            "KPgA34ErDTejGHX6HhagQEUOCaFh/ND0i4lR3mRFAX92yEkw5gB26EPVLWNdeP8V" +
            "mnbOq+bKe+eTX3CU8sZTA2oh+aysIpdqTd47jjrXLnmERHvTZFw/o/MzY0XN+Q1D" +
            "52YEv/zc+8fZFUeNi9jABPg/a7N1gVUQ+/RiCKTdC1BTm2JOR6P8kgdfjD3Q5faO" +
            "zES2ij/Wl9wSKQU39jEZhFo=";
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
