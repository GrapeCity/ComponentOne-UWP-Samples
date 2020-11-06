using DrillDown.Common;
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

namespace DrillDown
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
                "ABoBGgIaB3NEAHIAaQBsAGwARABvAHcAbgBNNP3cNbH2bdmdtqsrXi5C4zkIv0v9" +
            "zhFfhlbsIKFKHvkFSho75yvxkgyfAxiEy9GU/CNSvBTe4BqZqz33gxob0gSWGL6n" +
            "sSpQIayRBmQk+IzoQSolXng0B6mdFevTFcnqAZeMWksVi3JPgfggx9zOmxQ4N8Mr" +
            "/r+1zPpDkCSdv2mqTwvUnQd6+FZ0VVwDJcQ9+i7GpOjEnWXbOHIRrT0J2amLZKcr" +
            "ZM7+l2RfrcKnd9KGAOCQvagIEm3DySG4DcOq4+h8Rxyiwkk1G/wvg1rKBnGLMrLR" +
            "kMku4qxddhhcn/wLbAMHr/qgfIrTlG9l+vsLwODb8iGlOsZ4yFBXKPcMf8FMsz9l" +
            "WBlRoxSq55k/OoT+Ds7AZiXQF9893+xkz7kAZqz+xfr1yP7n5KF3NznV9J5sjFat" +
            "zIwY6YE4HGDgYoJvEmLvsC8dbOtyAo4qxracP6Zz9oR4yeCKXzUm2MnVd8p3q1Pi" +
            "RcNM6m96x4qLSAclKtw+NyYeGduD3A+HgVccRYt43PW3v6nEQ5onh8k3SAlckM5w" +
            "K8/BV4+uCZEVnxKUk5z2fy6Z3pKFj4rIm/q+tBKc1b3u5Ej6Hl+m2fhwQfvK/HpB" +
            "bWemzlZCrxGfnsUrD33n1LImjicpEKib5XhGo7WMy435dqQOCKVriK+sRfBbtXpq" +
            "D+3zu9GZVE9BPDCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsmxr0QlIswDQYJKoZI" +
            "hvcNAQEFBQAwgbQxCzAJBgNVBAYTAlVTMRcwFQYDVQQKEw5WZXJpU2lnbiwgSW5j" +
            "LjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0d29yazE7MDkGA1UECxMyVGVy" +
            "bXMgb2YgdXNlIGF0IGh0dHBzOi8vd3d3LnZlcmlzaWduLmNvbS9ycGEgKGMpMTAx" +
            "LjAsBgNVBAMTJVZlcmlTaWduIENsYXNzIDMgQ29kZSBTaWduaW5nIDIwMTAgQ0Ew" +
            "HhcNMTQxMjExMDAwMDAwWhcNMTUxMjIyMjM1OTU5WjCBhjELMAkGA1UEBhMCSlAx" +
            "DzANBgNVBAgTBk1peWFnaTEYMBYGA1UEBxMPU2VuZGFpIEl6dW1pLWt1MRcwFQYD" +
            "VQQKFA5HcmFwZUNpdHkgaW5jLjEaMBgGA1UECxQRVG9vbHMgRGV2ZWxvcG1lbnQx" +
            "FzAVBgNVBAMUDkdyYXBlQ2l0eSBpbmMuMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8A" +
            "MIIBCgKCAQEAwQL2ymVbspWkCpEHpVUHtcmbz5rrTHvwdlY2a8COz96uanuluHwz" +
            "0di4RVNGPwfhtpfEViriLvl7mQ2vuz6cZsnlR8zoKV2pt5GxDjO9Fvqel+u1w4HB" +
            "9g7HTCh5hB8jpXMtXOE9saNQMrqp0dkt/8Ry9Igq9Fu7cgs4TeS67HTuBCRv76ut" +
            "IFTIkpdTydbxz4r72x9aodg9vwUXYhrNbGGZ8h0igM0rKOvev/AifeNB6Omp9qaI" +
            "c2xT87bopLQRy8JLkIU4oNPq+92cCR6TeTItZ5/5xr9xsWjvi9rBga2bDbDPD+Fz" +
            "CUA0hBoIDHP7kkdBndISDwstJn4LwThP7wIDAQABo4IBjTCCAYkwCQYDVR0TBAIw" +
            "ADAOBgNVHQ8BAf8EBAMCB4AwKwYDVR0fBCQwIjAgoB6gHIYaaHR0cDovL3NmLnN5" +
            "bWNiLmNvbS9zZi5jcmwwZgYDVR0gBF8wXTBbBgtghkgBhvhFAQcXAzBMMCMGCCsG" +
            "AQUFBwIBFhdodHRwczovL2Quc3ltY2IuY29tL2NwczAlBggrBgEFBQcCAjAZDBdo" +
            "dHRwczovL2Quc3ltY2IuY29tL3JwYTATBgNVHSUEDDAKBggrBgEFBQcDAzBXBggr" +
            "BgEFBQcBAQRLMEkwHwYIKwYBBQUHMAGGE2h0dHA6Ly9zZi5zeW1jZC5jb20wJgYI" +
            "KwYBBQUHMAKGGmh0dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3J0MB8GA1UdIwQYMBaA" +
            "FM+Zqep7JvRLyY6P1/AFJu/j0qedMB0GA1UdDgQWBBQAWvCtpdR4NfWEEqgsBQ74" +
            "VhuOjjARBglghkgBhvhCAQEEBAMCBBAwFgYKKwYBBAGCNwIBGwQIMAYBAQABAf8w" +
            "DQYJKoZIhvcNAQEFBQADggEBAIjCmFo3jlvlWIqxF8IDqFtV6oyE0ImYvriarF1i" +
            "/DeCwXig4IOiIzqRaHLU2hR3Yulyv0+N8YnnllfixmWqjF5+VOkeCdfww8m4qkMG" +
            "yTtaSGIS7rl8HBv6D3BAcwx+BjSCMcgBDZkR/Y8npNNIVy+PbjCHvd2zKpyaPb3R" +
            "+nAO0doXaMTmmr+1AE4ny8OQ3jrC3ioyEbqcik6Bz0qeDIst0Q7tXfgozU1v6w30" +
            "mSpNZc2g2qU5/tCNgfCXDsq7tbeQgYr5/WQ/XGpMGlfCwETmwuWe6M/4kCpXxoqU" +
            "EkMpEjciGWsb0IlSaoU2GZnZ/lATmMC89B5d68ucxiKomuAwggLEMIIBrKADAgEC" +
            "AgQO7u7uMA0GCSqGSIb3DQEBBQUAMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5h" +
            "bCBEZXZlbG9wZXIwHhcNMTgwMjI3MTMzNjQ3WhcNMzgwMjI3MTMzNjQ3WjAkMSIw" +
            "IAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxvcGVyMIIBIjANBgkqhkiG9w0B" +
            "AQEFAAOCAQ8AMIIBCgKCAQEAxgEa/WdKNRX/JMHtkvIpY/AbtZiqSq4s+wer3kBR" +
            "wCBlgtGKaEIPih4s/Ca2KIXSvDlk3zZ2xGQrvfyyTn/numqvBZUY0+h1zWOJ5mDX" +
            "enyiRlTAaf+R8Eejg4XrzpNwjCiLA4RHBRCMPT+L6Nmuh30fkbbWrFks7maay8Fq" +
            "QGdN8tVvWKo0FzTdKJmTIsZSj8nSqiPMzBmOC6fQ6p+rLOGCI/Q3yWf4I8v5U6cm" +
            "foCGnVd4A8Jz1SPnoAqKHu3pisQ+2rGq8J7/g+lpQvgVSGRM8zWrheqoBHX84F2c" +
            "wxxpWPzo5QcW4Z0TLQUH0VO8+M6IOR9y0lsb+1znWWRBPQIDAQABMA0GCSqGSIb3" +
            "DQEBBQUAA4IBAQDEcGkES2pAb4OuJRd5FNupWUiALzAUE6rVEdw2zdgZZMD7LlwS" +
            "juQk3HCBHqZb7GPcQfsz3t3i30iW16vkS6MUaOBCG4LNsHSrgXj5Kro1gmeiqdE0" +
            "RryQpKpiGOIExlb04/N92A+HZ1lwJMNV6ErNN7PfmXie3njQM06fKpadxnr4SdmL" +
            "/VEdkpfolc0u39vfdKAfGYjUDrS6fCnGno3uX2vVHNmujzEatuWFScoLqyzgahm2" +
            "V06MNtTX7KCkMz8NGC9saGXUZzYSBQU/HtNthzJUmSVoFzwlMp9DfM2W8GCGenoZ" +
            "6LAEf8wXZGtS1IW1V6FF2z5uCs31rYmDd1+r";
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
