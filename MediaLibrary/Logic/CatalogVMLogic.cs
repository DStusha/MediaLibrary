using MediaLibrary.ViewModels;
using MediaLibrary.Extensions;
using MediaLibraryDataAccess.DataServices;
using System.Collections.Generic;

namespace MediaLibrary.Logic
{
    public static class CatalogVMLogic
    {
        public static List<CatalogViewModel> GetCatalogViewModels()
        {
            return CatalogService.GetCatalogs().ToCatalogViewModelCollection();
        }
    }
}
