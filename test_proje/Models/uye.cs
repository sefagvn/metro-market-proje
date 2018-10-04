namespace test_proje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("uye")]
    public partial class uye
    {
        public int uyeId { get; set; }

        [StringLength(50)]
        public string kullaniciAdi { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(20)]
        public string sifre { get; set; }

        [StringLength(20)]
        public string adi { get; set; }

        [StringLength(20)]
        public string soyadi { get; set; }

        public int? yetkiId { get; set; }

        public virtual yetki yetki { get; set; }
    }
}
