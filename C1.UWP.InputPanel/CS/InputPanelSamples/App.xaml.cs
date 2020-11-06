using InputPanelSamples.Common;
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

namespace InputPanelSamples
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
            "ACoBKgIqB4NJAG4AcAB1AHQAUABhAG4AZQBsAFMAYQBtAHAAbABlAHMAtGwu2SxQ" +
            "MeYvvi2+HfCgK+AIK8lJzhr0JgTvnbcn2uAB1lLKAZKzXh9eXMA0XpiBckpf6vbv" +
            "XDOb9ppn6O47aWfXKh8AR9yGgx5cdtfzu271onncKSkCwFH0iPFCJE86hgToISBV" +
            "v3RZcOD2/u2pqsywwr+XFr6RE2PDIdUnBcIQe7sB6Dcgah4xcMcQDNobKMNc239R" +
            "yJbk4/M0pamXvbgpEFnWhg+7O1Ksa8pOGx4CClFWYY76nVQnFKmIRdsze82m8N3N" +
            "yeIUFiB/ZHVAOoL0AoA7ismozu70NqgLH72m2E6JVHXrJo+qSUe84HKtY6toQeLr" +
            "hApFqisrnO7o2q/DbT03WCsovkOwFRKLHMw0ZEVyCTLZaAn+8SKs92xMk3vzYt2/" +
            "zqquTJ6Sw7j1hfHsrZiD3RTjpJRJSaG52c8CeSF4brPOBi4ifVovQAqiufGfL2PH" +
            "0L9DAKHQhv2N5KqkzBgWBo6BdJdEwc2KKc7NDDgehSV7x0cdSlTvqBVZYtN41Gp8" +
            "4YgjUpP6eJMhH49miFd36ZghD1o3bcykbtHXC6KVuWUpAzbyeQtm9fdsgvwQ43Xb" +
            "hlMis+9QcvQMUrnDPYhXx5ZGkmOSzvQeTWRljhR7ubhyyvZvmBtggIVpqhGpMR60" +
            "8E8Fo2Ldb0u8tzw/T7R3B5VHyXbASefTMSkwggVVMIIEPaADAgECAhBBA3jSJjZZ" +
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
            "cjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBANbx2FIXGaryeQKTo+ub" +
            "Pw3V4iJA//EKhlfJS9YEwU7w5j9D4RQvrqf/Nsg+ijlEJ/DyA3ItZsxAYrgOB5Ij" +
            "6KsK/b45k3DAzBUpcOmwFPZmtrpm0nWu+JETsS+xxvAxh1/Py3k1EtbzL4hHbm3p" +
            "qYQh/U/28m/vDdg2iIDpWy2E/A6giYyyqAKa+W/9hfrhtA5NkNvDuKXAQ0TXf2DU" +
            "dXRSgRtHOS6y9f3kYYQ0SjfjESv9UyAnTQ3kOM1emxUROCS5DENS18hEbNkcUJUI" +
            "KLVKD0/ETOezrSNBsoRVbrsObZaFhqRXrrQcKRuSlnpuMNmVRXqDwPD6snu97xOm" +
            "weECAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAE4pWUUIH7zhuumBeiJRJx+O+OwxG" +
            "+T3mQ+RYncxiOpaEOuZF2yuHyUv6zIr5pSPpwFrFV3CJmblgum6Lhs2jLWny/nRQ" +
            "k1GzpWzDII1R73znoBmv8uKlJSiurMsaDLUQKqk10jcwlwL7I1JJXrsPzA0ssd4l" +
            "5091mz/Z20yssVMMh1GBNpLlHpjyoivuyQrhLJmmXGx7fTUq1LHU5O2qe3ycvQir" +
            "Bh9meosT39Q12c/fNZNILb0MKCzTroWNz6Wbf4ub9H1cK4FHt8Z/idHdAlpNGIHF" +
            "5r473Ng6UM9057fyydc/S/zOQqNuYbxKGkHs53J6WA0RCDIUJe9NSppBsQ==";
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
