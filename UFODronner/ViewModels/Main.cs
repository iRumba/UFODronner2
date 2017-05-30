using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UFODronner.Models;
using UFODronner.Utils;

namespace UFODronner.ViewModels
{
    public class Main : Notifier
    {
        AppModel _source;

        double _windowWidth;
        double _windowHeight;

        public WorkFlow WorkFlow { get; set; }

        public RelayCommand AddDronCommand { get; set; }


        [Obsolete]
        public List<DronVm> Drons { get; }

        public MapVm Map { get; }

        [Obsolete]
        public ObservableCollection<CoordObject> MapObjects { get; set; }

        public Main()
        {
            _source = new AppModel();
            
            AddDronCommand = new RelayCommand();
            AddDronCommand.Predicate += AddDronCommand_Predicate;
            AddDronCommand.Executed += AddDronCommand_Executed;

            _source.DronAdded += _source_DronAdded;
            _source.DronRemoved += _source_DronRemoved;

            Map = new MapVm(new Map { Width = 250, Height=250 })
            {
                X = 20,
                Y = 20,
                Scale = 2
            };
            WindowWidth = 1000;
            WindowHeight = 800;
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

        private void _source_DronRemoved(Dron obj)
        {
            AddDronCommand.RaiseCanExecute();
        }

        private void _source_DronAdded(Dron obj)
        {
            AddDronCommand.RaiseCanExecute();
        }

        private void AddDronCommand_Executed(object obj)
        {
            var dron = obj as Dron;
            if (dron == null)
                dron = new Dron();
            _source.AddDron(dron);
        }

        private bool AddDronCommand_Predicate(object arg)
        {
            return _source.CanAdd;
        }

        [Obsolete]
        public IEnumerable<DronVm> DisactivatedDrons
        {
            get
            {
                return Drons.Where(d => !d.IsActivated);
            }
        }

        [Obsolete]
        public IEnumerable<DronVm> ActivatedDrons
        {
            get
            {
                return Drons.Where(d => d.IsActivated);
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

        [Obsolete]
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
