using C1.Xaml;
using C1.Xaml.ExpressionEditor;
using System.Globalization;

namespace ExpressionEditorSamples
{
    public class ExpressionGroupDescription : GroupDescription
    {
        public static C1ExpressionEditor editer = new C1ExpressionEditor();

        public string Expression
        {
            get;
            set;
        }

        public override object GroupNameFromItem(object item, int level, CultureInfo culture)
        {
            editer.DataSource = item;
            editer.Expression = Expression;

            if (editer.IsValid)
                return editer.Evaluate();
            return "";
        }
    }
}
