using MediaLibrary.Models;
using MediaLibrary.Commands;
using System;
using System.Windows.Input;

namespace MediaLibrary.ViewModels
{
    public class FileViewModel : BaseViewModel
    {
        File file;
        Uri mediaElementSourse;
        public ICommand PlayFileCommand { get; private set; }
        public ICommand SaveFileCommand { get; private set; }

        public File File
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

        public FileViewModel()
        {
            PlayFileCommand = new Command(Play, CanPlay);
            SaveFileCommand = new OpenWindowCommand(CanSave);
        }

        private void Play(object file)
        {
            if(file is File && (file as File).Type != FileTypesConstants.Other) {
                mediaElementSourse = new Uri((file as File).FullName);
            }
        }

        private bool CanPlay(object file)
        {
            if (file is File) {
                return ((file as File).Type != FileTypesConstants.Other);           
            }
            return false;
        }

        private bool CanSave(object file)
        {
            if (file is File && (file as File).Type != FileTypesConstants.Other) {
                return !DBManager.IsFileExists(file as File);
            }
            return false;
        }
    }
}
