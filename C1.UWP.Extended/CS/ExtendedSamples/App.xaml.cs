using ExtendedSamples.Common;
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

namespace ExtendedSamples
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
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            C1.UWP.LicenseManager.Key =
            "ACYBJgImB39FAHgAdABlAG4AZABlAGQAUwBhAG0AcABsAGUAcwA/zKaE6iLIgaiz" +
            "ojzsvh6RVOZp4mAECDxOp6J08JCXz15rztWfoMvXJOoiSMDhMYbUAiRu/+egWxR5" +
            "fEJNOgJPiyYOGUnJLFrPeMKZM+qSh1WGfRu8x4YvVNHfGGLku4bdHaNtoFwkd/oW" +
            "nfG2GwEAP/Jpj58T3KqhkKpS7AbjJGPGe02Aa2koHtRdFh1OudYa/bkNCLXCgvZI" +
            "uvNJ5odFwUthpT09WOaVryjFm23jXHaqGQQ6GHXJ/2DdADl8GUvpbeI/mg8cmnzl" +
            "kl4w5ML8dND39qIWS2BsIstW4KEl8+YSPylopLKNjO6VwNfiaLeDNBCeMFg3klLW" +
            "mnvA0qJzL8IlpA67lNoNHb7s6grgkww98X9e4oX6dbvSmeZqM0DK7kxl3YCpfXmS" +
            "eRtenDAuW5sl0OmGgh04e2IN14CnqfA3eQg5VDrBYniKSmqoUUowL7lQXWftJ49B" +
            "LMHyizff0XZ76U/H4lETXiz4EDGM+pn/2xVgzzkRH7WFiRHZMnKDRivsB74aiXOR" +
            "LIillDQv13MXlT19LqdR97btjkTpPj7QXRGCMtAxrgdBCNXyvYBYpn+ASCxS9jbv" +
            "hkzvqeZ73h/s4QdJOJ9uWlDOkSdEse0R1c82eJ8cKhEOy0DcBrVhu1ZVl0maKx6O" +
            "7wf3IHJoNx2U+VlO9yOUKaNFJojAjzCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsm" +
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
            "IjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAp6KeMffqHjKmFPFCZxoi3R6u" +
            "fk73d2oOQFIV+Vz0Gn62MtJ0NWB8DBVHmI2TMv23SB/UK4UEN7Uayke93C3Hai1x" +
            "gyr6vhaB1zYI8Vz3DM9i1oGmbBXwiAUmXEQeLMpar/FJaZwE9FoSAvzx5TpggfsM" +
            "CDRtJY7/bBIpvXOYPxvdlRdTNhiIy36l/+SdNBR5oLR1s6r7F9dqaEXel2TvPtPI" +
            "qBSSm7+YxQtDuo66DJqhbvKlsesQ1FfYAuSxtlHPYu3Dvbkh0YyHIL0EuzYO9tb7" +
            "vCs+pPnptLIZTNBgVSJIuiMAyXuhUIt73yWyOnhFaGv20p7siW3pVcOHWp+4gQID" +
            "AQABMA0GCSqGSIb3DQEBBQUAA4IBAQA4mW1Gv5t2BRXe+vQ1zfhpCxpL5IZvBYGn" +
            "7blgg7YoYBzahAtCnlfiNHXT4rPDCnF49RXX6jU+02H98DMdHH9J2V4EbKdMb3zZ" +
            "kKHk3/R4LnIXhtUHoDJ+Tfr9Ea2JwxII6rGQXKZNN2aZ90+SNAi6AzFNoV1KP9+x" +
            "k7Pb1dDhUQ82qyVYyfNDPUN3ElqAWTwhfYY4YXRP/qWwx0QFVOpkGKFK/tfWUFti" +
            "ckmnMn8sxbN/fpQYR4EQnl3pfYDIU+4TqH0TC3YlM7yFc34u/xbKX48NlWu7dmvZ" +
            "2oNkRq68MrW5eqOyHEqi/+sRgUeujpfJ+vf0hlHkYchlcukvO4rI";
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
