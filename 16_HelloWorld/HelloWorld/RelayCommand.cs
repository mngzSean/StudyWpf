using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloWorld
{
    class RelayCommand : ICommand
    {
        Action<object> _action;

        public RelayCommand(Action<object> action)
        {
            this._action = action;
        }

        //public event EventHandler? CanExecuteChanged;
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter == null)
                return false;

            if(parameter.ToString()!.Length == 0)
                return false;

            return true;
        }

        public void Execute(object? parameter)
        {
            _action(parameter);
        }
    }
}
