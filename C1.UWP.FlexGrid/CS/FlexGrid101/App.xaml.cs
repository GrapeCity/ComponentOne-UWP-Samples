using FlexGrid101.Common;
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

namespace FlexGrid101
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
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            C1.UWP.LicenseManager.Key =
            "AB4BHgIeB3dGAGwAZQB4AEcAcgBpAGQAMQAwADEAQC+mx/Rl57z5OiuSYJ31SJE9" +
            "CYjfFvG858UlM0jHiGDntBXoCaJ2uglpVqg0XGuy4PoF8H37RhtLclqFeMiT+Knn" +
            "Gr779DvxdRtLojMKrUSfViY5qlSwkirr+yUnGbEaCs6VMPitlvA/nDOdZ1aCIREb" +
            "VU9BjM3QmF2R/cp0KCrTQITEtrLwiu9887SrAGL5w6hDnmQcw3WdZ/DTYyl1wx6V" +
            "cyiSySfjycqAtOMJBAvcs1E223MkceWVgg6WOzN9hmj6Eba58fb7lC4WvCyBeybC" +
            "zS0cmI51qK1h0ThJGYsS0EyKGbnw97GE6RuIdNtPzpr19iOKXpOt+BDajcXzAL95" +
            "Id2uIs7zlVaNjNjxE4f2fyUCX9JQ0q7ycFUdhhNc+tlcpgEKffs98Q9sYT6dP4I2" +
            "uQ5uKAfbQfguw8ty5qtWFkWZGp7OVp6TRKtbemwDmu/KWwogTrbfjZbl/wf+D3QC" +
            "wlCs159WUcuDBWDmOEEI3oz7j9SGpZ+yOMw8tCSb33KxaN/Qx8tkH6PeSwCFJLHt" +
            "BF76o0ZkQDTTDd9eXtgsfbEogsZ+tne0zYlKG7H0V+n8Z7vy5nzCz+EtHRmjkbK2" +
            "CPR2dXKKxBD+BR/1/dPT9BZPrxfalNtK0/jhEEXmy4AHTNrYrjUt6hWXiw3BLdcN" +
            "khEQII2wCTC+oewpa+0wggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9EJSLMA0G" +
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
            "ZXJuYWwgRGV2ZWxvcGVyMB4XDTE4MDgyMjE3MjAxMVoXDTM5MTIzMTE3MjAxMVow" +
            "JDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjCCASIwDQYJKoZI" +
            "hvcNAQEBBQADggEPADCCAQoCggEBAKH3idBu5yuF4ErewElIdA+3zRJMBgAJ5A6T" +
            "48qhY8B8lAkvEJv2Hm5N0xlZSORs4zBhEon76H7mszc8iGeBTIH6ekYxQT1tmQiX" +
            "IiQf/YzdUwCWGHK0HP8af/LPEAIt7StdOeC5njCHVcDZqK0WCM9ebAgFivqayRt+" +
            "p7pEFwjAAz2AyeQFFDkcKL2U8Yr7vkPiWhaYalUc576HjswbDaAUjuNjGLmc6BCo" +
            "qboQBU6f/K/8AMDcRao9feDKVv4JleQ89P/0aLcB15xNT8vIaGTRZRDjceHz1f7l" +
            "1Bctv1ZFnd2/VmgxO5cStzB1Ip9IrnPkmw3XwTBilbi1RTNTHFcCAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEAXNQIr8Fr//j5Wyjggksv5A+t3I0Gicr1JymqJV1PkSm2" +
            "64Nqh1LCQqI1vmIyltLZ1k2RD+EZcPtuJ62KHAda9/+ErVszRHElTbMKv0OGVd+v" +
            "qmya5D0O5FvVEWc4152Wjym/Yt1LzRV+hkXyLmI4TOndoj5K7pcw0Nm2BSkQffmx" +
            "9mk/RcB29ArHCuW83nuzLyaOmwxArSd5ERGH45WJuAQEvKRjXYDmSpl0NTyTywUC" +
            "lze3qiomfA5ibcHa8WGR25Hwr2jVUtiG4chMOnR+f6WT2sYeIvl7DTIjoE3S/QG+" +
            "gc4XnhasavuJ6J6XokIudntuGdk/FR51HhBF8/Kp4Q==";
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
