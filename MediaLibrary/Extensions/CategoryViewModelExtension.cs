using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.Models;

namespace MediaLibrary.Extensions
{
    public static class CategoryViewModelExtension
    {
        public static CategoryViewModel ToCategoryViewModel(this Category c, out bool isExpanded)
        {
            CategoryViewModel cvm = new CategoryViewModel()
            {
                Name = c.Category_name,
                Id = c.Id
            };
            isExpanded = cvm.IsSelected = (cvm.Id == Properties.Settings.Default.CategoryId); 
            return cvm;
        }
    }
}
