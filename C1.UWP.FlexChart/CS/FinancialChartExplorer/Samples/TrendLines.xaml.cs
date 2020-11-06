﻿using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using C1.Chart;
using Windows.UI.Xaml.Data;
using System.ComponentModel;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for TrendLines.xaml
    /// </summary>
    public partial class TrendLines : Page, INotifyPropertyChanged
    {
        DataService dataSerivice = DataService.GetService();

        public TrendLines()
        {
            InitializeComponent();

            Binding bindingMinX = new Binding();
            bindingMinX.Source = this;
            bindingMinX.Path = new Windows.UI.Xaml.PropertyPath("MinX"); ;
            BindingOperations.SetBinding(trendLine, C1.Xaml.Chart.TrendLine.MinXProperty, bindingMinX);

            Binding bindingMaxX = new Binding();
            bindingMaxX.Source = this;
            bindingMaxX.Path = new Windows.UI.Xaml.PropertyPath("MaxX");
            bindingMaxX.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(trendLine, C1.Xaml.Chart.TrendLine.MaxXProperty, bindingMaxX);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string pName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(pName));
            }
        }
        
        public List<Quote> Data
        {
            get
            {
                return dataSerivice.GetSymbolData("box");
            }
        }

        private DateTime minDate = DateTime.MinValue;
        public DateTime MinDate
        {
            get
            {
                if (minDate == DateTime.MinValue)
                {
                    minDate = Data.Min(p => p.date);
                }
                return minDate;
            }
        }

        private DateTime maxDate = DateTime.MinValue;
        public DateTime MaxDate
        {
            get
            {
                if (maxDate == DateTime.MinValue)
                {
                    maxDate = Data.Max(p => p.date);
                }
                return maxDate;
            }
        }

        private uint forward = 30;
        public uint Forward
        {
            get { return forward; }
            set { forward = value; MaxX = Convert(MaxDate, (int)Forward); }
        }

        private uint backward = 0;
        public uint Backward
        {
            get { return backward; }
            set { backward = value; MinX = Convert(MinDate, (int)-Backward); }
        }

        private double minX=double.NaN;
        public double MinX
        {
            get { return minX; }
            set { minX = value; OnPropertyChanged("MinX"); }
        }

        private double maxX = double.NaN;

        public double MaxX
        {
            get { return maxX; }
            set { maxX = value; OnPropertyChanged("MaxX"); }
        }

        private double Convert(DateTime baseValue, int changes)
        {
            var value = double.NaN;
            if (this.chkForecast.IsChecked == true)
            {
                value = baseValue.AddDays(changes).ToOADate();
            }
            return value;
        }

        public List<string> FitType
        {
            get
            {
                return new List<string> { "Linear", "Exponent", "Polynom",
                    "AverageX", "MinX", "MaxX", "AverageY", "MinY", "MaxY"};
            }
        }

        private void chkForecast_CheckedChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (chkForecast.IsChecked == true)
            {
                financialChart.BeginUpdate();
                financialChart.BindingX = "date";
                financialChart.EndUpdate();
            }
            else
            {
                financialChart.BeginUpdate();
                financialChart.BindingX = "Date";
                financialChart.EndUpdate();
            }
            MinX = Convert(MinDate, (int)-Backward);
            MaxX = Convert(MaxDate, (int)Forward);
        }
    }
}
