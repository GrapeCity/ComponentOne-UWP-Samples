using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace C1FlexReportExplorer
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
            "ADABMAIwB4lDADEARgBsAGUAeABSAGUAcABvAHIAdABFAHgAcABsAG8AcgBlAHIA" +
            "aYpImTMBsnJXuc95nP6BuDeJHOGL0bH51Kjyaqkc8pHpFSjOijGmFH1QnMQBXHdT" +
            "T4lwV1vGhFG4fym+DYVFsDiqQKawSt4AG45EeKcaZGgNvU7qm+YCBBUA9++ed7aQ" +
            "+DNUclz3szJfIFUKwYBhemXJJaezLmFUOaI2078HmKBOM4yWJJUBJ8KeEzI4M/Ib" +
            "HQ0z0Ium/CJ6YWAzFdCspcfK8LuHKJ0K+bXr4Z53TbVJmigP10YCTVmTNTTH5oP9" +
            "z3Wn/+iYdy4zuET+aNrKT6Q6CPSUhHE04mzad+6p1begSpuHOhLsl7KCEFq9Q6hk" +
            "zZYSfjE+oWuQFK+3+DYB42jQZ2DNxtavBRyawS7zHfPNxMKXsw2y1pPI/WDOzJG8" +
            "/XV4LpmTw38ttD2NdpT6VtbT3dd0rqszg7xfSvKx0dE5Rb2WtZn3b86Dh12J6mcj" +
            "hda99iwyCvFgdWf+7lG96H6yqnRma+AGIoI/LOWfkaw18nxmMULVKxuOewUE1BjA" +
            "od/HiK6zmdeloM+MC7Cw8FBtGld2iUz8pkrEoI8iy6nXQwMbsQx1jcB4p2OQvsxt" +
            "fufXwn8Joe8BMMWFTKivQmGVLr6FnQCkdS6OhHPezJQl/vP9+yDZsHVCF2oSQuhl" +
            "qGciGKouRRpmIydwYV6lvxiGE5lMue+gMfdvel3HdNQwggVVMIIEPaADAgECAhBB" +
            "A3jSJjZZehbbJsa9EJSLMA0GCSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEX" +
            "MBUGA1UEChMOVmVyaVNpZ24sIEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0" +
            "IE5ldHdvcmsxOzA5BgNVBAsTMlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52" +
            "ZXJpc2lnbi5jb20vcnBhIChjKTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAz" +
            "IENvZGUgU2lnbmluZyAyMDEwIENBMB4XDTE0MTIxMTAwMDAwMFoXDTE1MTIyMjIz" +
            "NTk1OVowgYYxCzAJBgNVBAYTAkpQMQ8wDQYDVQQIEwZNaXlhZ2kxGDAWBgNVBAcT" +
            "D1NlbmRhaSBJenVtaS1rdTEXMBUGA1UEChQOR3JhcGVDaXR5IGluYy4xGjAYBgNV" +
            "BAsUEVRvb2xzIERldmVsb3BtZW50MRcwFQYDVQQDFA5HcmFwZUNpdHkgaW5jLjCC" +
            "ASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAMEC9splW7KVpAqRB6VVB7XJ" +
            "m8+a60x78HZWNmvAjs/ermp7pbh8M9HYuEVTRj8H4baXxFYq4i75e5kNr7s+nGbJ" +
            "5UfM6CldqbeRsQ4zvRb6npfrtcOBwfYOx0woeYQfI6VzLVzhPbGjUDK6qdHZLf/E" +
            "cvSIKvRbu3ILOE3kuux07gQkb++rrSBUyJKXU8nW8c+K+9sfWqHYPb8FF2IazWxh" +
            "mfIdIoDNKyjr3r/wIn3jQejpqfamiHNsU/O26KS0EcvCS5CFOKDT6vvdnAkek3ky" +
            "LWef+ca/cbFo74vawYGtmw2wzw/hcwlANIQaCAxz+5JHQZ3SEg8LLSZ+C8E4T+8C" +
            "AwEAAaOCAY0wggGJMAkGA1UdEwQCMAAwDgYDVR0PAQH/BAQDAgeAMCsGA1UdHwQk" +
            "MCIwIKAeoByGGmh0dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3JsMGYGA1UdIARfMF0w" +
            "WwYLYIZIAYb4RQEHFwMwTDAjBggrBgEFBQcCARYXaHR0cHM6Ly9kLnN5bWNiLmNv" +
            "bS9jcHMwJQYIKwYBBQUHAgIwGQwXaHR0cHM6Ly9kLnN5bWNiLmNvbS9ycGEwEwYD" +
            "VR0lBAwwCgYIKwYBBQUHAwMwVwYIKwYBBQUHAQEESzBJMB8GCCsGAQUFBzABhhNo" +
            "dHRwOi8vc2Yuc3ltY2QuY29tMCYGCCsGAQUFBzAChhpodHRwOi8vc2Yuc3ltY2Iu" +
            "Y29tL3NmLmNydDAfBgNVHSMEGDAWgBTPmanqeyb0S8mOj9fwBSbv49KnnTAdBgNV" +
            "HQ4EFgQUAFrwraXUeDX1hBKoLAUO+FYbjo4wEQYJYIZIAYb4QgEBBAQDAgQQMBYG" +
            "CisGAQQBgjcCARsECDAGAQEAAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCIwphaN45b" +
            "5ViKsRfCA6hbVeqMhNCJmL64mqxdYvw3gsF4oOCDoiM6kWhy1NoUd2Lpcr9PjfGJ" +
            "55ZX4sZlqoxeflTpHgnX8MPJuKpDBsk7WkhiEu65fBwb+g9wQHMMfgY0gjHIAQ2Z" +
            "Ef2PJ6TTSFcvj24wh73dsyqcmj290fpwDtHaF2jE5pq/tQBOJ8vDkN46wt4qMhG6" +
            "nIpOgc9KngyLLdEO7V34KM1Nb+sN9JkqTWXNoNqlOf7QjYHwlw7Ku7W3kIGK+f1k" +
            "P1xqTBpXwsBE5sLlnujP+JAqV8aKlBJDKRI3IhlrG9CJUmqFNhmZ2f5QE5jAvPQe" +
            "XevLnMYiqJrgMIICxDCCAaygAwIBAgIEDu7u7jANBgkqhkiG9w0BAQUFADAkMSIw" +
            "IAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxvcGVyMB4XDTE3MDEwMTA5MjA1" +
            "NloXDTM3MTIzMTA5MjA1NlowJDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERl" +
            "dmVsb3BlcjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAI78jpWT+N2H" +
            "dD3NFUKhnV7FztTDu9UN37SBxDNwQrK9fDLfsYXnizF7dD8bi9rO+HQrYaMoFTv+" +
            "WMZiFtNnUp9anspRazQ1lMIdUFxm5IeRdb74GVcKV2ti/R2D5ruduJYBV6/bDsli" +
            "4pWldmTnKFzmcSLTJa92tqtXdzgHAU4Mbv+9SHEOBxQB2L4TWjcHCRhjSOy3tJA6" +
            "5GrCtIYy2PjvGZkjdF9ILM3UFV1fj3fboYdNPBV+zTTzLGy4pln7qEOxvzQq4KHy" +
            "hH41f0E65tW/nm8QpOzheC8xBrkRCKt+4BAW8BsXNTvwJxsZMqmiD2nSH4PpwRQ0" +
            "2tR21Xv85h0CAwEAATANBgkqhkiG9w0BAQUFAAOCAQEACjbEQBgducMwViY5X43N" +
            "9UWBJKMLvzEf/xpa4jQFk/V/gg4/q+FSH1izKrClqnKCDyX2QasuTHvUppsSv+Zs" +
            "NxI1bS8yJ70bPhiH92kzOCqlFa5NRvCUUUNATpujdkAJE3/8FEaDBcxv+PM0WSyZ" +
            "g9uHtlNmNGgrqdrD2nlQMKhv7pmVA9nwEzsnD7DY/LhkqpCf7YEPoIP2aJb5GFWt" +
            "yi8GIg+Ygyj1UFrdu4uu5RU9tKgI81veBcQmMR/c8Xp2GVyBdZh8AM6dOB4T97Lt" +
            "3Os9nNxtO/DcRL1NuryBH4pY6nVNsHt2vSKvSHQF6Bnua71KMi2tcgplNzNSiaX7" +
            "ZA==";
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

                SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
            }

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

        void App_BackRequested(object sender, BackRequestedEventArgs e)
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null && frame.Content is MainPage)
            {
                if (((MainPage)frame.Content).HandleBackRequest())
                {
                    e.Handled = true;
                }
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

            var frame = Window.Current.Content as Frame;
            if (frame != null && frame.Content is MainPage)
            {
                ((MainPage)frame.Content).App_Suspending();
            }

            deferral.Complete();
        }
    }
}


