using MediaLibrary.Commands;
using MediaLibrary.Logic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MediaLibrary.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        TreeViewModel trees;
        public ICommand Collapse { get; private set; }
        public ICommand Visible { get; private set; }

        public TreeViewModel Trees
        {
            get { return trees; }
            set
            {
                trees = value;
                OnPropertyChanged("Trees");
            }
        }

        public MainWindowViewModel()
        {
            Collapse = new Command(CollapseElement);
            Visible = new Command(VisibleElement);
            Trees = new TreeViewModel() { CatalogPath = Properties.Settings.Default.CatalogPath,  SelectedValue = FileVMLogic.GetFiles(Properties.Settings.Default.CatalogPath), CategoryId = Properties.Settings.Default.CategoryId };
        }

        public void CollapseElement(object elem)
        {
            if(elem is UIElement)
            {
                (elem as UIElement).Visibility = Visibility.Collapsed;
            }
        }

        public void VisibleElement(object elem)
        {
            if (elem is UIElement)
            {
                (elem as UIElement).Visibility = Visibility.Visible;
            }
        }
    }
}
