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

using AnimationDemo.Common;

namespace AnimationDemo
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
            "ACIBIgIiB3tBAG4AaQBtAGEAdABpAG8AbgBEAGUAbQBvAITSi2OGWP6hFnC4CRJZ" +
            "iMXtvh80lB+iDwio2g3A0gOwJ7rQx3eb9ogVRUxUWEUDfjDcZHV9keCDa2WXBVoT" +
            "caviPk7q9E8hM5CG+41b0oHOw61/WSyn+6QdHcVy0tUJERZrWGyogScXmaFMrbPo" +
            "qNAeBfOssZWBFZx/81hVh8+k1sgfVteamChBpJCwxSAyhDhrlVPTVu4hLqWsknut" +
            "+qdJUYjmrjQSA85zRWrTu2ZedqVp4lp9ziZbKHEeT2UqQwE/qpQrabnvaK53IMuS" +
            "ohHnwHKCPDvtoS58/kSubYW6yMTy59DBqxu70Ow8DIJlAh3EXqvhPGUzMdebqrr5" +
            "bh6Ser/xJILcvU0maH6lz2s93Yxi2Ncg0+0wOeKoJL1u0nv3mN/YLPZ52Qvv0fIp" +
            "mwS8GMJJpENAPxBCkcaSeNP/NVi1EUXK9g/4QQYThBBt6XFBPl1UQ/GhExg9qqtq" +
            "+GKgy5iRcwawXDeI0eyEfyUOT23/bt7tqqLHNVOhWxSNgJLdbd25jLWoDQ3U+1yG" +
            "Y2BM5bk9gVc1GU+mcmqiVOFQ8q+zLwgaYc+aVDdERmeLID6GUZ9+iEIGoNI2U2Lv" +
            "BJpRG8Gz0zIyppSg1/Pru5CJGSNxVnjComcTI6vX0w+G7IR9q+b4JMwfXvqdVp9z" +
            "kEbo/3ZE++yUBY8NEh8yPU7ZMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCU" +
            "izANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlT" +
            "aWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYD" +
            "VQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3Jw" +
            "YSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcg" +
            "MjAxMCBDQTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYD" +
            "VQQGEwJKUDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkt" +
            "a3UxFzAVBgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZl" +
            "bG9wbWVudDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEB" +
            "AQUAA4IBDwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P" +
            "3q5qe6W4fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W" +
            "+p6X67XDgcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5Lrs" +
            "dO4EJG/vq60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ9" +
            "40Ho6an2pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGB" +
            "rZsNsM8P4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJ" +
            "BgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRw" +
            "Oi8vc2Yuc3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcD" +
            "MEwwIwYIKwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUF" +
            "BwICMBkMF2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUF" +
            "BwMDMFcGCCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNk" +
            "LmNvbTAmBggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYD" +
            "VR0jBBgwFoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg1" +
            "9YQSqCwFDvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgw" +
            "BgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQ" +
            "iZi+uJqsXWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J" +
            "1/DDybiqQwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe9" +
            "3bMqnJo9vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d" +
            "+CjNTW/rDfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7o" +
            "z/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsQw" +
            "ggGsoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZR0MtVVdQ" +
            "IEludGVybmFsIERldmVsb3BlcjAeFw0xODA5MDYxMjA0MTFaFw0yODA5MDYxMjA0" +
            "MTFaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0G" +
            "CSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQC2UAjsskghPa9c6efPYslc5sNzTW9i" +
            "jB0kO8KT/sTe9kXQWLJTNN+4C1lAmkIVoTrVRPY6z1Lvh2g+n7j6avxi9CUqc5dw" +
            "D88FOGMstGGeXK8/pt5O5w/dyVV0fzpK939c7ohhSwl8Vs2m+MG/RvxzjB9kHals" +
            "zg5LP6xCtkegC3Fgn/nP42UTwlcXqZCLoSivtZqvHDDnX6XMKoGOwE2N8gKx39XR" +
            "VkAI2H1pI65bNSZfGgrCkNVuqOVOH632aou4WUj/QasbyxfWj2Q4Zj5PZPHnM9Zd" +
            "r7UcRghY/8JuD/w0t69WpLwNBVFom8clZLPjvcQbim9pza9od0FCu8hnAgMBAAEw" +
            "DQYJKoZIhvcNAQEFBQADggEBACzXeGLQ1JGBuYuNWSiC5+QASlIBDx4p/SUgQSkG" +
            "Ih2SVmllhpwIVJg5BdExezwintN6EcFPqIlEtj2fgcxwpFnlFN7iKMnv2eKVlBQj" +
            "24NRKPMe01RJfAWQVNKif9hQIHvzxEvm1ZwAb6pM7UYDsRVsoBu3d96rNKaqiODL" +
            "+pn4xJyCch56V002QiQWnN3D8MZbE+8LHrNHabOjj0SEdmx7SJEmRUKeMaSf7GYB" +
            "4aANZgwZF5u2OPBI+k+nB1CvDuGgSco3p0AhGQ8ljOqUObsFrfJLxYNjU33axFLp" +
            "PExh6ttKqQk0OimDaQ+xeREp7w7ZufXuyH7gzebAUd2mTsY=";
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
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
