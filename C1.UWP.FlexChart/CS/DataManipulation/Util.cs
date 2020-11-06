using C1.Chart;
using C1.Xaml.Chart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation
{
    public static class Util
    {
        public static bool IsWindowsDevice
        {
            get
            {
                return Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            }
        }

        public static double GetMin(this Axis axis)
        {
            return ((IAxis)axis).GetMin();
        }

        public static double GetMax(this Axis axis)
        {
            return ((IAxis)axis).GetMax();
        }

        public static double ToOADate(this DateTime date)
        {
            return TicksToOADate(date.Ticks);
        }

        private static double TicksToOADate(long value)
        {
            if (value == 0L)
            {
                return 0.0;
            }
            if (value < 864000000000L)
            {
                value += 599264352000000000L;
            }
            long num = (value - 599264352000000000L) / 10000L;
            if (num < 0L)
            {
                long num2 = num % 86400000L;
                if (num2 != 0L)
                {
                    num -= (86400000L + num2) * 2L;
                }
            }
            return (double)num / 86400000.0;
        }
    }
}
