using FlexChart101.Common;
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

namespace FlexChart101
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
            "ACABIAIgB3lGAGwAZQB4AEMAaABhAHIAdAAxADAAMQA5vEO1X1RT4kwqG8cfgDQA" +
            "STvEYP7iqUKaRTnhcc5wGzy+3XGGdQselZxB77kGJ3zMnxqF6Cixnwk/HjYcnH+M" +
            "ntLGiHfVmPl0ZP7mQqOA9fVxXroPYEVit5LgKJdw3jdyHim/0dcHP+NbP3+mc+RZ" +
            "RAYfzQfdH3jFhWOWPbmOABlauByWjjrSaqpg74z+rtW0qPfjTjLJMM/2LPhai5VS" +
            "XfzGS6Ae0G6MtzWZtauvtKJRONPolfWvPSATP2N0qfi2IAtPH6IjJT5cvWdPRw6U" +
            "ge9kYY45JuMKWqcUFqbe49e0YzRijxB0Rtu0C3TlUZZ8YBbp0jOPftPoMC98qmNG" +
            "s9oY6gowzy2VrZEW5+lN+09hPjpnrgr04rLNBN7Hg63aFVIhjGtvRlTizxjF5Sc8" +
            "MOK82o4XwxS35wRTd+tE9swkI73rz/JyabtfPTnXdSI3nUnL3cgDC31UUro0+Htf" +
            "N1k/hTRDhqrKVwdxxPQAAZ2fGDAuo/BEhwnMpvqgAjQN07ye+WR1XukZ5F9UUPr9" +
            "b45njSbDKzVw9ss9nFvSYnzy36Yeaj+NqIymbGaJ2bYj/JlZcLPXEtGNkgPMIGdS" +
            "VoTmYKNZ/iUQ3YokCno0TmuZmooAnuhYm0fNBoH4Yizzff+4qBRZIcNOqQ7kkSuD" +
            "Daod400nljwplv+Hnv9wgTCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsmxr0QlIsw" +
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
            "hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAkLCSeIN5oTMvN5gCJR29qDBkG7jjYY+Q" +
            "G7pTlZxK4DSvvXZh7uVg7Bw/aDToU4hduqwrGXlATthqE1762oJ8mIkeemYvnn81" +
            "A5zSvGHTNloOB51CPQAIOreOnJG+CRDQZ5azjFFaZQkUAG7aIEl7pszS5+6SdGu1" +
            "TFGxb959V6FSdUe2CWJ2DGC8EGPfH4EJUmxyL/EIKvjIc4LVZfLbzTnMRiM/PAzh" +
            "BwZ+v0BwUotbrwxdAikmzpEE9niSlThZI+q4/jPH2OZV4viCKABQmtRLrpJsSssM" +
            "wW3i/5YEldoP63kvvL6N/ymNup9dFokzui1a4lDQTkfPyz/vFJaORQIDAQABMA0G" +
            "CSqGSIb3DQEBBQUAA4IBAQBI4P1VlpdLjb6r8s6mGFWqS/gryAtP+0FaQdCBGTVW" +
            "3SeP0lnWvZr3uLYQLPVZvStf9payPe0aJ5VMZEOjruj8kyCoaEWXOWRDxNR+9SLc" +
            "v++WFUgoJrFhhEUGXJHagOLdTcADvxPImAEOd3ZWFc8kiWzXuSk280sE+q8KgVyn" +
            "JiQNkoyVkBW4rRDVGwIbEK01Il/ZadiWVEdT+Pn5064SlEWAcm24jwtbMzo55lXS" +
            "vjHIo4GcRMMkbNkfCTulv28W/OvieFbOXhLvnL0dHcJJCicQAFRWcq2CEXON6TK1" +
            "C1YAAmFOKc3kVWdkrRgeNZ+T4CtZ6+8yM/dxYs5pkCM0";
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
