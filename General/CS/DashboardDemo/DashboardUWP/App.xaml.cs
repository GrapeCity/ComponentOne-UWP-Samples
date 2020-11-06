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

namespace DashboardUWP
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
            "ACABIAIgB3lEAGEAcwBoAGIAbwBhAHIAZABVAFcAUAAgblQJHrnlkBaSbbu7lV2E" +
            "gsuUA9VEUVDyJbbsxMEW02yAtRISuI9ZVJdT/c02J+5ark03nGq/pnruC999fP5Z" +
            "HQ2Sh6IMuLVawKxgkCMawhH3h9MX0GJWWpR6faM5k/Tr0XDDOqB/89KOAqidSbil" +
            "5ReDhZoQvsnlk+UH13Sg41M54+iaVAkYGPuYhCnkfZ7iUwmy7q/3NQ7yIaDRGeMh" +
            "mgFE3paKEjG93PoQuUjtOW0Qt/iVkv0u+d1BHSQQPq1X9foNmA+mOcIf06J+Oyw3" +
            "bdct1zHY89zfOpQE03IuYpHdxq+8jU9Mg8zOWa73kKUgo0xzCUZTN5ZG0dDUljo1" +
            "EGwe4WHlQglXteDyOuCqSPeaAZ5fhfvZ8WFjD6nm5q+kDgbLTse+UFN9I5eTIfWD" +
            "4UwHJb+fAoWOfsGqVzVyJq8gEfzeSjwg4UQDXBeSKnDM32R8UQuQqcbjXfKPmsk8" +
            "hQH9YxCciVwMoos/ry1/xyvtgJSlRIXACgNizZQgnxuQg7Z9d5zPHtE2mpi+9ohB" +
            "T4n+G4X2Ihh4V9LtOj4rsbVN35dIutUYHU60E2j6MTjAVboLC34ojeCjwgwAqF7r" +
            "CCAWZxbmpHvZ1DbQdWYWs7hb1N1qMZUSeQLGMVyQ818RTG+9mcrkAT6nA5Z5AMaM" +
            "+khogSV6rxVogzTDJsDhvDCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsmxr0QlIsw" +
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
            "bnRlcm5hbCBEZXZlbG9wZXIwHhcNMTcwMTAxMDgyNzAxWhcNMzcxMjMxMDgyNzAx" +
            "WjAkMSIwIAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxvcGVyMIIBIjANBgkq" +
            "hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAvpZlAzcAR91V2bADJe1K4H7RHjouP3Fm" +
            "WXGQqcyoEivDHiBMAye5hADq55iFSN0gH/ZhIBTanlV4I+zrV1zDig8zmTpjdpSI" +
            "07D5CgqVLCOKHpiZ+h9UOmril4cXavPWc16ouzE1nN48FQ0sBFeogiEgYJ3FLfgp" +
            "kcSKtkez9zyrjPzQflKOMRVYaZCJl0lJr+z0BSxoAuZL1UPDM3NsMw6WESNjuVN8" +
            "iA6qoshPngYC3lFFIjxHfglJWwTQYyxOMqlaDo91lBzIhwgf3kqMle1bLMXXtq/Y" +
            "P8pL12DxxKmsCHE0emiOPIRC2ZpQ2g9gzMqpxbCggMi6ZsnmD/O3XQIDAQABMA0G" +
            "CSqGSIb3DQEBBQUAA4IBAQCIfFHwyjF5RQkWtqyCCqcRtvRGg0tPUGSJVRtD56B6" +
            "JeYDVXTe9tjeOC2lPm3Fo8VeX316v/e1OyNoRWITzB+sG0hK3uwK2zWSLQ7aRI5A" +
            "h5Qy7jVNBZdVtJ03l7OuJqw5rzieZ+3Ism42ExiuOM3mJKCJm0PhJyBqgiG390vz" +
            "YlOThQli/ubPVcBn/piCPDi3h/jtgUHiBdoi3EefpZiAzICBesZ4g6gKX+s5kAxG" +
            "KBT9/GKqR4/lfJkHOnT+0UZEJ6FX94w3QXvJqXiR4DVd9xGHhuPjj83XzjjMeuiZ" +
            "DOzxQkQ1if6BhCMaldW/PLrWt37uGffaVzbcq2atBFOT";
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
