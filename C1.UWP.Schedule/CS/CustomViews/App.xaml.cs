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

namespace CustomViews
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
            "AB4BHgIeB3dDAHUAcwB0AG8AbQBWAGkAZQB3AHMAS+LqssyRK3VeBEBmDeX1L9lY" +
            "HdW73SFwc941ZJuXH3dQYFjlMDy5sLRpm+NVjiwa96trH9Cp3YbOahLfxScADqEg" +
            "WPEZ0o7lc0lbS713ngIvIVVNkknKGwBdRoUCLRBeSRfBSbOetlBBjLwdKoLVqoI6" +
            "XjitNwAnpALkP3g6tfSNeeFPenktenTuOPwlu/1kGqkERy8kBXThuTjGpR0AtrIY" +
            "OFljXLT16cp2loL1Oza5hEhlwkbj5Y3uszHbfVnn3vvRedUZ4c4DmuShMc1XoSRY" +
            "OT6jhCV9pxVKKn6dRBGwIJ67jjpqlVTkXFKo0QzqzWzrQy1HczWEjXxRmP80BE22" +
            "RuCj83LhapE3FzigzEHnhDSHjEk/YxRcyUPkyai1lL687RzQLOpaeLYSG5iZ5a7H" +
            "VhaFRbhYp96+xlF/iCtNVrwaZSvqK8glQwgXBDWzpH/xISCRB+g/8plosaw9RW1t" +
            "8o9O9DwRvELeT1x4AhdgUB+G0P9nnve6BFxq9PMgKqSYR9eZc6um6MyXciJ7ppib" +
            "8bI/OyRIPQqDyDWc3mCwll0raTHu6e1g4WfV2/Pcjo30n0ej7c0b21ox10S5020o" +
            "1kdW6m6A2iJ+1nkpC+OqXXh7Hc3ADwwSw2J8LLm+2B3ag22UmCZxtqvWYonrlQeN" +
            "JI5qrHkk9Y9TiUXH7wcwggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9EJSLMA0G" +
            "CSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVyaVNpZ24s" +
            "IEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5BgNVBAsT" +
            "MlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20vcnBhIChj" +
            "KTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmluZyAyMDEw" +
            "IENBMB4XDTE0MTIxMTAwMDAwMFoXDTE1MTIyMjIzNTk1OVowgYYxCzAJBgNVBAYT" +
            "AkpQMQ8wDQYDVQQIEwZNaXlhZ2kxGDAWBgNVBAcTD1NlbmRhaSBJenVtaS1rdTEX" +
            "MBUGA1UEChQOR3JhcGVDaXR5IGluYy4xGjAYBgNVBAsUEVRvb2xzIERldmVsb3Bt" +
            "ZW50MRcwFQYDVQQDFA5HcmFwZUNpdHkgaW5jLjCCASIwDQYJKoZIhvcNAQEBBQAD" +
            "ggEPADCCAQoCggEBAMEC9splW7KVpAqRB6VVB7XJm8+a60x78HZWNmvAjs/ermp7" +
            "pbh8M9HYuEVTRj8H4baXxFYq4i75e5kNr7s+nGbJ5UfM6CldqbeRsQ4zvRb6npfr" +
            "tcOBwfYOx0woeYQfI6VzLVzhPbGjUDK6qdHZLf/EcvSIKvRbu3ILOE3kuux07gQk" +
            "b++rrSBUyJKXU8nW8c+K+9sfWqHYPb8FF2IazWxhmfIdIoDNKyjr3r/wIn3jQejp" +
            "qfamiHNsU/O26KS0EcvCS5CFOKDT6vvdnAkek3kyLWef+ca/cbFo74vawYGtmw2w" +
            "zw/hcwlANIQaCAxz+5JHQZ3SEg8LLSZ+C8E4T+8CAwEAAaOCAY0wggGJMAkGA1Ud" +
            "EwQCMAAwDgYDVR0PAQH/BAQDAgeAMCsGA1UdHwQkMCIwIKAeoByGGmh0dHA6Ly9z" +
            "Zi5zeW1jYi5jb20vc2YuY3JsMGYGA1UdIARfMF0wWwYLYIZIAYb4RQEHFwMwTDAj" +
            "BggrBgEFBQcCARYXaHR0cHM6Ly9kLnN5bWNiLmNvbS9jcHMwJQYIKwYBBQUHAgIw" +
            "GQwXaHR0cHM6Ly9kLnN5bWNiLmNvbS9ycGEwEwYDVR0lBAwwCgYIKwYBBQUHAwMw" +
            "VwYIKwYBBQUHAQEESzBJMB8GCCsGAQUFBzABhhNodHRwOi8vc2Yuc3ltY2QuY29t" +
            "MCYGCCsGAQUFBzAChhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNydDAfBgNVHSME" +
            "GDAWgBTPmanqeyb0S8mOj9fwBSbv49KnnTAdBgNVHQ4EFgQUAFrwraXUeDX1hBKo" +
            "LAUO+FYbjo4wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisGAQQBgjcCARsECDAGAQEA" +
            "AQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCIwphaN45b5ViKsRfCA6hbVeqMhNCJmL64" +
            "mqxdYvw3gsF4oOCDoiM6kWhy1NoUd2Lpcr9PjfGJ55ZX4sZlqoxeflTpHgnX8MPJ" +
            "uKpDBsk7WkhiEu65fBwb+g9wQHMMfgY0gjHIAQ2ZEf2PJ6TTSFcvj24wh73dsyqc" +
            "mj290fpwDtHaF2jE5pq/tQBOJ8vDkN46wt4qMhG6nIpOgc9KngyLLdEO7V34KM1N" +
            "b+sN9JkqTWXNoNqlOf7QjYHwlw7Ku7W3kIGK+f1kP1xqTBpXwsBE5sLlnujP+JAq" +
            "V8aKlBJDKRI3IhlrG9CJUmqFNhmZ2f5QE5jAvPQeXevLnMYiqJrgMIICxDCCAayg" +
            "AwIBAgIEDu7u7jANBgkqhkiG9w0BAQUFADAkMSIwIAYDVQQDDBlHQy1VV1AgSW50" +
            "ZXJuYWwgRGV2ZWxvcGVyMB4XDTE4MDIyNjA4MjQzMloXDTM4MTIzMTA4MjQzMlow" +
            "JDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjCCASIwDQYJKoZI" +
            "hvcNAQEBBQADggEPADCCAQoCggEBAKcUwu5wjAcRbMtmsiEL7x4368wsQHBGTYtH" +
            "5Y4M2FxlKSr406Qwo2W15QS/t66oiYTaSX9xdpXTVu6+TKAA+67OiOkXXYNrsn/j" +
            "FbZTPB9vREytraRYWj4xT62F7ZILYmeMhDKm9tUS0Cvg4dIJ+brLvaq2cn9Hz1en" +
            "YVY5EwhNRx/fWLs7BJW1lq2Ua7u6Oio2wrAtwY5heM2Bj+S16i6ceEAZ3joJdtuJ" +
            "8hbjzsCHaLgDqQ0UNUBicS4Qw25rppLeeXOLU8RMDqmtYJcK4Cnt9yBIexbQZnbY" +
            "okwCbeOhvKpS9VSGClAOPt16ZO+vknZbIQrzk5E4hnW/NPbn450CAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEAbvIuETR6F9OfTTn1YarrIfs1ZuCE7IxNvcnP9naV1Ny/" +
            "sVWc9n0HueAL3DocypCirPGUQaDuZZKjg6QZfktEgMr1HNVeGlxwpKJz7N5ozj71" +
            "1unAKUTNJ15S321rInEPX7c5JFW8zMlGEt1ldsp8MOz4MH0pE0B1ug2VyAk3YYfa" +
            "hi2wphTD+8TR2oC/PbS3T1K2g9PqwwAvwcOnTgMX6Jhq1TT0AGh9O+ieUrJFcbei" +
            "DDor7G0VOPwKlpBwT30iJbS6LdVFi8QAJFia7bToKo4mnw2vslXFSUiS8J/Zb/A7" +
            "dKxf208u3HeU5DExKKXZc+6jMuXiCZo+lgNjWaYLkA==";
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
}
