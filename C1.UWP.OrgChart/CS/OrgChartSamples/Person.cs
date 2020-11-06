using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OrgChartSamples
{
    /// <summary>
    /// Our hierarchical data item: A Person has Subordinates of type Person.
    /// </summary>
    public class Person
    {
        ObservableCollection<Person> _list = new ObservableCollection<Person>();

        #region ** object model

        public string Name { get; set; }
        public string Position { get; set; }
        public string Notes { get; set; }
        public IList<Person> Subordinates
        {
            get { return _list; }
        }
        public int TotalCount
        {
            get
            {
                var count = 1;
                foreach (var p in Subordinates)
                {
                    count += p.TotalCount;
                }
                return count;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}:\r\n\t{1}", Name, Position);
        }

        #endregion

        #region ** Person factory

        static Random _rnd = new Random();
        static string[] _positions = (Strings.Director + "|" + Strings.Manager + "|" + Strings.Designer + "|" + Strings.StringPositions).Split('|');
        static string[] _areas = Strings.StringAreas.Split('|');
        static string[] _first = Strings.StringFirstName.Split('|');
        static string[] _last = Strings.StringLastName.Split('|');
        static string[] _verb = Strings.StringVerb.Split('|');
        static string[] _adjective = Strings.StringAdjective.Split('|');
        static string[] _noun = Strings.StringNoun.Split('|');

        public static Person CreatePerson(int level)
        {
            var p = CreatePerson();
            if (level > 0)
            {
                level--;
                if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
                {
                    for (int i = 0; i < _rnd.Next(3, 3); i++)
                    {
                        p.Subordinates.Add(CreatePerson(_rnd.Next(level / 2, level)));
                    }
                }
                else
                {
                    for (int i = 0; i < _rnd.Next(1, 4); i++)
                    {
                        p.Subordinates.Add(CreatePerson(_rnd.Next(level / 2, level)));
                    }
                }
                   
            }
            return p;
        }
        public static Person CreatePerson()
        {
            var p = new Person();
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                p.Position = string.Format("{0}", GetItem(_positions));
            }
            else
            {
                p.Position = string.Format(Strings.StringFormatTwoArg, GetItem(_positions), GetItem(_areas));
            }
            p.Name = string.Format("{0} {1}", GetItem(_first), GetItem(_last));
            p.Notes = string.Format("{0} {1} {2} {3}", p.Name, GetItem(_verb), GetItem(_adjective), GetItem(_noun));
            while (_rnd.NextDouble() < .5)
            {
                p.Notes += string.Format(Strings.StringFormatThreeArg, GetItem(_verb), GetItem(_adjective), GetItem(_noun));
            }
            p.Notes += ".";
            return p;
        }
        static string GetItem(string[] list)
        {
            return list[_rnd.Next(0, list.Length)];
        }

        #endregion
    }
}
