using Microsoft.Toolkit.Uwp.Notifications;
using System;
using Windows.UI.Notifications;

namespace InputSamples
{
    public class AppHelper
    {
        public static bool IsWindowsPhoneDevice()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                return true;
            }
            return false;
        }
    }

    public class ToastNotificationsHelper
    {
        public static void ShowToastNotification(string subject, string[] names)
        {
            string toastInfomation = String.Format(Strings.ToastSubjectFormat, subject);
            if(names.Length <5)
            {
                toastInfomation += String.Join(Strings.ToastJoinSeprator, names) + Strings.ToastPeriod;
                int index = toastInfomation.LastIndexOf(Strings.ToastJoinSeprator);
                if (index > 0)
                {
                    toastInfomation = toastInfomation.Remove(index, 1);
                    toastInfomation = toastInfomation.Insert(index, Strings.ToastAnd);
                }
            }
            else
            {
                int others = names.Length - 4;
                toastInfomation += String.Format(Strings.ToastNamesFormat, names) + others.ToString() + Strings.ToastPeopleEnd;
            }
            var content = new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText(){ Text = Strings.ToastTitle},
                            new AdaptiveText() { Text = toastInfomation }
                        }
                    }
                },
            };

            var toast = new ToastNotification(content.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
