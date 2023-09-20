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
using System.Windows.Threading;

namespace WpfApp20._09._2023
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DateTime dateTime;

        private Random random;
        private int randomNumber;
        int count = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Game.Visibility = Visibility.Visible;
            Start.Visibility = Visibility.Collapsed;
            Exit.Visibility = Visibility.Collapsed;

            dateTime = DateTime.Now.AddSeconds(60);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += DownTimer;
            timer.Start();

            random = new Random();
            randomNumber = random.Next(10,31);
        }
        private void DownTimer(object sender, EventArgs e)
        {
            TimeSpan timeSpan = dateTime - DateTime.Now;
            if (timeSpan.TotalSeconds > 0)
            {
                Timebox.Text =timeSpan.ToString("ss");
            }
            else
            {
                timer.Start();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckNumberButton_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(NumberText.Text);
            if(num == randomNumber)
            {
                HelpText.Text = "Верно";
                HelpText.Foreground = Brushes.Green;
                timer.Stop();
            }
            else
            {
                count++;
                if(count % 3 == 0)
                {
                    HelpButton.Visibility = Visibility.Visible;
                }
                else  HelpButton.Visibility = Visibility.Collapsed;

                HelpText.Text = "Не верно";
                HelpText.Foreground = Brushes.Red;
            }
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(NumberText.Text);
            HelpText.Foreground = Brushes.Black;
            if (num > randomNumber)
            {
                HelpText.Text = "число должно быть меньше";
            }
            else
            {
                HelpText.Text = "число должно быть больше";
            }
        }
    }
}
