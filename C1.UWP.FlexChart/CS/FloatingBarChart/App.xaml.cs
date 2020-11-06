using FloatingBarChart.Common;
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

namespace FloatingBarChart
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
                "ACgBKAIoB4FGAGwAbwBhAHQAaQBuAGcAQgBhAHIAQwBoAGEAcgB0AAvKkFKBZ07b" +
            "7CIYWRxz9BGh+98So86KeLr9ywLgEbcayOq/KyCHVFa3RMqh4yCCVWPG62HEGUXz" +
            "SEBDNrAwMGhTXVBJ+NGXNQG8C3zVdOmyoKOO2Kb2DIO5miz0pktlS+el/SWlaDrn" +
            "Od29DRKW7wdjpPFk8/W4Yr8jpaI2POTa42rnlLGUakUQLXx1xsgx7yCEyWDUyOkw" +
            "SBtCROznmG0HHIoFwa350Wp58stwt0Z6LviutjpQj7kimIxh2FT/EJhtU6PY/edD" +
            "tOePbBIWxXq779pRoPKGJuBDJ6DzlA8fZfcAEw877lQKR66IrogBH9Cgt6LtAT4a" +
            "+p5oAoxnzpRRVBWrRfHiuRTOr1MY6ChtyK3yam2p7XBFq46BFSNtJXTt4ECkxuJt" +
            "SqSxaDac0h2UeSmnoYQVTrZvPXbo+q/y4PftBRZVRs9lfv8kvekbOlhoZwSky9zw" +
            "H4W7rOgUJ4R3D0hKi92IcKspySdH/NvhWuPf6k/svNZwRJFDge7K/QuIk7Sbvmqf" +
            "Wev39RmkC6oUOVpdA5jAfVmjQjXnSEeyk5SVdfkTQH1XEq/eW+6ktt7dQTJ4FNvM" +
            "BYMZg00z5X/tFZsOjqZfMU71eR0OrG2cgFyasIf+imeICBcWv04fEnZZHXevf/oJ" +
            "OTvqEZ7OR0tyKhBzVgGI/yxZ6SkMUo6PMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW" +
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
            "R0MtVVdQIEludGVybmFsIERldmVsb3BlcjAeFw0xNzExMDkxMzM3MTVaFw0zNzEx" +
            "MDkxMzM3MTVaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIw" +
            "ggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCGSvX90UbiFocihLMT6v91" +
            "Y6JCuhFrx105V2kVcaMUoQXYsEgK01T3BPsQwI5LAjFR/OQuEyUU6jnk0NwC5v1y" +
            "QZngpSEh1QxrafcRdy+0s3kFOBenUVz6UKRcSr938w/beXbvrk1cKd9y570L4KGP" +
            "FzaeRalTwKqpcq/LOPs5kBrYs+25m0+9Mr8ZQZncM3VDfZ/PonWUyG3rtlPnrOfI" +
            "LoytSmZ6D2vwuZyzG05INByCebKAmA/h7HjD2JQt61+/pydVjQAE3+CvjEni7NEG" +
            "xIkR6ZNPN/mHjNrvD/zJ0JIzpapg2zw56fixyxxScX3rNP6Pj+mnPUb9nkT4OAnz" +
            "AgMBAAEwDQYJKoZIhvcNAQEFBQADggEBAIGRwdStCHo1u8KVCqOvexeWyrBcF2mf" +
            "wTgp89cz+JXMT6kyeG4oE/CFkhkW1nyeRGglmA/1mTUnZuNiFyOMreA5vNhoYiBV" +
            "D+B+r/oY2B+xcqoro3n2Lm7kbpGQLW7Zyby38CctFcrsJ9EKiGcLAqdBFD23zgWo" +
            "6JCZkPiLTnTR21VOmh4ZI6podIghbDMKF+UA0ip0CzJW9NsLU6wiRkkiNIA4TRuM" +
            "PSEvaL0brO57iLSsS3UAUm+p6oDcfUqXKm8HSuylq0Ib5VHw8or0YojDUhQ+vCeT" +
            "xSF/iZopLB+u9KG35YdI+E6BkpF+7D2tsti8pmPgtgkvN2Nh8Fvwp9A=";
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
