using SunburstIntro.Common;
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

namespace SunburstIntro
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
            "ACIBIgIiB3tTAHUAbgBiAHUAcgBzAHQASQBuAHQAcgBvAILhgMxUrM2uMDHJfwdC" +
            "Et6ObSasy+9+Xo3ds4nX22DHdmBQd6sAdlk1vlxI/gxBMpPc7VHHYsxo0HOynBsd" +
            "3lvIcP90fVPb7jJxmzdtVvU659kAOXPCXWbNDWrsFjg7D0w4ho/QbIy8Dv7omane" +
            "EwoBzoX3OZbF5Fkxlcu+OuCqREFSmB4s44W5JKxiMr51mGYugyCjviAOmJlHIaTw" +
            "pDu97L5e0fsjJW7aH11kzCBGL8EEwpqBP91LY3wOHT4iw7U21wsMIvd+vX7zxwP+" +
            "F/26CldsaaDlEV1LqXPzMpVouII0+Kqaw/spWeQzNRLjkO5lG2c1wYl7W85yynqr" +
            "hAAuv3vrjNvm9ce6kpSfSFn9n7Ic/dalNJMyCWU+KmtbxW16+XWwnumYR0KpWxEN" +
            "EDINnk9GQmwsWELoHzrlXb17yDPhbxXrvxMtzYqlMatxytmRe0FNGrXicgmAlp82" +
            "pEvicbTfxGtKQFMHvXzowIU+tXklZM/TsPfJGSrn7/Dn1m3O/lQ+/JdZ9ZNTW9pk" +
            "T+PHR/KSGVa0ntjwQUe9nqHuANwGJ86VtkIFdRmSBEsQHsNPPNNZe7UUuFVFTJiS" +
            "dc4RTHW1kaSD8pgpIjHDKIF85jx4lhGKEFow+lEuWrAUJd7dovh/l/shh2LX7f0f" +
            "MmJMZqiOlUKgrdirhuTIY4epMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCU" +
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
            "IEludGVybmFsIERldmVsb3BlcjAeFw0xNzAxMDEwOTIwNTZaFw0zNzEyMzEwOTIw" +
            "NTZaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0G" +
            "CSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCSL7FxpG/g1pzS1JIWNkqXOzVubILH" +
            "jA31E41T4ABoWqB/e6+APJtSSEZiNXNudnOIM2qZ+E0b/tb7fWqGWrMKfX4QzWMU" +
            "IWm7og84aXai2BPf7MC7mecoPPhItZ6xRunhbtb6cjNmRG8mX4IRj1WJufLZfhDA" +
            "NygreTiNveFqgghO1suSczf+zYjf+sdRqmF+nndXXmQ4a0ZyQBeIje5b149wy4wS" +
            "PpThekrVTFveuPs7rop9ZOGqGagQQaZyW/jgmSAtW0kcJkvW8yWvEu9+z3AHJRnJ" +
            "8KkRzp1YH4tz48HF7ybV0vYD21Pwg/bsMglo2h+Vm7fW6MUDgeYTE0NtAgMBAAEw" +
            "DQYJKoZIhvcNAQEFBQADggEBAHp/TZahLpNNZg1jcfxUoxzpRflrSYstGiNVmssE" +
            "PBNpwGdAxaEomKDOgQ45CZVLeVoTkFmOuKNqvbQRBgmfplld5QkvwqC6CrhjbwU7" +
            "PoIASnb9Z+CPuwFlFPdeztM8YHJT2UOS4RiwaA665RLC2Lahd4UUFBEOkWz6TA3D" +
            "ImoV/7MEqRZvVpwAzIGmz6bhFnnbR9kPNGlFQxYIDSKGokXGAGiVSZ+EuFcbRNx8" +
            "vOWCrsE2S8EIS0FxVJLf8GGmYeVsCePe08WTaJd1KdgQwdEztzHDq+84QOxby7ru" +
            "UNUKCbR8RW3HDlRaSizYOIpuHXk2HReHwn3+C7UUt4/Wuvs=";
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
