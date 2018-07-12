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
using System.Threading;

namespace main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static pages.gripper GRIPPER;
        public static pages.rov ROV;
        public static pages.report REPORT;
        public static pages.left_video LEFT_VIDEO;
        public static pages.right_video RIGHT_VIDEO;
        public double INPUT_X;
        public double INPUT_Y;
        public double POSITION_X;
        public double POSITION_Y;

        // Brushes
        SolidColorBrush DARK_BACKGROUND = new SolidColorBrush();
        SolidColorBrush LIGHT_BACKGROUND = new SolidColorBrush();

        SolidColorBrush LIGHT_GRAY = new SolidColorBrush();
        SolidColorBrush DARK_GRAY = new SolidColorBrush();
        public MainWindow()
        {
            InitializeComponent();
            GRIPPER = new pages.gripper();
            ROV = new pages.rov();
            REPORT = new pages.report();
            LEFT_VIDEO = new pages.left_video();
            RIGHT_VIDEO = new pages.right_video();
            FRAME.Content = ROV;
            LEFT_VIDEO_FRAME.Content = LEFT_VIDEO;
            RIGHT_VIDEO_FRAME.Content = RIGHT_VIDEO;
            POSITION_X = Canvas.GetLeft(_ROV);
            POSITION_Y = Canvas.GetTop(_ROV);

            // Temp velocity
            INPUT_X = 0.0;
            INPUT_Y = 0.0;

            LIGHT_BACKGROUND.Color = Color.FromArgb(255, 60, 59, 77);
            DARK_BACKGROUND.Color = Color.FromArgb(255, 56, 55, 72);
            DARK_GRAY.Color = Color.FromArgb(255, 137, 136, 145);
            LIGHT_GRAY.Color = Color.FromArgb(255, 223, 223, 225);

            Loaded += Window_Loaded;
        }

        private void BUTTON_ROV_Click(object sender, RoutedEventArgs e)
        {
            Change_Tab(0);
        }

        private void BUTTON_GRIPPER_Click(object sender, RoutedEventArgs e)
        {
            Change_Tab(1);
        }

        private void BUTTON_REPORT_Click(object sender, RoutedEventArgs e)
        {
            Change_Tab(2);
        }

        public void Change_Tab(int tab)
        {
            if (tab == 0)
            {
                FRAME.Content = ROV;
                BUTTON_ROV.Background = DARK_BACKGROUND;
                IMAGE_ROV.Fill = LIGHT_GRAY;
                LABEL_ROV.Foreground = LIGHT_GRAY;
                BUTTON_GRIPPER.Background = LIGHT_BACKGROUND;
                IMAGE_GRIPPER.Fill = DARK_GRAY;
                LABEL_GRIPPER.Foreground = DARK_GRAY;
                BUTTON_REPORT.Background = LIGHT_BACKGROUND;
                IMAGE_REPORT.Fill = DARK_GRAY;
                LABEL_REPORT.Foreground = DARK_GRAY;
            }
            else if (tab == 1)
            {
                FRAME.Content = GRIPPER;
                BUTTON_ROV.Background = LIGHT_BACKGROUND;
                IMAGE_ROV.Fill = DARK_GRAY;
                LABEL_ROV.Foreground = DARK_GRAY;
                BUTTON_GRIPPER.Background = DARK_BACKGROUND;
                IMAGE_GRIPPER.Fill = LIGHT_GRAY;
                LABEL_GRIPPER.Foreground = LIGHT_GRAY;
                BUTTON_REPORT.Background = LIGHT_BACKGROUND;
                IMAGE_REPORT.Fill = DARK_GRAY;
                LABEL_REPORT.Foreground = DARK_GRAY;
            }
            else
            {
                FRAME.Content = REPORT;
                BUTTON_ROV.Background = LIGHT_BACKGROUND;
                IMAGE_ROV.Fill = DARK_GRAY;
                LABEL_ROV.Foreground = DARK_GRAY;
                BUTTON_GRIPPER.Background = LIGHT_BACKGROUND;
                IMAGE_GRIPPER.Fill = DARK_GRAY;
                LABEL_GRIPPER.Foreground = DARK_GRAY;
                BUTTON_REPORT.Background = DARK_BACKGROUND;
                IMAGE_REPORT.Fill = LIGHT_GRAY;
                LABEL_REPORT.Foreground = LIGHT_GRAY;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread Velocity_thread = new Thread(()
                => Velocity_components());
            Velocity_thread.Start();
        }

        void Velocity_components()
        {
            while (true)
            {
                if (INPUT_X > 0)
                {
                    POSITION_X += INPUT_X * INPUT_X * 1.0;
                    INPUT_X -= INPUT_X * INPUT_X * 0.05;
                }
                else
                {
                    POSITION_X -= INPUT_X * INPUT_X * 1.0;
                    INPUT_X += INPUT_X * INPUT_X * 0.05;
                }

                if (INPUT_Y > 0)
                {
                    POSITION_Y += INPUT_Y * INPUT_Y * 1.0;
                    INPUT_Y -= INPUT_Y * INPUT_Y * 0.05;
                }
                else
                {
                    POSITION_Y -= INPUT_Y * INPUT_Y * 1.0;
                    INPUT_Y += INPUT_Y * INPUT_Y * 0.05;
                }

                double velocity =Math.Sqrt(INPUT_Y * INPUT_Y + INPUT_X * INPUT_X);

                Dispatcher.Invoke(() =>
                {
                    Canvas.SetLeft(_ROV, POSITION_X);
                    Canvas.SetTop(_ROV, POSITION_Y);
                    _LABEL_SOG.Content = $"{velocity.ToString("0.0")} m/s";
                });
                Thread.Sleep(50);

            }

        }

        private void Window_key_down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                INPUT_X = -1.0;
            }
            else if (e.Key == Key.D)
            {
                INPUT_X = 1.0;
            }

            if (e.Key == Key.W)
            {
                INPUT_Y = -1.0;
            }
            else if (e.Key == Key.S)
            {
                INPUT_Y = 1.0;
            }

            if (e.Key == Key.D1)
            {
                Change_Tab(0);
            }

            if (e.Key == Key.D2)
            {
                Change_Tab(1);
            }

            if (e.Key == Key.D3)
            {
                Change_Tab(2);
            }
        }

    }

}