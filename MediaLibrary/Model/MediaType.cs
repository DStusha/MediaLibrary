namespace MediaLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MediaType")]
    public partial class MediaType: INotifyPropertyChanged
    {
        int id;
        string type_name;
        ObservableCollection<Category> categories;

       [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MediaType()
        {
            Categories = new ObservableCollection<Category>();
        }

        public int Id {
            get { return id; }
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }

        [Column("Type name")]
        [Required]
        [StringLength(50)]
        public string Type_name {
            get { return type_name; }
            set
            {
                type_name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Type_name"));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Category> Categories {
            get { return categories; }
            set
            {
                categories = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Categories"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
