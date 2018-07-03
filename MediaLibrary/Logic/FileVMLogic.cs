using MediaLibrary.ViewModels;
using MediaLibrary.Extensions;
using System.Collections.ObjectModel;
using MediaLibraryDataAccess.DataServices;
using System.IO;

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
            string path = Path.GetTempPath()+@"\" + file.Name;
            File.WriteAllBytes(path, file.Content);
            return path;
        }

        public static bool IsFileExists(FileViewModel file)
        {
            return FileService.IsFileExists(file.ToFileModel());
        }
    }
}
