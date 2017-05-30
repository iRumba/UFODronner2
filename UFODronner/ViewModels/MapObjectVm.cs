using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFODronner.Models;

namespace UFODronner.ViewModels
{
    public class MapObjectVm : ViewModelBase<MapObject>
    {
        double _scale;
        public MapVm Map { get; set; }

        public double Scale
        {
            get
            {
                return _scale;
            }

            set
            {
                _scale = value;
                OnPropertyChanged(nameof(Scale));
                OnPropertyChanged(nameof(X));
                OnPropertyChanged(nameof(Y));
            }
        }

        public MapObjectVm(MapObject source) : base(source)
        {
            
        }

        public MapObjectVm() : this(new MapObject()) { }

        public double X
        {
            get
            {
                return Model.X * Scale;
            }
            set
            {
                var newVal = Math.Min(Math.Max(value / Scale, 0), Map?.Model.Width ?? double.PositiveInfinity);
                if (newVal != value)
                {
                    Model.X = newVal;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        public double Y
        {
            get
            {
                return Model.Y * Scale;
            }
            set
            {
                var newVal = Math.Min(Math.Max(value / Scale, 0), Map?.Model.Height ?? double.PositiveInfinity);
                if (newVal != value)
                {
                    Model.Y = newVal;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }

        public string Name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                Model.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
