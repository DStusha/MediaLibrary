using System.Collections.ObjectModel;
using System.Windows.Input;
using MediaLibrary.Commands;
using MediaLibrary.Logic;
using System.Collections.Generic;
using System;

namespace MediaLibrary.ViewModels
{
    public class TreeViewModel: BaseViewModel
    {
        ObservableCollection<FileViewModel> selectedValue;
        public string CatalogPath { get; set; }
        public int CategoryId { get; set; }
        public List<CatalogViewModel> CatalogsRoot { get; set; }
        public ObservableCollection<MediaTypeViewModel> CategoriesRoot { get; set; }
        public ICommand SelectedCommand { get; private set; }
        public ICommand UnloadedCommand { get; private set; }
        public ICommand TabSelectedCommand { get; private set; }

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
            CatalogsRoot = CatalogVMLogic.GetCatalogViewModels();
            CategoriesRoot = MediaTypeVMLogic.GetMediaTypeViewModels();
            SelectedCommand = new Command(SelectedCatalog);
            UnloadedCommand = new Command(Unloaded);
            TabSelectedCommand = new Command(TabSelected);
        }

        public void Unloaded()
        {
            Properties.Settings.Default.CatalogPath = CatalogPath;
            Properties.Settings.Default.CategoryId = CategoryId;
            Properties.Settings.Default.Save();
        }

        public void TabSelected(object obj)
        {
            if((int)obj == 0)
            {
                if (!String.IsNullOrEmpty(CatalogPath))
                {
                    SelectedValue = FileVMLogic.GetFiles(CatalogPath);
                }
                else
                {
                    SelectedValue = null;
                }
            }
            else
            {
                if (CategoryId != 0)
                {
                    SelectedValue = FileVMLogic.GetFiles(CategoryId);
                }
                else
                {
                    SelectedValue = null;
                }
            }
        }

        public void SelectedCatalog(object obj)
        {
            if (obj is string)
            {
                CatalogPath = obj.ToString();
                SelectedValue = FileVMLogic.GetFiles(CatalogPath);                
            }
            else
            {
                if(obj is int)
                {
                    CategoryId = (int)obj;
                    SelectedValue = FileVMLogic.GetFiles(CategoryId);
                }
                else { SelectedValue = null; }
            }                 
        }
    }
}
