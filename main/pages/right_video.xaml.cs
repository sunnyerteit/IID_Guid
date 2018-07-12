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

namespace main.pages
{
    /// <summary>
    /// Interaction logic for right_video.xaml
    /// </summary>
    public partial class right_video : Page
    {
        public double CAMERA_INPUT_X;
        public double CAMERA_INPUT_Y;
        public double CAMERA_POSITION_X;
        public double CAMERA_POSITION_Y;
        public static double INITIAL_CAMERA_POSITION_X;
        public static double INITIAL_CAMERA_POSITION_Y;

        public right_video()
        {
            InitializeComponent();
            INITIAL_CAMERA_POSITION_X = Canvas.GetLeft(_RIGHT_CAMERA);
            INITIAL_CAMERA_POSITION_Y = Canvas.GetTop(_RIGHT_CAMERA);
            CAMERA_POSITION_X = Canvas.GetLeft(_RIGHT_CAMERA); ;
            CAMERA_POSITION_Y = Canvas.GetTop(_RIGHT_CAMERA); ;
            CAMERA_INPUT_X = 0.0;
            CAMERA_INPUT_Y = 0.0;
            Thread Camera_movement_thread = new Thread(()
                => Camera_movement());
            Camera_movement_thread.Start();
        }

        void Camera_movement()
        {
            while (true)
            {
                if (CAMERA_INPUT_X > 0)
                {
                    CAMERA_POSITION_X = CAMERA_INPUT_X * 100 + INITIAL_CAMERA_POSITION_X;
                    CAMERA_INPUT_X -= 0.05 * CAMERA_INPUT_X * CAMERA_INPUT_X;
                }
                else if (CAMERA_INPUT_X < 0)
                {
                    CAMERA_POSITION_X = CAMERA_INPUT_X * 100 + INITIAL_CAMERA_POSITION_X;
                    CAMERA_INPUT_X += 0.05 * CAMERA_INPUT_X * CAMERA_INPUT_X;
                }

                if (CAMERA_INPUT_Y > 0)
                {
                    CAMERA_POSITION_Y = CAMERA_INPUT_Y * 100 + INITIAL_CAMERA_POSITION_Y;
                    CAMERA_INPUT_Y -= 0.05 * CAMERA_INPUT_Y * CAMERA_INPUT_Y;
                }
                else if (CAMERA_INPUT_Y < 0)
                {
                    CAMERA_POSITION_Y = CAMERA_INPUT_Y * 100 + INITIAL_CAMERA_POSITION_Y;
                    CAMERA_INPUT_Y += 0.05 * CAMERA_INPUT_Y * CAMERA_INPUT_Y;
                }

                Dispatcher.Invoke(() =>
                {
                    Canvas.SetLeft(_RIGHT_CAMERA, CAMERA_POSITION_X);
                    Canvas.SetTop(_RIGHT_CAMERA, CAMERA_POSITION_Y);
                });

                Thread.Sleep(50);


            }
        }
    }
}
