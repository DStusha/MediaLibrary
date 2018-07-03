using MediaLibraryDataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MediaLibraryDataAccess.DataServices
{
    public static class CatalogService
    {
        public static List<Catalog> GetCatalogs()
        {
            List<Catalog> catalogs = new List<Catalog>();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                try
                {
                    Catalog c = new Catalog()
                    {
                        Name = drive.ToString(),
                        FullName = drive.RootDirectory.FullName,
                        CatalogChildren = GetCatalogs(drive)
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

        private static List<Catalog> GetCatalogs(object o)
        {
            List<Catalog> result = new List<Catalog>();
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
            foreach (DirectoryInfo directoryinfo in dir.EnumerateDirectories())
            {
                try
                {
                    Catalog ctlg = new Catalog()
                    {
                        CatalogChildren = GetCatalogs(directoryinfo),
                        Name = directoryinfo.Name,
                        FullName = directoryinfo.FullName
                    };
                    result.Add(ctlg);

                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex.StackTrace);
                }
            }
            return result;
        }
    }
}
