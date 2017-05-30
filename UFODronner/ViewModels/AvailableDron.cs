using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFODronner.ViewModels
{
    public class AvailableDron : Notifier
    {
        bool _inAction;

        public bool InAction
        {
            get
            {
                return _inAction;
            }

            set
            {
                _inAction = value;
                OnPropertyChanged(nameof(InAction));
            }
        }
    }
}
