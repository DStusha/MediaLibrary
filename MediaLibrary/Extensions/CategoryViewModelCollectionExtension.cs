using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MediaLibrary.Extensions
{
    public static class CategoryViewModelCollectionExtension
    {
        public static ObservableCollection<CategoryViewModel> ToCategoryViewModelCollection(this ICollection<Category> list, out bool isParentExpanded)
        {
            bool isChildSelected;
            isParentExpanded = false;
            ObservableCollection<CategoryViewModel> collection = new ObservableCollection<CategoryViewModel>();
            foreach(Category c in list)
            {                
                collection.Add(c.ToCategoryViewModel(out isChildSelected));
                if (!isParentExpanded) isParentExpanded = isChildSelected;
            }
            return collection;
        }
    }
}
