using FlexChartExplorer.Common;
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

namespace FlexChartExplorer
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
            "ACoBKgIqB4NGAGwAZQB4AEMAaABhAHIAdABFAHgAcABsAG8AcgBlAHIABJxsZQQQ" +
            "vrrhPxsHX46PtlxGN92Z5rO8+C6o/KIYi/ZdZMeLLEzy9GNj4s9VJ+XGc1eg4ATf" +
            "XUFgdx24R9uLm32gbHFV5AJwD0ytePlpZD8vEjwbAGrjGqlrZg1BQVqwBnlgo+ZN" +
            "2NWniZ9vRmhAQCdyyY9cUG4hN0sbN7rJOmBoD+UDENZ7LTHKL5KMBdPoNBpSqnkv" +
            "dx5/1Hx2XLRD6XQUdMwBXsxkSiYkeiPOxkChU7p6ApbsM+M4l/ork2MqnJrdqZF3" +
            "G+BwzDPiioMJYKl736ha1aOCzuFPv3YShRWNzquIfAhoqr5NBkoOzLh4RDs0kNpa" +
            "BKxT0Cc8DOjZ04oxNyv1DGPyj6awuoU0xhRcU6o3yYj0vsCUG4TLxbL/qqQego2K" +
            "sML6bk/mlZO5kaELYeXfQMDy+eXUuxz0quxAUsae8Q4eHQZVkqBK4XZWx0iZghTC" +
            "K4Qq5kMNjaN2SQidn8PBYLFN6GnQZ8eptcx5WH9MmuY/dzKDApdupyJKTHEkNhLW" +
            "i3LmaTlJfaTfM05B1HsnCNrALZR17ungOVYeqjuXHEWiUnyQtdcoHaJQ0tS90BHk" +
            "OkwxpRcnnRAlhuICqIjPjqD3YeQR/VvFs8KJQFdcH9Xn33HpytETGTGc2k8C5rvC" +
            "230rG7hFufdJk9oOWFcjbrp+Q9H1q1f9qwIwggVVMIIEPaADAgECAhBBA3jSJjZZ" +
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
            "cjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAJmQrUZf+Waf6cjl2Nn5" +
            "MloyNQLsNQo53GB0WRoiG+qz1AE8KqdXr2Y6Q5gCcIinJGgRM1Rnh88gcqlt/Ibq" +
            "E4YLxPyo3mLAlvflxzSUKh0Hh5Y13n2Xcw9n0OnRaySnfYIXkUdcVuoPp+Krgb0T" +
            "WG88XcBsCDz8UvN8xdGpJ3vP8qqa08F35JMULNrMPQH+MZYij0s2NEi0N6DL2FIZ" +
            "Qxng6gUSWUuqZDpwD6nw6baz5RTVA6hg2bdgl8CLn2CefdYFYc9JHTe1O0cN8XQH" +
            "yRQAnD+Ww42d2DIr3Gc2DPc50fiTuT/IMmy/lQMiu3sKjM6HQCgw3UhBKtNMZhPc" +
            "GAUCAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAUOo0OzeKiXkbHtkM8bHAbuNWrmtc" +
            "kWQw4foRH/Tl2G3wu0h4cQjRvVlkaZ3lzDC5NX7Nmnyq31DIkqb2NyYNwdfWV8Hg" +
            "ScAKz/Q5vAL875nxKywBVvTsBPgFy18wWy3MJi2ughigGhIswco0Jztp4df6rOHw" +
            "2oAxUbee0XD6gnX0YJ5eHxKtYU9S82XgW29CRaKB0Hk+ZfoTvzhI4h7xwErl+aPI" +
            "f2RCSmO0KqUyD+KYT/00MOx2doObqRHw+S3Ndn9bFgUbCaZYhUskoq58f1z2kRts" +
            "SSkB0UKgcDSGZT/Wt1wFRB01ZlilWRBdbinDO7OohPU2RXkzJ0EuGnrrGw==";
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
