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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Animation
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {

        public double FadeInTime = 1;
        public double FadeOutTime = 1;
        public Window1()
        {
            InitializeComponent();
        }

        


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DoubleAnimation daV = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(FadeOutTime)));
            Storyboard sb = new Storyboard();
            sb.Children.Add(daV);
            Storyboard.SetTargetProperty(daV, new PropertyPath(OpacityProperty));
            sb.Completed += (s, ee) => base.Close();
            sb.Begin(this, true);
        }

        private void Window1_OnLoaded(object sender, RoutedEventArgs e)
        {
            Opacity = 0;
            DoubleAnimation daV = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(FadeInTime)));
            BeginAnimation(OpacityProperty, daV);
        }
    }
}
