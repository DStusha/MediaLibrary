using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MediaLibrary.ViewModels
{
    public class CatalogViewModel:BaseViewModel
    {
        string name;
        string fullName;
        bool isSelected;
        bool isExpanded;
        public List<CatalogViewModel> CatalogChildren { get; set; }

        public CatalogViewModel()
        {
            CatalogChildren = new List<CatalogViewModel>();
        }

        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }  
    }
}
