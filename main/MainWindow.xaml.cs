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

            LIGHT_BACKGROUND.Color = Color.FromArgb(255, 60, 59, 77);
            DARK_BACKGROUND.Color = Color.FromArgb(255, 56, 55, 72);
            DARK_GRAY.Color = Color.FromArgb(255, 137, 136, 145);
            LIGHT_GRAY.Color = Color.FromArgb(255, 223, 223, 225);
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
    }
}
