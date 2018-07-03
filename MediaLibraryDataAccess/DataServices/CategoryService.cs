using MediaLibraryDataAccess.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MediaLibraryDataAccess.DataServices
{
    public static class CategoryService
    {
        public static List<Category> GetCategories(MediaType m)
        {
            using (MediaLibraryContext db = new MediaLibraryContext())
            {
                return db.Categories.Include(c => c.Files).Where(c => c.MediaType == m).ToList();
            }
        }
    }
}
