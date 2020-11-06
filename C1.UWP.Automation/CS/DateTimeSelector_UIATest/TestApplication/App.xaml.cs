using DateTimeSelector_UIATest.Common;

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

// The Grid App template is documented at http://go.microsoft.com/fwlink/?LinkId=234226

namespace DateTimeSelector_UIATest
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public const string Key =
            "AEIBQgJCB5tDADEARABhAHQAZQBUAGkAbQBlAFMAZQBsAGUAYwB0AG8AcgBfAFQA" +
            "ZQBzAHQAUwBhAG0AcABsAGUAYaFiQs0EiW33MVFdSXhAFBIpoPIS12p74a/gO32C" +
            "jjRfhHbd4YshF90g4qi4jb5Hweq/pKYLF7OnDE8ove/nhaz+7Tad9o1DVzLVCABs" +
            "/nr3yMiHX7D5/5WmMejXIubHnu5l0gakUzNiY8Kcr1QtsIzj33d6w/hjJpQaBDoj" +
            "E6zWtZtuE1otOpWiZC6Soi9OhAIbAIMkYd0LfoazYmJfoxPkog5YT5MxtTzBeBgG" +
            "hzt/oDiuTpGRe2WE449qbGV26CSkyavISlH0c0byxLi/W0I/kOVaZVNqsEqajDt/" +
            "MILNzXmqANInu59+JD5DSS+82E7egW++vMsTWdbTMB0XmnmWykWNw75tyoBJjb6/" +
            "SEjg5jtfUgeXSduWMCQsPoUGclz5ggtgsi9X4ocdMUypcJc78kA4n5Cy2FNdxVbj" +
            "GyofsbmXu2PzzhR1ft+Z1sfZVPpTTtQg9Pt2E4LrUCSgn4kxKOyVfW9xJSjF1yFg" +
            "K3VKQepV9ZiPF+PI5pZjyVeZGb/LSLFgFqIjAgTP2xkl2X9prsWieR7p3eip4E0U" +
            "8YR5YbsX2oEF843Nctb+pn1srffO/JF5JvM8wVL3ZGTtIQaoAxy3H7ClONjuTqpq" +
            "QqZxkqsQoPnfun/rw+t//g/Qulfq3HCsvp4c3z/7xWHYceRZ23V5RsuQV0hMrPzZ" +
            "pnYwggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9EJSLMA0GCSqGSIb3DQEBBQUA" +
            "MIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVyaVNpZ24sIEluYy4xHzAdBgNV" +
            "BAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5BgNVBAsTMlRlcm1zIG9mIHVz" +
            "ZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20vcnBhIChjKTEwMS4wLAYDVQQD" +
            "EyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmluZyAyMDEwIENBMB4XDTE0MTIx" +
            "MTAwMDAwMFoXDTE1MTIyMjIzNTk1OVowgYYxCzAJBgNVBAYTAkpQMQ8wDQYDVQQI" +
            "EwZNaXlhZ2kxGDAWBgNVBAcTD1NlbmRhaSBJenVtaS1rdTEXMBUGA1UEChQOR3Jh" +
            "cGVDaXR5IGluYy4xGjAYBgNVBAsUEVRvb2xzIERldmVsb3BtZW50MRcwFQYDVQQD" +
            "FA5HcmFwZUNpdHkgaW5jLjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEB" +
            "AMEC9splW7KVpAqRB6VVB7XJm8+a60x78HZWNmvAjs/ermp7pbh8M9HYuEVTRj8H" +
            "4baXxFYq4i75e5kNr7s+nGbJ5UfM6CldqbeRsQ4zvRb6npfrtcOBwfYOx0woeYQf" +
            "I6VzLVzhPbGjUDK6qdHZLf/EcvSIKvRbu3ILOE3kuux07gQkb++rrSBUyJKXU8nW" +
            "8c+K+9sfWqHYPb8FF2IazWxhmfIdIoDNKyjr3r/wIn3jQejpqfamiHNsU/O26KS0" +
            "EcvCS5CFOKDT6vvdnAkek3kyLWef+ca/cbFo74vawYGtmw2wzw/hcwlANIQaCAxz" +
            "+5JHQZ3SEg8LLSZ+C8E4T+8CAwEAAaOCAY0wggGJMAkGA1UdEwQCMAAwDgYDVR0P" +
            "AQH/BAQDAgeAMCsGA1UdHwQkMCIwIKAeoByGGmh0dHA6Ly9zZi5zeW1jYi5jb20v" +
            "c2YuY3JsMGYGA1UdIARfMF0wWwYLYIZIAYb4RQEHFwMwTDAjBggrBgEFBQcCARYX" +
            "aHR0cHM6Ly9kLnN5bWNiLmNvbS9jcHMwJQYIKwYBBQUHAgIwGQwXaHR0cHM6Ly9k" +
            "LnN5bWNiLmNvbS9ycGEwEwYDVR0lBAwwCgYIKwYBBQUHAwMwVwYIKwYBBQUHAQEE" +
            "SzBJMB8GCCsGAQUFBzABhhNodHRwOi8vc2Yuc3ltY2QuY29tMCYGCCsGAQUFBzAC" +
            "hhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNydDAfBgNVHSMEGDAWgBTPmanqeyb0" +
            "S8mOj9fwBSbv49KnnTAdBgNVHQ4EFgQUAFrwraXUeDX1hBKoLAUO+FYbjo4wEQYJ" +
            "YIZIAYb4QgEBBAQDAgQQMBYGCisGAQQBgjcCARsECDAGAQEAAQH/MA0GCSqGSIb3" +
            "DQEBBQUAA4IBAQCIwphaN45b5ViKsRfCA6hbVeqMhNCJmL64mqxdYvw3gsF4oOCD" +
            "oiM6kWhy1NoUd2Lpcr9PjfGJ55ZX4sZlqoxeflTpHgnX8MPJuKpDBsk7WkhiEu65" +
            "fBwb+g9wQHMMfgY0gjHIAQ2ZEf2PJ6TTSFcvj24wh73dsyqcmj290fpwDtHaF2jE" +
            "5pq/tQBOJ8vDkN46wt4qMhG6nIpOgc9KngyLLdEO7V34KM1Nb+sN9JkqTWXNoNql" +
            "Of7QjYHwlw7Ku7W3kIGK+f1kP1xqTBpXwsBE5sLlnujP+JAqV8aKlBJDKRI3Ihlr" +
            "G9CJUmqFNhmZ2f5QE5jAvPQeXevLnMYiqJrgMIICtDCCAZygAwIBAgIEDu7u7jAN" +
            "BgkqhkiG9w0BAQUFADAcMRowGAYDVQQDDBFHQy1TVTIxOTAwLTc1NjAxODAeFw0x" +
            "OTA1MDEwMDAwMDBaFw0yNDA1MDEwMDAwMDBaMBwxGjAYBgNVBAMMEUdDLVNVMjE5" +
            "MDAtNzU2MDE4MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAmdoC4O/s" +
            "KWofrdlepzcxhFPsVzJV2KkiqnDjyK0M/xi7fVpCiBtf4hEBxuJNt1MPkOJGI8lR" +
            "jjR5mcruaNAq2kKYcrsh1oKVlAmTXq8bhN+at1eV6yzSScmCmG3sQVy2I011Gj1k" +
            "8a/OhTrKGVoAOXrj9qKmJ9GV724XBvfTxGkjYTbanZE5kz2euhtGejcapIu5yQps" +
            "jEPniJ7GrH+uHVr4QADKhM8+tCKEQod3+xTeXDoW6llcCgjbfamPNt00+Kj3g3Ru" +
            "+GaAcDCOtl1B3g7dewwW9U6l+5NBuKOhXzQW2L54K9NzRLviTZCqb0ltA476m1Q/" +
            "zDXgphGT3rqnGQIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQAncOU0DCBNUHTrc7Fq" +
            "coxWNpIb3UWrQnoYrmsbU8/MNBBucSedJiX01a0+XjX/1H88oC1dfQ7ThTkAf01d" +
            "iKpCRbd9Fvf4SLOKLVCgy/Nis2DA3BdgsKMGj77Vo3kC5By3RLfko5J47CbGwl12" +
            "KQBXIr6iv9NLZ+Zoryk2yuDoeGr5ZfABF7i24vdZy7U0dpjhljwo/v4CKDx4wbD+" +
            "RQpfhtHxYckclfG9Tpvqs8I9zuLX/xzJK7O83D9voIj80z3/YPX9wOhsKirEhdB4" +
            "xp98Pn21mrunRRRk7pgkrMhXv7MdkZklFpGjHdtCFWoKRo6msVsZ0p+Hyylc4Axs" +
            "Aap9";

        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            C1.UWP.LicenseManager.Key = Key;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters
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
                //Associate the frame with a SuspensionManager key                                
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");
                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
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
                rootFrame.Navigate(typeof(GroupedItemsPage), e.Arguments);
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
            throw new Exception(Strings.InitializationException + " " + e.SourcePageType.FullName);
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