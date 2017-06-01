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
    public class ChangeValueBehavior : Behavior<FrameworkElement>
    {
        Point _currentCursorPosition;
        bool _isCaptured;

        public DronVm Dron
        {
            get { return (DronVm)GetValue(DronProperty); }
            set { SetValue(DronProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Dron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DronProperty =
            DependencyProperty.Register("Dron", typeof(DronVm), typeof(ChangeValueBehavior), new PropertyMetadata(null));

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dron != null && _isCaptured && Keyboard.Modifiers == ModifierKeys.Shift)
            {
                var newPos = e.GetPosition(AssociatedObject);
                Dron.Value += (newPos.X - _currentCursorPosition.X) / 10;
                _currentCursorPosition = newPos;
            }
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isCaptured)
            {
                AssociatedObject.ReleaseMouseCapture();
                _isCaptured = false;
            }
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Dron != null && Keyboard.Modifiers == ModifierKeys.Shift)
            {
                _currentCursorPosition = e.GetPosition(AssociatedObject);
                _isCaptured = AssociatedObject.CaptureMouse();
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
        }
    }
}
