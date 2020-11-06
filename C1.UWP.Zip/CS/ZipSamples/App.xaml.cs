using ZipSamples.Common;
using ZipSamples;
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

namespace ZipSamples
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
            "ABwBHAIcB3VaAGkAcABTAGEAbQBwAGwAZQBzABQFqODRFQovcyFshGDhnzhNp1fu" +
            "nfFwR7ZXrZDQG/DDxK7utCc2yLjHQ7pAv15Jh29TCrdDdtna3hdFQUyZlXLUIewL" +
            "MS3Il+x4EGVeeTEC849ErHFNo0WgeRs9wrI0hr3+n9NQTCTykwUs4qTWJ2CfRSfD" +
            "Z5vmUqUKUbBIY/xzF9otWyU6j/DdLWI2IXAKuT4HZ2IKzfcHHiDBhZ443HFc05Fi" +
            "W5E/Eyune4eJ5NEXIwzZkyL0C4RhY0kw17NxST341rCrAHp+K+mxUp4i25cB//gs" +
            "rNyPvFC7IM9985bX4cjfw4vuun3/7V9K/M0Q1V4HrBpPyFBr92TiBZ3zHou+4oVq" +
            "Z1OE5fV1xz8y7PuqMzrT7gCMs7PI4V54W2IJtl3ssQeuOG7bDkeaU6p2oS3JgX4g" +
            "nRi/1hL/USMynYmzMs+6ohuTUzSbVUWKwLWqQw/pf1n1Sks6aVivk24rOwepPfWL" +
            "zObjkbiVkKBOacK3urpuK6g5uydCQEWuYPbaCRcw0dKV2NL1QrU3I3fFeqdCsq9k" +
            "5uw0d3fumUqaQ7pHnoEkW9yKrEDdwuSirfjTKNTwUfy19irllHcM6WSLhT4poq4t" +
            "4/6k2aHUiFo8Dgrn0lynOoXfMvEe+1Zmj373XstvSu+78eVSYiX2UKV4r86J0mAC" +
            "cmkh9cfJdf9HLFm8MIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkq" +
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
            "DQEBAQUAA4IBDwAwggEKAoIBAQCK5HINhoV8nyPwtFR/ev+jRcJBy9tMVmEwU0NU" +
            "AXuo3lboQbZxRpqu9oTufeXE7GJPKz0wXzCduCliXb3YfJ+64iJcCATJEa++/zh0" +
            "xQOIGKP3Qw7flCfI1wiqUwbB6SdsseIrxX9waE04Lr6toLhOP5oz7einRAwL1njG" +
            "Va0fpLRHw3EWfSLXEeNLjSJx+RvCt9X563td8UbFFPmF05wOzkHXf18mAU3BEEh+" +
            "n20vxRaLbKiq9NOF1q3ETYxYQ+bwd2jicL0Dyc35a7AKfzEjD2Bq7MigwS6BvWQN" +
            "ixQ61UhUGMU+qd2UPrlrm2ES6SyrAzxl4wlJPJFybzDQkKPpAgMBAAEwDQYJKoZI" +
            "hvcNAQEFBQADggEBAFEXy+7Jq5DEQAMg1Lu3CE2SMEJJGcbg1KCuSOUHZoyJbSKl" +
            "A8VC0Vxw6sLXQCcqlTI7sqO2yeos9UsaWf1EviiIDc8ehXy0Yotu1llQ3ewn0JRY" +
            "yFEMQO+0TQB5C2Y2UhOhNkgerYWKHSsc8kgf4cdeoSy/F8D7jyYLRDsvEcPRtuz7" +
            "YntowDhvuMBuSi7ZI7G+h8JQh5xIzgGlsRliiOzAkg7HndkN15YApBahY21sm9HM" +
            "6Bbm7UmKwW3+ZSTFa3ya7NuIbvRFbKMUXOYUDEwyM93lTpMrYoGziuwWUMcT6AiO" +
            "rOWSV5ZZAO36wolmlyzbgMjtY8NrMHCmADabMTA=";
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
