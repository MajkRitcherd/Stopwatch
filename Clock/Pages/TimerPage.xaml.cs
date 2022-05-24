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

namespace Clock.Pages
{
    /// <summary>
    /// Interaction logic for TimerPage.xaml
    /// </summary>
    public partial class TimerPage : Page
    {

        // Timer for correct 
        System.Windows.Threading.DispatcherTimer dispTimer = new System.Windows.Threading.DispatcherTimer();

        private short hours = 0;
        private short minute = 0;
        private short second = 0;
        private string textOutput = "";
        public TimerPage()
        {
            InitializeComponent();
            dispTimer.Tick += OneTick;
        }

        private void hourUp(object sender, RoutedEventArgs e)
        {
            hours++;

            if (hours < 24)
            {
                if (hours > 9)
                    textOutput = hours.ToString();
                else
                    textOutput = "0" + hours.ToString();
            }
            else
            {
                hours = 0;
                textOutput = "0" + hours.ToString();
            }

            hoursTextBlock.Text = textOutput;
        }

        private void hourDown(object sender, RoutedEventArgs e)
        {
            hours--;

            if (hours >= 0)
            {
                if (hours > 9)
                    textOutput = hours.ToString();
                else
                    textOutput = "0" + hours.ToString();
            }
            else
            {
                hours = 23;
                textOutput = hours.ToString();
            }

            hoursTextBlock.Text = textOutput;
        }

        private void minuteUp(object sender, RoutedEventArgs e)
        {
            minute++;

            if (minute < 60)
            {
                if (minute > 9)
                    textOutput = minute.ToString();
                else
                    textOutput = "0" + minute.ToString();
            }
            else
            {
                minute = 0;
                textOutput = "0" + minute.ToString();
            }

            minutesTextBlock.Text = textOutput;
        }

        private void minuteDown(object sender, RoutedEventArgs e)
        {
            minute--;

            if (minute >= 0)
            {
                if (minute > 9)
                    textOutput = minute.ToString();
                else
                    textOutput = "0" + minute.ToString();
            }
            else
            {
                minute = 59;
                textOutput = minute.ToString();
            }

            minutesTextBlock.Text = textOutput;
        }

        private void secondUp(object sender, RoutedEventArgs e)
        {
            second++;

            if (second < 60)
            {
                if (second > 9)
                    textOutput = second.ToString();
                else
                    textOutput = "0" + second.ToString();
            }
            else
            {
                second = 0;
                textOutput = "0" + second.ToString();
            }

            secondsTextBlock.Text = textOutput;
        }

        private void secondDown(object sender, RoutedEventArgs e)
        {
            second--;

            if (second >= 0)
            {
                if (second > 9)
                    textOutput =second.ToString();
                else
                    textOutput = "0" + second.ToString();
            }
            else
            {
                second = 59;
                textOutput = second.ToString();
            }

            secondsTextBlock.Text = textOutput;
        }

        private void startTimer(object sender, RoutedEventArgs e)
        {
            hour1.IsEnabled = false;
            hour2.IsEnabled = false;
            minute1.IsEnabled = false;
            minute2.IsEnabled = false;
            second1.IsEnabled = false;
            second2.IsEnabled = false;

            if (hours != 0 || minute != 0 || second != 0)
            {
                dispTimer.Interval = TimeSpan.FromSeconds(1); // Updating app every 1 second
                dispTimer.Start();
            }
            else
            {
                hour1.IsEnabled = true;
                hour2.IsEnabled = true;
                minute1.IsEnabled = true;
                minute2.IsEnabled = true;
                second1.IsEnabled = true;
                second2.IsEnabled = true;
            }
        }

        private void OneTick(object sender, EventArgs e)
        {
            if (hours == 0 && minute == 0 && second == 0)
            {
                Console.Beep();
            }
            else if (second > 0)
            {
                second--;
                if (second >= 10)
                    secondsTextBlock.Text = second.ToString();
                else
                    secondsTextBlock.Text = "0" + second.ToString();
            }
            else if (second == 0 && minute > 0)
            {
                second = 59;
                minute--;

                if (minute >= 10)
                {
                    minutesTextBlock.Text = minute.ToString();
                    secondsTextBlock.Text = second.ToString();
                }
                else
                {
                    minutesTextBlock.Text = "0" + minute.ToString();
                    secondsTextBlock.Text = second.ToString();
                }
            }
            else if (second == 0 && minute == 0 && hours > 0)
            {
                minute = 59;
                second = 59;
                hours--;

                if (hours >= 10)
                {
                    hoursTextBlock.Text = hours.ToString();
                    minutesTextBlock.Text = minute.ToString();
                    secondsTextBlock.Text = second.ToString();
                }
                else
                {
                    hoursTextBlock.Text = "0" + hours.ToString();
                    minutesTextBlock.Text = minute.ToString();
                    secondsTextBlock.Text = second.ToString();
                }
            }
        }

        private void resetTimer(object sender, RoutedEventArgs e)
        {
            dispTimer.Stop();
            hours = minute = second = 0;
            hoursTextBlock.Text = "0" + hours.ToString();
            minutesTextBlock.Text = "0" + minute.ToString();
            secondsTextBlock.Text = "0" + second.ToString();

            hour1.IsEnabled =true;
            hour2.IsEnabled =true;
            minute1.IsEnabled =true;
            minute2.IsEnabled =true;
            second1.IsEnabled =true;
            second2.IsEnabled =true;

        }
    }
}
