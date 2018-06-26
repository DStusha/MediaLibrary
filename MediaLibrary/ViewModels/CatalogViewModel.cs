using System.Collections.ObjectModel;

namespace MediaLibrary.ViewModels
{
    public class CatalogViewModel:BaseViewModel
    {
        string catalogName;
        public ObservableCollection<CatalogViewModel> CatalogChildren { get; set; }
        public ObservableCollection<FileViewModel> Files { get; set; }

        public CatalogViewModel()
        {
            CatalogChildren = new ObservableCollection<CatalogViewModel>();
            Files = new ObservableCollection<FileViewModel>();
        }

        public string CatalogName
        {
            get { return catalogName; }
            set
            {
                catalogName = value;
                OnPropertyChanged("CatalogName");
            }
        }  
    }
}
