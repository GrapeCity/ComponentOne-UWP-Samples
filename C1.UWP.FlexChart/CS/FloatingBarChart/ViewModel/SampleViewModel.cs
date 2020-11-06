using System;
using System.Collections.Generic;
using Windows.UI;

namespace FloatingBarChart
{
    public class SampleViewModel
    {
        List<SubjectScoreRange> scores;
        static List<Phase> phases;

        public List<SubjectScoreRange> SubjectScoreRanges
        {
            get
            {
                if (scores == null)
                {
                    scores = new List<SubjectScoreRange>();
                    scores.Add(new SubjectScoreRange() { Name = "English", ClassAHigh = 99, ClassALow = 56, ClassBHigh = 96, ClassBLow = 67 });
                    scores.Add(new SubjectScoreRange() { Name = "Mathematics", ClassAHigh = 100, ClassALow = 75, ClassBHigh = 98, ClassBLow = 65 });
                    scores.Add(new SubjectScoreRange() { Name = "Reading", ClassAHigh = 91, ClassALow = 32, ClassBHigh = 96, ClassBLow = 67 });
                    scores.Add(new SubjectScoreRange() { Name = "Science", ClassAHigh = 85, ClassALow = 21, ClassBHigh = 92, ClassBLow = 51 });
                    scores.Add(new SubjectScoreRange() { Name = "Writing", ClassAHigh = 92, ClassALow = 47, ClassBHigh = 95, ClassBLow = 61 });
                }
                return scores;
            }
        }

        public static List<Phase> ReleasePhases
        {
            get
            {
                if (phases == null)
                {
                    phases = new List<Phase>();
                    phases.Add(new Phase() { Name = "Distribute", End = 11, Start = 10, Color = Color.FromArgb(255, 210, 192, 135) });
                    phases.Add(new Phase() { Name = "Test, Accept", End = 10, Start = 8, Color = Color.FromArgb(255, 248, 195, 217) });
                    phases.Add(new Phase() { Name = "Development", End = 8, Start = 2, Color = Color.FromArgb(255, 252, 201, 137) });
                    phases.Add(new Phase() { Name = "Design", End = 2, Start = 1, Color = Color.FromArgb(255, 177, 220, 182) });
                    phases.Add(new Phase() { Name = "Plan", End = 1, Start = 0, Color = Color.FromArgb(255, 171, 208, 237) });
                }
                return phases;
            }
        }
    }
}
