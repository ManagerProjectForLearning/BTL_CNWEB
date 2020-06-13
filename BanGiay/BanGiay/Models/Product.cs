namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [StringLength(200)]
        public string nameP { get; set; }

        public int? size { get; set; }

        [Required]
        [StringLength(16)]
        public string IDBrand { get; set; }

        [StringLength(1000)]
        public string descriptionP { get; set; }

        [StringLength(200)]
        public string shortDescription { get; set; }

        [StringLength(50)]
        public string color { get; set; }

        public string cost { get; set; }

        [StringLength(100)]
        public string img1 { get; set; }

        [StringLength(100)]
        public string img2 { get; set; }

        [Key]
        [StringLength(16)]
        public string IDProduct { get; set; }

        public double? reviewStar { get; set; }

        public double? realCost { get; set; }

        public int? sale { get; set; }

        public int? productBuy { get; set; }
    }
}
