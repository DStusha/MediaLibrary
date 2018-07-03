using MediaLibrary.Commands;
using MediaLibrary.Logic;
using MediaLibraryDataAccess;
using System;
using System.Windows.Input;

namespace MediaLibrary.ViewModels
{
    public class FileViewModel : BaseViewModel
    {
        FileViewModel file;
        Uri mediaElementSourse;
        Uri imageSourse;
        public string Type { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public string FullName { get; set; }
        public ICommand PlayFileCommand { get; private set; }
        public ICommand SaveFileCommand { get; private set; }

        public FileViewModel File
        {
            get { return file; }
            set
            {
                file = value;
                OnPropertyChanged("File");
            }
        }

        public Uri MediaElementSourse
        {
            get { return mediaElementSourse; }
            set
            {
                mediaElementSourse = value;
                OnPropertyChanged("MediaElementSourse");
            }
        }

        public Uri ImageSourse
        {
            get { return imageSourse; }
            set
            {
                imageSourse = value;
                OnPropertyChanged("ImageSourse");
            }
        }

        public FileViewModel()
        {
            PlayFileCommand = new Command(Play, CanPlay);
            SaveFileCommand = new OpenWindowCommand(CanSave);
            File = this;
        }

        private void Play(object file)
        {
            try
            {
                if (file is FileViewModel && (file as FileViewModel).Type != FileTypesConstants.Other)
                {
                    if ((file as FileViewModel).Type == FileTypesConstants.Image)
                    {
                        ImageSourse = new Uri(FileVMLogic.CreateTempFile((file as FileViewModel)));
                    }
                    else
                    {
                        mediaElementSourse = new Uri(FileVMLogic.CreateTempFile((file as FileViewModel)));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex.StackTrace);
            }
        }

        private bool CanPlay(object file)
        {
            if (file is FileViewModel) {
                return ((file as FileViewModel).Type != FileTypesConstants.Other);           
            }
            return false;
        }

        private bool CanSave(object file)
        {
            if (file is FileViewModel && (file as FileViewModel).Type != FileTypesConstants.Other) {
                return !FileVMLogic.IsFileExists(file as FileViewModel);
            }
            return false;
        }
    }
}
