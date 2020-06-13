namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BrandShoes
    {
        [Key]
        [StringLength(16)]
        public string IDBrand { get; set; }

        [StringLength(200)]
        public string nameB { get; set; }

        [StringLength(100)]
        public string logo { get; set; }

        public int? sale { get; set; }

        public int? numberP { get; set; }
    }
}
