using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UFODronner.Utils
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event Action<object> Executed;
        public event Func<object, bool> Predicate;

        public event EventHandler CanExecuteChanged;

        public RelayCommand() { }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return Predicate?.Invoke(parameter) ?? true;
            //return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            Executed?.Invoke(parameter);
        }

        public void RaiseCanExecute()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
