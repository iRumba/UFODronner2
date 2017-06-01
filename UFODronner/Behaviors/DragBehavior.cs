using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using UFODronner.ViewModels;

namespace UFODronner.Behaviors
{
    public class DragBehavior : Behavior<FrameworkElement>
    {
        Point _currentCursorPosition;
        bool _isDragged;

        public MapObjectVm MapObject
        {
            get { return (MapObjectVm)GetValue(MapObjectProperty); }
            set { SetValue(MapObjectProperty, value); }
        }

        public static readonly DependencyProperty MapObjectProperty =
            DependencyProperty.Register("MapObject", typeof(MapObjectVm), typeof(DragBehavior), new PropertyMetadata(null));



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
                Top = Top + newCursorPos.Y - _currentCursorPosition.Y;
                Left = Left + newCursorPos.X - _currentCursorPosition.X;
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
            if (Keyboard.Modifiers == ModifierKeys.None)
            {
                _currentCursorPosition = e.GetPosition(AssociatedObject);
                _isDragged = AssociatedObject.CaptureMouse();
            }
        }

        double Top
        {
            get
            {
                return MapObject.Y;
            }
            set
            {

                MapObject.Y = value;
            }
        }

        double Left
        {
            get
            {
                return MapObject.X;
            }
            set
            {
                MapObject.X = value;
            }
        }
    }
}
