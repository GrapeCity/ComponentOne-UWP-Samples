using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using System.Collections;
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

namespace ControlExplorer
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
            "ACYBJgImB39DAG8AbgB0AHIAbwBsAEUAeABwAGwAbwByAGUAcgCFRnSPUNMiT4fj" +
            "Npv+CqEt8Yykyfs83ISGgz+4To+BC/UuqMOkTqA2rjM9vny8x7k1aIG6MLM3U43y" +
            "jBNYbw9wq9Hb9xcIplHtOPnvFjJY2WoXyaffrpZFp8JRg1cPs53TBj2h3QEAZjSI" +
            "JK8eSrPCyOTwJRsGv8ratVAvMfX9ywXkahUQclUqVn0VWM+Lk3YswL4fx9UEsfqR" +
            "6u5CHTxTTOyNXF5Yse/qJg3Jvowrau9iJpJxOq8fMU8IgU4vWFMIp9yIc3yJmnZv" +
            "6pNAseqazIKOJJ0qXmtc++BepZ7c4VeSc3xKFLl3Zq9BXRPJ8YSbM9OtyJMASKpx" +
            "CpXn07nsMtS8QyGBcESKX2R7SZK8cbXRn2MF4VjIf7WqJlSuNuk9YvRxtzx0A5nE" +
            "W9HzVnkTQ5KwyzkxA4Rj5dlV+88XzrfH2Cuo3Pro5UdRkXZLdFdKQhtCF/7NG/Iz" +
            "JiH5Wo2/KQFTgEqoioTc2d8+iAaqDJxIhOEU1AzDyMMRdOtgR37EQ9k2e1QC2Aly" +
            "Fw4GLK0eEkVtlhudX/8QHu748np/aqBqORspjDuTAp9ktFpz15UxLHHAm42BnOVs" +
            "seKAEvpmzYGhmoX6oj+a/hAd5GDhSQu+JNhnEd7jXk2Jg2mmzMuM496mCnXPcvSG" +
            "wsRf/vcMrdwwE7b7VuQeZ84K6GgKvzCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsm" +
            "xr0QlIswDQYJKoZIhvcNAQEFBQAwgbQxCzAJBgNVBAYTAlVTMRcwFQYDVQQKEw5W" +
            "ZXJpU2lnbiwgSW5jLjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0d29yazE7" +
            "MDkGA1UECxMyVGVybXMgb2YgdXNlIGF0IGh0dHBzOi8vd3d3LnZlcmlzaWduLmNv" +
            "bS9ycGEgKGMpMTAxLjAsBgNVBAMTJVZlcmlTaWduIENsYXNzIDMgQ29kZSBTaWdu" +
            "aW5nIDIwMTAgQ0EwHhcNMTQxMjExMDAwMDAwWhcNMTUxMjIyMjM1OTU5WjCBhjEL" +
            "MAkGA1UEBhMCSlAxDzANBgNVBAgTBk1peWFnaTEYMBYGA1UEBxMPU2VuZGFpIEl6" +
            "dW1pLWt1MRcwFQYDVQQKFA5HcmFwZUNpdHkgaW5jLjEaMBgGA1UECxQRVG9vbHMg" +
            "RGV2ZWxvcG1lbnQxFzAVBgNVBAMUDkdyYXBlQ2l0eSBpbmMuMIIBIjANBgkqhkiG" +
            "9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwQL2ymVbspWkCpEHpVUHtcmbz5rrTHvwdlY2" +
            "a8COz96uanuluHwz0di4RVNGPwfhtpfEViriLvl7mQ2vuz6cZsnlR8zoKV2pt5Gx" +
            "DjO9Fvqel+u1w4HB9g7HTCh5hB8jpXMtXOE9saNQMrqp0dkt/8Ry9Igq9Fu7cgs4" +
            "TeS67HTuBCRv76utIFTIkpdTydbxz4r72x9aodg9vwUXYhrNbGGZ8h0igM0rKOve" +
            "v/AifeNB6Omp9qaIc2xT87bopLQRy8JLkIU4oNPq+92cCR6TeTItZ5/5xr9xsWjv" +
            "i9rBga2bDbDPD+FzCUA0hBoIDHP7kkdBndISDwstJn4LwThP7wIDAQABo4IBjTCC" +
            "AYkwCQYDVR0TBAIwADAOBgNVHQ8BAf8EBAMCB4AwKwYDVR0fBCQwIjAgoB6gHIYa" +
            "aHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcmwwZgYDVR0gBF8wXTBbBgtghkgBhvhF" +
            "AQcXAzBMMCMGCCsGAQUFBwIBFhdodHRwczovL2Quc3ltY2IuY29tL2NwczAlBggr" +
            "BgEFBQcCAjAZDBdodHRwczovL2Quc3ltY2IuY29tL3JwYTATBgNVHSUEDDAKBggr" +
            "BgEFBQcDAzBXBggrBgEFBQcBAQRLMEkwHwYIKwYBBQUHMAGGE2h0dHA6Ly9zZi5z" +
            "eW1jZC5jb20wJgYIKwYBBQUHMAKGGmh0dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3J0" +
            "MB8GA1UdIwQYMBaAFM+Zqep7JvRLyY6P1/AFJu/j0qedMB0GA1UdDgQWBBQAWvCt" +
            "pdR4NfWEEqgsBQ74VhuOjjARBglghkgBhvhCAQEEBAMCBBAwFgYKKwYBBAGCNwIB" +
            "GwQIMAYBAQABAf8wDQYJKoZIhvcNAQEFBQADggEBAIjCmFo3jlvlWIqxF8IDqFtV" +
            "6oyE0ImYvriarF1i/DeCwXig4IOiIzqRaHLU2hR3Yulyv0+N8YnnllfixmWqjF5+" +
            "VOkeCdfww8m4qkMGyTtaSGIS7rl8HBv6D3BAcwx+BjSCMcgBDZkR/Y8npNNIVy+P" +
            "bjCHvd2zKpyaPb3R+nAO0doXaMTmmr+1AE4ny8OQ3jrC3ioyEbqcik6Bz0qeDIst" +
            "0Q7tXfgozU1v6w30mSpNZc2g2qU5/tCNgfCXDsq7tbeQgYr5/WQ/XGpMGlfCwETm" +
            "wuWe6M/4kCpXxoqUEkMpEjciGWsb0IlSaoU2GZnZ/lATmMC89B5d68ucxiKomuAw" +
            "ggLEMIIBrKADAgECAgQO7u7uMA0GCSqGSIb3DQEBBQUAMCQxIjAgBgNVBAMMGUdD" +
            "LVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwHhcNMTcwMTAxMDkyMDU2WhcNMzcxMjMx" +
            "MDkyMDU2WjAkMSIwIAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxvcGVyMIIB" +
            "IjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhb21ENmilOpFfyj8qBDWjU5w" +
            "zDhiLVzAJjNlWMaTzyMBtxd1K1+JQ1ZlBtdLaPWoAfWM53wp/VcXk78xeQOkvzBk" +
            "znimb9fjQVQWqUe3Q6f4tbjMwJ/9SGa4rTcSmBZG4SccztR0jCnuUH97YBgXV+C4" +
            "J5x+dnrWCEvK0Mkyh6bt9F2M7Z6P61wtbvoQrTWeRPtAEOXoQStr7EZMwjfFb6U+" +
            "pHq3zts6zebW5N1XRsmesZZeJrUiEmyIz0DJ8cccsRXWsUMMh7SVY42WzDpDCErV" +
            "lvTttpkLY/92rmMs+3SV6MiK9/qJcvjQIox8yAneEbGFc/sl5F9cLtYRN3fD6wID" +
            "AQABMA0GCSqGSIb3DQEBBQUAA4IBAQBZc4pNWHjl9a46lT1mSqpgnEpDYnonEStn" +
            "3fNmX/OeGLFMypXovnhmU+PGnsfamUz3dleWgAE4GQzVGETdwZB8x8U5pDuaR3gd" +
            "NwQvWpcGDCqijjmlJZLpwR1a/9kE2pEz73FqgZ3kOn6nIJBZUlPxmgueCH3Vm8Bp" +
            "h52fxdyz8R8r2BlPgi90Sj/QY39ssPHl8aX4OiB6oLJ5j20hzYVBcj+VJfGJFEuw" +
            "JkPQg/B3k/wyAtR6pnJNEThhc8CEuphOgl35RHIPZDZJv/cbKN93QEDPfREHVWde" +
            "bWHAh7S0J4tTFr3c+E4xlEQeNRCGoYDIqFoaMvCfTPmaryTRUAiC";
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            HomePage homePage = Window.Current.Content as HomePage;
            var viewModel = MainViewModel.Instance;
            if (homePage == null)
            {
                homePage = new HomePage();
                await viewModel.Load();
                homePage.DefaultViewModel["Groups"] = viewModel.Groups;
            }

            Window.Current.Content = homePage;
            if (homePage.AppFrame.Content == null)
            {
                homePage.AppFrame.Navigate(typeof(ControlsPage), new object[] { viewModel, homePage.NavigationHelper });
            }

            if (!PlatformUtils.IsWindowsPhoneDevice())
            {
                Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.FullScreen;
            }

            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception(Strings.InitializationException + e.SourcePageType.FullName);
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
