using System.Windows.Input;
using MediaLibrary.Commands;

namespace MediaLibrary.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        TreeViewModel trees;
        FileViewModel file;
        public ICommand UnloadedCommand { get; private set; }
        public ICommand LoadedCommand { get; private set; }

        public TreeViewModel Trees
        {
            get { return trees; }
            set
            {
                trees = value;
                OnPropertyChanged("Trees");
            }
        }

        public FileViewModel File
        {
            get { return file; }
            set
            {
                file = value;
                OnPropertyChanged("File");
            }
        }

        public MainWindowViewModel()
        {
            Trees = new TreeViewModel();
            File = new FileViewModel();
            UnloadedCommand = new Command(Unloaded);
            LoadedCommand = new Command(Loaded);
        }

        private void Unloaded() { }
        private void Loaded() { }
    }
}
