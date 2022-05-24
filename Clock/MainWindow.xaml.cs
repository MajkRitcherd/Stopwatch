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

namespace Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ClockWindow : Window
    {

        private ClockPage cp;
        private Pages.StopwatchPage swp;
        private Pages.TimerPage tp;

        public ClockWindow()
        {
            InitializeComponent();
            cp = new ClockPage();
            myFrame.NavigationService.Navigate(cp);
        }

        private void EndClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clockClick(object sender, RoutedEventArgs e)
        {
            myFrame.NavigationService.Navigate(cp);
        }

        private void stopwatchClick(object sender, RoutedEventArgs e)
        {
            swp = new Pages.StopwatchPage();
            myFrame.NavigationService.Navigate(swp);
        }

        private void timerClick(object sender, RoutedEventArgs e)
        {
            tp = new Pages.TimerPage();
            myFrame.NavigationService.Navigate(tp);
        }
    }
}
