using MediaLibraryDataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;

namespace MediaLibraryDataAccess.DataServices
{
    public static class CatalogService
    {
        public static List<Catalog> GetCatalogs()
        {
            List<Catalog> catalogs = new List<Catalog>();
            foreach (DriveInfo drive in DriveInfo.GetDrives().Where(d => d.IsReady == true))
            {
                try
                {
                    Catalog c = new Catalog()
                    {
                        Name = drive.ToString(),
                        FullName = drive.RootDirectory.FullName,
                        CatalogChildren = GetCatalogs(drive.RootDirectory)
                    };               
                    catalogs.Add(c);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex.StackTrace);
                }
            }
            return catalogs;
        }

        private static List<Catalog> GetCatalogs(DirectoryInfo dir)
        {
            List<Catalog> result = new List<Catalog>();
            foreach (DirectoryInfo directoryinfo in dir.EnumerateDirectories("*.*", SearchOption.TopDirectoryOnly).Where(d => !d.Attributes.HasFlag(FileAttributes.Hidden | FileAttributes.System)&&d.GetAccess()))
            {
                try
                {
                    Catalog c = new Catalog()
                    { 
                        CatalogChildren = GetCatalogs(directoryinfo),
                        Name = directoryinfo.Name,
                        FullName = directoryinfo.FullName
                    };
                    result.Add(c);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex.StackTrace);
                }
            }
            return result;
        }
        
        private static bool GetAccess(this DirectoryInfo dir)
        {
            DirectorySecurity d = dir.GetAccessControl();
            var rules = d.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
            foreach (FileSystemAccessRule rule in rules)
            {
                if (!rule.FileSystemRights.HasFlag(FileSystemRights.ListDirectory))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
