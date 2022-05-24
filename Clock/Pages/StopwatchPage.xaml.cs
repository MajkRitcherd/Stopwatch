using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Clock.Pages
{
    /// <summary>
    /// Interaction logic for StopwatchPage.xaml
    /// </summary>
    public partial class StopwatchPage : Page
    {
        private Stopwatch stopwatch;
        private int numberOfClicks;

        // Timer for correct 
        System.Windows.Threading.DispatcherTimer dispTimer = new System.Windows.Threading.DispatcherTimer();

        public StopwatchPage()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
        }

        private void startClick(object sender, RoutedEventArgs e)
        {
            ++numberOfClicks;
            startClickButton.Content = "Stop";

            switch(numberOfClicks)
            {
                case 1:
                    dispTimer.Start();
                    dispTimer.Interval = TimeSpan.FromMilliseconds(1); // Updating app every 1 second
                    stopwatch.Start();
                    dispTimer.Tick += WatchTick;
                    break;
                default:
                    dispTimer.Stop();
                    stopwatch.Stop();
                    startClickButton.Content = "Start";
                    numberOfClicks = 0;
                    break;
            }

        }

        private void WatchTick(object sender, EventArgs e)
        {
            stopwatchLabel.Content = string.Format("{0:hh\\:mm\\:ss\\:fff}", stopwatch.Elapsed);
        }

        private void resetClick(object sender, RoutedEventArgs e)
        {
            if (numberOfClicks != 1)
            {
                stopwatchLabel.Content = "00:00:00:000";
                stopwatch.Restart();
            }
        }
    }
}
