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
    /// Interaction logic for gripper.xaml
    /// </summary>
    public partial class gripper : Page
    {
        public RotateTransform ROTATE_TRANSFORM_GRIPPER_1;
        public RotateTransform ROTATE_TRANSFORM_GRIPPER_2;
        public RotateTransform ROTATE_TRANSFORM_GRIPPER_3;
        public ScaleTransform TRANSFORM_GRIPPER_1;
        public ScaleTransform TRANSFORM_GRIPPER_2;
        public ScaleTransform TRANSFORM_GRIPPER_3;
        static double GRIPPER_1_LENGTH;
        static double GRIPPER_2_LENGTH;
        public double GRIPPER_3_INPUT;
        public double GRIPPER_3_ANGLE;
        public double GRIPPER_2_INPUT;
        public double GRIPPER_2_ANGLE;
        public double GRIPPER_1_INPUT;
        public double GRIPPER_1_ANGLE;

        public gripper()
        {
            InitializeComponent();
            GRIPPER_1_LENGTH = 105.47;
            GRIPPER_2_LENGTH = 34.14;
            GRIPPER_2_ANGLE = 0.0;

            Thread Gripper_thread_1 = new Thread(()
                => Rotate_gripper_1());
            Gripper_thread_1.Start();

            Thread Gripper_thread_2 = new Thread(()
                => Rotate_gripper_2());
            Gripper_thread_2.Start();

            Thread Gripper_thread_3 = new Thread(()
                => Rotate_gripper_3());
            Gripper_thread_3.Start();
        }

        void Rotate_gripper_1()
        {
            while (true)
            {
                if (GRIPPER_1_INPUT > 0)
                {
                    GRIPPER_1_ANGLE += GRIPPER_1_INPUT;
                    GRIPPER_1_INPUT -= 0.8 * GRIPPER_1_INPUT;
                    if (GRIPPER_1_ANGLE > 45.0)
                    {
                        GRIPPER_1_ANGLE = 45.0;
                    }
                }
                else if (GRIPPER_1_INPUT < 0)
                {
                    GRIPPER_1_ANGLE += GRIPPER_1_INPUT;
                    GRIPPER_1_INPUT -= 0.8 * GRIPPER_1_INPUT;
                    if (GRIPPER_1_ANGLE < -45.0)
                    {
                        GRIPPER_1_ANGLE = -45.0;
                    }
                }

                Dispatcher.Invoke(() =>
                {
                    TRANSFORM_GRIPPER_1 = new ScaleTransform(1, (GRIPPER_1_ANGLE + 45.0) / 90.0, 0.5, 1.0);
                    _GRIPPER_1_BAR.RenderTransform = TRANSFORM_GRIPPER_1;
                    ROTATE_TRANSFORM_GRIPPER_1 = new RotateTransform(GRIPPER_1_ANGLE);
                    _GRIPPER_1_ARM_1.RenderTransform = ROTATE_TRANSFORM_GRIPPER_1;
                    Canvas.SetTop(_GRIPPER_1_ARM_2,  - GRIPPER_1_LENGTH * (( Math.Cos(Math.PI * (GRIPPER_1_ANGLE) / 180.0)) - 1.0));
                    Canvas.SetLeft(_GRIPPER_1_ARM_2, GRIPPER_1_LENGTH * ( Math.Sin(Math.PI * (GRIPPER_1_ANGLE) / 180.0)));
                });

                Thread.Sleep(50);
            }
        }

        void Rotate_gripper_2()
        {
            while ( true )
            {
                if (GRIPPER_2_INPUT > 0)
                {
                    GRIPPER_2_ANGLE += GRIPPER_2_INPUT;
                    GRIPPER_2_INPUT -= 0.8 * GRIPPER_2_INPUT;
                    if (GRIPPER_2_ANGLE > 45.0)
                    {
                        GRIPPER_2_ANGLE = 45.0;
                    }
                }
                else if (GRIPPER_2_INPUT < 0)
                {
                    GRIPPER_2_ANGLE += GRIPPER_2_INPUT;
                    GRIPPER_2_INPUT -= 0.8 * GRIPPER_2_INPUT;
                    if (GRIPPER_2_ANGLE < 0.0)
                    {
                        GRIPPER_2_ANGLE = 0.0;
                    }
                }


                Dispatcher.Invoke(() =>
                {
                    TRANSFORM_GRIPPER_2 = new ScaleTransform(1, (GRIPPER_2_ANGLE) / 45.0, 0.5, 1.0);
                    _GRIPPER_2_BAR.RenderTransform = TRANSFORM_GRIPPER_2;
                    ROTATE_TRANSFORM_GRIPPER_2 = new RotateTransform(GRIPPER_2_ANGLE);
                    _GRIPPER_2_ARM_2.RenderTransform = ROTATE_TRANSFORM_GRIPPER_2;
                    Canvas.SetTop(_GRIPPER_2_ARM_3, GRIPPER_2_LENGTH * (- Math.Cos(Math.PI * (- 25.0 - GRIPPER_2_ANGLE - 90) / 180.0) + Math.Cos(Math.PI * (- 25.0 - 90.0) / 180.0)));
                    Canvas.SetLeft(_GRIPPER_2_ARM_3, GRIPPER_2_LENGTH * (- Math.Sin(Math.PI * (- 25.0 - GRIPPER_2_ANGLE - 90) / 180.0) + Math.Sin(Math.PI * (- 25.0 - 90.0) / 180.0)));
                });

                Thread.Sleep(50);

            }

        }
        void Rotate_gripper_3()
        {
            while ( true )
            {
                if (GRIPPER_3_INPUT > 0)
                {
                    GRIPPER_3_ANGLE += GRIPPER_3_INPUT;
                    GRIPPER_3_INPUT -= 0.8 * GRIPPER_3_INPUT;
                    if (GRIPPER_3_ANGLE > 15.0)
                    {
                        GRIPPER_3_ANGLE = 15.0;
                    }
                }
                else if (GRIPPER_3_INPUT < 0)
                {
                    GRIPPER_3_ANGLE += GRIPPER_3_INPUT;
                    GRIPPER_3_INPUT -= 0.8 * GRIPPER_3_INPUT;
                    if (GRIPPER_3_ANGLE < 0.0)
                    {
                        GRIPPER_3_ANGLE = 0.0;
                    }
                }


                Dispatcher.Invoke(() =>
                {
                    TRANSFORM_GRIPPER_3 = new ScaleTransform(1, (GRIPPER_3_ANGLE) / 15.0, 0.5, 1.0);
                    _GRIPPER_3_BAR.RenderTransform = TRANSFORM_GRIPPER_3;
                    ROTATE_TRANSFORM_GRIPPER_3 = new RotateTransform(GRIPPER_3_ANGLE);
                    _GRIPPER_3_ARM_2.RenderTransform = ROTATE_TRANSFORM_GRIPPER_3;
                    ROTATE_TRANSFORM_GRIPPER_3 = new RotateTransform(- GRIPPER_3_ANGLE);
                    _GRIPPER_3_ARM_3.RenderTransform = ROTATE_TRANSFORM_GRIPPER_3;
                });

                Thread.Sleep(50);

            }

        }


    }
}
