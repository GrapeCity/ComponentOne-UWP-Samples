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

namespace WeatherChart
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
            "ACABIAIgB3lXAGUAYQB0AGgAZQByAEMAaABhAHIAdABxvi8kImS3KGcMIZIeh+AO" +
            "3LRrMZX3kks2yXYtuNPnrro8wb5OvDPTMjDdsr+oDBu2ghMlWQZKZw5Uwo0UiIa2" +
            "bXK+9trVChEmcsfWSLp3H1+4u6YnMZ3f4iAzKtxXGW+OPHRTov1KSxmGvqXI1cAV" +
            "GcMQuOo1YegnAZEclyQyssU0GiJJunSs59EDbpUwP3feMeXEyl5bRGhGV5L89ntS" +
            "t+q0t2jgbc4PIJiKK/eD0hVgaQf5HOv0q2YZyQLzoE6zeQZSjiIy3yIXkZkjBYWd" +
            "ue5YAjeE30rnG7nMxf7Rh2r227pzgs0mHS/Pj0vGi3yXlph0w0PVLzUzsBUq0toX" +
            "Tuc6Vm5tM/sX2mNaex2/4a1290441Xm/i+yn8UCSYEYwzn9fW2qTaTWq/RUHPSPK" +
            "jyem2AySo8Q3Cvhb2zjQu+Oi6d8JUKjxJVOwXD67ySGk8nbE8sWo6taF42YwwBWK" +
            "eSu4zsjfH/Vb4AKxwXye6KSf/Bu5ET/p93TUSGc10Y3wTUz4MM701axwxbkZEDgh" +
            "z4SL+Te/HWUINmjuj5UrVq1txVnPdrHfaWCsumf91jfdShi/d5MkY3vMjDo7CXz4" +
            "tpX9aWdej/4gH3BsBw+EcbjAkNSBSqo8HjBkoxnBvnHQYt4JRMjIGFviORP1qNLJ" +
            "WhtBgki15KXoSykBC4/FYzCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsmxr0QlIsw" +
            "DQYJKoZIhvcNAQEFBQAwgbQxCzAJBgNVBAYTAlVTMRcwFQYDVQQKEw5WZXJpU2ln" +
            "biwgSW5jLjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0d29yazE7MDkGA1UE" +
            "CxMyVGVybXMgb2YgdXNlIGF0IGh0dHBzOi8vd3d3LnZlcmlzaWduLmNvbS9ycGEg" +
            "KGMpMTAxLjAsBgNVBAMTJVZlcmlTaWduIENsYXNzIDMgQ29kZSBTaWduaW5nIDIw" +
            "MTAgQ0EwHhcNMTQxMjExMDAwMDAwWhcNMTUxMjIyMjM1OTU5WjCBhjELMAkGA1UE" +
            "BhMCSlAxDzANBgNVBAgTBk1peWFnaTEYMBYGA1UEBxMPU2VuZGFpIEl6dW1pLWt1" +
            "MRcwFQYDVQQKFA5HcmFwZUNpdHkgaW5jLjEaMBgGA1UECxQRVG9vbHMgRGV2ZWxv" +
            "cG1lbnQxFzAVBgNVBAMUDkdyYXBlQ2l0eSBpbmMuMIIBIjANBgkqhkiG9w0BAQEF" +
            "AAOCAQ8AMIIBCgKCAQEAwQL2ymVbspWkCpEHpVUHtcmbz5rrTHvwdlY2a8COz96u" +
            "anuluHwz0di4RVNGPwfhtpfEViriLvl7mQ2vuz6cZsnlR8zoKV2pt5GxDjO9Fvqe" +
            "l+u1w4HB9g7HTCh5hB8jpXMtXOE9saNQMrqp0dkt/8Ry9Igq9Fu7cgs4TeS67HTu" +
            "BCRv76utIFTIkpdTydbxz4r72x9aodg9vwUXYhrNbGGZ8h0igM0rKOvev/AifeNB" +
            "6Omp9qaIc2xT87bopLQRy8JLkIU4oNPq+92cCR6TeTItZ5/5xr9xsWjvi9rBga2b" +
            "DbDPD+FzCUA0hBoIDHP7kkdBndISDwstJn4LwThP7wIDAQABo4IBjTCCAYkwCQYD" +
            "VR0TBAIwADAOBgNVHQ8BAf8EBAMCB4AwKwYDVR0fBCQwIjAgoB6gHIYaaHR0cDov" +
            "L3NmLnN5bWNiLmNvbS9zZi5jcmwwZgYDVR0gBF8wXTBbBgtghkgBhvhFAQcXAzBM" +
            "MCMGCCsGAQUFBwIBFhdodHRwczovL2Quc3ltY2IuY29tL2NwczAlBggrBgEFBQcC" +
            "AjAZDBdodHRwczovL2Quc3ltY2IuY29tL3JwYTATBgNVHSUEDDAKBggrBgEFBQcD" +
            "AzBXBggrBgEFBQcBAQRLMEkwHwYIKwYBBQUHMAGGE2h0dHA6Ly9zZi5zeW1jZC5j" +
            "b20wJgYIKwYBBQUHMAKGGmh0dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3J0MB8GA1Ud" +
            "IwQYMBaAFM+Zqep7JvRLyY6P1/AFJu/j0qedMB0GA1UdDgQWBBQAWvCtpdR4NfWE" +
            "EqgsBQ74VhuOjjARBglghkgBhvhCAQEEBAMCBBAwFgYKKwYBBAGCNwIBGwQIMAYB" +
            "AQABAf8wDQYJKoZIhvcNAQEFBQADggEBAIjCmFo3jlvlWIqxF8IDqFtV6oyE0ImY" +
            "vriarF1i/DeCwXig4IOiIzqRaHLU2hR3Yulyv0+N8YnnllfixmWqjF5+VOkeCdfw" +
            "w8m4qkMGyTtaSGIS7rl8HBv6D3BAcwx+BjSCMcgBDZkR/Y8npNNIVy+PbjCHvd2z" +
            "KpyaPb3R+nAO0doXaMTmmr+1AE4ny8OQ3jrC3ioyEbqcik6Bz0qeDIst0Q7tXfgo" +
            "zU1v6w30mSpNZc2g2qU5/tCNgfCXDsq7tbeQgYr5/WQ/XGpMGlfCwETmwuWe6M/4" +
            "kCpXxoqUEkMpEjciGWsb0IlSaoU2GZnZ/lATmMC89B5d68ucxiKomuAwggLEMIIB" +
            "rKADAgECAgQO7u7uMA0GCSqGSIb3DQEBBQUAMCQxIjAgBgNVBAMMGUdDLVVXUCBJ" +
            "bnRlcm5hbCBEZXZlbG9wZXIwHhcNMTcwMTAxMDkyMDU2WhcNMzcxMjMxMDkyMDU2" +
            "WjAkMSIwIAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxvcGVyMIIBIjANBgkq" +
            "hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAoLdLc+C219pFypWnG0nS05K/A7e5Henf" +
            "e97HpqPGQKkL0whfwGh7AG41uuWiaY3N8V9yppKEYs40K1akKl4XCrA/wPZ3hI0u" +
            "zbcb0QgqLp6vXJMFtbPq4RE9mhXEfclMs7y2IXO2lH3MA9s/nmFmJxnrVRVrxl06" +
            "E7TwpS4iQvQdGi68Ffn7Q2LjQjjdtlirH2X+eoWKuP0jz932xoDyNQ38n+B8l4EZ" +
            "M9hZNoZQwFSv1mr39L1mD/DcfnlgrzaE+NoJ7wm9SSMfe6MCC3ptwIpbEbgFoPj3" +
            "5B1kCaiJIXwtbkb7x8UgcmxAWIVKp8Dp4E/8g9lQbrXRbYyOD/vUNQIDAQABMA0G" +
            "CSqGSIb3DQEBBQUAA4IBAQCCtgrZv6mL4vlPHOF2v1dPJpDJj0io9zf6SspFOnKZ" +
            "L362Fys7gdYjiaSnLnQGoY/LAlhE13pWEoii+UUgpFfaKLOoTyKffUiZ3SuyV/YP" +
            "qZTtV+lhx3CCtuOYGAsYXqbb8odvRp+Ff8oOs6cYci02JSURuMPDxm1MeaDJHXED" +
            "tL+oClse+meiOE2pwNwaEVMHVRr1CMigmIYDcTRomXBTO5n2aBjjG4L3QIlAkmfM" +
            "zOClE17Ao8K8MGVKg0jSXfZStS+QJ1DmTXXMKC3MbtENjz2EsGMSWMobViccLJx1" +
            "cjTgSTdU4/IhFYskgqPVMqzf5QhbyXH/tJZDjxwYj/t1";
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
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
