using System;

namespace MediaLibrary.Commands
{
    public class Command:MyCommand
    {
        public Command(Action action) : base(action) { }
        public Command(Action<object> parameterizedAction) : this(parameterizedAction, null) { }
        public Command(Action<object> parameterizedAction, Func<object,bool> canExecuteFunc):base(parameterizedAction, canExecuteFunc) { }

        public override void Execute(object parameter)
        {
            action?.Invoke();
            parameterizedAction?.Invoke(parameter);
        }
    }
}
