using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.Models;

namespace MediaLibrary.Extensions
{
    public static class CatalogViewModelExtension
    {
        public static CatalogViewModel ToCatalogViewModel(this Catalog c, out bool isSelected)
        {
            bool isExpanded;
            CatalogViewModel cvm = new CatalogViewModel()
            {
                Name = c.Name,
                FullName = c.FullName,
                CatalogChildren = c.CatalogChildren.ToCatalogViewModelCollection(out isExpanded)
            };
            cvm.IsSelected = cvm.FullName == Properties.Settings.Default.CatalogPath;
            isSelected = cvm.IsSelected|isExpanded;
            cvm.IsExpanded = isExpanded;
            return cvm;
        }
    }
}
