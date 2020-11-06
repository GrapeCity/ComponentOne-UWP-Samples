using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockChart.ViewModel
{
    public class ChangeSymbolCommand : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, new EventArgs());
            }
        }

        ChartViewModel _viewModel;
        public ChangeSymbolCommand(ChartViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (_viewModel.ChangeSymbolCommandParamter != null)
            {
                var text = _viewModel.ChangeSymbolCommandParamter;
                if (!string.IsNullOrEmpty(text))
                {
                    var code = text.Split(new char[] { ' ' }).FirstOrDefault();
                    if (_viewModel.SymbolNames.Keys.Contains(code))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Execute(object parameter)
        {
            var code = parameter.ToString().Split(new char[] { ' ' }).FirstOrDefault();
            if (!string.IsNullOrEmpty(code))
            {
                _viewModel.MainSymbol = code;

                _viewModel.ChangeSymbolCommandParamter = string.Empty;
            } 


        }
    }
}
