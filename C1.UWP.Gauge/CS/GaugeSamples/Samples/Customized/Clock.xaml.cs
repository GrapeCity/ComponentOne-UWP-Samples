using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GaugeSamples
{
    public sealed partial class Clock : Page
    {
        public Clock()
        {
            this.InitializeComponent();
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                Task.Run(new Action(RunClock));
            }
        }
        private delegate void UpdateUIDelegate();
        private ThreadPoolTimer _timer;

        private void RunClock()
        {
            _timer=ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler((target) =>
                {
                    Dispatcher.RunAsync(CoreDispatcherPriority.Normal, UpdateClock);
                }),
                TimeSpan.FromSeconds(1));
            
        }

        private void UpdateClock()
        {
            var now = DateTime.Now;
            clockHours.Value = now.Hour % 12 + now.Minute / 60.0;
            clockMins.Value = now.Minute;
            clockSecs.Value = now.Second;
        }
    }
}
