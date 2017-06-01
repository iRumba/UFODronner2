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
    public class RemoveBehavior : Behavior<FrameworkElement>
    {
        public DronVm Dron
        {
            get { return (DronVm)GetValue(DronProperty); }
            set { SetValue(DronProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Dron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DronProperty =
            DependencyProperty.Register("Dron", typeof(DronVm), typeof(RemoveBehavior), new PropertyMetadata(null));


        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Dron!=null && Keyboard.Modifiers == ModifierKeys.Alt)
            {
                Dron.IsActivated = false;
            }
        }
    }
}
