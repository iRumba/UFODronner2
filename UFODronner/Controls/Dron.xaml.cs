using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для Dron.xaml
    /// </summary>
    public partial class Dron : UserControl, INotifyPropertyChanged
    {
        public double ValueAngle
        {
            get
            {
                return Angle - Value / MaxValue * Angle;
            }
        }

        public double RotateAngle
        {
            get { return (double)GetValue(RotateAngleProperty); }
            set { SetValue(RotateAngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RotateAngleProperty =
            DependencyProperty.Register("RotateAngle", typeof(double), typeof(Dron), new PropertyMetadata(0D));



        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WorkAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(Dron), new PropertyMetadata(0D)
            { PropertyChangedCallback = AngleChanged } );

        static void AngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dron = d as Dron;
            if (d != null)
            {
                dron.OnPropertyChanged(nameof(ValueAngle));
            }
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(Dron), new PropertyMetadata(double.NaN)
            { PropertyChangedCallback = ValueChanged });

        static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dron = d as Dron;
            if (d != null)
            {
                dron.OnPropertyChanged(nameof(ValueAngle));
            }
        }


        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(Dron), new PropertyMetadata(0D)
            { PropertyChangedCallback = MaxValueChanged });


        static void MaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dron = d as Dron;
            if (d != null)
            {
                dron.OnPropertyChanged(nameof(ValueAngle));
            }
        }

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Radius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(Dron), new PropertyMetadata(0D));



        public ControlTemplate DronTemplate
        {
            get { return (ControlTemplate)GetValue(DronTemplateProperty); }
            set { SetValue(DronTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DronTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DronTemplateProperty =
            DependencyProperty.Register("DronTemplate", typeof(ControlTemplate), typeof(Dron), new PropertyMetadata(null));



        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(Dron), new PropertyMetadata(Brushes.White));

        public event PropertyChangedEventHandler PropertyChanged;

        public Dron()
        {
            DefaultStyleKey = typeof(Dron);
            InitializeComponent();
        }

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
