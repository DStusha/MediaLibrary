using System;
using System.Windows.Input;

namespace MediaLibrary.Commands
{
    public abstract class MyCommand:ICommand
    {
        protected Action action;
        protected Action<object> parameterizedAction;
        Func<object, bool> canExecute;

        public MyCommand(Action action)
        {
            this.action = action;
        }

        public MyCommand(Action<object> action, Func<object, bool> canExecuteFunc)
        {
            canExecute = canExecuteFunc;
            parameterizedAction = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public  bool CanExecute(object parameter)
        {
            if (canExecute != null)
            {
                return canExecute(parameter);
            }
            return true;
        }

        public abstract void Execute(object parameter);
    }
}
