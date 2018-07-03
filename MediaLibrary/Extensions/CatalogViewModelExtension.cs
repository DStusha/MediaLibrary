using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.Models;

namespace MediaLibrary.Extensions
{
    public static class CatalogViewModelExtension
    {
        public static CatalogViewModel ToCatalogViewModel(this Catalog c)
        {
            CatalogViewModel cvm = new CatalogViewModel()
            {
                Name = c.Name,
                FullName = c.FullName,
                CatalogChildren =c.CatalogChildren.ToCatalogViewModelCollection() ,
                IsSelected = false
            };
            if (c.FullName == Properties.Settings.Default.CatalogPath) { cvm.IsSelected = true; }
            return cvm;
        }
    }
}
