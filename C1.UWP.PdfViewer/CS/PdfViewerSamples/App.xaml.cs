using PdfViewerSamples.Common;
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

namespace PdfViewerSamples
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
            "ACgBKAIoB4FQAGQAZgBWAGkAZQB3AGUAcgBTAGEAbQBwAGwAZQBzACtX0Q2Tt+1t" +
            "PPgM5cK00746DR4xXOKnbGdnxh1rc9lcA01PdhZDQRATwKrVf1fVZI0WaIAl+wnR" +
            "DRJL0ExZJ5jyAEy5WZKIflJ7c1pyXgQMN3FDRiHcpzYp/k6kE4jzb23PxEqdpMG4" +
            "YUxeyKK5pBpFtKgTmDeY55KG6TTQBUwKANLLFPmjUnkGQvSfnsSIqcX0TuCWqBmC" +
            "iRQTFVIVTp6+lhj1J/+daaWLlKmIfPPKHk5h5DKEWYn6judCOp+Wpl/wS5Ft1N8C" +
            "iKKzF/4HleHkigDub7J1J/BfJ36xo6KoPcKbCq42LE84l4BgNYYbhZpSWD/xtxnq" +
            "4OPLvpo2zp+O7z8iFwP3Z6h/UB8yPtl3lEC8a9/bXmHbZVNWTCpL8VswqkcDYjNT" +
            "jKRBM3MH1/Qqv4r+Pxr2ralU388b1KAt9iq0RporaDrH7UHZN2JV+W3AxU479bOg" +
            "IhxsXGgbNLTg4lo0iVsB4VRb337jlVR6vb913ujPFeAYg+ca6kw0J89RIDY0iXbQ" +
            "EQkA8cp8waQbhBUZOyLgnqImf9Jk8t2zhLIZA9263HzBbTxquTEOKNs9BUOE74Zm" +
            "/tychcpQI6pcJ0uL2diuNS1/CymcYvPa5myb2iIYG9msdHcJwHhqMlmEyVxvpkNo" +
            "70t7gCv8nMzMWRXKVjPQGKJJgwheRuPEMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW" +
            "2ybGvRCUizANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoT" +
            "DlZlcmlTaWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3Jr" +
            "MTswOQYDVQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24u" +
            "Y29tL3JwYSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNp" +
            "Z25pbmcgMjAxMCBDQTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGG" +
            "MQswCQYDVQQGEwJKUDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkg" +
            "SXp1bWkta3UxFzAVBgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29s" +
            "cyBEZXZlbG9wbWVudDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqG" +
            "SIb3DQEBAQUAA4IBDwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2" +
            "VjZrwI7P3q5qe6W4fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3" +
            "kbEOM70W+p6X67XDgcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7ty" +
            "CzhN5LrsdO4EJG/vq60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso" +
            "696/8CJ940Ho6an2pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3Gx" +
            "aO+L2sGBrZsNsM8P4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGN" +
            "MIIBiTAJBgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAc" +
            "hhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG" +
            "+EUBBxcDMEwwIwYIKwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUG" +
            "CCsGAQUFBwICMBkMF2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoG" +
            "CCsGAQUFBwMDMFcGCCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3Nm" +
            "LnN5bWNkLmNvbTAmBggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5j" +
            "cnQwHwYDVR0jBBgwFoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa" +
            "8K2l1Hg19YQSqCwFDvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3" +
            "AgEbBAgwBgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOo" +
            "W1XqjITQiZi+uJqsXWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqM" +
            "Xn5U6R4J1/DDybiqQwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hX" +
            "L49uMIe93bMqnJo9vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4M" +
            "iy3RDu1d+CjNTW/rDfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LA" +
            "RObC5Z7oz/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia" +
            "4DCCAsQwggGsoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZ" +
            "R0MtVVdQIEludGVybmFsIERldmVsb3BlcjAeFw0xNzAxMDEwOTIwNTZaFw0zNzEy" +
            "MzEwOTIwNTZaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIw" +
            "ggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCAuoFSj02+4grW7qr+pEKH" +
            "EisjmhgsknoLPLBdB8JvlhKazzog9lfX4l1QE2t2SxjVLkYNIotUUZ2YxCj4XobS" +
            "1Fbd8AypKayxV/FU/X+t/73WDco3/X0Q5vA1kbhXjB1pdabYsWQWTUxrZJiUSSJ1" +
            "HRi2NpDT3NcQhBGGjLH/yhdleNcEhUAqoDPdfAFWjTp5prCxTwNiGSqzgw0gHqAD" +
            "gyKqus/1kPTg2VDh3CNcQhGXftTk+9/kj2lImblsWKsytqXT+R/paffFceTAYWel" +
            "kZAI+vPSKkYfF6H0frfilfDM/SW8A2mYy7Xdr+gd35PC9zUerLDp22lO0uLIY09f" +
            "AgMBAAEwDQYJKoZIhvcNAQEFBQADggEBAGuARwVkCAK40G2E6j3yspAtNWMB1OxE" +
            "Y+w9hwT6OBxtloM5gw46mzwAirS6qzipxn2Uwo+cVFW6qaeKBC9O4ojfRvbUch5S" +
            "4NsL1IHxWJUqVdjQQseJ7CIsxzse+B/lqPi7WBtrK7mAeWasbxcLzTXddSoReYPB" +
            "Ud/itOU0GPYTe7ZuFHnF/D7MEIU1msijbrOX5/un5dIx5eRujga5c+NM+IzCue/3" +
            "16Bc5+i6WBQz1pwO8D7uttEdQcrgsbfigIkpveI837J7qMxPW7XnSSc51+9KbmJb" +
            "Ve3ASGc0IslLMiZouTyBNYH8pjSFBxWhr7hdfe2MHUn01XJ5NPs2sZ8=";
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
