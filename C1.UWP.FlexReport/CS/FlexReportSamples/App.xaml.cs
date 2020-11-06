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

namespace FlexReportSamples
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
            C1.UWP.LicenseManager.Key=
            "ACoBKgIqB4NGAGwAZQB4AFIAZQBwAG8AcgB0AFMAYQBtAHAAbABlAHMAR2MH4GBw" +
            "KjuAVtC4VDwqlk0Er5gPf0Hwb8debTJCIBbzQBtFxxepHugQZyPobI/Nso6jIrKT" +
            "OOYjLTN+7lrh23Jk0VSqVhJJg0SxuSHKw7V+lj4Tai17vO94anoeb7lJMQCIy2wa" +
            "chN5pVnGEbZdlOmNe9VBO4na9yQvbfenQvECYyDkXyFM/r+y9/MMp7xdNRPsLc6z" +
            "67zmTd/tV3gq4Ezd5yqY+BIJzRtL10uGrs94ni8UsHrrv26tXkSQ8TIIb4QhOZoy" +
            "6IcyDQN0tZHWCVx6mnJ/+F9yS10btzIaCrgUz+2x6bKMY8idgo8fXFFVglc6qOaM" +
            "tk4e1iityloBYw4ft13tBFzin1T7vLs3rzAV6mNqcCbbDVMr1SAMGAdv8QTIZ0cg" +
            "muHhFu9EgI+E7M+g3m2OF8fvFW9agbb+pesgQ8KC5bGAPsocPyPcL8i2gvg4mEJN" +
            "FYzKLbRiTUTS+Yr1Zc0iTa2kSIgoInDHBhOm3+KvMSihPOlS+8+5yPJ4+Qlu4jPL" +
            "TjL9beX7eZ7PsH9CbD/v9XTNqog9ky+2oOfu3kAl3NwMWrxWQPawRCbmoDNWJj8G" +
            "2ndBSnh4Z2fuElBqiOrxt91f/MYiESxnqjqwARYWV57VR9e5pAatI6CHoJmGqJ0J" +
            "qv5Z+qG1MrmGhvCUbXFFvAvOBjoOJC7sX1swggVVMIIEPaADAgECAhBBA3jSJjZZ" +
            "ehbbJsa9EJSLMA0GCSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UE" +
            "ChMOVmVyaVNpZ24sIEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdv" +
            "cmsxOzA5BgNVBAsTMlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2ln" +
            "bi5jb20vcnBhIChjKTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUg" +
            "U2lnbmluZyAyMDEwIENBMB4XDTE0MTIxMTAwMDAwMFoXDTE1MTIyMjIzNTk1OVow" +
            "gYYxCzAJBgNVBAYTAkpQMQ8wDQYDVQQIEwZNaXlhZ2kxGDAWBgNVBAcTD1NlbmRh" +
            "aSBJenVtaS1rdTEXMBUGA1UEChQOR3JhcGVDaXR5IGluYy4xGjAYBgNVBAsUEVRv" +
            "b2xzIERldmVsb3BtZW50MRcwFQYDVQQDFA5HcmFwZUNpdHkgaW5jLjCCASIwDQYJ" +
            "KoZIhvcNAQEBBQADggEPADCCAQoCggEBAMEC9splW7KVpAqRB6VVB7XJm8+a60x7" +
            "8HZWNmvAjs/ermp7pbh8M9HYuEVTRj8H4baXxFYq4i75e5kNr7s+nGbJ5UfM6Cld" +
            "qbeRsQ4zvRb6npfrtcOBwfYOx0woeYQfI6VzLVzhPbGjUDK6qdHZLf/EcvSIKvRb" +
            "u3ILOE3kuux07gQkb++rrSBUyJKXU8nW8c+K+9sfWqHYPb8FF2IazWxhmfIdIoDN" +
            "Kyjr3r/wIn3jQejpqfamiHNsU/O26KS0EcvCS5CFOKDT6vvdnAkek3kyLWef+ca/" +
            "cbFo74vawYGtmw2wzw/hcwlANIQaCAxz+5JHQZ3SEg8LLSZ+C8E4T+8CAwEAAaOC" +
            "AY0wggGJMAkGA1UdEwQCMAAwDgYDVR0PAQH/BAQDAgeAMCsGA1UdHwQkMCIwIKAe" +
            "oByGGmh0dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3JsMGYGA1UdIARfMF0wWwYLYIZI" +
            "AYb4RQEHFwMwTDAjBggrBgEFBQcCARYXaHR0cHM6Ly9kLnN5bWNiLmNvbS9jcHMw" +
            "JQYIKwYBBQUHAgIwGQwXaHR0cHM6Ly9kLnN5bWNiLmNvbS9ycGEwEwYDVR0lBAww" +
            "CgYIKwYBBQUHAwMwVwYIKwYBBQUHAQEESzBJMB8GCCsGAQUFBzABhhNodHRwOi8v" +
            "c2Yuc3ltY2QuY29tMCYGCCsGAQUFBzAChhpodHRwOi8vc2Yuc3ltY2IuY29tL3Nm" +
            "LmNydDAfBgNVHSMEGDAWgBTPmanqeyb0S8mOj9fwBSbv49KnnTAdBgNVHQ4EFgQU" +
            "AFrwraXUeDX1hBKoLAUO+FYbjo4wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisGAQQB" +
            "gjcCARsECDAGAQEAAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCIwphaN45b5ViKsRfC" +
            "A6hbVeqMhNCJmL64mqxdYvw3gsF4oOCDoiM6kWhy1NoUd2Lpcr9PjfGJ55ZX4sZl" +
            "qoxeflTpHgnX8MPJuKpDBsk7WkhiEu65fBwb+g9wQHMMfgY0gjHIAQ2ZEf2PJ6TT" +
            "SFcvj24wh73dsyqcmj290fpwDtHaF2jE5pq/tQBOJ8vDkN46wt4qMhG6nIpOgc9K" +
            "ngyLLdEO7V34KM1Nb+sN9JkqTWXNoNqlOf7QjYHwlw7Ku7W3kIGK+f1kP1xqTBpX" +
            "wsBE5sLlnujP+JAqV8aKlBJDKRI3IhlrG9CJUmqFNhmZ2f5QE5jAvPQeXevLnMYi" +
            "qJrgMIICxDCCAaygAwIBAgIEDu7u7jANBgkqhkiG9w0BAQUFADAkMSIwIAYDVQQD" +
            "DBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxvcGVyMB4XDTE3MDEwMTA5MjA1NloXDTM3" +
            "MTIzMTA5MjA1NlowJDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3Bl" +
            "cjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAJ772IopslSVa3HjZ+cD" +
            "fc+t/viYwayvYTyWq+/AytKVnBHO2ZbEn6TA2KnoC94pRR884FbHpp3HWhHFur/C" +
            "yVG+g1OQSg7ZAsiX4+7TGcj9z3Y+ZbZDVfePJB+gmonxL+kF0mcl0qAC5QKj+pBz" +
            "plyiXwYL4Ia2vVPOjk7H4O3GTucTJ4DmKuX1v7QattvSb94GRWpyJfjgbrGbv4r5" +
            "+KqjJdYLUehqQVdRl03N3Lce+xqvc8qios8Xsr6Ug4cNZ/FBfw0E8tPAXTzzARec" +
            "jJsjdbsjE1SdVGbdKSj/iNkXwewt2eiC7P0RG5QvXC4s9iDASXRuoYRbpRb5n4o+" +
            "ppsCAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAgYhFMzxNhutmhVudfHIKU3tZXhJf" +
            "ZE5dRRHZ4jExtFuFU4Ea3SCAUw2f4fsWC41ML7AtYoj8ZcqElj56+g1J1VC9Kqfk" +
            "CAxMBf652gmPPRTt2++m/oDaFBJ0xInVUicBZWulyIMH+OciBHVkdATdF+eP6FlQ" +
            "UwaEZfFKehhIp965YK5JLTuuw9JObl2Y85KgJaMPr2ZRlPKzFBBgctsv/257wJv4" +
            "Zq1ImKdm+FUMChBSMzjaGrhI6/4t87coRuLAiGCC5q6cxvTChwKlqVr5rqkwbMHA" +
            "jMECceCBJxXOy5Kozfu+sF5C7c62SEPMNA2L9pSHrCgpPw+ivvofg472EQ==";
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
