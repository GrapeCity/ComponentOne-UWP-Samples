using PdfSamples.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace PdfSamples
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
            "ABwBHAIcB3VQAGQAZgBTAGEAbQBwAGwAZQBzAGQHkdeiX+TukPyMA4W/Oc4CKbPJ" +
            "6Qp+QH+nO6x4rFLABvN851LJDkpRcfSnOW3/PseOLL/AxMvhx3p5yYYHTLJ1cB+h" +
            "jiCfBCynyahupAhhK5ZTF099c96CU/8Fv0pWj5qZ1gWXgKzFqqvwO1pCfKDomS6t" +
            "aM7/51X3XrKHxBU8MM20/TEHktNlKnY/pmNJx72Y5PaVdT3AfnWMBCNOa3eXaS9p" +
            "H2NBbrdDTmcJnWE2fA9b6IwHgP1xXC4Xy4adxErK3DTTWO0bOrwmPRnfdrRwWD+C" +
            "lHQIO4S51WMJPx82+QzrudNPgaoi4COqOMWMq20EeEh/0w5HS1yGgcMiGVw3nxQe" +
            "Q5lBNi+1JwPFLOohCplJk97TtEmNhx5J77I8GXDF9LSegVezr/GNZNKNXAG1/l4k" +
            "MoUT+35Wqy/1ReXov3BU/URT3xiqpLgN/qYTWAP/gYznskDqmVSp3B63oU0RxoK/" +
            "9GQje73JTx4FTjfylj5JwX9olaqm785nbA9M1Yney9oyfOKu6MOPpIZtkhmwxFss" +
            "GWXuaxf7FyfbXbrpZDXP0Ue1e7fGJaxlVbQjPxpVrj7wSpTwjEtXdIbM0GG49O/p" +
            "CPI2re/+guHxz4M7GwQrNBz7EJIWNcivA16I1jqYvg5BM5prHjt4tPVLwFGKu8F+" +
            "44E5qL3xXub09HqvMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkq" +
            "hkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlTaWduLCBJ" +
            "bmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYDVQQLEzJU" +
            "ZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYSAoYykx" +
            "MDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcgMjAxMCBD" +
            "QTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYDVQQGEwJK" +
            "UDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkta3UxFzAV" +
            "BgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZlbG9wbWVu" +
            "dDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEBAQUAA4IB" +
            "DwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P3q5qe6W4" +
            "fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W+p6X67XD" +
            "gcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5LrsdO4EJG/v" +
            "q60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ940Ho6an2" +
            "pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGBrZsNsM8P" +
            "4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJBgNVHRME" +
            "AjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRwOi8vc2Yu" +
            "c3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcDMEwwIwYI" +
            "KwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUFBwICMBkM" +
            "F2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUFBwMDMFcG" +
            "CCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNkLmNvbTAm" +
            "BggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYDVR0jBBgw" +
            "FoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg19YQSqCwF" +
            "DvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgwBgEBAAEB" +
            "/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQiZi+uJqs" +
            "XWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J1/DDybiq" +
            "QwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe93bMqnJo9" +
            "vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d+CjNTW/r" +
            "DfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7oz/iQKlfG" +
            "ipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsQwggGsoAMC" +
            "AQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZR0MtVVdQIEludGVy" +
            "bmFsIERldmVsb3BlcjAeFw0xNzAxMDEwOTIwNTZaFw0zNzEyMzEwOTIwNTZaMCQx" +
            "IjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0GCSqGSIb3" +
            "DQEBAQUAA4IBDwAwggEKAoIBAQCOmkpnV5Jvqj7wxRae/kYEV5r8vnY73BjCOqL/" +
            "va0DAMPNXDv3xTC774DvhBOvEpmbAhbd2mHq96NoHID1Ab733PE6tFc3cOGJYgPp" +
            "Dgd9Re5doZ1fTq/w052I0AAi4NRuBf0jxWOyBE5q4CLGYRmdp/2V0qMD3WUcpb3Y" +
            "cJxSKD0YQ11ANu5Dv343nggcH6bKJWUP1TAJfQ8+cdL0bNxrVi5rG2osnZFSSaki" +
            "ZVGRCQ25cr6X4dVPBogZ/JR55ETnFUQbBlEsSfzQkWIKkZkplJChruuKsC+E1cZN" +
            "z32BhFJYpjPJPez2LIMGRFOxNssuLvv4pNF8XGB8A5+wjZrnAgMBAAEwDQYJKoZI" +
            "hvcNAQEFBQADggEBAC0VUe4YASCSE2cbebwOqq/l65MjNliEVJT6XUHnrY1+qHDz" +
            "09DUQvMPPcjW6pIkPpmIl9CClxEhOWdc72IrLY8WjtleU2TN6+LdnlpWnaXBDd/X" +
            "wYy6Wp0Zk9tsdsYiBYNw+MOlF9C6Bw1FTGL8SrReTgFlgHvAXl4Xln35CME6zhhz" +
            "M+yF7kLx+AyMx75WjPhbv7wsRrGpWFzPrGcpYbEWBJLijkNS6mGSLQMG3oA4x7h7" +
            "MECBJ8rHI9ReCMov9wKuUhUI8ctem1NjOsMcGiZBaJWyHiILHFIS5C7xZHspx+1L" +
            "fs9vPe2zfkH4qSLw1bYrGyrojOZBsMamDWc7scI=";
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
