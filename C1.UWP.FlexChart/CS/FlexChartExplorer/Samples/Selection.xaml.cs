﻿using System;
using System.Linq;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using C1.Chart;
using C1.Xaml.Chart;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexChartExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Selection : Page
    {
        Dictionary<ChartType, string> _chartTypes;
        List<FruitDataItem> _fruits;
        List<string> _selectionMode;
        List<string> _stackings;

        public Selection()
        {
            this.InitializeComponent();
        }

        public Dictionary<ChartType, string> ChartTypes
        {
            get
            {
                if (_chartTypes == null)
                {
                    _chartTypes = DataCreator.CreateSimpleChartTypes();
                }

                return _chartTypes;
            }
        }

        public List<string> Stackings
        {
            get
            {
                if (_stackings == null)
                {
                    _stackings = Enum.GetNames(typeof(Stacking)).ToList();
                }

                return _stackings;
            }
        }

        public List<string> SelectionModes
        {
            get
            {
                if (_selectionMode == null)
                {
                    _selectionMode = Enum.GetNames(typeof(ChartSelectionMode)).ToList();
                }

                return _selectionMode;
            }
        }

        public List<FruitDataItem> Data
        {
            get
            {
                if (_fruits == null)
                {
                    _fruits = DataCreator.CreateFruit();
                }

                return _fruits;
            }
        }

        public C1FlexChart FlexChart
        {
            get
            {
                return flexChart;
            }
        }
    }
}
