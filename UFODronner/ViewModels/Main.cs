using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UFODronner.Models;

namespace UFODronner.ViewModels
{
    public class Main : Notifier
    {
        Size _windowSize;
        Point _mapPosition;
        Size _mapSize;

        double _windowWidth;
        double _windowHeight;

        public WorkFlow WorkFlow { get; set; }

        public List<DronVm> Drons { get; }

        public MapVm Map { get; }

        public ObservableCollection<CoordObject> MapObjects { get; set; }

        public Main()
        {
            Map = new MapVm(new Map { Width = 250, Height=250 })
            {
                X = 20,
                Y = 20,
                Scale = 2
            };
            //Map.Size.X = 250;
            //Map.Size.Y = 250;
            WindowSize = new Size(1000, 800);
            WindowWidth = 1000;
            WindowHeight = 800;
            //MapSize = new Size(500, 500);
            //MapPosition = new Point(20, 20);
            //MapObjects = new ObservableCollection<MapObject>();
            Drons = new List<DronVm>
            {
                new DronVm(new Dron1() { X = 100, Y = 100 }),
                new DronVm(new Dron1()),
                new DronVm(new Dron1()),
                new DronVm(new Dron2()),
                new DronVm(new Dron2()),
                new DronVm(new Dron2())
            };
            foreach(var dron in Drons)
            {
                dron.ActivatedChanged += Dron_ActivatedChanged;
            }
            WorkFlow = new WorkFlow();
        }

        public IEnumerable<DronVm> DisactivatedDrons
        {
            get
            {
                return Drons.Where(d => !d.IsActivated);
            }
        }

        public IEnumerable<DronVm> ActivatedDrons
        {
            get
            {
                return Drons.Where(d => d.IsActivated);
            }
        }

        public Point MapPosition
        {
            get
            {
                return _mapPosition;
            }

            set
            {
                _mapPosition = value;
            }
        }

        public Size MapSize
        {
            get
            {
                return _mapSize;
            }

            set
            {
                _mapSize = value;
                OnPropertyChanged(nameof(MapSize));
            }
        }

        public Size WindowSize
        {
            get
            {
                return _windowSize;
            }

            set
            {
                _windowSize = value;
                OnPropertyChanged(nameof(WindowSize));
            }
        }

        public double WindowWidth
        {
            get
            {
                return _windowWidth;
            }

            set
            {
                _windowWidth = value;
                OnPropertyChanged(nameof(WindowWidth));
            }
        }

        public double WindowHeight
        {
            get
            {
                return _windowHeight;
            }

            set
            {
                _windowHeight = value;
                OnPropertyChanged(nameof(WindowHeight));
            }
        }

        private void Dron_ActivatedChanged(DronVm obj)
        {
            var canActivate = ActivatedDrons.Count() < 3;
            foreach (var dron in DisactivatedDrons)
                dron.CanActivate = canActivate;
            if (obj.IsActivated)
                Map.MapObjects.Add(obj);
            else
                Map.MapObjects.Remove(obj);
        }
    }
}
