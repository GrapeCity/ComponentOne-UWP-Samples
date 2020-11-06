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

namespace SalesDashboard2015
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
            "ACwBLAIsB4VTAGEAbABlAHMARABhAHMAaABiAG8AYQByAGQAMgAwADEANQAeKRnD" +
            "MAvYKlhIjaESZwXv6CUqrccjYLw8ZwmIpHzZ5jWiVjeuHC487c/zTWFtTusWI61n" +
            "H5mSFXNlBgARFm+wL4PaCeeHstLzKqScJgf/Nq8gTPHz22U3zJifi9UhArfYDxYQ" +
            "9/5jEW2R59SxB8iYI30+wS+LACR3LD8btp1m+2QLtEWDU89NjVOejm21etZfokW3" +
            "mygiqgzFLnsXrLtWaJTzWSIgj4zzGVMSvEpSudnpqAhN7kKIgBybMXwaaJO4LpCR" +
            "CxjoiyTgUGY1YD8OEBJPMZKN4xeRRuHA/h/D/nVP9Zm8eIK2ey/R/IMB+wvtN945" +
            "184flJIri8qQbkHAH8KuNDtp8mh/VoOZKfF2f0qZyVdSsIr1jJRkaap4YITe5pac" +
            "TDFHq6a62vhccpJJO5B+l816ar8viVsxLlqIumK9UO550JyOnMMtCkEqOxYqVw8t" +
            "dV7nCJDzbEIKvYq7p6BZcgmWOHrhjJIW425y4ztj0eUoCXeKlxGT+RNXB0Sgk8NP" +
            "gnfOQ6CVCxK9YX1T3/Qyhc3xMFp6bwOwEW6YhnKHK1lu7Majv/kqBvNp1iSj9/51" +
            "6bcL1e7CXH0U/HnbS1g2qoE08mrxUNTJA+t/yiHGvKfmgjLYGUqEBiTytmdxBKRo" +
            "uVtVLGv55fuZzfUkEgeKb3LWfXX6TC0KSczozjCCBVUwggQ9oAMCAQICEEEDeNIm" +
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
            "cGVyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAmqS/DsayCYrHYuGd" +
            "jESHGaER2lmBgxDkIMmTIySWMxBEmZQp+STyNjX173soYtmr34IoODm54m1z16ee" +
            "7jMu77FVMs+NFZOSJR18rlsO7OXJ7nH1D0dxKpsO+Jr8HRuRfyncdRiTUq+RcW7G" +
            "C4Itu7K0zkixw4UVh8FTIPOuX9RJPmr5bYtLSxdStwFAryUbRj4BOLdMmn2wLYvu" +
            "qnW+OLjiQks9Hl/wIw5Y/oISlVWj+/J//jrGc4nb8P6K0aKinDrzfdMHSDpu8weT" +
            "ckGLezeXDkIdLhPEQq6QVPC+yTo/ggRIrdKVgQzsURiaFSw4pOdGaoCKQvc+Cb+G" +
            "aai0XQIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQBS0LruEp++TuNYNhc/JBQvhEnq" +
            "m4wLjmTvIY3mJlUL9Z7Xo3eVpSCvzM9dHDaR4i6r4DAw4VgBGcNO8oDf/xpu8f42" +
            "S2blE1vxZcj/mKIsGrlFd10rRY2kvVGsq0CCkRWWYMKZOCW9PpA9NJjrJ3iUogDr" +
            "5q1sCSoZAqMULyoZaV6fYsmmKAQCd+5FNdkmQPT51wYPh6ixiePjbC5shBV6yeqL" +
            "WqBqGetYSd40qjAs9SKehgo9NEFB49JEWSSvIxBA7Ch2llRUqk+ggtzjYIDwVR3R" +
            "kRJP6wur9o53ZxNSqPmK3Cyif6MGvEq+OKgmXt7UbbsEhObrBA9TYTMo8N47";
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
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
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception(Strings.InitializedPageError);
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
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
