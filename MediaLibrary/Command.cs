using MediaLibrary.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace MediaLibrary
{
    public class Command:ICommand
    {
        bool isAsync;
        protected Action action;
        protected Action<object> parameterizedAction;
        Func<object, bool> canExecuteFunc;

        public Command(Action action)
        {
            this.action = action;
        }

        public Command(Action<object> parameterizedAction) :this(parameterizedAction, null,false) { }

        public Command(Action<object> parameterizedAction, Func<object, bool> canExecuteFunc) : this(parameterizedAction, canExecuteFunc, false) { }

        public Command(Action<object> parameterizedAction, Func<object, bool> canExecuteFunc, bool isasync)
        {
            this.canExecuteFunc = canExecuteFunc;
            this.parameterizedAction = parameterizedAction;
            isAsync = isasync;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecuteFunc != null)
            {
                return canExecuteFunc(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            if (!isAsync)
            {
                action?.Invoke();
                parameterizedAction?.Invoke(parameter);
            }
            else
            {
                AsyncExecute(parameter);
            }
        }


        private async void AsyncExecute(object parameter)
        {
            var displayRootRegistry = (Application.Current as App).displayRootRegistry;
            var saveFileViewModel = new SaveFileWindowViewModel(parameter as FileViewModel);
            await displayRootRegistry.ShowModalPresentation(saveFileViewModel);
        }
    }
}