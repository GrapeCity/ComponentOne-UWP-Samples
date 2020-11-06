using Windows.Foundation;
using Windows.UI.Xaml.Media;
namespace OfflineMaps
{
    class Utils
    {
        public static Geometry CreateBaloon()
        {
            PathGeometry pg = new PathGeometry();
            pg.Transform = new TranslateTransform() { X = -10, Y = -27.14 };
            PathFigure pf = new PathFigure() { StartPoint = new Point(10, 27.14), IsFilled = true, IsClosed = true };
            pf.Segments.Add(new ArcSegment() { SweepDirection = SweepDirection.Counterclockwise, Point = new Point(5, 19.14), RotationAngle = 45, Size = new Size(10, 10) });
            pf.Segments.Add(new ArcSegment() { SweepDirection = SweepDirection.Clockwise, Point = new Point(15, 19.14), RotationAngle = 270, Size = new Size(10, 10), IsLargeArc = true });
            pf.Segments.Add(new ArcSegment() { SweepDirection = SweepDirection.Counterclockwise, Point = new Point(10, 27.14), RotationAngle = 45, Size = new Size(10, 10) });
            pg.Figures.Add(pf);
            return pg;
        }
    }
}
