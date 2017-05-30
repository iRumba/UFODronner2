using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using UFODronner.ViewModels;

namespace UFODronner.Behaviors
{
    public class RotateBehavior : Behavior<FrameworkElement>
    {
        Point _currentCursorPosition;
        bool _isDragged;


        public DronVm Dron
        {
            get { return (DronVm)GetValue(DronProperty); }
            set { SetValue(DronProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Dron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DronProperty =
            DependencyProperty.Register("Dron", typeof(DronVm), typeof(RotateBehavior), new PropertyMetadata(null));


        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Cursor = Cursors.SizeAll;

            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragged)
            {
                var newCursorPos = e.GetPosition(AssociatedObject);
                var a = _currentCursorPosition;
                var b = GetVector(newCursorPos);

                var angle = (Math.Atan2(b.X, b.Y) - Math.Atan2(a.X, a.Y)) / Math.PI * 180;

                Angle += angle;
            }
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragged)
            {
                AssociatedObject.ReleaseMouseCapture();
                _isDragged = false;
            }

        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var curPos = e.GetPosition(AssociatedObject);
            _currentCursorPosition = GetVector(curPos);
            _isDragged = AssociatedObject.CaptureMouse();
        }

        public Point Mid
        {
            get
            {
                return new Point(AssociatedObject.ActualWidth / 2, AssociatedObject.ActualHeight / 2);
            }
        }

        public Point GetVector(Point glob)
        {
            var mid = Mid;
            return new Point(glob.X - mid.X, mid.Y - glob.Y);
        }

        public double Angle
        {
            get
            {
                return Dron?.RotateAngle ?? 0;
            }
            set
            {
                if (Dron!=null)
                    Dron.RotateAngle = value;
            }
        }
    }
}
