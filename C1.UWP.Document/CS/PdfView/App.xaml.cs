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

namespace PdfView
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
            "ABYBFgIWB29QAGQAZgBWAGkAZQB3AELCXfdDrHGZMulg9z/piBJk5bq/VtHTJfBQ" +
            "JymIj7ixBBbQJqCShEIJpAIB4weq5J1Ti3rkjeoHeVjRtKfVCubl4Utbk655upcZ" +
            "WiwkfPSVwiOCyOny4xneXrCcugsWaGPJCQnicGSFMh3XGrC8etyugYAkU2/zzybx" +
            "O8IrNEgMo5NTK+x5qzVXX5I6ZldBvIUKsRQn9BPbHuKLUcO2t6iIykfFIszq6b7y" +
            "kSmJ9ZhhQwBz1H26RHGJZ9orSrNJ7j4zRaxhABVwd7KY8erGG1X5mk4ULmTSuWLh" +
            "stI8LxsIr2Y4MLKAJcLI3+ChqZvIusVEm+htVG4Vjsg9CaD8pKZxHx/OvmlVckFG" +
            "6bUkXF/5HJp/UKsOW640x7hfYhmqsUH27SSKRDBmJX4F0Zu1UTg6QcDHzbjM5u5/" +
            "ITuJ7vvaUzxbx5SxAHLtyLJfwj2GBf01waiSyM71ZwtkFODYRW/9Awa6LqMa8U83" +
            "29kbuxkT9m4B0M2wDG+SB0iPRpUuoPdyZs7OqKawL6/2jAIW55zy1yp11l2fN4G1" +
            "VUmqRrOCf4iOQFvVJFduPvpvkg6AhKsfKVnygJ6nnXpVSI8sSd7DA4R4b9Hl1dEp" +
            "qP1kgWEd81oNmyqsg9M+viFRlqaaKau0RDb0vNER2YQU4ekPIyIX9dzqMCk4euRz" +
            "POlOIcOnMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkqhkiG9w0B" +
            "AQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlTaWduLCBJbmMuMR8w" +
            "HQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYDVQQLEzJUZXJtcyBv" +
            "ZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYSAoYykxMDEuMCwG" +
            "A1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcgMjAxMCBDQTAeFw0x" +
            "NDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYDVQQGEwJKUDEPMA0G" +
            "A1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkta3UxFzAVBgNVBAoU" +
            "DkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZlbG9wbWVudDEXMBUG" +
            "A1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEK" +
            "AoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P3q5qe6W4fDPR2LhF" +
            "U0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W+p6X67XDgcH2DsdM" +
            "KHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5LrsdO4EJG/vq60gVMiS" +
            "l1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ940Ho6an2pohzbFPz" +
            "tuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGBrZsNsM8P4XMJQDSE" +
            "GggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJBgNVHRMEAjAAMA4G" +
            "A1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRwOi8vc2Yuc3ltY2Iu" +
            "Y29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcDMEwwIwYIKwYBBQUH" +
            "AgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUFBwICMBkMF2h0dHBz" +
            "Oi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUFBwMDMFcGCCsGAQUF" +
            "BwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNkLmNvbTAmBggrBgEF" +
            "BQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYDVR0jBBgwFoAUz5mp" +
            "6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg19YQSqCwFDvhWG46O" +
            "MBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgwBgEBAAEB/zANBgkq" +
            "hkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQiZi+uJqsXWL8N4LB" +
            "eKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J1/DDybiqQwbJO1pI" +
            "YhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe93bMqnJo9vdH6cA7R" +
            "2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d+CjNTW/rDfSZKk1l" +
            "zaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7oz/iQKlfGipQSQykS" +
            "NyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsQwggGsoAMCAQICBA7u" +
            "7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERl" +
            "dmVsb3BlcjAeFw0xNzAxMDEwODU2MjdaFw0zNzEyMzEwODU2MjdaMCQxIjAgBgNV" +
            "BAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0GCSqGSIb3DQEBAQUA" +
            "A4IBDwAwggEKAoIBAQC1JdOxQAtW+kO7bCmHMjdc9AYau4Ad8LezJdTH2YrmFUY4" +
            "ly+K5iiq6gUflYyyRyV/QgNdcj2EZD+zr1hz67/4Vh3OwZ15//ZrPe91gtd8yMZ2" +
            "hYVv2o55xEYynhEBa87oLxc6k9R2mdPYJj8S+8jJuxE+TvZug06OkkoT2u7FdY7l" +
            "M5GKnMRZH3/TuGFynykGqH5Ggva6yRT+kAgbcfNDXf0ZfH4tdMGTWgeJkyINwjRN" +
            "BLLVBn+7lum/oO/1rKqbCQ0JS7GNxq8DRwNGioWkI3Y04eBSKUDiP9qK/2XWQPvY" +
            "qdMjRdcnm2jvlhZ02uaehhRZpjIv5uwMmL1IIQpNAgMBAAEwDQYJKoZIhvcNAQEF" +
            "BQADggEBADrgES0xaT2B9JaDffFSzZMCQ/UN30PB8Jn6BxdHk1UOZ+2mTxhBWySw" +
            "HTbZAERVh/0Fcwr/rpQnMRuWeJZVaMpovVebI/A6QCbKWmJeT/RfOnmSAvRptDur" +
            "pURE/WzBO9Znws6MG7CF48EZgkfO5KkN3Whib8YPHAQMBLIzn2zSK2f/ZF165hv/" +
            "Qq53pt2DKrsoUI2piErKV83ljWlIigu6qF6rZqSxN7/1q5hgrlFgTLzI5EaM/l3P" +
            "JN676zeBT1FV6mDsttuPQhB+S980U3i8tkPgAAGafZOjwotAfykaidkTRojpXaH3" +
            "bIXxNtb5YKVojgQElfbRwq51JyyAl8c=";
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
            var frame = Window.Current.Content as Frame;
            if (frame != null && frame.Content is MainPage)
            {
                ((MainPage)frame.Content).App_Suspending();
            }
            deferral.Complete();
        }
    }
}
