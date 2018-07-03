using System.Collections.Generic;

namespace MediaLibraryDataAccess.Models
{
    public class Catalog
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public List<Catalog> CatalogChildren { get; set; }

        public Catalog()
        {
            CatalogChildren = new List<Catalog>();
        }
    }
}
