using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChartExplorer
{
    public static class DateTimeExtends
    {

        public static double ToOADate(this System.DateTime date)
        {
            return TicksToOADate(date.Ticks);
        }

        public static DateTime FromOADate(this System.DateTime date, double val)
        {
            return new DateTime(DoubleDateToTicks(val), DateTimeKind.Unspecified);
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
            if (value < 31241376000000000L)
            {
                throw new OverflowException("Arg_OleAutDateInvalid");
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

        internal static long DoubleDateToTicks(double value)
        {
            if (value >= 2958466.0 || value <= -657435.0)
            {
                throw new ArgumentException("Arg_OleAutDateInvalid");
            }
            long num = (long)(value * 86400000.0 + ((value >= 0.0) ? 0.5 : -0.5));
            if (num < 0L)
            {
                num -= num % 86400000L * 2L;
            }
            num += 59926435200000L;
            if (num < 0L || num >= 315537897600000L)
            {
                throw new ArgumentException("Arg_OleAutDateScale");
            }
            return num * 10000L;
        }
    }
}
