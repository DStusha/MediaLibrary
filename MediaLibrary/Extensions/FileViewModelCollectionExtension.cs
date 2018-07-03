using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MediaLibrary.Extensions
{
    public static class FileViewModelCollectionExtension
    {
        public static ObservableCollection<FileViewModel> ToFileViewModelCollection(this ICollection<File> list)
        {
            ObservableCollection<FileViewModel> collection = new ObservableCollection<FileViewModel>();
            if (list != null)
            {
                foreach (File f in list)
                {
                    collection.Add(f.ToFileViewModel());
                }
            }
            return collection;
        }
    }
}
