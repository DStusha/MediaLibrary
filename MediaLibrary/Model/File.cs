namespace MediaLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("File")]
    public partial class File: INotifyPropertyChanged
    {
        int id;
        int id_category;
        string name;
        string extension;
        DateTime creation_date;
        int size;
        byte[] content;
        Category category;

        public int Id {
            get { return id; }
            set {
                id= value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }

        [Column("Id category")]
        public int Id_category {
            get { return id_category; }
            set {
                id_category = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id_catagory"));
            }
        }

        [Required]
        [StringLength(50)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        [Required]
        [StringLength(10)]
        public string Extension
        {
            get { return extension; }
            set
            {
                extension = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Extension"));
            }
        }

        [Column("Сreation date", TypeName = "date")]
        public DateTime Сreation_date
        {
            get { return creation_date; }
            set
            {
                creation_date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Сreation_date"));
            }
        }

        public int Size {
            get { return size; }
            set
            {
                size = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Size"));
            }
        }

        [Required]
        public byte[] Content
        {
            get { return content; }
            set
            {
                content = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content"));
            }
        }

        public virtual Category Category
        {
            get { return category; }
            set
            {
                category = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Category"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
