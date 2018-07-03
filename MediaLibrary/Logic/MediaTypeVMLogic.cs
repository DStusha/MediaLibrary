using MediaLibrary.ViewModels;
using MediaLibraryDataAccess.DataServices;
using System.Collections.ObjectModel;
using MediaLibrary.Extensions;

namespace MediaLibrary.Logic
{
    public static class MediaTypeVMLogic
    {
        public static ObservableCollection<MediaTypeViewModel> GetMediaTypeViewModels()
        {
            return MediaTypeService.GetMediaTypes().ToMediaTypeViewModelCollection();
        }
    }
}
