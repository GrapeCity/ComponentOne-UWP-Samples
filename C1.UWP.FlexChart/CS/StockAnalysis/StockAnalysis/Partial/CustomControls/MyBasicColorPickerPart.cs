using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace StockAnalysis.Partial.CustomControls
{
    public class MyBasicColorPickerPart : C1.Xaml.Extended.C1BasicColorPickerPart
    {
        ///<summary> 
        /// Avoid child collection must not be modified during measure or arrange
        ///</summary>
        private bool _firstArrangeAndMeasure = true;
        public MyBasicColorPickerPart()
        {            
            this.SelectedColorChanged += (o, e) =>
            {
                if (!_firstArrangeAndMeasure)
                {
                    Command.CloseDropdownCommand cmd = new Command.CloseDropdownCommand();
                    cmd.Execute(this);
                }
                _firstArrangeAndMeasure = false;
            };
        }
    }
}
