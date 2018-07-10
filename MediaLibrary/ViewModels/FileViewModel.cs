using MediaLibrary.Logic;
using MediaLibraryDataAccess;
using System.Windows.Input;

namespace MediaLibrary.ViewModels
{
    public class FileViewModel : BaseViewModel
    {
        FileViewModel file;
        public string Type { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public string FullName { get; set; }
        public ICommand SaveFileCommand { get; private set; }
        public ICommand PlayFileCommand { get; private set; }

        public FileViewModel File
        {
            get { return file; }
            set
            {
                file = value;
                OnPropertyChanged("File");
            }
        }

        public FileViewModel()
        {
            SaveFileCommand = new Command(null,CanSave,true);
            PlayFileCommand = new Command(Play, CanPlay);
            File = this;
        }

        private void Play(object file)
        {
            FileVMLogic.SetMediaSource(file as FileViewModel);
        }

        private bool CanPlay(object file)
        {
            if (file is FileViewModel)
            {
                return ((file as FileViewModel).Type != FileTypesConstants.Other);
            }
            return false;
        }

        private bool CanSave(object file)
        {
            if (file is FileViewModel)
            {
                return (file as FileViewModel).Type != FileTypesConstants.Other && !FileVMLogic.IsFileExistsInDb(file as FileViewModel);
            }
            return false;
        }
    }
}
