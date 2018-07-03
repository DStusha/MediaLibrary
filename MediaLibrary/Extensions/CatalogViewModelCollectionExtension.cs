using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.Models;
using System.Collections.Generic;

namespace MediaLibrary.Extensions
{
    public static class CatalogViewModelCollectionExtension
    {
        public static List<CatalogViewModel> ToCatalogViewModelCollection(this ICollection<Catalog> list)
        {
            List<CatalogViewModel> collection = new List<CatalogViewModel>();
            if (list != null)
            {
                foreach (Catalog c in list)
                {
                    collection.Add(c.ToCatalogViewModel());
                }
            }
            return collection;
        }
    }
}
