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

namespace FlexChartMvvmDemo
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
            "ACoBKgIqB4NGAGwAZQB4AEMAaABhAHIAdABNAHYAdgBtAEQAZQBtAG8AP39e4ODb" +
            "/CYqJ0SHPee/CzY6ijFJkC1NshAR7SVcbdrbd0ytGCv0Bd7kzjKX4Df26peRIZ9R" +
            "W0CMXxKnQ4ak39UvDd9PnliBr0BHvC/JlY44UFsSNqseo1aPbWo87/idEndZOzj7" +
            "AyLgFw4strGZEDh+O15JsJgSjYX3WkAmkbnk7e+NY/SgNUedFG2U9oui4fKf0K74" +
            "kOaMaYi+tj0UDEVNJnoV8C688ybRQpz5mcB9XeKSbjDkGwgI4OK/bUyjYfpXFsdt" +
            "QcjM+tV3j67xI2Xr5rUYoIor4dQSLskR2YjbIjqdze+RxogoFdZ5NjMh9f/M98Fw" +
            "DWMcr+RK3YMnw1T4yUTvERgUXfw8TWXdoK5FkWWRmsEsHo/QsZDKkq/0YJsUEXV0" +
            "COZhEuuHMb/lbsS/ezuzljKwSSyy1lHZEBTECaB507JhR+LDXdp9g4GJINcwXX9x" +
            "9DDWnfVTuM3zJZuOi1kWieC3Whsv7UkIFN1XEWVvgIAbRmmGRzXNAJar9hQa5yOr" +
            "+KhrO57biX8pojB3E37hg2X1Wp3FRUzwmb8YGZ3mSWcolj/H4uSce82EWTib2LFc" +
            "81gJEOhiJOflBGu9zFpPzX4Q2u4NABsNapJPeO+TWSZxQtKzC5t6+ns4tNOswHHG" +
            "7YUdU+cRES6jYB+Qj0wZFKruq6kl+gWJLc0wggVVMIIEPaADAgECAhBBA3jSJjZZ" +
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
            "cjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKNLDz/WkngjE/5oD3Fe" +
            "0/pL/laXtJn2y9cLJQdQ9izoK6bnyOH8vFxQV6fz5Cx6eHvNAkt3lYKJVRImFZsb" +
            "pOYz3C0LB///7dLAIsM0fHDy9OcTQRPAGzmT/GrK7wswDbLtrKoIScZhgbTW2ilt" +
            "/5Fcz8sGZdv99rNkZcHh1bu0UJlnJT/ti4nCEUcVEyDGx8cySpMbkEw7IOV8OSdM" +
            "h8mcsyHQ/NJflEdMYRkjgMPmDeyYjbpSC8Z0K8N8i/aTpEqYazO4lJ7SP4BFDQ3G" +
            "kMGKY9cEgtYbZ09/VBzl5drEwZ9tUaKF84ckuUQiCYZrXqid/I0vhoggjbOUblmA" +
            "6icCAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAhFmoUgX4FTUxz8kozbf7L+40JsbJ" +
            "/fFn5Ey8fMUEdJQhGIXlpE+VL2v1R6n3SqtqqkLhvDp4XTVt7NBmUXDuQkn6E2WJ" +
            "/pGF3SFQ4XrYyXXJTO/oE1rWSX4zGVbMuVdKIkR4nTvG9rfc+5yogzqdbE2LWaDE" +
            "pIYNxL9P8M35ZkRo8nvIezBZciWuZet/Yn3nZrlO+StLZMjfxWe4VtkwceVOq1jG" +
            "1N60feV7dh6km/JTjz0p1Eb+wSZDubsB0Q96JQImW9MLy4j74MIUUcYjhwfo7zWS" +
            "e+LnR1UCc2Qar0UIr3jGqoMMDesCICal3C83nJPN9UQVZ8WCH1Q47M1P+A==";
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

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);

                // Attach view model
                rootFrame.DataContext = new ViewModel.OrdersViewModel();
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
