using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using UFODronner.Models;

namespace UFODronner.ViewModels
{
    public class WorkFlow : Notifier
    {
        Point _cursorPoint;
        Point _globalCursorPoint;
        //Dictionary<NamedDron, DronVm> _dronsDic;

        System.Drawing.Color _cursorPixel;

        ObservableCollection<DronVm> _drons;
        public ReadOnlyObservableCollection<DronVm> Drons { get; set; }

        public WorkFlow()
        {
            _drons = new ObservableCollection<DronVm>();
            Drons = new ReadOnlyObservableCollection<DronVm>(_drons);
            //_dronsDic = new Dictionary<Dron, DronVm>();
        }

        public Point CursorPoint
        {
            get
            {
                return _cursorPoint;
            }

            set
            {
                _cursorPoint = value;
                OnPropertyChanged(nameof(CursorPoint));
            }
        }

        public System.Drawing.Color CursorPixel
        {
            get
            {
                return _cursorPixel;
            }

            set
            {
                _cursorPixel = value;
                OnPropertyChanged(nameof(CursorPixel));
            }
        }

        public Point GlobalCursorPoint
        {
            get
            {
                return _globalCursorPoint;
            }

            set
            {
                _globalCursorPoint = value;
                OnPropertyChanged(nameof(GlobalCursorPoint));
            }
        }

        //public void AddDron(Dron dron)
        //{
        //    var dronVm = new DronVm(dron);
        //    _dronsDic[dron] = dronVm;
        //    _drons.Add(dronVm);
        //}

        //public void RemoveDron(Dron dron)
        //{
        //    var dronVm = _dronsDic[dron];
        //    _dronsDic.Remove(dron);
        //    _drons.Remove(dronVm);
        //}
    }
}
