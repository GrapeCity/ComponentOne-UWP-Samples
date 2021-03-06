﻿using System;
using System.Linq;
using System.Collections.Generic;
using C1.Xaml.Chart.Interaction;

namespace LineMarkerSample
{
    public class LineMarkerViewModel
    {
        const int Count = 300;
        Random rnd = new Random();

        public List<DataItem> Items
        {
            get
            {
                List<DataItem> items = new List<DataItem>();
                DateTime date = new DateTime(2016, 1, 1);
                for (var i = 0; i < Count; i++)
                {
                    var item = new DataItem()
                    {
                        Date = date.AddDays(i),
                        Input = rnd.Next(10, 20),
                        Output = rnd.Next(0, 10)
                    };
                    items.Add(item);
                }

                return items;
            }
        }

        public List<string> LineType
        {
            get
            {
                return Enum.GetNames(typeof(LineMarkerLines)).ToList();
            }
        }

        public List<string> LineMarkerInteraction
        {
            get
            {
                return Enum.GetNames(typeof(LineMarkerInteraction)).ToList();
            }
        }

        public Dictionary<string, LineMarkerAlignment> LineMarkerAlignments
        {
            get
            {
                var alignments = new Dictionary<string, LineMarkerAlignment>();
                alignments.Add(Strings.Auto, LineMarkerAlignment.Auto);
                alignments.Add(Strings.Right, LineMarkerAlignment.Right);
                alignments.Add(Strings.Left, LineMarkerAlignment.Left);
                alignments.Add(Strings.Bottom, LineMarkerAlignment.Bottom);
                alignments.Add(Strings.Top, LineMarkerAlignment.Top);
                alignments.Add(Strings.LeftBottom, LineMarkerAlignment.Left | LineMarkerAlignment.Bottom);
                alignments.Add(Strings.LeftTop, LineMarkerAlignment.Left | LineMarkerAlignment.Top);
                return alignments;
            }
        }

        public List<string> CanDrag
        {
            get
            {
                return new List<string>() { Strings.True, Strings.False };
            }
        }
    }
}
