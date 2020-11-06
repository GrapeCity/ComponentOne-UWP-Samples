using ScheduleSamples.Common;
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

namespace ScheduleSamples
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
            "ACYBJgImB39TAGMAaABlAGQAdQBsAGUAUwBhAG0AcABsAGUAcwAS3VEFLL7JB7s9" +
            "q7IHRNvO07mfwDYAgABSa7l5XUr2eUIMsdOnWlFR+uWsBQJ/HKiEPi/DpfiqL/c7" +
            "hKvLLZLcKTSmV8xN1cfivITr2YT+A8N1Z99W7k17p79RK9tFvBee26iXr3jSO0ME" +
            "XaNQTgqU2sti/EcX9HHIXdJKYRWcoH/sq8rH923yfnnDeS2haUgo//DhnZVpZnJc" +
            "f6nlf70ySTqt974MZpt9O7eC32Ulthr8x5AhseH+LeLWtoO9oQx+XYFUkSCOtm9k" +
            "hkuV/DikxxpydlHLpv6BadrB3EPjzoVFjIfe7iy+x1u/9ytrzCFrJHVYq90zJlfe" +
            "vfH4hVQtTm6e2wJDaYfxMED6lEwd1ESTHEOQpcm+AcPoNsDbBHcLYNCG8QOWYkjm" +
            "R4uDGYCBJl9bNeQAVGSpYG+o6vWZ69QZyOnxUbj69VN6QDOQ1Kq0A2pnWqB+VwDZ" +
            "7dERGI+6T+kRTm1YaiY6c52hS/9NM/W1SlQORjVONDr78uNTXLVfA8IpXKDs2uMJ" +
            "hg1NUbYArgF5wDrHGDeMHdhpLGf0OAwnUkC82W32Ff54HVxqUJJZvWOems0M64I8" +
            "fluhpK4sGpFondSZYTcU91ugxLXCE+quf6SE+Xk2TGpAkdb1ZGAlAnlWkX42nDAN" +
            "/pRgdXUrCozxi/wZpQ1mttV8OGefFjCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsm" +
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
            "IjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAmANoVazc+j6NnYElLI8QrIFe" +
            "Cci31h3C4d7m3OPJ+tolRFJ6SUD5QuPiufwKlYvfxYBJDyUl6jEw7NJJaRYtCWaL" +
            "OGLV/GKO4pekkc1F0Y0QbMHJ5Sk2LTMkUbi9ucCnObL0b6cW7ZNoZ5kzgD/U+ShD" +
            "IM8jOHVJelvw8/ijmUxWvlyqY38WoMQMM8yNJML65jSMXb1NCE3q5mtQqg/UOhyO" +
            "DQamLUJJ25EZG4WoC5a1YkkBxwGuP2BV3akymwTiKAuBTskcYVSIyibNWdOSSmPV" +
            "k7sCN1r2RYwdK0iyaTlIcwIfoJpbwOMns4zLr4XpRsT5+4MKK68qVn/RcA8xZwID" +
            "AQABMA0GCSqGSIb3DQEBBQUAA4IBAQBu75Tpu+ZeGwtnrCFSxiZ3X8uR4E1EBnp/" +
            "DIC8RDmEm5E1riYRFuBADx2zQmWWO8DS89ilqYvbwSqPV2sQiFMdUDOtF57CkWyR" +
            "53T3f6Y47r+J3owFaPhr8OlpzJPPYxLAW83Ky9j2bBGNP0GMBLyjwhsbOZVjvpZK" +
            "8UffZNYL8TDAJOGhTV6HwvSZzmc2zyNrMPsXiAZFPt95PO6aVNyv6nu5tofJI9/R" +
            "tL8/d1uJ2KR2Nwvh4k8lfaG+sm6Bktkeck3oYxj1NR1HKvcIfqo2G6Q8UwLoQpWO" +
            "KC4u8rxS0/sYxsvUUv9oFUkduAP8EaHuIRlVAP2vXINNPiBWsrvZ";
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
