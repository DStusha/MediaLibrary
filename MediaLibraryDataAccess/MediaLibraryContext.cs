using MediaLibraryDataAccess.DataAccess;
using System.Data.Entity;

namespace MediaLibraryDataAccess
{    
    public partial class MediaLibraryContext : DbContext
    {
        public MediaLibraryContext()
            : base("name=MediaLibraryConnection")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Category_name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Files)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Id_category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<File>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<File>()
                .Property(e => e.Extension)
                .IsUnicode(false);

            modelBuilder.Entity<MediaType>()
                .Property(e => e.Type_name)
                .IsUnicode(false);

            modelBuilder.Entity<MediaType>()
                .HasMany(e => e.Categories)
                .WithRequired(e => e.MediaType)
                .HasForeignKey(e => e.Id_media_type)
                .WillCascadeOnDelete(false);
        }
    }
}
