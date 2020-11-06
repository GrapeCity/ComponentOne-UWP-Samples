using System;
using System.Linq;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FlexGridSamples
{
    internal static class LabelEx
    {
        const string REGEX_CONTAINS_PATTERN = "\\b{0}\\b";

        public static string GetText(this TextBlock label)
        {
            return label.Text;
        }

        public static void SetFormattedText(this TextBlock label, FormattedString formattedText)
        {
            label.Inlines.Clear();
            foreach (var inline in formattedText)
            {
                label.Inlines.Add(inline);
            }
        }

        public static bool Highlight(this TextBlock label, string[] highlightingStrings, Brush highlightingColor, bool isMatchCase = false, bool isMatchWholeWord = false)
        {
            bool isHighlight = false;
            var originalText = label.GetText();
            var matches = GetHighLightMatches(originalText, highlightingStrings, isMatchCase, isMatchWholeWord).ToArray();
            if (matches.Length > 0)
            {
                var formattedString = new FormattedString();
                var previousIndex = 0;
                foreach (var match in matches)
                {
                    string matchText = originalText.Substring(match.Item2, match.Item1.Length);
                    if (match.Item2 > previousIndex)
                        formattedString.AddSpan(originalText.Substring(previousIndex, match.Item2 - previousIndex));
                    else if (match.Item2 < previousIndex)
                    {
                        var length = match.Item1.Length - previousIndex + match.Item2;
                        if (length > 0)
                            matchText = originalText.Substring(previousIndex, length);
                        else continue; // match item is add by previous item
                    }
                    formattedString.AddSpan(matchText, highlightingColor);
                    previousIndex = match.Item2 + match.Item1.Length;
                }
                if (previousIndex < originalText.Length)
                    formattedString.AddSpan(originalText.Substring(previousIndex));
                label.SetFormattedText(formattedString);

                isHighlight = true;
            }

            return isHighlight;
        }

        private static IEnumerable<Tuple<string, int>> GetHighLightMatches(string originalText, string[] queryParts, bool isMatchCase = false, bool isMatchWholeWord = false)
        {
            List<Tuple<string, int>> matches = new List<Tuple<string, int>>();
            var comparisonType = isMatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;
            foreach (var queryPart in queryParts)
            {
                matches.AddRange(GetMatches(originalText, new string[] { queryPart }, isMatchCase, isMatchWholeWord));
            }

            // Sort matches follow ascending index order
            matches.Sort(new Comparison<Tuple<string, int>>((x, y) => { return x.Item2 - y.Item2; }));

            return matches;
        }

        private static IEnumerable<Tuple<string, int>> GetMatches(string originalText, string[] queryParts, bool isMatchCase = false, bool isMatchWholeWord = false)
        {
            var previousIndex = 0;
            begginning:
            int firstIndex = -1;
            string firstQueryPart = "";
            foreach (var queryPart in queryParts)
            {
                if (string.IsNullOrWhiteSpace(queryPart))
                    continue;
                if (isMatchWholeWord)
                {
                    string pattern = String.Format(REGEX_CONTAINS_PATTERN, Regex.Escape(queryPart));
                    Regex regex = new Regex(pattern, isMatchCase ? RegexOptions.None : RegexOptions.IgnoreCase);
                    if (regex.IsMatch(originalText))
                    {
                        var matches = regex.Matches(originalText);
                        foreach (Match item in matches)
                        {
                            yield return new Tuple<string, int>(queryPart, item.Index);
                        }
                    }
                }
                else
                {
                    var index = originalText.IndexOf(queryPart, previousIndex, isMatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0)
                    {
                        if (firstIndex == -1 || index < firstIndex)
                        {
                            firstIndex = index;
                            firstQueryPart = queryPart;
                        }
                    }
                }
            }
            if (firstIndex >= 0)
            {
                yield return new Tuple<string, int>(firstQueryPart, firstIndex);
                previousIndex = firstIndex + firstQueryPart.Length;
                goto begginning;
            }
            yield break;
        }
    }

    internal class FormattedString : List<Inline>
    {
        public void AddSpan(string text, Brush foreground = null)
        {
            var run = new Run() { Text = text };
            if (foreground != null)
                run.Foreground = foreground;
            Add(run);
        }
    }
}
