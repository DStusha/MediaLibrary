using System.Collections.ObjectModel;

namespace MediaLibrary.ViewModels
{
    public class MediaTypeViewModel: BaseViewModel
    {
        string mediaTypeName;
        ObservableCollection<CategoryViewModel> categories;

        public MediaTypeViewModel()
        {
            Categories = new ObservableCollection<CategoryViewModel>();
        }

        public string MediaTypeName
        {
            get { return mediaTypeName; }
            set
            {
                mediaTypeName = value;
                OnPropertyChanged("MediaTypeName");
            }
        }

        public ObservableCollection<CategoryViewModel> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }
    }
}
