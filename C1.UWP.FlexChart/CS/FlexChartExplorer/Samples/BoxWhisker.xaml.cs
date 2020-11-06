using C1.Chart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FlexChartExplorer
{
    /// <summary>
    /// Interaction logic for BoxWhisker.xaml
    /// </summary>
    public partial class BoxWhisker : Page
    {
        private List<string> _calculations = null;
        private List<ClassScore> _data = null;

        public BoxWhisker()
        {
            InitializeComponent();
        }

        public List<string> Calculations
        {
            get
            {
                if (_calculations == null)
                {
                    _calculations = DataCreator.CreateQuartileCalculations();
                }

                return _calculations;
            }
        }

        public List<ClassScore> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = DataCreator.CreateSchoolScoreData();
                }

                return _data;
            }
        }

        private void CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (boxWhiskerA == null || boxWhiskerB == null || boxWhiskerC == null) return;

            if(sender == cbShowMeanLine)
            {
                boxWhiskerA.ShowMeanLine = cbShowMeanLine.IsChecked.Value;
                boxWhiskerB.ShowMeanLine = cbShowMeanLine.IsChecked.Value;
                boxWhiskerC.ShowMeanLine = cbShowMeanLine.IsChecked.Value;
            }
            else if(sender == cbShowInnerPoints)
            {
                boxWhiskerA.ShowInnerPoints = cbShowInnerPoints.IsChecked.Value;
                boxWhiskerB.ShowInnerPoints = cbShowMeanLine.IsChecked.Value;
                boxWhiskerC.ShowInnerPoints = cbShowMeanLine.IsChecked.Value;
            }
            else if(sender == cbShowOutliers)
            {
                boxWhiskerA.ShowOutliers = cbShowOutliers.IsChecked.Value;
                boxWhiskerB.ShowOutliers = cbShowOutliers.IsChecked.Value;
                boxWhiskerC.ShowOutliers = cbShowOutliers.IsChecked.Value;
            }
            else
            {
                boxWhiskerA.ShowMeanMarks = cbShowMeanMarks.IsChecked.Value;
                boxWhiskerB.ShowMeanMarks = cbShowMeanMarks.IsChecked.Value;
                boxWhiskerC.ShowMeanMarks = cbShowMeanMarks.IsChecked.Value;
            }
        }

        private void cboQuartileCalculation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (boxWhiskerA == null || boxWhiskerB == null || boxWhiskerC == null)
                return;

            var comboBox = sender as ComboBox;
            if(comboBox.SelectedValue !=null)
            {
                var calculation = (QuartileCalculation)Enum.Parse(typeof(QuartileCalculation), comboBox.SelectedValue.ToString());
                boxWhiskerA.QuartileCalculation = calculation;
                boxWhiskerB.QuartileCalculation = calculation;
                boxWhiskerC.QuartileCalculation = calculation;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cboQuartileCalculation.SelectedIndex = 0;
        }
    }
}
