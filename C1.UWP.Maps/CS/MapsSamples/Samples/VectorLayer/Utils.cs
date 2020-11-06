using C1.Xaml.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Media;
using System.Reflection;

namespace MapsSamples
{
    public class Utils
    {
        public static Geometry CreateBaloon()
        {
            PathGeometry pg = new PathGeometry();
            pg.Transform = new TranslateTransform() { X = -20, Y = -54.28 };
            PathFigure pf = new PathFigure() { StartPoint = new Point(20, 54.28), IsFilled = true, IsClosed = true };
            pf.Segments.Add(new ArcSegment() { SweepDirection = SweepDirection.Counterclockwise, Point = new Point(10, 38.28), RotationAngle = 45, Size = new Size(20, 20) });
            pf.Segments.Add(new ArcSegment() { SweepDirection = SweepDirection.Clockwise, Point = new Point(30, 38.28), RotationAngle = 270, Size = new Size(20, 20), IsLargeArc = true });
            pf.Segments.Add(new ArcSegment() { SweepDirection = SweepDirection.Counterclockwise, Point = new Point(20, 54.28), RotationAngle = 45, Size = new Size(20, 20) });
            pg.Figures.Add(pf);
            return pg;
        }

        public static void LoadShapeFromResource(C1VectorLayer vl, string resname, string dbfname, Location location, bool clear, ProcessShapeItem pv)
        {
            using (Stream shapeStream = typeof(Utils).GetTypeInfo().Assembly.GetManifestResourceStream(resname))
            {
                using (Stream dbfStream = typeof(Utils).GetTypeInfo().Assembly.GetManifestResourceStream(dbfname))
                {
                    if (shapeStream != null)
                    {
                        if (clear)
                            vl.Children.Clear();

                        vl.LoadShape(shapeStream, dbfStream, location, true, pv);
                    }
                }
            }
        }

        public static void LoadKMZFromResources(C1VectorLayer vl, string resname, bool clear, ProcessVectorItem pv)
        {
            using (Stream zipStream = typeof(Utils).GetTypeInfo().Assembly.GetManifestResourceStream(resname))
            {
                if (zipStream != null)
                {
                    if (clear)
                        vl.Children.Clear();

                    vl.LoadKMZ(zipStream, true, pv);
                }
            }
        }

        public static void LoadKMLFromResources(C1VectorLayer vl, string resname, bool clear, ProcessVectorItem pv)
        {
            using (Stream stream = typeof(Utils).GetTypeInfo().Assembly.GetManifestResourceStream(resname))
            {
                if (stream != null)
                {
                    if (clear)
                        vl.Children.Clear();

                    vl.LoadKML(stream, false, pv);
                }
            }
        }

        static Random rnd = new Random();

        public static Color GetRandomColor(byte a)
        {
            return Color.FromArgb(a, (byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255));
        }

        public static Color GetRandomColor(byte min, byte a)
        {
            return Color.FromArgb(a, (byte)(min + rnd.Next(255 - min)),
              (byte)(min + rnd.Next(255 - min)), (byte)(min + rnd.Next(255 - min)));
        }
    }
}
