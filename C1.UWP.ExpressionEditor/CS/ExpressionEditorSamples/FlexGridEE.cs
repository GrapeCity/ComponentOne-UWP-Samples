using C1.Xaml.ExpressionEditor;
using C1.Xaml.FlexGrid;

namespace ExpressionEditorSamples
{
    public class FlexGridEE : C1FlexGrid, ISupportExpressions
    {
        #region Ctor
        public FlexGridEE() : base()
        {
            ExpressionEditors = new ExpressionEditorCollection(this);
        }
        #endregion

        #region Override
        protected override void OnCellEditEnded(CellEditEventArgs e)
        {
            base.OnCellEditEnded(e);
            // ignore expression column changing
            if (!e.Cancel && !ExpressionEditors.Contains(Columns[e.Column].ColumnName))
                ExpressionEditors.Evaluate(GetDataIndex(e.Row));
        }
        #endregion

        #region ISupportExpressions
        public void SetCellValue(int row, string colName, object value)
        {
            this[GetRowIndex(row), colName] = value;
        }

        public ExpressionEditorCollection ExpressionEditors { get; }
        #endregion
    }
}
