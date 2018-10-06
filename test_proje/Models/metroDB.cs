namespace test_proje.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class metroDB : DbContext
    {
        public metroDB()
            : base("name=metroDB")
        {
        }

        public virtual DbSet<kategori> kategoris { get; set; }
        public virtual DbSet<urunler> urunlers { get; set; }
        public virtual DbSet<uye> uyes { get; set; }
        public virtual DbSet<yetki> yetkis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<urunler>()
                .Property(e => e.fiyat)
                .HasPrecision(19, 4);
        }
    }
}
