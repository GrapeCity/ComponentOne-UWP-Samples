using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace BasicLibrarySamples
{

    public static class Helper
    {
        public static Color ToColor(this string webColor)
        {
            return new Color()
            {
                A = Convert.ToByte(webColor.Substring(1, 2), 16),
                R = Convert.ToByte(webColor.Substring(3, 2), 16),
                G = Convert.ToByte(webColor.Substring(5, 2), 16),
                B = Convert.ToByte(webColor.Substring(7, 2), 16)
            };
        }

        public static T PickOne<T>(this Random rnd, T[] array)
        {
            return array[rnd.Next(array.Length)];
        }
    }
}
