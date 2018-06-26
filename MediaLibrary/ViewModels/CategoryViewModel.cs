using System.Collections.ObjectModel;

namespace MediaLibrary.ViewModels
{
    public class CategoryViewModel :BaseViewModel
    {
        string categoryName;
        public int Id { get; set; }
        public ObservableCollection<FileViewModel> Files { get; set; }

        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        public CategoryViewModel()
        {
            Files = new ObservableCollection<FileViewModel>();
        }
    }
}
