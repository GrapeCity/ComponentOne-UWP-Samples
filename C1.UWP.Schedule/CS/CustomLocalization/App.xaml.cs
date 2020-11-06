using CustomLocalization.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace CustomLocalization
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
            "ACwBLAIsB4VDAHUAcwB0AG8AbQBMAG8AYwBhAGwAaQB6AGEAdABpAG8AbgBWFrqw" +
            "7qrp+V4rT4/mm4WA6lC/fcNOWoa5FgZChF2+iYQcjQEKx6i6TKik+ypgiCdhzV03" +
            "1J/P1UOEnCPJZidblxrHW52IwJfDLULox3dMhseeH9w1LQ4UkWAws+7n2NKSqctQ" +
            "8BoZDgppA9O6Vkr0LkfNTY1ccmvOQlR1PYh890VA2h/NRtqZYykcsHYJ0FEGhYmB" +
            "xJ1WcQq1yq/09SQLFhbywjWroo1ucScYQxkVbPDYVimOZpWRp35s47Kka5OnDVs5" +
            "/TwmzQwmJf6ZtJvQhRJjn4v5TIUMJIKD2sy0duSLpj8S4Vv4gJUAsi25unEttVd2" +
            "Bfipim1csyYmWOKnVh8HbnigvGDuu/4eEnQ9+tSPeCqJQlv26UR/K3KPYlRqUtMU" +
            "/b0AD34PhsnnysLKRFaYMQif3ZlZ58c+GITnX4hv6bxuij2Ct62wNGJ8e+ZyEpSp" +
            "F0Bvd7amyti1TnPbAQpuy8w+T4LFaCteCNDBLHGnpPldKfyKmDibXm7fbm0AG/3r" +
            "i0i4/JY6DT8SesA+wfnXjOWNv6FpfYDM9gkZIOtXlDlOMUNAzBBkZqefanzHBGY3" +
            "4N2xyciM57D+Fa9G3AoiX7BS/NuW/DsdpTS3tHnvKf8fF6dbpYst8K4tTCRD3BgV" +
            "p5G0dyV4saKSDMt9fU1O2St+mtMwJq2X3SmBezCCBVUwggQ9oAMCAQICEEEDeNIm" +
            "Nll6Ftsmxr0QlIswDQYJKoZIhvcNAQEFBQAwgbQxCzAJBgNVBAYTAlVTMRcwFQYD" +
            "VQQKEw5WZXJpU2lnbiwgSW5jLjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0" +
            "d29yazE7MDkGA1UECxMyVGVybXMgb2YgdXNlIGF0IGh0dHBzOi8vd3d3LnZlcmlz" +
            "aWduLmNvbS9ycGEgKGMpMTAxLjAsBgNVBAMTJVZlcmlTaWduIENsYXNzIDMgQ29k" +
            "ZSBTaWduaW5nIDIwMTAgQ0EwHhcNMTQxMjExMDAwMDAwWhcNMTUxMjIyMjM1OTU5" +
            "WjCBhjELMAkGA1UEBhMCSlAxDzANBgNVBAgTBk1peWFnaTEYMBYGA1UEBxMPU2Vu" +
            "ZGFpIEl6dW1pLWt1MRcwFQYDVQQKFA5HcmFwZUNpdHkgaW5jLjEaMBgGA1UECxQR" +
            "VG9vbHMgRGV2ZWxvcG1lbnQxFzAVBgNVBAMUDkdyYXBlQ2l0eSBpbmMuMIIBIjAN" +
            "BgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwQL2ymVbspWkCpEHpVUHtcmbz5rr" +
            "THvwdlY2a8COz96uanuluHwz0di4RVNGPwfhtpfEViriLvl7mQ2vuz6cZsnlR8zo" +
            "KV2pt5GxDjO9Fvqel+u1w4HB9g7HTCh5hB8jpXMtXOE9saNQMrqp0dkt/8Ry9Igq" +
            "9Fu7cgs4TeS67HTuBCRv76utIFTIkpdTydbxz4r72x9aodg9vwUXYhrNbGGZ8h0i" +
            "gM0rKOvev/AifeNB6Omp9qaIc2xT87bopLQRy8JLkIU4oNPq+92cCR6TeTItZ5/5" +
            "xr9xsWjvi9rBga2bDbDPD+FzCUA0hBoIDHP7kkdBndISDwstJn4LwThP7wIDAQAB" +
            "o4IBjTCCAYkwCQYDVR0TBAIwADAOBgNVHQ8BAf8EBAMCB4AwKwYDVR0fBCQwIjAg" +
            "oB6gHIYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcmwwZgYDVR0gBF8wXTBbBgtg" +
            "hkgBhvhFAQcXAzBMMCMGCCsGAQUFBwIBFhdodHRwczovL2Quc3ltY2IuY29tL2Nw" +
            "czAlBggrBgEFBQcCAjAZDBdodHRwczovL2Quc3ltY2IuY29tL3JwYTATBgNVHSUE" +
            "DDAKBggrBgEFBQcDAzBXBggrBgEFBQcBAQRLMEkwHwYIKwYBBQUHMAGGE2h0dHA6" +
            "Ly9zZi5zeW1jZC5jb20wJgYIKwYBBQUHMAKGGmh0dHA6Ly9zZi5zeW1jYi5jb20v" +
            "c2YuY3J0MB8GA1UdIwQYMBaAFM+Zqep7JvRLyY6P1/AFJu/j0qedMB0GA1UdDgQW" +
            "BBQAWvCtpdR4NfWEEqgsBQ74VhuOjjARBglghkgBhvhCAQEEBAMCBBAwFgYKKwYB" +
            "BAGCNwIBGwQIMAYBAQABAf8wDQYJKoZIhvcNAQEFBQADggEBAIjCmFo3jlvlWIqx" +
            "F8IDqFtV6oyE0ImYvriarF1i/DeCwXig4IOiIzqRaHLU2hR3Yulyv0+N8Ynnllfi" +
            "xmWqjF5+VOkeCdfww8m4qkMGyTtaSGIS7rl8HBv6D3BAcwx+BjSCMcgBDZkR/Y8n" +
            "pNNIVy+PbjCHvd2zKpyaPb3R+nAO0doXaMTmmr+1AE4ny8OQ3jrC3ioyEbqcik6B" +
            "z0qeDIst0Q7tXfgozU1v6w30mSpNZc2g2qU5/tCNgfCXDsq7tbeQgYr5/WQ/XGpM" +
            "GlfCwETmwuWe6M/4kCpXxoqUEkMpEjciGWsb0IlSaoU2GZnZ/lATmMC89B5d68uc" +
            "xiKomuAwggLEMIIBrKADAgECAgQO7u7uMA0GCSqGSIb3DQEBBQUAMCQxIjAgBgNV" +
            "BAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwHhcNMTcwMTAxMDkyMDU2WhcN" +
            "MzcxMjMxMDkyMDU2WjAkMSIwIAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxv" +
            "cGVyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEArFuDgcG5nZ8yBMvH" +
            "dRfCoanEWv0avbdaYBVVA8Fnnk/FByUl8xq3SMX6/YBtHFkup6/n6Jg4nk7gFlrp" +
            "Zsgb2/V6onnMmFmcAbsxa4M9i0eYmvi3kfNKiDttFAW5XZ9ZIg7GZRKRGKRSGz9T" +
            "8lcjJGBbmbjq40WDBXh8nFsUIn5WFjQgXfy98gQKutgEi/x0f2LWOgpA0k03K27m" +
            "swP9u1aB21fTZ6TEnEd2AUfwIchgRfEEamMt+s46UzVBS/Egv3+UrmeGdgzPV0rR" +
            "J3U7xyXnI8y+oOf+8WoyhHCMDKkHujbH5/f/C8S020lv7AdkkHJvcn3r+9v7rslF" +
            "2A3kJQIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQAPVo2njIUIOh3FXRD0YsDkr9G/" +
            "SJqa1eOtzbiebN/jVg3ZQ5pi5tYxu6DeJksfVk3xuvpsBk4FQFK68haWSGnbjshy" +
            "RfBSdfK+10BUagJQhFEGr6a9kxDyqbTKvCv3VUYvB6f01lNz1APK45IVXNo+G8S2" +
            "Cr/u8LyJKocM0y9sxSE1JvzjRdySbZ0t9th1ZH0Yyp0mBecXIMYYYj9JUZl9qWTE" +
            "91O7wfgQYO1uZ8d9pcKbCQq6LfNOcLxhMk7HQR3Lc4T/Tav5oFpYQWOojvzblleI" +
            "5gRiMRvMUdvpB/WOh1OWr488u9V4uBHmPWMxXKwQF+n4aF28wIlylcn5qERG";
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
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
                    throw new Exception("Failed to create initial page");
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
