using ExpressionEditorSamples.Common;
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

namespace ExpressionEditorSamples
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
            "ADYBNgI2B49FAHgAcAByAGUAcwBzAGkAbwBuAEUAZABpAHQAbwByAFMAYQBtAHAA" +
            "bABlAHMAOSAmZcamx+H4p9utqBQwLT8Z8TAwEXkLJyMB7mb6zi2/d6w+UgLoPKx7" +
            "SVFrnCAQhdQG4TAKg5YhyolTE0FW5g9rDvbQETU+NJZLd8FHa0UTuLxrX6SDKUKL" +
            "E3mFXePlI0/B7xU2EWVY1xrxFRGaA9AzgOkGE9d+PsBOqiEQcCec0mNesR7eXlFh" +
            "mx/7mUaT9ttBLVOkbbenAEKJkmAq6HQquHhWk5h3ftAJ3XGWesBVy0rvtHNygaP6" +
            "KEc5yjDoY/fFDySu+gt1m0QkfYrkf1mj2r8SVhI0np9K5YST1gzo+8DZqN8S7d3a" +
            "LbAxkJhBh/3UURH1l/gTJm3RRgiDU1JcIiPXB4VyN3OR8IvFJuPaR6bZN00oSSSq" +
            "n4O4QW6h4nMMJ3t+0raF+36XCUW9VruS1X3zARbfe9ogw740ql09Ca0xV6hfe3qc" +
            "j12N0Xi779Z8kSXhzbhrqDMd8z0igpUVNvvgeTlLMfOPPHrDtd0QZl+EvPo2ymkT" +
            "dabsyF8UgJIdBu1ythrKNuuddBJ+bN8I6j0p7CF/NAC5lVjtFbcn3gUYkGxDyjEj" +
            "JWmSxdIjF+t1s4bAzse9ueCIVBF3YtvKU/IqzmTNL9loNpzyBl/07n2Cn10FlxPj" +
            "JC+7TPAvNJYxbcGWXc1E2X2Yw3BAZ8rbEd1c50q2NEKnHn1KM+swggVVMIIEPaAD" +
            "AgECAhBBA3jSJjZZehbbJsa9EJSLMA0GCSqGSIb3DQEBBQUAMIG0MQswCQYDVQQG" +
            "EwJVUzEXMBUGA1UEChMOVmVyaVNpZ24sIEluYy4xHzAdBgNVBAsTFlZlcmlTaWdu" +
            "IFRydXN0IE5ldHdvcmsxOzA5BgNVBAsTMlRlcm1zIG9mIHVzZSBhdCBodHRwczov" +
            "L3d3dy52ZXJpc2lnbi5jb20vcnBhIChjKTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBD" +
            "bGFzcyAzIENvZGUgU2lnbmluZyAyMDEwIENBMB4XDTE0MTIxMTAwMDAwMFoXDTE1" +
            "MTIyMjIzNTk1OVowgYYxCzAJBgNVBAYTAkpQMQ8wDQYDVQQIEwZNaXlhZ2kxGDAW" +
            "BgNVBAcTD1NlbmRhaSBJenVtaS1rdTEXMBUGA1UEChQOR3JhcGVDaXR5IGluYy4x" +
            "GjAYBgNVBAsUEVRvb2xzIERldmVsb3BtZW50MRcwFQYDVQQDFA5HcmFwZUNpdHkg" +
            "aW5jLjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAMEC9splW7KVpAqR" +
            "B6VVB7XJm8+a60x78HZWNmvAjs/ermp7pbh8M9HYuEVTRj8H4baXxFYq4i75e5kN" +
            "r7s+nGbJ5UfM6CldqbeRsQ4zvRb6npfrtcOBwfYOx0woeYQfI6VzLVzhPbGjUDK6" +
            "qdHZLf/EcvSIKvRbu3ILOE3kuux07gQkb++rrSBUyJKXU8nW8c+K+9sfWqHYPb8F" +
            "F2IazWxhmfIdIoDNKyjr3r/wIn3jQejpqfamiHNsU/O26KS0EcvCS5CFOKDT6vvd" +
            "nAkek3kyLWef+ca/cbFo74vawYGtmw2wzw/hcwlANIQaCAxz+5JHQZ3SEg8LLSZ+" +
            "C8E4T+8CAwEAAaOCAY0wggGJMAkGA1UdEwQCMAAwDgYDVR0PAQH/BAQDAgeAMCsG" +
            "A1UdHwQkMCIwIKAeoByGGmh0dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3JsMGYGA1Ud" +
            "IARfMF0wWwYLYIZIAYb4RQEHFwMwTDAjBggrBgEFBQcCARYXaHR0cHM6Ly9kLnN5" +
            "bWNiLmNvbS9jcHMwJQYIKwYBBQUHAgIwGQwXaHR0cHM6Ly9kLnN5bWNiLmNvbS9y" +
            "cGEwEwYDVR0lBAwwCgYIKwYBBQUHAwMwVwYIKwYBBQUHAQEESzBJMB8GCCsGAQUF" +
            "BzABhhNodHRwOi8vc2Yuc3ltY2QuY29tMCYGCCsGAQUFBzAChhpodHRwOi8vc2Yu" +
            "c3ltY2IuY29tL3NmLmNydDAfBgNVHSMEGDAWgBTPmanqeyb0S8mOj9fwBSbv49Kn" +
            "nTAdBgNVHQ4EFgQUAFrwraXUeDX1hBKoLAUO+FYbjo4wEQYJYIZIAYb4QgEBBAQD" +
            "AgQQMBYGCisGAQQBgjcCARsECDAGAQEAAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCI" +
            "wphaN45b5ViKsRfCA6hbVeqMhNCJmL64mqxdYvw3gsF4oOCDoiM6kWhy1NoUd2Lp" +
            "cr9PjfGJ55ZX4sZlqoxeflTpHgnX8MPJuKpDBsk7WkhiEu65fBwb+g9wQHMMfgY0" +
            "gjHIAQ2ZEf2PJ6TTSFcvj24wh73dsyqcmj290fpwDtHaF2jE5pq/tQBOJ8vDkN46" +
            "wt4qMhG6nIpOgc9KngyLLdEO7V34KM1Nb+sN9JkqTWXNoNqlOf7QjYHwlw7Ku7W3" +
            "kIGK+f1kP1xqTBpXwsBE5sLlnujP+JAqV8aKlBJDKRI3IhlrG9CJUmqFNhmZ2f5Q" +
            "E5jAvPQeXevLnMYiqJrgMIICxDCCAaygAwIBAgIEDu7u7jANBgkqhkiG9w0BAQUF" +
            "ADAkMSIwIAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxvcGVyMB4XDTE3MDgx" +
            "NzE0NTEyMVoXDTM3MTIzMTE0NTEyMVowJDEiMCAGA1UEAwwZR0MtVVdQIEludGVy" +
            "bmFsIERldmVsb3BlcjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKA5" +
            "3yM3z7hgncoFgvlVPeUOAyGzt2vYqD+wt2WVMHnA/quJylYR3JMYOLHvYbUmTwV+" +
            "H8vJlMiDfypiiGf6mTctGIxAX5zOkOlvomZ3IE5U5COv8ptSSzaUyQe1bOY/yicK" +
            "eZhUCdGcNC/Yt8SKv69kkkOaQ9AksJck7W4BBm9/g0/gyExfAHpyBH/5jhaQM43+" +
            "S8SM4QNHMEjDBv2Na9QwNh+274hiscPCVVqATDQ3mpAQb9dcMIshUCzRQag4HMHe" +
            "myPcixjWkaECADpaMZf8WRt9Q4QKqa3h6woL9UYcRtzhv2hfe2EVL0tbQf2YE0Me" +
            "Sz8VblECEFugcCQjEgkCAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAlp8uOV5NbZmK" +
            "leMI5gcphoeZrrBK+xyheK0BvAexGtUXO7oJWHSsR1S1yFIb5MeEDgEvOaUWVFJD" +
            "zholtPQqWKUTBJkKDzjVjXD7APryM8+piIk35rdH46HeW9sXSItq/mTuEvhiDpPV" +
            "/wnmEhEXaq94p4w4V3Q6svKSZOBpjoRMvGPVlfG+sLPI+Xficj5vlN5EBoSRi8zj" +
            "SA9TFt/0WN6WmwzlZQHjXfZGeVS4WQg4uz/n+eQ/xsucm4qzClZY9SrqFJahcS3J" +
            "vj1ZcbGhF4HbT1sQxvcXYgBeWGtssN+QuxegkTBS7e/EZjYYI2NChJoUZe7u/1LE" +
            "1fHNXujZiQ==";
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
