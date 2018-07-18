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

namespace main.pages
{
    /// <summary>
    /// Interaction logic for rov.xaml
    /// </summary>
    public partial class rov : Page
    {
        public RotateTransform ROTATE_TRANSFORM_ROLL;
        public RotateTransform ROTATE_TRANSFORM_DIRECTION;
        SolidColorBrush NEUTRAL = new SolidColorBrush();
        SolidColorBrush BLUE = new SolidColorBrush();
        SolidColorBrush RED = new SolidColorBrush();
        public rov()
        {

            InitializeComponent();
            RED.Color = Color.FromArgb(255, 210, 115, 130);
            BLUE.Color = Color.FromArgb(255, 91, 145, 166);
            NEUTRAL.Color = Color.FromArgb(255, 137, 136, 145);
        }

        public void Pitch(double pitch)
        {
            if (pitch < - 1.0)
            {
                _PITCH_ROLL.OpacityMask = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/images/pitch_roll_0.png")));
            }

            else if (pitch < - 0.66)
            {
                _PITCH_ROLL.OpacityMask = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/images/pitch_roll_1.png")));
            }

            else if (pitch < - 0.33)
            {
                _PITCH_ROLL.OpacityMask = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/images/pitch_roll_2.png")));
            }

            else if (pitch < 0.0)
            {
                _PITCH_ROLL.OpacityMask = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/images/pitch_roll_3.png")));
            }

            else if (pitch < 0.33)
            {
                _PITCH_ROLL.OpacityMask = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/images/pitch_roll_4.png")));
            }

            else if (pitch < 0.66)
            {
                _PITCH_ROLL.OpacityMask = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/images/pitch_roll_5.png")));
            }

            else
            {
                _PITCH_ROLL.OpacityMask = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/images/pitch_roll_6.png")));
            }
        }

        public void Roll(double roll)
        {
            ROTATE_TRANSFORM_ROLL = new RotateTransform(roll * 45.0);
            _PITCH_ROLL.RenderTransform = ROTATE_TRANSFORM_ROLL;
        }

        public void Direction(double direction)
        {
            int direction_int = Convert.ToInt32(Mod(Convert.ToInt32(direction * 360), 360));
            _DIRECTION_LABEL.Content = direction_int.ToString();

            ROTATE_TRANSFORM_DIRECTION = new RotateTransform(- direction * 360.0);
            _DIRECTION.RenderTransform = ROTATE_TRANSFORM_DIRECTION;
        }

        int Mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }

        public void Battery(bool control)
        {
            if (control == true)
            {
                _BATTERY.Fill = RED;
            }
            else
            {
                _BATTERY.Fill = NEUTRAL;
            }
        }
        public void Collision(bool control)
        {
            if (control == true)
            {
                _COLLISION.Fill = RED;
            }
            else
            {
                _COLLISION.Fill = NEUTRAL;
            }
        }
        public void Wifi(bool control)
        {
            if (control == true)
            {
                _WIFI.Fill = RED;
            }
            else
            {
                _WIFI.Fill = NEUTRAL;
            }
        }
        public void Radar(bool control)
        {
            if (control == true)
            {
                _RADAR.Fill = BLUE;
            }
            else
            {
                _RADAR.Fill = NEUTRAL;
            }
        }
        public void Corrosion(bool control)
        {
            if (control == true)
            {
                _CORROSION.Fill = BLUE;
            }
            else
            {
                _CORROSION.Fill = NEUTRAL;
            }
        }
        public void Bio(bool control)
        {
            if (control == true)
            {
                _BIO.Fill = BLUE;
            }
            else
            {
                _BIO.Fill = NEUTRAL;
            }
        }
    }
}
