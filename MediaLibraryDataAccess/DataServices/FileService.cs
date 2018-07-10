using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MediaLibraryDataAccess.DataServices
{
    public static class FileService
    {
        public static String GetFileTypeByExtension(string ext)
        {
            string extension = ext.ToLower();
            string[] videoExtensionSet = new string[] { ".mp4", ".wmv", ".wmva", ".wmvc1" };
            string[] audioExtensionSet = new string[] { ".mp3", ".wav", ".wma" };
            string[] imageExtensionSet = new string[] { ".jpg", ".png", ".bmp", ".gif" };
            if (Array.IndexOf(videoExtensionSet, extension) != -1) return FileTypesConstants.Video;
            if (Array.IndexOf(audioExtensionSet, extension) != -1) return FileTypesConstants.Audio;
            if (Array.IndexOf(imageExtensionSet, extension) != -1) return FileTypesConstants.Image;
            return FileTypesConstants.Other;
        }

        public static void SaveFile(Models.File file)
        {
            using (MediaLibraryContext db = new MediaLibraryContext())
            {
                db.Files.Add(file);
                db.SaveChanges();
            }
        }

        public static List<Models.File> GetFiles(int id)
        {
            using (MediaLibraryContext db = new MediaLibraryContext())
            {
                return db.Files.Where(f => f.Id_category == id).ToList();
            }
        }

        public static bool IsFileExists(Models.File file)
        {
            using (MediaLibraryContext db = new MediaLibraryContext())
            {
                return db.Files.Any(f => f.Name==file.Name && f.Extension==file.Extension);
            }
        }

        public static string CreateTempFile(string name, byte[] content)
        {
            string path = Path.GetTempPath() + Path.DirectorySeparatorChar + name;
            if(!File.Exists(path))File.WriteAllBytes(path, content);
            return path;
        }

        public static byte[] GetContent(string fullName)
        {
            try
            {
                using (FileStream fs = new FileStream(fullName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    byte[] res = new byte[fs.Length];
                    fs.Read(res, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    return res;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex.StackTrace);
                return null;
            }
        }

        public static List<Models.File> GetFiles(string directoryName)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(directoryName);
                return GetFiles(dir.EnumerateFiles());
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex.StackTrace);
                return null;
            }
        }

        public static List<Models.File> GetFiles(IEnumerable<FileInfo> files)
        {
            List<Models.File> res = new List<Models.File>();
            foreach (FileInfo f in files)
            {
                try
                {
                    Models.File file = new Models.File()
                    {
                        Name = f.FullName,
                        Extension = f.Extension
                    };
                    res.Add(file);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex.StackTrace);
                }
            }
            return res;
        }

    }
}
