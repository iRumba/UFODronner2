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

        public RelayCommand MoveMapCommand { get; set; }
        public RelayCommand ShowHelpCommand { get; set; }
        public RelayCommand OpenUrl { get; set; }

        [Obsolete]
        public WorkFlow WorkFlow { get; set; }

        public RelayCommand AddDronCommand { get; set; }

        public List<DonateItem> DonateValues { get; set; }

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

            MoveMapCommand = new RelayCommand();
            MoveMapCommand.Predicate += MoveMapCommand_Predicate;
            MoveMapCommand.Executed += MoveMapCommand_Executed;

            ShowHelpCommand = new RelayCommand();
            ShowHelpCommand.Executed += ShowHelpCommand_Executed;

            OpenUrl = new RelayCommand();
            OpenUrl.Executed += OpenUrl_Executed;

            DonateValues = new List<int> { 5, 10, 15, 20, 0 }.Select(i => new DonateItem { Value = i }).ToList();

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
                new DronVm(new Dron1() { X = 100, Y = 100 }),
                new DronVm(new Dron1() { X = 100, Y = 100 }),
                new DronVm(new Dron2() { X = 100, Y = 100 }),
                new DronVm(new Dron2() { X = 100, Y = 100 }),
                new DronVm(new Dron2() { X = 100, Y = 100 })
            };
            foreach(var dron in Drons)
            {
                dron.ActivatedChanged += Dron_ActivatedChanged;
            }
            WorkFlow = new WorkFlow();
        }

        private void OpenUrl_Executed(object obj)
        {
            var url = obj as string;
            if (!string.IsNullOrWhiteSpace(url))
                System.Diagnostics.Process.Start(url);
        }

        private void ShowHelpCommand_Executed(object obj)
        {
            foreach(Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(WndHelp))
                {
                    if (!window.IsVisible)
                        window.Show();
                    window.Activate();
                    return;
                }
            }
            new WndHelp().Show();
        }

        private void MoveMapCommand_Executed(object obj)
        {
            var dir = obj as string;
            if (dir != null)
            {
                switch (dir.ToLower())
                {
                    case "l":
                        Map.X -= 1;
                        break;
                    case "t":
                        Map.Y -= 1;
                        break;
                    case "r":
                        Map.X += 1;
                        break;
                    case "b":
                        Map.Y += 1;
                        break;
                    default:
                        break;
                }
            }
        }

        private bool MoveMapCommand_Predicate(object arg)
        {
            var dir = arg as string;
            if (dir != null)
            {
                switch (dir.ToLower())
                {
                    case "l":
                        break;
                    case "t":
                        break;
                    case "r":
                        break;
                    case "b":
                        break;
                    default:
                        break;
                }
            }
            return true;
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
