namespace FlexChart101
{
    public class Util
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
}
