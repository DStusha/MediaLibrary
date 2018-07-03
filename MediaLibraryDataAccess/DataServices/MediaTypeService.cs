using MediaLibraryDataAccess.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MediaLibraryDataAccess.DataServices
{
    public static class MediaTypeService
    {
        public static List<MediaType> GetMediaTypes()
        {
            using (MediaLibraryContext db = new MediaLibraryContext())
            {
                return db.MediaTypes.Include(m => m.Categories).ToList();
            }
        }
    }
}
