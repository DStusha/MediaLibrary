using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MediaLibrary.Commands;

namespace MediaLibrary.ViewModels
{
    public class TreeViewModel: BaseViewModel
    {
        ObservableCollection<FileViewModel> selectedValue;
        public ObservableCollection<CatalogViewModel> CatalogsRoot { get; set; }
        public ObservableCollection<MediaTypeViewModel> CategoriesRoot { get; set; }

        public ICommand SelectedCommand { get; private set; }

        public ObservableCollection<FileViewModel> SelectedValue
        {
            get { return selectedValue; }
            set
            {
                selectedValue = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public TreeViewModel()
        {
            CatalogsRoot = DirectoryAndFileManager.GetCatalogViewModelCollection();           
            CategoriesRoot = DBManager.GetMediaTypeViewModelsFromDB();
            SelectedCommand = new Command(SelectedCatalog);
        }

        public void SelectedCatalog(object value)
        {
            SelectedValue = value as ObservableCollection<FileViewModel>;
        }
    }
}
