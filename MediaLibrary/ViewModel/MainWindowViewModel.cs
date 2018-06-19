using MediaLibrary.Model;
using MediaLibrary.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MediaLibrary.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        string selectedCatalogPath;
        string selectedCategoryPath;
        public IEnumerable<object> CatalogsRoot { get; set; }
        public IEnumerable<object> CategoriesRoot { get; set; }
        public ICommand UnloadedCommand { get; private set; }
        public ICommand LoadedCommand { get; private set; }
        public ICommand TreeViewCatalogExpandedCommand { get; private set; }
        public ICommand SelectedCatalogCommand { get; private set; }

        public string SelectedCatalogPath
        {
            get { return selectedCatalogPath; }
            set
            {
                selectedCatalogPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCatalogPath"));
            }
        }

        public string SelectedCategoryPath
        {
            get { return selectedCategoryPath; }
            set
            {
                selectedCategoryPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCategoryPath"));
            }
        }

        public MainWindowViewModel()
        {
            CategoriesRoot = new ObservableCollection<MediaType>();
            using (MediaLibraryContext db = new MediaLibraryContext())
            {
                CategoriesRoot = db.MediaTypes.Include(m=>m.Categories).ToList();
            }
            CatalogsRoot = new ObservableCollection<Catalog>();
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    Catalog c = new Catalog();
                    c.Name = drive.ToString();
                    c.Directory = drive.RootDirectory;
                    c.Files = (c.Directory.EnumerateFiles() as ObservableCollection<FileInfo>);
                    c.Catalogs = GetCatalogs(drive);
                    (CatalogsRoot as ObservableCollection<Catalog>).Add(c);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            UnloadedCommand = new Command(Unloaded);
            LoadedCommand = new Command(Loaded);
            TreeViewCatalogExpandedCommand = new Command(CatalogExpanded);
            SelectedCatalogCommand = new Command(SelectedCatalog);
        }

        private ObservableCollection<Catalog> GetCatalogs(object o)
        {
            ObservableCollection<Catalog> result = new ObservableCollection<Catalog>();
            DirectoryInfo dir;
            if (o is DriveInfo)
            {
                DriveInfo d = o as DriveInfo;
                dir = d.RootDirectory;
            }
            else
            {
                dir = o as DirectoryInfo;
            }
            try
            {
                foreach (DirectoryInfo directoryinfo in dir.EnumerateDirectories())
                {
                    Catalog ctlg = new Catalog();
                    ctlg.Catalogs = GetCatalogs(directoryinfo);
                    ctlg.Name = directoryinfo.Name;
                    ctlg.Files = (directoryinfo.EnumerateFiles() as ObservableCollection<FileInfo>);
                    result.Add(ctlg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            return result;
        }

        private void CatalogExpanded()
        {

        }

        private void SelectedCatalog(object item)
        {
            TreeViewItem selectedItem = (TreeViewItem)item;
        }

        private void Unloaded()
        {
            Properties.Settings.Default.CatalogPath = selectedCatalogPath;
            Properties.Settings.Default.CategoryPath = selectedCategoryPath;
            Properties.Settings.Default.Save();
        }

        public void Loaded()
        {
            SelectedCatalogPath = Properties.Settings.Default.CatalogPath;
            SelectedCategoryPath = Properties.Settings.Default.CategoryPath;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
