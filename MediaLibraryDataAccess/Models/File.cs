using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaLibraryDataAccess.Models
{
    [Table("File")]
    public partial class File
    {
        public int Id { get; set; }

        [Column("Id category")]
        public int Id_category { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Extension { get; set; }

        [Column("Сreation date", TypeName = "date")]
        public DateTime Сreation_date { get; set; }

        public int Size { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public virtual Category Category { get; set; }
    }
}
