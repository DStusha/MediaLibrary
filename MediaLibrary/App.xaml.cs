using MediaLibrary.ViewModels;
using MediaLibrary.Views;
using System.Windows;

namespace MediaLibrary
{
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();
        MainWindowViewModel mainWindowViewModel;
        public App()
        {
            displayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            displayRootRegistry.RegisterWindowType<SaveFileWindowViewModel, SaveFileWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            mainWindowViewModel = new MainWindowViewModel();
            await displayRootRegistry.ShowModalPresentation(mainWindowViewModel);
            Shutdown();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            mainWindowViewModel.Trees.Unloaded();
        }
    }
}
