using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MediaLibrary.Extensions
{
    public static class CatalogViewModelCollectionExtension
    {
        public static ObservableCollection<CatalogViewModel> ToCatalogViewModelCollection(this ICollection<Catalog> list, out bool isParentExpanded)
        {
            bool isChildSelected;
            isParentExpanded = false;
            ObservableCollection<CatalogViewModel> collection = new ObservableCollection<CatalogViewModel>();
            if (list != null)
            {
                foreach (Catalog c in list)
                {
                    collection.Add(c.ToCatalogViewModel(out isChildSelected));
                    if (!isParentExpanded) isParentExpanded = isChildSelected;
                }
            }
            return collection;
        }
    }
}
