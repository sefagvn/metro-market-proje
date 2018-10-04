namespace test_proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("urunler")]
    public partial class urunler
    {
        [Key]
        public int urunId { get; set; }

        [StringLength(50)]
        public string urunAdi { get; set; }

        public string icerik { get; set; }

        [StringLength(500)]
        public string foto { get; set; }

        public int? kategoriId { get; set; }

        public virtual kategori kategori { get; set; }
    }
}
