using MediaLibrary.ViewModels;
using MediaLibraryDataAccess;
using MediaLibraryDataAccess.DataServices;
using System;
using System.IO;

namespace MediaLibrary.Extensions
{
    public static class FileViewModelExtension
    {
        public static FileViewModel ToFileViewModel(this MediaLibraryDataAccess.Models.File f)
        {
            FileViewModel file = new FileViewModel()
            {
               Name = Path.GetFileName(f.Name),
               FullName = f.Name,
               Type = FileService.GetFileTypeByExtension(f.Extension),
               IdCategory= f.Id_category
            };
            if (String.IsNullOrEmpty(Path.GetExtension(f.Name))){
                file.Name = f.Name + f.Extension;
            }
            if (file.Type != FileTypesConstants.Other)
            {
                file.Content = FileService.GetContent(file.FullName);
            }
            return file;
        }

        public static MediaLibraryDataAccess.Models.File ToFileModel(this FileViewModel fileModel)
        {
            FileInfo fileinf = new FileInfo(fileModel.FullName);
            return new MediaLibraryDataAccess.Models.File()
            {
                Name = Path.GetFileNameWithoutExtension(fileModel.FullName),
                Extension = Path.GetExtension(fileModel.Name),
                Content = fileModel.Content,
                Size = (int)fileinf.Length,
                Сreation_date = fileinf.CreationTime,
                Id_category = fileModel.IdCategory
            };
        }
    }
}
