using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFODronner.ViewModels
{
    public class ScaledValue : ScaledObject
    {
        double _value;

        public double Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public double ViewValue
        {
            get
            {
                return Value * Scale;
            }
            set
            {
                Value = value / Scale;
                OnPropertyChanged(nameof(ViewValue));
            }
        }

        public override void SetScale(double scale)
        {
            base.SetScale(scale);
            OnPropertyChanged(nameof(ViewValue));
        }
    }
}
