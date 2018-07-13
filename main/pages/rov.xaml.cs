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
        public rov()
        {

            InitializeComponent();
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
    }
}
