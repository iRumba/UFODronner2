using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UFODronner.ViewModels
{
    public class CoordObject : ScaledObject
    {
        ScaledValue _x;
        ScaledValue _y;

        public CoordObject()
        {
            _x = new ScaledValue();
            _y = new ScaledValue();
        }

        public double X
        {
            get
            {
                return _x.Value;
            }

            set
            {
                _x.Value = value;
                OnPropertyChanged(nameof(X));
                OnPropertyChanged(nameof(ViewX));
            }
        }

        public double Y
        {
            get
            {
                return _y.Value;
            }

            set
            {
                _y.Value = value;
                OnPropertyChanged(nameof(Y));
                OnPropertyChanged(nameof(ViewY));
            }
        }

        public double ViewX
        {
            get
            {
                return X * Scale;
            }
            set
            {
                X = value / Scale;
                OnPropertyChanged(nameof(ViewX));
            }
        }

        public double ViewY
        {
            get
            {
                return Y * Scale;
            }
            set
            {
                Y = value / Scale;
                OnPropertyChanged(nameof(ViewY));
            }
        }

        public override void SetScale(double scale)
        {
            base.SetScale(scale);
            OnPropertyChanged(nameof(ViewX));
            OnPropertyChanged(nameof(ViewY));
        }
    }
}
