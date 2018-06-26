using MediaLibrary.ViewModels;
using MediaLibraryDataAccess;
using MediaLibraryDataAccess.DataAccess;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace MediaLibrary
{
    public static class DBManager
    {
        private static CategoryViewModel GetCategoryViewModelFromDB(Category c)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.CategoryName = c.Category_name;
            categoryViewModel.Id = c.Id;
            foreach (MediaLibraryDataAccess.DataAccess.File f in c.Files)
            {
                categoryViewModel.Files.Add(GetFileFromDB(f));
            }
            return categoryViewModel;
        }

        private static FileViewModel GetFileFromDB(MediaLibraryDataAccess.DataAccess.File f)
        {
            FileViewModel fm = new FileViewModel()
            {
                File = new Models.File()
                {
                    Name = f.Name + f.Extension,
                    Type = DirectoryAndFileManager.GetTypeByCategory(f.Category.Category_name),
                    Content = f.Content
                }
            };
            return fm;
        }

        public static ObservableCollection<MediaTypeViewModel> GetMediaTypeViewModelsFromDB()
        {
            ObservableCollection<MediaTypeViewModel> mediaTypeViewModels = new ObservableCollection<MediaTypeViewModel>();
            using (MediaLibraryContext db = new MediaLibraryContext())
            {
                foreach (MediaType m in db.MediaTypes.ToList())
                {
                    MediaTypeViewModel mediaTypeViewModel = new MediaTypeViewModel()
                    {
                        MediaTypeName = m.Type_name
                    };
                    foreach (Category c in m.Categories)
                    {
                        mediaTypeViewModel.Categories.Add(GetCategoryViewModelFromDB(c));
                    }
                    mediaTypeViewModels.Add(mediaTypeViewModel);
                }
            }
            return mediaTypeViewModels;
        }

        public static void SaveFileToDB(Models.File fileModel, int id)
        {
            MediaLibraryDataAccess.DataAccess.File file = new MediaLibraryDataAccess.DataAccess.File()
            {
                Name = Path.GetFileNameWithoutExtension(fileModel.FullName),
                Extension = Path.GetExtension(fileModel.Name),
                Content = fileModel.Content,
                Id_category = id
            };
            FileInfo fileinf = new FileInfo(fileModel.FullName);
            file.Size = (int)fileinf.Length;
            file.Сreation_date = fileinf.CreationTime;
            using (MediaLibraryContext db = new MediaLibraryContext())
            {
                db.Files.Add(file);
                db.SaveChanges();
            }
        }

        public static bool IsFileExists(Models.File file)
        {
            return false;
        }
    }
}
