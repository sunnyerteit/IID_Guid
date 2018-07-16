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
    /// Interaction logic for left_video.xaml
    /// </summary>
    public partial class left_video : Page
    {
        public double CAMERA_INPUT_X;
        public double CAMERA_INPUT_Y;
        public double CAMERA_POSITION_X;
        public double CAMERA_POSITION_Y;
        public static double INITIAL_CAMERA_POSITION_X;
        public static double INITIAL_CAMERA_POSITION_Y;

        public left_video()
        {
            InitializeComponent();
            INITIAL_CAMERA_POSITION_X = Canvas.GetLeft(_LEFT_CAMERA);
            INITIAL_CAMERA_POSITION_Y = Canvas.GetTop(_LEFT_CAMERA);
            CAMERA_POSITION_X = Canvas.GetLeft(_LEFT_CAMERA); ;
            CAMERA_POSITION_Y = Canvas.GetTop(_LEFT_CAMERA); ;
            CAMERA_INPUT_X = 0.0;
            Thread Camera_movement_thread = new Thread(()
                => Camera_movement());
            Camera_movement_thread.Start();

        }

        void Camera_movement()
        {
            while(true)
            {
                if (CAMERA_INPUT_X > 0)
                {
                    CAMERA_POSITION_X += (CAMERA_INPUT_X * 10) * (305 - (CAMERA_POSITION_X - INITIAL_CAMERA_POSITION_X)) / 305.0 ;
                    CAMERA_INPUT_X -= 0.05 * CAMERA_INPUT_X * CAMERA_INPUT_X;
                }
                else if (CAMERA_INPUT_X < 0)
                {
                    CAMERA_POSITION_X += (CAMERA_INPUT_X * 10) * (305 - (INITIAL_CAMERA_POSITION_X - CAMERA_POSITION_X)) / 305.0 ;
                    CAMERA_INPUT_X += 0.05 * CAMERA_INPUT_X * CAMERA_INPUT_X;
                }

                if (CAMERA_INPUT_Y > 0)
                {
                    //CAMERA_POSITION_Y += CAMERA_INPUT_Y * 10;
                    CAMERA_POSITION_Y += (CAMERA_INPUT_Y * 10) * (217 - (CAMERA_POSITION_Y - INITIAL_CAMERA_POSITION_Y)) / 217.0 ;
                    CAMERA_INPUT_Y -= 0.05 * CAMERA_INPUT_Y * CAMERA_INPUT_Y;
                }
                else if (CAMERA_INPUT_Y < 0)
                {
                    //CAMERA_POSITION_Y += CAMERA_INPUT_Y * 10;
                    CAMERA_POSITION_Y += (CAMERA_INPUT_Y * 10) * (217 - (INITIAL_CAMERA_POSITION_Y - CAMERA_POSITION_Y)) / 217.0 ;
                    CAMERA_INPUT_Y += 0.05 * CAMERA_INPUT_Y * CAMERA_INPUT_Y;
                }

                Dispatcher.Invoke(() =>
                {
                    Canvas.SetLeft(_LEFT_CAMERA, CAMERA_POSITION_X);
                    Canvas.SetTop(_LEFT_CAMERA, CAMERA_POSITION_Y);
                });

                Thread.Sleep(50);


            }
        }
    }
}
