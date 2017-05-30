using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFODronner.Models;

namespace UFODronner.ViewModels
{
    public class MapVm : ViewModelBase<Map>
    {
        double _x;
        double _y;
        //CoordObject _size;
        double _width;
        double _height;
        double _scale;

        public ObservableCollection<MapObjectVm> MapObjects { get; }

        public MapVm() : this(new Map())
        {

            //Size = new CoordObject();
        }

        public MapVm(Map map) : base(map)
        {
            MapObjects = new ObservableCollection<MapObjectVm>();
            MapObjects.CollectionChanged += MapObjects_CollectionChanged;
        }

        private void MapObjects_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    foreach(var item in e.NewItems)
                    {
                        if (item is MapObjectVm)
                        {
                            ((MapObjectVm)item).Scale = Scale;
                            ((MapObjectVm)item).Map = this;
                        }
                            
                    }

                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems)
                    {
                        if (item is MapObjectVm)
                        {
                            ((MapObjectVm)item).Map = null;
                        }

                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                default:
                    break;
            }
        }

        public double X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        public double Width
        {
            get
            {
                return Model.Width * Scale;
            }

            set
            {
                Model.Width = value / Scale;
                OnPropertyChanged(nameof(Width));
            }
        }

        public double Height
        {
            get
            {
                return Model.Height * Scale;
            }

            set
            {
                Model.Height = value / Scale;
                OnPropertyChanged(nameof(Height));
            }
        }

        public double Scale
        {
            get
            {
                return _scale;
            }

            set
            {
                _scale = value;
                OnScaleChanged();
                //OnPropertyChanged(nameof(Scale));
            }
        }

        //public CoordObject Size { get; }

        void OnScaleChanged()
        {
            OnPropertyChanged(nameof(Scale));
            OnPropertyChanged(nameof(Width));
            OnPropertyChanged(nameof(Height));
            //Size.SetScale(Scale);
            foreach (var mapObject in MapObjects)
                mapObject.Scale = Scale;
        }
    }
}
