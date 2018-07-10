using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.Models;

namespace MediaLibrary.Extensions
{
    public static class MediaTypeViewModelExtension
    {
        public static MediaTypeViewModel ToMediaTypeViewModel(this MediaType m)
        {
            bool isExpanded;
            return new MediaTypeViewModel()
            {
                MediaTypeName = m.Type_name,
                Categories = m.Categories.ToCategoryViewModelCollection(out isExpanded),
                IsExpanded = isExpanded
            };
        }
    }
}
