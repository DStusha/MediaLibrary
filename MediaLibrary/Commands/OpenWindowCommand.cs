using MediaLibrary.Models;
using MediaLibrary.ViewModels;
using System;
using System.Windows;

namespace MediaLibrary.Commands
{
    public class OpenWindowCommand : MyCommand
    {
        public OpenWindowCommand(Func<object, bool> canExecuteFunc) : base(null, canExecuteFunc) { }

        public override async void Execute(object parameter)
        { 
            var displayRootRegistry = (Application.Current as App).displayRootRegistry;
            var saveFileViewModel = new SaveFileWindowViewModel(parameter as File);
            await displayRootRegistry.ShowModalPresentation(saveFileViewModel);
        }
    }
}
