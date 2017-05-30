using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using UFODronner.ViewModels;

namespace UFODronner.Behaviors
{
    public class SensitivityBehavior : Behavior<FrameworkElement>
    {
        public DronVm Dron
        {
            get { return (DronVm)GetValue(DronProperty); }
            set { SetValue(DronProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Dron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DronProperty =
            DependencyProperty.Register("Dron", typeof(DronVm), typeof(SensitivityBehavior), new PropertyMetadata(null));


        public double Delta
        {
            get { return (double)GetValue(DeltaProperty); }
            set { SetValue(DeltaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Delta.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeltaProperty =
            DependencyProperty.Register("Delta", typeof(double), typeof(SensitivityBehavior), new PropertyMetadata(0.1D));



        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseWheel += AssociatedObject_MouseWheel;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseWheel -= AssociatedObject_MouseWheel;
        }

        private void AssociatedObject_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                Dron.Sensitivity += Delta;
            else
                Dron.Sensitivity -= Delta;
        }

        
    }
}
