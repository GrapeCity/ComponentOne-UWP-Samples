using FinancialChartExplorer.Common;
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

namespace FinancialChartExplorer
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
            "ADQBNAI0B41GAGkAbgBhAG4AYwBpAGEAbABDAGgAYQByAHQARQB4AHAAbABvAHIA" +
            "ZQByAGvD2VE0IhbhvM98B9RK4ItSx4QqKaq3CeZm6Z9X718am9DL9A4Q5G6+5/Bt" +
            "SqRVEGqKeGwqLHcI0brSLWcATcVLnJJTMaEDFqzGibN5qxsu2A/WRmrQ+vKfQIvP" +
            "TqTFtu8J6TLa9xl+Ogo2PUEGwJsolKXBjOWeknjw4n/w+RbOQWgUccSqzY6TOOhu" +
            "QgQEhVEHModFLnr/lDt0sKH7KeQ09joDSZZoAy+MqfyolYcYqGbKtQC5UlC7wueK" +
            "eESiGHTgT1Yxt1l23djRCFm2xinr2poMqfGtBXwI5zv5/gNRLY1Y9YXvcEiVRZsU" +
            "3OTpugw+BdoKfw38KjYEBZgCkVh1zJhhT2j1LcVnfTfrGRM8qlkkg4lSl2yGqrzo" +
            "Mxw7R59KmUALQk+zsz3oFOUgTwcK4QM5Xvg/5khZIQMVFBK9BUomxv07Z6KKPwLc" +
            "HAM5Uo2R9neD/g4/q5+vhqWeOqeFK1+NqSwt/5JZmf2G9Sjm1vFIkeNJ3P93e6DV" +
            "TK4XKF0eyhmqaLsqvdi1g0PVTE2HUexr7/zF8miHBJA0GEP43Ni4orjK4P3hNmSU" +
            "w7sH5ic3XhIzbl+c4hMnnsrJ48f1hziP9W96cax8cLKDIpIrX43PLiRC0v7lPBhj" +
            "M4VjTm6EomFFId9Wpe+8skY/C71QYTYpqBKoQOp0cvaF68JjMIIFVTCCBD2gAwIB" +
            "AgIQQQN40iY2WXoW2ybGvRCUizANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMC" +
            "VVMxFzAVBgNVBAoTDlZlcmlTaWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBU" +
            "cnVzdCBOZXR3b3JrMTswOQYDVQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93" +
            "d3cudmVyaXNpZ24uY29tL3JwYSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xh" +
            "c3MgMyBDb2RlIFNpZ25pbmcgMjAxMCBDQTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEy" +
            "MjIyMzU5NTlaMIGGMQswCQYDVQQGEwJKUDEPMA0GA1UECBMGTWl5YWdpMRgwFgYD" +
            "VQQHEw9TZW5kYWkgSXp1bWkta3UxFzAVBgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRow" +
            "GAYDVQQLFBFUb29scyBEZXZlbG9wbWVudDEXMBUGA1UEAxQOR3JhcGVDaXR5IGlu" +
            "Yy4wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDBAvbKZVuylaQKkQel" +
            "VQe1yZvPmutMe/B2VjZrwI7P3q5qe6W4fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7" +
            "PpxmyeVHzOgpXam3kbEOM70W+p6X67XDgcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR" +
            "2S3/xHL0iCr0W7tyCzhN5LrsdO4EJG/vq60gVMiSl1PJ1vHPivvbH1qh2D2/BRdi" +
            "Gs1sYZnyHSKAzSso696/8CJ940Ho6an2pohzbFPztuiktBHLwkuQhTig0+r73ZwJ" +
            "HpN5Mi1nn/nGv3GxaO+L2sGBrZsNsM8P4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvB" +
            "OE/vAgMBAAGjggGNMIIBiTAJBgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIHgDArBgNV" +
            "HR8EJDAiMCCgHqAchhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNybDBmBgNVHSAE" +
            "XzBdMFsGC2CGSAGG+EUBBxcDMEwwIwYIKwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1j" +
            "Yi5jb20vY3BzMCUGCCsGAQUFBwICMBkMF2h0dHBzOi8vZC5zeW1jYi5jb20vcnBh" +
            "MBMGA1UdJQQMMAoGCCsGAQUFBwMDMFcGCCsGAQUFBwEBBEswSTAfBggrBgEFBQcw" +
            "AYYTaHR0cDovL3NmLnN5bWNkLmNvbTAmBggrBgEFBQcwAoYaaHR0cDovL3NmLnN5" +
            "bWNiLmNvbS9zZi5jcnQwHwYDVR0jBBgwFoAUz5mp6nsm9EvJjo/X8AUm7+PSp50w" +
            "HQYDVR0OBBYEFABa8K2l1Hg19YQSqCwFDvhWG46OMBEGCWCGSAGG+EIBAQQEAwIE" +
            "EDAWBgorBgEEAYI3AgEbBAgwBgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKY" +
            "WjeOW+VYirEXwgOoW1XqjITQiZi+uJqsXWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/" +
            "T43xieeWV+LGZaqMXn5U6R4J1/DDybiqQwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIx" +
            "yAENmRH9jyek00hXL49uMIe93bMqnJo9vdH6cA7R2hdoxOaav7UATifLw5DeOsLe" +
            "KjIRupyKToHPSp4Miy3RDu1d+CjNTW/rDfSZKk1lzaDapTn+0I2B8JcOyru1t5CB" +
            "ivn9ZD9cakwaV8LARObC5Z7oz/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOY" +
            "wLz0Hl3ry5zGIqia4DCCAsQwggGsoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAw" +
            "JDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjAeFw0xNzAxMDEw" +
            "OTIwNTZaFw0zNzEyMzEwOTIwNTZaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5h" +
            "bCBEZXZlbG9wZXIwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCYH/1x" +
            "C1n/88regQbcxFJ6sOUhILYu7HK0RCmSRU2wgYpvgegyxFS0y+TyrBZCVucIlwG+" +
            "DbysTPOt33P6cKLUSA+GuKbtyFT+t+p6vk4Sl3X9NR9M7IkwHV5T2UHs7O26hLuq" +
            "opZVRCJ6r3dMSjIGXvlJuQhnDxCqYMGSamipZG8HRrmBeiMow16IpDllE8sicS24" +
            "sE1bLiElwf4vJ8Mvk5wexRcW5N2mbUFAbcTjgwWL2rfwvReZ+fJT8UVG3UZKHC7D" +
            "vVMYAEEi0N6/hJW6iBmDoN0yo9FVWQ66onQPX3uMfFDVBiNpdz45YK+WpBkaYVy+" +
            "d+ntYDmE17L1yJmLAgMBAAEwDQYJKoZIhvcNAQEFBQADggEBAH8he8/G/tsqO5CS" +
            "10KDcrPtQkFe6YeWWmj4Xrez23IwS4192ZK9WWWqobLLFUoBFUTPu6u+ahwBqAOp" +
            "dwh1uzQ8Ur1hdf4NjRO6HqfNx23vzYVpqC+cfCb0r14yOk/8sB/phKAjBgyEn0+2" +
            "XyGoPDOKqbPdhZOu2J42PB7QM9Kc8TTwFlcw9Wwr53MbPBJiQ93lyuuNCRqN1VaQ" +
            "QjrnJP158KNfP5MKJ/WjQpti1wpPaZ8yzv3fAQogsmtYs2YSoWn6lcIyjwNP9G0/" +
            "f3Sh00VeKImtlrMywXyZE2vBP8j42DudWy9A9U6F3nekjwywgIAh1wxwl+ZSvxyF" +
            "UyAkam0=";
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                //Associate the frame with a SuspensionManager key
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");
                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        //Something went wrong restoring state.
                        //Assume there is no state and continue
                    }
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), "AllItems"))
                {
                    throw new Exception(Strings.InitializationException);
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }
    }
}
