using C1.C1Zip;
using C1.Xaml.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace MapsSamples
{
    public delegate bool ProcessVectorItem(C1VectorItemBase vector);

    public static class Extension
    {
        public static void LoadKML(this C1VectorLayer vl, Stream stream, bool centerAndZoom,
          ProcessVectorItem processVector)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                string s = sr.ReadToEnd();
                List<C1VectorItemBase> vects = KmlReader.Read(s);

                vl.BeginUpdate();
                foreach (C1VectorItemBase vect in vects)
                {
                    if (processVector != null)
                    {
                        if (!processVector(vect))
                            continue;
                    }

                    vl.Children.Add(vect);
                }
                vl.EndUpdate();

                if (centerAndZoom)
                {
                    Rect bnds = vects.GetBounds();
                    C1Maps maps = ((IMapLayer)vl).ParentMaps;

                    if (maps != null)
                    {
                        maps.Center = new Point(bnds.Left + 0.5 * bnds.Width, bnds.Top + 0.5 * bnds.Height);
                        double scale = Math.Max(bnds.Width / 360 * maps.ActualWidth,
                              bnds.Height / 180 * maps.ActualHeight); ;
                        double zoom = Math.Log(512 / scale, 2.0);
                        maps.TargetZoom = maps.Zoom = zoom > 0 ? zoom : 0;
                    }
                }

                sr.Dispose();
            }
        }

        public static void LoadKMZ(this C1VectorLayer vl, Stream stream, bool centerAndZoom,
          ProcessVectorItem processVector)
        {
            using (C1ZipFile zip = new C1ZipFile(stream))
            {
                foreach (C1ZipEntry entry in zip.Entries)
                {
                    if (entry.FileName.EndsWith(".kml"))
                    {
                        using (Stream docStream = entry.OpenReader())
                        {
                            if (docStream != null)
                                LoadKML(vl, docStream, centerAndZoom, processVector);
                        }
                    }
                }
            }
        }

        public static Rect GetBounds(this IEnumerable<C1VectorItemBase> items)
        {
            Rect bounds = Rect.Empty;
            foreach (C1VectorItemBase item in items)
                bounds.Union(item.Bounds);
            return bounds;
        }
    }
}
