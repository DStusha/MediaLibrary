namespace MediaLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category: INotifyPropertyChanged
    {
        int id;
        int id_media_type;
        string category_name;
        MediaType mediaType;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Files = new ObservableCollection<File>();
        }

        public int Id {
            get { return id; }
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }

        [Column("Id media type")]
        public int Id_media_type {
            get { return id_media_type; }
            set
            {
                id_media_type = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id_media_type"));
            }
        }

        [Column("Category name")]
        [Required]
        [StringLength(50)]
        public string Category_name {
            get { return category_name; }
            set
            {
                category_name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Category_name"));
            }
        }

        public virtual MediaType MediaType
        {
            get { return mediaType; }
            set
            {
                mediaType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MediaType"));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<File> Files { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
