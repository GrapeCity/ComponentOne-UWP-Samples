using FlexChartCustomization.Common;
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

namespace FlexChartCustomization
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
                "ADQBNAI0B41GAGwAZQB4AEMAaABhAHIAdABDAHUAcwB0AG8AbQBpAHoAYQB0AGkA" +
            "bwBuADH2k7C1+h3eC6ze75FSR/8VEH7qaXZulsAobH8RSR4FrKI63HsM1YLZT1Ip" +
            "QuFY/jNiAesqdQLjD3NUsvMqpyKIeHEs+UAOGys607S3vhn6BPtdUWGHuT+I2x9n" +
            "f+TRqZ3i34kdMx+4feh/mZ0BeXoZ2WKdwz+Ul48lHq63hIB8+wSqb9eAlbtSah3G" +
            "vMdxwgI0JLhRj5xkEr6aFCNdD0gTPVKexcQ57yQqE/nfhQyPIvInw5NXhDEKfKLR" +
            "KRYCpsJ5xlOxhCVJY4INTOs/EbqU57hMfAJGRrjsmBBu8RAT6XDPTkIZ8e6W4lfQ" +
            "xCdrwt77rsTS5zEmA2IHrwp3mB2clsq7zLrMg0/RY4yNN7Srx8ymDAqrl3hAFQbJ" +
            "H1cGrPWtCryiC4LzMmZZnaWaueFMaSrCDbpgYLcCIORZWvo1wPo89o4TyZlSju1C" +
            "E2xeeJXEycPEwaad/3Jqx2iH8Z05fJsSqXldoU3balX7mG9uNRkHQ3RbNBOoJu7z" +
            "Q12+ot8qKZwdwWnf579ZC7xRnFiLrKqMRl2XZ/z/xHTVcinhrJz9qAMWUQhDWRjS" +
            "+ROqeF9YieyroeUBc5nBKpuTYZVA+1bqB0f9k9lXN4CkDZS0XOAueSDdSciOdz35" +
            "Cp15HpwgOpF6TDP5s0kbqbAOp0qtLkkRKE9HjcmVbJA9LvYDMIIFVTCCBD2gAwIB" +
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
            "JDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjAeFw0xNzExMDkx" +
            "MzQ4MjBaFw0zNzExMDkxMzQ4MjBaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5h" +
            "bCBEZXZlbG9wZXIwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCDDSM3" +
            "4ZRvf7JSpiupWZw29zkDq6Mpc3LuG9I2S+LWKZ+pZpyjxsMQgEZKvJmNoOy7XpHO" +
            "1wDbWZlKZSk/73L76v12fPAzek/yEIL+4myd81LheS23Z2nvsCJdcZLMGfFQsirL" +
            "8O4N0Vn2k4nMYwO9FLy1inAeZx0PIe8u9OPPSue8Tm6vYknz6XBdmWNodK673L9M" +
            "eTsarZ92Pu9Gs1kyBoje1lDmf9kvgR5vI/lcY8bVSFaCAneBeaDxoxpuikU7uhmE" +
            "gOT/W2vGPeQE5YaN6hAmVfCQhQbZYeN8BciGbx2Z6qgBMiL2r9WfiiIWEvmMdLWL" +
            "+6Q0v+ZxnPtvb7XZAgMBAAEwDQYJKoZIhvcNAQEFBQADggEBABTgmAqKSSFFbar9" +
            "2F7XZq9mxlahlrdoPLGN+rmFHOIuwBkIi5ZcdeWxUnLxkaUaOkCZGMdqHaVg2xbF" +
            "CfwVE2lHkmUVPEC753qyKeX5Kui3M/bL+VTYxKJ0cFo4OQGGQofZOz6RJ6f8cdpt" +
            "2OkMuXY61SWXFB+87SJUm5eV9eIl4UKOJvJiQhQ9KR+esbDU8y0awvONrPRRaF5p" +
            "rtYCOnV1P0I+8JJ4A9xWzl4Lwis65yKwL9c2ovFYtJow8zkndd7H9DTZMfZ2v66r" +
            "KdeuyV9XhwA1urT9We0tQffZ9pZHD77K2JeZeb87YB537RstqODU/aS/vjfv7At4" +
            "B2KPHWU=";
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
