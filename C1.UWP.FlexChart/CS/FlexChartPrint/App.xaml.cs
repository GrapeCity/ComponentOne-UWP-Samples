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

namespace FlexChartPrint
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
            C1.UWP.LicenseManager.Key = License.Key;
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
                //this.DebugSettings.EnableFrameRateCounter = true;
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

    public static class License
    {
        public const string Key =
            "ACQBJAIkB31GAGwAZQB4AEMAaABhAHIAdABQAHIAaQBuAHQAAqQEdLhoiissL1j9" +
            "/VclHeZiBzED6KN8WjrVGAsmU9rEJ8XL8fRSB8ryCDIpClgUke3QkIw+R7UH1knI" +
            "uUAyFTRR9oMyz80guErIzwUhxzN+eRSGgQ5NsFGhdDhpoRiLAPxTjudpFw1Um222" +
            "nn1Qf0Hps6CvkSWi5FDt/8dknaK5IbAEWyI1udHny0vnBv1efLf2vH/NF+AXY/I1" +
            "/tti6nGVvXvNYpN5zmt7N64V/2BPsZkADawyznGzGwIgECSNvnmaVDCWZXY9s3UU" +
            "T6oPPyJRLgx8BJm4GWUDXpnzheJGi+4sT8mI6NV2Pda26KsaSDBWIpphbW0NPr7F" +
            "blQQ5VOjLe5XDMm68BKUI6VcfGsSIi4S3gr1Gi8mtsG6rUepvfzdO1ptv1brK6J+" +
            "8IN+pzC9JTlrOp1FrJajWpbt44/Xrfgn3Wu7SpWQzxLCaogWzAIncu8T/g4QONfT" +
            "GxN8D0TRNtmBMMLw7R+UvbBsYx2CSN78QM3X7JhoVOWfz9qnzMZ5NJRD30jwp3hN" +
            "jdXf4a5XZbDi1BeDY0SWS2ExVoPiPlAPI+gSFRMq6pV0wYrxJdCoxPKYNETx8bBa" +
            "2QJKDv7m5765wTxl3B+NOYNAzZC0F34DscHKKgM4fK/ocWxQslmjINTvqgA3BQGc" +
            "DJeC5h/AffXq0A7ECrSmNfRFtZswggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9" +
            "EJSLMA0GCSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVy" +
            "aVNpZ24sIEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5" +
            "BgNVBAsTMlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20v" +
            "cnBhIChjKTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmlu" +
            "ZyAyMDEwIENBMB4XDTE0MTIxMTAwMDAwMFoXDTE1MTIyMjIzNTk1OVowgYYxCzAJ" +
            "BgNVBAYTAkpQMQ8wDQYDVQQIEwZNaXlhZ2kxGDAWBgNVBAcTD1NlbmRhaSBJenVt" +
            "aS1rdTEXMBUGA1UEChQOR3JhcGVDaXR5IGluYy4xGjAYBgNVBAsUEVRvb2xzIERl" +
            "dmVsb3BtZW50MRcwFQYDVQQDFA5HcmFwZUNpdHkgaW5jLjCCASIwDQYJKoZIhvcN" +
            "AQEBBQADggEPADCCAQoCggEBAMEC9splW7KVpAqRB6VVB7XJm8+a60x78HZWNmvA" +
            "js/ermp7pbh8M9HYuEVTRj8H4baXxFYq4i75e5kNr7s+nGbJ5UfM6CldqbeRsQ4z" +
            "vRb6npfrtcOBwfYOx0woeYQfI6VzLVzhPbGjUDK6qdHZLf/EcvSIKvRbu3ILOE3k" +
            "uux07gQkb++rrSBUyJKXU8nW8c+K+9sfWqHYPb8FF2IazWxhmfIdIoDNKyjr3r/w" +
            "In3jQejpqfamiHNsU/O26KS0EcvCS5CFOKDT6vvdnAkek3kyLWef+ca/cbFo74va" +
            "wYGtmw2wzw/hcwlANIQaCAxz+5JHQZ3SEg8LLSZ+C8E4T+8CAwEAAaOCAY0wggGJ" +
            "MAkGA1UdEwQCMAAwDgYDVR0PAQH/BAQDAgeAMCsGA1UdHwQkMCIwIKAeoByGGmh0" +
            "dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3JsMGYGA1UdIARfMF0wWwYLYIZIAYb4RQEH" +
            "FwMwTDAjBggrBgEFBQcCARYXaHR0cHM6Ly9kLnN5bWNiLmNvbS9jcHMwJQYIKwYB" +
            "BQUHAgIwGQwXaHR0cHM6Ly9kLnN5bWNiLmNvbS9ycGEwEwYDVR0lBAwwCgYIKwYB" +
            "BQUHAwMwVwYIKwYBBQUHAQEESzBJMB8GCCsGAQUFBzABhhNodHRwOi8vc2Yuc3lt" +
            "Y2QuY29tMCYGCCsGAQUFBzAChhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNydDAf" +
            "BgNVHSMEGDAWgBTPmanqeyb0S8mOj9fwBSbv49KnnTAdBgNVHQ4EFgQUAFrwraXU" +
            "eDX1hBKoLAUO+FYbjo4wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisGAQQBgjcCARsE" +
            "CDAGAQEAAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCIwphaN45b5ViKsRfCA6hbVeqM" +
            "hNCJmL64mqxdYvw3gsF4oOCDoiM6kWhy1NoUd2Lpcr9PjfGJ55ZX4sZlqoxeflTp" +
            "HgnX8MPJuKpDBsk7WkhiEu65fBwb+g9wQHMMfgY0gjHIAQ2ZEf2PJ6TTSFcvj24w" +
            "h73dsyqcmj290fpwDtHaF2jE5pq/tQBOJ8vDkN46wt4qMhG6nIpOgc9KngyLLdEO" +
            "7V34KM1Nb+sN9JkqTWXNoNqlOf7QjYHwlw7Ku7W3kIGK+f1kP1xqTBpXwsBE5sLl" +
            "nujP+JAqV8aKlBJDKRI3IhlrG9CJUmqFNhmZ2f5QE5jAvPQeXevLnMYiqJrgMIIC" +
            "xDCCAaygAwIBAgIEDu7u7jANBgkqhkiG9w0BAQUFADAkMSIwIAYDVQQDDBlHQy1V" +
            "V1AgSW50ZXJuYWwgRGV2ZWxvcGVyMB4XDTE3MDEwMTA4MzQyNVoXDTM3MTIzMTA4" +
            "MzQyNVowJDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjCCASIw" +
            "DQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKuhsGCh0vqNYHv6ndanCOQ+PPo7" +
            "8u6iGIFKf5BxQMSS74qLZ6KNw/AyRoqcPCYLEjmM2h/I4oEpU8MzhM7GGothXipK" +
            "RcjvRYNOjzD+aHX4XWc7iOBhDLjVdZNODUqlbknU3A42rAk/y8x2LHNlGKMUjEfL" +
            "0HZyHjbFa6kxzEOyYPSqPXlJABkdUxed3FleJZ3zaAdKh24/CHgEKBNtUghaYu2M" +
            "zLdAlIGDjIk0ljUz/wPZMnHwu+6tYfzT12ECet1NgmsbgyifHfn+ppE2VzdJxNtm" +
            "Kg4cy0WNs6DJ16KIhcVciqKTKTKIPXCCB+d1DnlOlIahxsGwV27h7QqurlkCAwEA" +
            "ATANBgkqhkiG9w0BAQUFAAOCAQEAJ0MLmPbC0OQcNjNsIDXHOKEsRGwcbL1+xe2F" +
            "iQhStuYXkDBXoB8ycOiaAravj6ZcTtbpSeAF2skHeOWGkYsTXi1g5WO8Y5/VVX4N" +
            "ly8B6RVOqqGYp3V0AIk68d3YW4hS56KFZMaZPaAPSnor+Tu3EdW2cuU4dkMHaG/1" +
            "zGc07my/qBXk8Qo6I+DiOUE0w7XYiKMNINrZuicXAdNYNKWJpEpjVWCB4oAkVSCF" +
            "/GJ2DxS1Ay+C6mEY1f/2347+jX4oUzOJVdf11bbqPsAE0RMyg2O9VlZrMLKwyfsh" +
            "PUHXqewo+OygtJnj+aM3iZHYoYJfIAxsmKAObSeR5TjJNl+fhw==";
    }
}
