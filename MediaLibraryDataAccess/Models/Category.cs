using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaLibraryDataAccess.Models
{
    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Files = new HashSet<File>();
        }

        public int Id { get; set; }

        [Column("Id media type")]
        public int Id_media_type { get; set; }

        [Column("Category name")]
        [Required]
        [StringLength(50)]
        public string Category_name { get; set; }

        public virtual MediaType MediaType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<File> Files { get; set; }
    }
}
