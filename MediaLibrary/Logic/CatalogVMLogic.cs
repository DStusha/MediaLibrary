using MediaLibrary.Extensions;
using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.DataServices;
using System.Collections.ObjectModel;

namespace MediaLibrary.Logic
{
    public static class CatalogVMLogic
    {
        public static ObservableCollection<CatalogViewModel> GetCatalogViewModels()
        {
            return CatalogService.GetCatalogs().ToCatalogViewModelCollection(out bool flag);
        }
    }
}
