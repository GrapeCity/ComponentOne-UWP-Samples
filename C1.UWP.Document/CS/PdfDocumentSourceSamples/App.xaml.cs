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

namespace PdfDocumentSourceSamples
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
            "ADgBOAI4B5FQAGQAZgBEAG8AYwB1AG0AZQBuAHQAUwBvAHUAcgBjAGUAUwBhAG0A" +
            "cABsAGUAcwBHPE8yFOF8Lo2bZs3ZpVobaKSyaTWgDDSJB3Y5FNwdqZU29L5HiTjC" +
            "/IRzRsmb03jOG3r9+rEgpBp13PjZuB7z+hhyGNWu/gbUhB5jztOmeWzepOnecuM6" +
            "L+FwlOVm+OVITtkF81SnVxWmB/6/8rJFff5WLHnmb3Z5BUsTP/DVuEzx/chNuRLo" +
            "V1k4Uhn/1lqIGvPAIFgmj982BmVlaMxvcH6iPYjlhroy11gVXKuZ+qheU7ewiK8h" +
            "GkZ0JRUahD4xwp1vgx55nKyDV+BBmx+1UtGhrEG/wEbm8giEkzQAS5proaK1fk4O" +
            "Tg8C9mMTOv9vFadQ6kPydQYCVR6flxmAFGuPNn3SssInjcc6S+1vB1V0bhICGGac" +
            "+AaX42lCWAEml+6kQWRm9gzy9tr3uR5aK7nfyFtgdKjepXIjbqzBgf48Jh33YoIE" +
            "0UKrZ573nS+Jn4g68cro5jXpgW5iLo4qxmMFCzNoihFp9AL/6h3muiNw0FaugCoR" +
            "ixWe3wxW/FD4WjNb+PB8xVFj/exrk+MMQze/BWlrRsHaH4jtCWZ/6L8AejmnpTJQ" +
            "xpxCOzDGw+Cc2S2O2sYNzmLY5g6iQsOdH90u65pF5V5GP2d0Awym1m0bdl7GJ1Zv" +
            "2WtMLPQ+DjAmSPo9j5L/bW67sd027mO0JX1GfUEnhkZXFyJ+VRVOcTCCBVUwggQ9" +
            "oAMCAQICEEEDeNImNll6Ftsmxr0QlIswDQYJKoZIhvcNAQEFBQAwgbQxCzAJBgNV" +
            "BAYTAlVTMRcwFQYDVQQKEw5WZXJpU2lnbiwgSW5jLjEfMB0GA1UECxMWVmVyaVNp" +
            "Z24gVHJ1c3QgTmV0d29yazE7MDkGA1UECxMyVGVybXMgb2YgdXNlIGF0IGh0dHBz" +
            "Oi8vd3d3LnZlcmlzaWduLmNvbS9ycGEgKGMpMTAxLjAsBgNVBAMTJVZlcmlTaWdu" +
            "IENsYXNzIDMgQ29kZSBTaWduaW5nIDIwMTAgQ0EwHhcNMTQxMjExMDAwMDAwWhcN" +
            "MTUxMjIyMjM1OTU5WjCBhjELMAkGA1UEBhMCSlAxDzANBgNVBAgTBk1peWFnaTEY" +
            "MBYGA1UEBxMPU2VuZGFpIEl6dW1pLWt1MRcwFQYDVQQKFA5HcmFwZUNpdHkgaW5j" +
            "LjEaMBgGA1UECxQRVG9vbHMgRGV2ZWxvcG1lbnQxFzAVBgNVBAMUDkdyYXBlQ2l0" +
            "eSBpbmMuMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwQL2ymVbspWk" +
            "CpEHpVUHtcmbz5rrTHvwdlY2a8COz96uanuluHwz0di4RVNGPwfhtpfEViriLvl7" +
            "mQ2vuz6cZsnlR8zoKV2pt5GxDjO9Fvqel+u1w4HB9g7HTCh5hB8jpXMtXOE9saNQ" +
            "Mrqp0dkt/8Ry9Igq9Fu7cgs4TeS67HTuBCRv76utIFTIkpdTydbxz4r72x9aodg9" +
            "vwUXYhrNbGGZ8h0igM0rKOvev/AifeNB6Omp9qaIc2xT87bopLQRy8JLkIU4oNPq" +
            "+92cCR6TeTItZ5/5xr9xsWjvi9rBga2bDbDPD+FzCUA0hBoIDHP7kkdBndISDwst" +
            "Jn4LwThP7wIDAQABo4IBjTCCAYkwCQYDVR0TBAIwADAOBgNVHQ8BAf8EBAMCB4Aw" +
            "KwYDVR0fBCQwIjAgoB6gHIYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcmwwZgYD" +
            "VR0gBF8wXTBbBgtghkgBhvhFAQcXAzBMMCMGCCsGAQUFBwIBFhdodHRwczovL2Qu" +
            "c3ltY2IuY29tL2NwczAlBggrBgEFBQcCAjAZDBdodHRwczovL2Quc3ltY2IuY29t" +
            "L3JwYTATBgNVHSUEDDAKBggrBgEFBQcDAzBXBggrBgEFBQcBAQRLMEkwHwYIKwYB" +
            "BQUHMAGGE2h0dHA6Ly9zZi5zeW1jZC5jb20wJgYIKwYBBQUHMAKGGmh0dHA6Ly9z" +
            "Zi5zeW1jYi5jb20vc2YuY3J0MB8GA1UdIwQYMBaAFM+Zqep7JvRLyY6P1/AFJu/j" +
            "0qedMB0GA1UdDgQWBBQAWvCtpdR4NfWEEqgsBQ74VhuOjjARBglghkgBhvhCAQEE" +
            "BAMCBBAwFgYKKwYBBAGCNwIBGwQIMAYBAQABAf8wDQYJKoZIhvcNAQEFBQADggEB" +
            "AIjCmFo3jlvlWIqxF8IDqFtV6oyE0ImYvriarF1i/DeCwXig4IOiIzqRaHLU2hR3" +
            "Yulyv0+N8YnnllfixmWqjF5+VOkeCdfww8m4qkMGyTtaSGIS7rl8HBv6D3BAcwx+" +
            "BjSCMcgBDZkR/Y8npNNIVy+PbjCHvd2zKpyaPb3R+nAO0doXaMTmmr+1AE4ny8OQ" +
            "3jrC3ioyEbqcik6Bz0qeDIst0Q7tXfgozU1v6w30mSpNZc2g2qU5/tCNgfCXDsq7" +
            "tbeQgYr5/WQ/XGpMGlfCwETmwuWe6M/4kCpXxoqUEkMpEjciGWsb0IlSaoU2GZnZ" +
            "/lATmMC89B5d68ucxiKomuAwggLEMIIBrKADAgECAgQO7u7uMA0GCSqGSIb3DQEB" +
            "BQUAMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwHhcNMTcw" +
            "MTAxMDg1NjI3WhcNMzcxMjMxMDg1NjI3WjAkMSIwIAYDVQQDDBlHQy1VV1AgSW50" +
            "ZXJuYWwgRGV2ZWxvcGVyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA" +
            "vptz68dfne0vxWsz7Uo95fhynsfouka0dBNSsZtwsWo6PicXR/XJOR//PM6xkARm" +
            "7xvtaTjDwgB1XmjkifS3qnc0fFFbUdmXWfOISFW0nL32owT1A2FAvUTgtR/4+DVk" +
            "ABVHgi+ZHV1rnwuD/CT62AXkngroBzGnBj74vJxtr82Rt36d7WfezxNSHRWLpVnh" +
            "T6vymppYoLDwHG4xt4nfsh8vbioBu45brapMYT8t7qh9EX6YX7M4QcEwEjidJywd" +
            "jOWFksK3BZcecW0FfeBoaUMimlqzHhFWKL9CzhE2OBPjQWTrTczyYqQYKk5v0Vff" +
            "HDrxHdIvjoKRgixqcoMCMQIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQBWZfaazIpe" +
            "M2wQm52/EYEjZ/VFsgN1ZX9KF6uqbEhaiP3bjHlOxcAy8dRaANU+2ownO0kE2/yt" +
            "eYL+P2Wd70t5AfvtDLOkHRCpOkDC1g7hZ/+bCVsw7TMFvUgHu9Ab6nNKid4bVKao" +
            "w8yxtx04wXJ+ZTCwihFZY/MFmJT4fBV6omYI2WKX13R8f9n9se9YY3b2PAfpl2ZL" +
            "oFL3a3DNuM5DijXx8NMMuxrQr6F3hX0KZ2ul7fjf2Z2xc2Tp2g9NGPRAg6osUGBf" +
            "OkjlFJ3LPlc3Bh2q2dU4xFQbwWJKj6F+CZz5Th0LXDE1DzqjAThwnqa63f/n4BSR" +
            "ZH+MAsmE1OGo";
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
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

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
                if (!rootFrame.Navigate(typeof(MainPage), "AllItems"))
                {
                    throw new Exception(Strings.InitializationException);
                }
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
