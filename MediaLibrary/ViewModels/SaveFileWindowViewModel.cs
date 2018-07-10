using MediaLibrary.Logic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace MediaLibrary.ViewModels
{
    public class SaveFileWindowViewModel: BaseViewModel
    {
        private ObservableCollection<MediaTypeViewModel> types;
        private FileViewModel file;
        public ICommand Save { get; private set; }
        public ICommand Click { get; private set; }

        public ObservableCollection<MediaTypeViewModel> Types
        {
            get { return types; }
            set
            {
                types = value;
                OnPropertyChanged("Types");
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

        public SaveFileWindowViewModel() : this(null) { }

        public SaveFileWindowViewModel(FileViewModel f)
        {
            Types = MediaTypeVMLogic.GetMediaTypeViewModels();
            Save = new Command(SaveFile);
            Click = new Command(ButtonClick);
            file = f;
        }

        public void ButtonClick(object parameter)
        {
            (parameter as Window).DialogResult = true;
        }

        public void SaveFile(object parameter)
        {
            FileVMLogic.SaveFileToDB(file, (int)parameter);
        }
    }
}
