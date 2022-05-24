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
    /// Interaction logic for ClockPage.xaml
    /// </summary>
    /// 
    public partial class ClockPage : Page
    {

        // Timer for correct 
        System.Windows.Threading.DispatcherTimer dispTimer = new System.Windows.Threading.DispatcherTimer();

        public ClockPage()
        {
            InitializeComponent();
            dispTimer.Start();
            dispTimer.Interval = TimeSpan.FromSeconds(1); // Updating app every 1 second
            dispTimer.Tick += OneTick;
        }

        private void OneTick(object sender, EventArgs e)
        {
            string time = "";
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            if (hour < 10)
                time += "0" + hour.ToString() + ":";
            else
                time += hour.ToString() + ":";

            if (minute < 10)
                time += "0" + minute.ToString() + ":";
            else
                time += minute.ToString() + ":";

            if (second < 10)
                time += "0" + second.ToString();
            else
                time += second.ToString();

            LblTime.Content = time;
        }
    }
}
