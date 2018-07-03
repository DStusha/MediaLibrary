using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MediaLibrary.Extensions
{
    public static class MediaTypeViewModelCollectionExtension
    {
        public static ObservableCollection<MediaTypeViewModel> ToMediaTypeViewModelCollection(this ICollection<MediaType> list)
        {
            ObservableCollection<MediaTypeViewModel> collection = new ObservableCollection<MediaTypeViewModel>();
            foreach (MediaType mt in list)
            {
                collection.Add(mt.ToMediaTypeViewModel());
            }
            return collection;
        }
    }
}
