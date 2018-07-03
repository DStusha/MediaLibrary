using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.Models;

namespace MediaLibrary.Extensions
{
    public static class MediaTypeViewModelExtension
    {
        public static MediaTypeViewModel ToMediaTypeViewModel(this MediaType m)
        {
            return new MediaTypeViewModel()
            {
                MediaTypeName = m.Type_name,
                Categories = m.Categories.ToCategoryViewModelCollection()
            };
        }
    }
}
