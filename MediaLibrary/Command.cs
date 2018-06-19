using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaLibrary
{
    public class Command:ICommand
    {
        private Action action;
        private Action<object> parameterizedAction;

        public Command(Action action)
        {
            this.action = action;
        }

        public Command(Action<object> action)
        {
            this.parameterizedAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (action != null)
            {
                action();
            }
        }
    }
}
