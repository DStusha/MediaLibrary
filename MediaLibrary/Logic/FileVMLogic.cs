using MediaLibrary.ViewModels;
using MediaLibrary.Extensions;
using System.Collections.ObjectModel;
using MediaLibraryDataAccess.DataServices;
using System.IO;
using MediaLibraryDataAccess;
using System.Windows.Media.Imaging;
using System;

namespace MediaLibrary.Logic
{
    public static class FileVMLogic
    {
        public static ObservableCollection<FileViewModel> GetFiles(string directoryName)
        {
            return FileService.GetFiles(directoryName).ToFileViewModelCollection();
        }

        public static ObservableCollection<FileViewModel> GetFiles(int id)
        {
            return FileService.GetFiles(id).ToFileViewModelCollection();
        }

        public static void SaveFileToDB(FileViewModel file, int id)
        {
            file.IdCategory = id;
            FileService.SaveFile(file.ToFileModel());        
        }

        public static string CreateTempFile(FileViewModel file)
        {
            if (File.Exists(file.FullName)) return file.FullName;
            return FileService.CreateTempFile(file.FullName, file.Content);
        }

        public static void SetMediaSource(FileViewModel file)
        {
            try
            {
                ClearSource();
                switch ((file as FileViewModel).Type)
                {
                    case FileTypesConstants.Audio:
                        MainWindowViewModel.Media.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/playmusic.png"));
                        MainWindowViewModel.Media.MediaElementSource = CreateTempFile(file);
                        break;
                    case FileTypesConstants.Video:
                        MainWindowViewModel.Media.IsVisible = true;
                        MainWindowViewModel.Media.MediaElementSource = CreateTempFile(file);
                        break;
                    case FileTypesConstants.Image:
                        MainWindowViewModel.Media.ImageSource = new BitmapImage(new Uri(CreateTempFile(file)));
                        break;                   
                }               
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex.StackTrace);
            }
        }

        public static void ClearSource()
        {
            MainWindowViewModel.Media.MediaElementSource = null;
            MainWindowViewModel.Media.ImageSource = null;
            MainWindowViewModel.Media.IsPause = false;
            MainWindowViewModel.Media.IsImageSourceSet = false;
            MainWindowViewModel.Media.IsMediaSourceSet = false;
            MainWindowViewModel.Media.IsVisible = false ;
        }

        public static bool IsFileExistsInDb(FileViewModel file)
        {
            if (file.IdCategory == 0)
            {
                return FileService.IsFileExists(file.ToFileModel());
            }
            else return true;
        }
    }
}
