using Windows.UI;

namespace FloatingBarChart
{
    public class Phase
    {
        public string Name { get; set; }
        public int End { get; set; }
        public int Start { get; set; }
        public Color Color { get; set; }
    }

    public class SubjectScoreRange
    {
        public string Name { get; set; }
        public int ClassAHigh { get; set; }
        public int ClassALow { get; set; }
        public int ClassBHigh { get; set; }
        public int ClassBLow { get; set; }
        public string ClassName { get; set; }
    }
}
