using System;
using System.Collections.ObjectModel;
using Windows.Foundation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationDemo.Data
{
    class DataHelper
    {
        static Random rnd = new Random();

        public static ObservableCollection<Point> Create(int npts, float max = 100)
        {
            var pts = new Point[npts];

            Func<int, Point> f = (i) => new Point(i, (int)(rnd.NextDouble() * max));
            for (var i = 0; i < npts; i++)
                pts[i] = f(i);

            return new ObservableCollection<Point>(pts);
        }
    }
}
