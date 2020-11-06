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

namespace GestureChartSample
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
            "ACwBLAIsB4VHAGUAcwB0AHUAcgBlAEMAaABhAHIAdABTAGEAbQBwAGwAZQBRMMEQ" +
            "l4oeD6TXUXntH842/TtI7h4jpOItbloTParcBVaqHkrNxmt6wdzA+BQCLbRAhKvv" +
            "qRA1XKAscn0gNnYz4TkNUJFQEohJvHHFIOA97SSfKL0SgecJSYmKSbUj/j7TgKr3" +
            "tifMHVuLL1JC+KHtkODGa8Wi99ZyoJvOpvPpTvwiZfgbhYOexjPA6D6RQ97G7dfO" +
            "gXbrYi6C//01p6RN7Iin8iG/ZojjB31aax0px5bQrACzemMpM/lv0YiuEkCMtSTp" +
            "4kixjnzpM4nCWmv8Ca4pNqdcUwla8/dJyib0SB4atW8dOy1+XRcMYxbb/bgGTZUl" +
            "QEXP9rVRfQYEXOckmYqvyQ5qSb6BpLJ0ch0ihmWjecCIUaOXYuMUdml1PoRdVsti" +
            "Y/EkSDvM+Z9uMxX3pi9aKHJGkvYk4cXAP8TLpOc42kLmsPVXAhcNbUtgp0/YYEjt" +
            "JZZN38EMF4IODZqeb0icMIwvC2bON0u1HM06756KoaJcbTOr81IcrNXTdj9Cpi3C" +
            "m1tAh2WP1UVhHuFoayU0W4MPHTm8wOM+qY1TFF6Q7XLpzm3vWMy7M8KMrUx1e8u7" +
            "1SWSFatb0xQdkghS8YZbg21NJBZrrDi5lAxvwsbdcVCr+1+IS5VmaOpZDPq8JpVg" +
            "Zqh5Dvg9aRG+xZgJmQgxXT9it8yN3+zgDHuBbzCCBVUwggQ9oAMCAQICEEEDeNIm" +
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
            "cGVyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAmXAwBi7DLVxmpqqk" +
            "sROKFZ+RYrPGMhhX1oK0T4g8aKc+qCJS+nZJfMPnD3KRYT2vHllddcXvqtjXRzfc" +
            "DNU8gTz9Djud+Qfcjl5KBdhsHfsGv9EG+0rjiQHxjWZYqGlzPSUeTN+cFoeJlwev" +
            "S9HvPMIxAOjnEAd53O6prlK5Bdcf1hutXBt7nUzLRMdjOSKPI4/HG2V4pRGqtPBe" +
            "TrzK8eUXYddL55t3Yo16UUdV6c5F6tbwUr2aOa2FavGinnvupL1JN73lTdmqCOJU" +
            "IUdl7sUzKeRBJmClUfUKSh3zdQnKfWt+Rih6ncsiu9ropZmdU2mQDyGf/1IZjUKz" +
            "1IKG6QIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQBp3dZEV8nQrill+MSxVcAxkN0Q" +
            "S+bwS0DkmW3khZNIEmZkBQmmYHqlxpXrpE7nz5NMKI0/3HU6xHdTvuE+VayUjDBX" +
            "bVH0YOEcZoSHbPBUo/YiPkqnQH1S/aFC2e6JQ4qqyoZ0w9nwJCStoAutFjeeblqy" +
            "EceDyzxRPGno1bFKnaaHvZ6fv3LEv6pQpxOkEjhnkeNlEEFBZRYgZu+kxjTpCzul" +
            "NekauIWqsqWJhIlTApDi6438vrFOajn4wM1Xdp/+nCFjsjqqZGINypqlzP9GaBrm" +
            "wLqRA4B3HuL3hqmtbB3u51CANOTNrHcv3gx6/vM6Z6n7hMyj2wYW2xm+MR6q";
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
