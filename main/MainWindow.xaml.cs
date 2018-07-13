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
        public double DEPTH_INPUT;
        public double DEPTH;
        public double PITCH;
        public double PITCH_INPUT;
        public double ROLL;
        public double ROLL_INPUT;
        public double YAW;
        public double YAW_INPUT;
        public RotateTransform ROTATE_TRANSFORM_YAW;

        // Brushes
        SolidColorBrush DARK_BACKGROUND = new SolidColorBrush();
        SolidColorBrush LIGHT_BACKGROUND = new SolidColorBrush();

        SolidColorBrush LIGHT_GRAY = new SolidColorBrush();
        SolidColorBrush DARK_GRAY = new SolidColorBrush();

        
        SolidColorBrush DEPTH_0 = new SolidColorBrush();
        SolidColorBrush DEPTH_1 = new SolidColorBrush();
        SolidColorBrush DEPTH_2 = new SolidColorBrush();
        SolidColorBrush DEPTH_3 = new SolidColorBrush();
        SolidColorBrush DEPTH_4 = new SolidColorBrush();
        SolidColorBrush DEPTH_5 = new SolidColorBrush();
        SolidColorBrush DEPTH_6 = new SolidColorBrush();
        SolidColorBrush DEPTH_7 = new SolidColorBrush();
        SolidColorBrush DEPTH_8 = new SolidColorBrush();

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
            DEPTH_INPUT = 0.0;
            DEPTH = 0.0;

            LIGHT_BACKGROUND.Color = Color.FromArgb(255, 60, 59, 77);
            DARK_BACKGROUND.Color = Color.FromArgb(255, 56, 55, 72);
            DARK_GRAY.Color = Color.FromArgb(255, 137, 136, 145);
            LIGHT_GRAY.Color = Color.FromArgb(255, 223, 223, 225);

            DEPTH_0.Color = Color.FromRgb(113, 211, 232);
            DEPTH_1.Color = Color.FromRgb(125, 213, 220);
            DEPTH_2.Color = Color.FromRgb(138, 215, 207);
            DEPTH_3.Color = Color.FromRgb(150, 218, 195);
            DEPTH_4.Color = Color.FromRgb(162, 220, 182);
            DEPTH_5.Color = Color.FromRgb(175, 222, 170);
            DEPTH_6.Color = Color.FromRgb(199, 227, 145);
            DEPTH_7.Color = Color.FromRgb(212, 229, 132);
            DEPTH_8.Color = Color.FromRgb(224, 231, 120);


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

        public void Depth_Color(double depth)
        {
            if (depth < 0.5)
            {
                _DEPTH_COLOR.Fill = DEPTH_0;
            }
            else if (depth < 1.5)
            {
                _DEPTH_COLOR.Fill = DEPTH_1;
            }
            else if (depth < 2.5)
            {
                _DEPTH_COLOR.Fill = DEPTH_2;
            }
            else if (depth < 3.5)
            {
                _DEPTH_COLOR.Fill = DEPTH_3;
            }
            else if (depth < 4.5)
            {
                _DEPTH_COLOR.Fill = DEPTH_4;
            }
            else if (depth < 5.5)
            {
                _DEPTH_COLOR.Fill = DEPTH_5;
            }
            else if (depth < 6.5)
            {
                _DEPTH_COLOR.Fill = DEPTH_6;
            }
            else if (depth < 7.5)
            {
                _DEPTH_COLOR.Fill = DEPTH_7;
            }
            else
            {
                _DEPTH_COLOR.Fill = DEPTH_8;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread Velocity_thread = new Thread(()
                => Velocity_components());
            Velocity_thread.Start();

            Thread Depth_thread = new Thread(()
                => Depth_components());
            Depth_thread.Start();

            Thread Orientation_thread = new Thread(()
                => Orientation_components());
            Orientation_thread.Start();
        }

        void Depth_components()
        {
            while (true)
            {
                if (DEPTH_INPUT > 0)
                {
                    DEPTH += DEPTH_INPUT * DEPTH_INPUT * 0.1;
                    DEPTH_INPUT -= DEPTH_INPUT * DEPTH_INPUT * 0.05;
                }
                else
                {
                    DEPTH -= DEPTH_INPUT * DEPTH_INPUT * 0.1;
                    DEPTH_INPUT += DEPTH_INPUT * DEPTH_INPUT * 0.05;

                    if (DEPTH < 0)
                    {
                        DEPTH = 0.0;
                    }
                }

                Dispatcher.Invoke(() =>
                {
                    Depth_Color(DEPTH);
                    _DEPTH_LABEL.Content = $"{DEPTH.ToString("0.0")}";
                });

                Thread.Sleep(50);

            }
        }

        void Orientation_components()
        {
            while (true)
            {
                if (PITCH_INPUT > 0)
                {
                    PITCH += PITCH_INPUT * PITCH_INPUT * 0.1;
                    PITCH_INPUT -= PITCH_INPUT * PITCH_INPUT * 0.1;
                }
                else if (PITCH_INPUT < 0)
                {
                    PITCH -= PITCH_INPUT * PITCH_INPUT * 0.1;
                    PITCH_INPUT += PITCH_INPUT * PITCH_INPUT * 0.1;
                }

                if (ROLL_INPUT > 0)
                {
                    ROLL += ROLL_INPUT * ROLL_INPUT * 0.05;
                    ROLL_INPUT -= ROLL_INPUT * ROLL_INPUT * 0.05;

                    if (ROLL > 1)
                    {
                        ROLL = 1;
                    }
                }
                else if ( ROLL_INPUT < 0)
                {
                    ROLL -= ROLL_INPUT * ROLL_INPUT * 0.05;
                    ROLL_INPUT += ROLL_INPUT * ROLL_INPUT * 0.05;

                    if (ROLL < - 1)
                    {
                        ROLL = - 1;
                    }
                }

                if (YAW_INPUT > 0)
                {
                    YAW += YAW_INPUT * YAW_INPUT * 0.01;
                    YAW_INPUT -= YAW_INPUT * YAW_INPUT * 0.05;

                }
                else if (YAW_INPUT < 0)
                {
                    YAW -= YAW_INPUT * YAW_INPUT * 0.01;
                    YAW_INPUT += YAW_INPUT * YAW_INPUT * 0.05;
                }

                double yaw = Mod(Convert.ToInt32(YAW * 360), 360);

                Dispatcher.Invoke(() =>
                {
                    ROV.Pitch(PITCH);
                    ROV.Roll(ROLL);
                    ROV.Direction(YAW);
                    ROTATE_TRANSFORM_YAW = new RotateTransform(yaw);
                    _DEPTH_COLOR.RenderTransform = ROTATE_TRANSFORM_YAW;
                });

                Thread.Sleep(50);
            }
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

                double velocity = Math.Sqrt(INPUT_Y * INPUT_Y + INPUT_X * INPUT_X);

                double longitude = 10.3501 + POSITION_Y / 1000.0;
                double latitude = 63.4502 + POSITION_X / 1000.0;

                Dispatcher.Invoke(() =>
                {
                    Canvas.SetLeft(_ROV, POSITION_X);
                    Canvas.SetTop(_ROV, POSITION_Y);
                    _LABEL_SOG.Content = $"{velocity.ToString("0.0")} m/s";
                    _LABEL_LONGITUDE.Content = $"{longitude.ToString("0.0000")}";
                    _LABEL_LATITUDE.Content = $"{latitude.ToString("0.0000")}";
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

            if (e.Key == Key.Left)
            {
                LEFT_VIDEO.CAMERA_INPUT_X = -1.0;
                RIGHT_VIDEO.CAMERA_INPUT_X = -1.0;
            }
            else if (e.Key == Key.Right)
            {
                LEFT_VIDEO.CAMERA_INPUT_X = 1.0;
                RIGHT_VIDEO.CAMERA_INPUT_X = 1.0;
            }

            if (e.Key == Key.Up)
            {
                LEFT_VIDEO.CAMERA_INPUT_Y = -1.0;
                RIGHT_VIDEO.CAMERA_INPUT_Y = -1.0;
            }
            else if (e.Key == Key.Down)
            {
                LEFT_VIDEO.CAMERA_INPUT_Y = 1.0;
                RIGHT_VIDEO.CAMERA_INPUT_Y = 1.0;
            }

            if (e.Key == Key.K)
            {
                DEPTH_INPUT = 1.0;
            }
            else if (e.Key == Key.J)
            {
                DEPTH_INPUT = - 1.0;
            }

            if (e.Key == Key.H)
            {
                PITCH_INPUT = 1.0;
            }
            else if (e.Key == Key.L)
            {
                PITCH_INPUT = - 1.0;
            }

            if (e.Key == Key.M)
            {
                ROLL_INPUT = 1.0;
            }
            else if (e.Key == Key.N)
            {
                ROLL_INPUT = - 1.0;
            }

            if (e.Key == Key.D4)
            {
                YAW_INPUT = 1.0;
            }
            else if (e.Key == Key.D5)
            {
                YAW_INPUT = - 1.0;
            }
        }

        int Mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }

    }

}