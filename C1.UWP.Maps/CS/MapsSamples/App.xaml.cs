using MapsSamples.Common;
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

namespace MapsSamples
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            C1.UWP.LicenseManager.Key =
            "AB4BHgIeB3dNAGEAcABzAFMAYQBtAHAAbABlAHMAKCv4U4chOddIeCSQ99VQVKl3" +
            "gjFZRaymH5usEOxOy55unSBQlAa4MLxDA+1OpFpLYxkTtNyINDOXc1UE1x22LHan" +
            "xxGozBSaABrnol5thRLLZ+nYCxJppufZdShLCz5ZXr7zbKkdQ/75kNLjT6kMSgKg" +
            "3maT5SbbiNWbFSXtAj28z5+MfJmA8IZhn5f6dsEPOknbF4SdgCO8sZakU/wLGspM" +
            "1v+pQYm6m3/V2Cgj0JFwpKuICCj9rbfz/0lycMlROAZ7LOYARQ99jZrz8ynxHmy+" +
            "Vdx8W/hCqKfUYH05ya7fZuthNRFMlI74ucKS9/AIHYofw0jHuTgs61bnHet3tlj/" +
            "3Pxc1YR5zV/7WJwldw/0sb3ppG3EVL+9y1ktIe7iN9Q1zj/oMYMMdZfvtOFPbpIE" +
            "RuhIj6Slvq7s7GqDBPCPAhxYfkrDTQQmI3ZHLest5v3SXrFIRgDfFJgpJlliciGH" +
            "0fqTVd6CkxsYHJ2KtRpnznBJmeKQ+0UOejYE60uAeHqODPxKm1f/Zg+4UYdt+NBS" +
            "DTHmoUE1WQW//zpSkNPWIXpnvaXlOdxPDpuZUWA+DDlH5Jd4ReNm2w12NyOEF2HP" +
            "yyUpluMKbctG2b5wQUOsbmGhm+HmcfxMhU8GKP7YZb1zFf1o1NDGvhCzbXqg8DN9" +
            "LRcWrHZdP+IHdU5NjwowggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9EJSLMA0G" +
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
            "ZXJuYWwgRGV2ZWxvcGVyMB4XDTE3MDEwMTA5MjA1NloXDTM3MTIzMTA5MjA1Nlow" +
            "JDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjCCASIwDQYJKoZI" +
            "hvcNAQEBBQADggEPADCCAQoCggEBAJxzESXqzro7PvRj7Bv7Wg3H03c/gn1vWocK" +
            "oHmnnLKWrojRtVZhgdiMI37YJflJJZUrlaiOmYADHyLgSbnKIW4wz25mkq3P1qnE" +
            "WSWlfPioj1+Vqwj0n12WmUGM7Efwf2Rdj0Q5mdWjhRLH3Ti4VJNYnWkuqnK2152L" +
            "GoT/n57EiiheGjtspMOHh0GbqrWum1N0o/+UbwqX5Gf///UT6ux1wMV8fDCiEyAF" +
            "6ZFczOdgZZdoopUsuC7j/ZP7Atj1hxDSalj3vs+8C5lMw9PHbjLIAkTnFwjgQPWb" +
            "bpRgYC8b2P+YkwzxX88bYoUCvoljlwHe5rS8fbSphzB5Po8KD9UCAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEAZPoSD7VlC9KcHgQxSCQsfHg01ufRDAt615Cu9Y1m4bVW" +
            "i03R8DblbpsES5xGWYu17+hK/yg0rzBwroOHwN/A1SbK48Onz/koieTUNPVqlLVo" +
            "xdLjAaZk+7oH6+7F3Qvddbe0oicctbyIj0ELszKRBZ7ATXWawE/DMHOMr6tQrM3K" +
            "jBK25dnbCIDUXURyv30cv7zrObH5pQpHUwfZp8ZF8fYcllirBykttlEdKmEdQOBN" +
            "DCjFrfHeKg+j3reeel2ivW8q70Am+Fv1pK8JP8rhs5TS8pCblPhd+r0thDnN50tH" +
            "zRQsI7WE8JogFGJau8lsUZqS6mPSwRPLraM/fd+RFw==";
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
