using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MediaLibrary.ViewModels
{
    public class MediaViewModel: BaseViewModel
    {
        string mediaElementSource;
        BitmapImage imageSource;
        bool isImageSourceSet;
        bool isMediaSourceSet;
        bool isVisible;
        public bool IsPause { get; set; }
        public ICommand PlayCommand { get; private set; }
        public ICommand PauseCommand { get; private set; }
        public ICommand StopCommand { get; private set; }

        public bool IsImageSourceSet
        {
            get { return isImageSourceSet; }
            set
            {
                isImageSourceSet = value;
                OnPropertyChanged("IsImageSourceSet");
            }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }

        public bool IsMediaSourceSet
        {
            get { return isMediaSourceSet; }
            set
            {
                isMediaSourceSet = value;
                OnPropertyChanged("IsMediaSourceSet");
            }
        }

        public string MediaElementSource
        {
            get { return mediaElementSource; }
            set
            {
                if (value != null) IsMediaSourceSet = true;
                mediaElementSource = value; 
                OnPropertyChanged("MediaElementSourse");
            }
        }

        public BitmapImage ImageSource
        {
            get { return imageSource; }
            set
            {
                if(value !=null)IsImageSourceSet = true;
                imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        public MediaViewModel()
        {
            PlayCommand = new Command(Play);
            PauseCommand = new Command(Pause);
            StopCommand = new Command(Stop);
        }

        private void Play(object elem)
        {
            if (elem is MediaElement)
            {
               if(!IsPause) (elem as MediaElement).Source = new Uri(MediaElementSource);
               (elem as MediaElement).Play(); 
            }
        }

        private void Pause(object elem)
        {
            if (elem is MediaElement)
            {
                (elem as MediaElement).Pause();
                IsPause = true;
            }
        }

        private void Stop(object elem)
        {
            if (elem is MediaElement)
            {
                (elem as MediaElement).Stop();
            }
        }

    }
}
