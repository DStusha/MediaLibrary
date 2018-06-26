using MediaLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace MediaLibrary
{
    public static class DirectoryAndFileManager
    {
        public static String GetTypeByCategory(string typeName)
        {
            switch (typeName)
            {
                case "Видеофайлы": return FileTypesConstants.Video;
                case "Аудиофайлы": return FileTypesConstants.Audio;
                case "Изображения": return FileTypesConstants.Image;
                default: return FileTypesConstants.Other;
            }
        }

        public static ObservableCollection<CatalogViewModel> GetCatalogViewModelCollection()
        {
            ObservableCollection<CatalogViewModel> catalogs = new ObservableCollection<CatalogViewModel>();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                try
                {
                    CatalogViewModel c = new CatalogViewModel()
                    {
                        CatalogName = drive.ToString()
                    };
                    c.Files = GetFileViewModelCollection(drive.RootDirectory.EnumerateFiles());
                    c.CatalogChildren = GetCatalogs(drive);
                    catalogs.Add(c);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex.StackTrace);
                }
            }
            return catalogs;
        }

        private static ObservableCollection<FileViewModel> GetFileViewModelCollection(IEnumerable<FileInfo> files)
        {
            ObservableCollection<FileViewModel> res = new ObservableCollection<FileViewModel>();
            foreach (FileInfo f in files)
            {
                try
                {
                    FileViewModel fileViewModel = new FileViewModel()
                    {
                        File = new Models.File()
                        {
                            Name = f.Name,
                            Type = GetTypeByExtension(Path.GetExtension(f.Name)),
                            FullName = f.FullName
                        }
                    };
                    try
                    {
                        if (fileViewModel.File.Type != FileTypesConstants.Other)
                        {
                            using (FileStream fs = new FileStream(f.FullName, FileMode.OpenOrCreate, FileAccess.Read))
                            {
                                fileViewModel.File.Content = new byte[fs.Length];
                                fs.Read(fileViewModel.File.Content, 0, Convert.ToInt32(fs.Length));
                                fs.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message, ex.StackTrace);
                    }
                    res.Add(fileViewModel);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex.StackTrace);
                }
            }    
            return res;
        }

        private static String GetTypeByExtension(string extension)
        {
            string[] videoExtensionSet = new string[] { ".mp4", ".wmv", ".wmva", ".wmvc1" };
            string[] audioExtensionSet = new string[] { ".mp3", ".wav", ".wma" };
            string[] imageExtensionSet = new string[] { ".jpg", ".png", ".bmp", ".gif" };
            if (Array.IndexOf(videoExtensionSet, extension) != -1) return FileTypesConstants.Video;
            if (Array.IndexOf(audioExtensionSet, extension) != -1) return FileTypesConstants.Audio;
            if (Array.IndexOf(imageExtensionSet, extension) != -1) return FileTypesConstants.Image;
            return FileTypesConstants.Other;
        }

        private static ObservableCollection<CatalogViewModel> GetCatalogs(object o)
        {
            ObservableCollection<CatalogViewModel> result = new ObservableCollection<CatalogViewModel>();
            DirectoryInfo dir;
            if (o is DriveInfo)
            {
                DriveInfo d = o as DriveInfo;
                dir = d.RootDirectory;
            }
            else
            {
                dir = o as DirectoryInfo;
            }
            try
            {
                foreach (DirectoryInfo directoryinfo in dir.EnumerateDirectories())
                {
                    CatalogViewModel ctlg = new CatalogViewModel()
                    {
                        CatalogChildren = GetCatalogs(directoryinfo),
                        CatalogName = directoryinfo.Name
                    };
                    ctlg.Files = GetFileViewModelCollection(directoryinfo.EnumerateFiles());
                    result.Add(ctlg);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex.StackTrace);
            }
            return result;
        }
    }
}
