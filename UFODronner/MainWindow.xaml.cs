using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UFODronner.ViewModels;

namespace UFODronner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [System.Runtime.InteropServices.DllImport("gdi32")]
        private static extern uint GetPixel(int hdc, int nXPos, int nYPos);
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        bool _clickRequest;
        Point _clickCoord;
        Point _resizeCoords;

        bool _resizeMode;

        public Main Source { get; private set; }

        public MainWindow()
        {
            Source = new Main();
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Source.WorkFlow.CursorPoint = e.GetPosition((IInputElement)sender);
            var globalPoint = ((FrameworkElement)sender).PointToScreen(Source.WorkFlow.CursorPoint);
            var hdc = GetDC(IntPtr.Zero);
            var px = GetPixel(hdc.ToInt32(), (int)globalPoint.X, (int)globalPoint.Y);
            ReleaseDC(IntPtr.Zero, hdc);
            Source.WorkFlow.CursorPixel = System.Drawing.Color.FromArgb((int)px);
        }

        private void wndMain_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                Opacity = Math.Max(0.1, Math.Min(1, e.Delta > 0 ? Opacity + 0.1 : Opacity - 0.1));
                e.Handled = true;
            }
        }

        //private void ResizeGrip_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    _resizeMode = Mouse.Capture((IInputElement)sender);
        //    if (_resizeMode)
        //    {
        //        _resizeCoords = e.GetPosition((IInputElement)sender);
        //    }
        //}

        //private void ResizeGrip_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (_resizeMode)
        //    {
        //        //var newResizeCoords = e.GetPosition((IInputElement)sender);
        //        //Source.WindowWidth += newResizeCoords.X - _resizeCoords.X;
        //        //Source.WindowHeight += newResizeCoords.Y - _resizeCoords.Y;
        //        ////Source.WindowSize = new Size(Source.WindowSize.Width + , 
        //        ////    Source.WindowSize.Height + );
        //        //_resizeCoords = newResizeCoords;
        //    }
        //}

        //private void ResizeGrip_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    _resizeMode = false;
        //    Mouse.Capture(null);
        //}
    }

    public class MyBehaviors : List<Behavior>
    {

    }

    public static class SupplementaryInteraction
    {
        public static MyBehaviors GetBehaviors(DependencyObject obj)
        {
            return (MyBehaviors)obj.GetValue(BehaviorsProperty);
        }

        public static void SetBehaviors(DependencyObject obj, MyBehaviors value)
        {
            obj.SetValue(BehaviorsProperty, value);
        }

        public static readonly DependencyProperty BehaviorsProperty =
            DependencyProperty.RegisterAttached("Behaviors", typeof(MyBehaviors), typeof(SupplementaryInteraction), new UIPropertyMetadata(null, OnPropertyBehaviorsChanged));

        private static void OnPropertyBehaviorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behaviors = Interaction.GetBehaviors(d);
            foreach (var behavior in e.NewValue as MyBehaviors) behaviors.Add(behavior);
        }
    }
}
