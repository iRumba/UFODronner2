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

namespace UFODronner.Controls
{
    /// <summary>
    /// Логика взаимодействия для DronBody.xaml
    /// </summary>
    public partial class DronBody : UserControl
    {
        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(DronBody), new PropertyMetadata(Brushes.White));

        public DronBody()
        {
            DefaultStyleKey = typeof(DronBody);
            InitializeComponent();
        }
    }
}
