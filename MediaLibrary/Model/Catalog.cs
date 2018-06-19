using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Model
{
    public class Catalog : INotifyPropertyChanged
    {
        string name;
        DirectoryInfo directory;
        bool isCatalogSelected;
        bool isCatalogExpanded;

        public Catalog()
        {
            Catalogs = new ObservableCollection<Catalog>();
            Files = new ObservableCollection<FileInfo>();
        }

        public bool IsCatalogSelected
        {
            get { return isCatalogSelected; }
            set
            {
                isCatalogSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsCatalogSelected"));
            }
        }

        public bool IsCatalogExpanded
        {
            get { return isCatalogExpanded; }
            set
            {
                isCatalogExpanded = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsCatalogExpanded"));
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public DirectoryInfo Directory
        {
            get { return directory; }
            set
            {
                directory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Directory"));
            }
        }

        public ObservableCollection<Catalog> Catalogs { get; set; }
        public ObservableCollection<FileInfo> Files { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
