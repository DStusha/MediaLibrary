using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.Models;

namespace MediaLibrary.Extensions
{
    public static class CategoryViewModelExtension
    {
        public static CategoryViewModel ToCategoryViewModel(this Category c)
        {
            CategoryViewModel cvm = new CategoryViewModel()
            {
                Name = c.Category_name,
                Id = c.Id,
                IsSelected = false
            };
            if(cvm.Id == Properties.Settings.Default.CategoryId) { cvm.IsSelected = true; }
            return cvm;
        }
    }
}
