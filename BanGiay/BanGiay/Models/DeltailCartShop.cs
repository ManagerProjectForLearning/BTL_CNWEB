namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeltailCartShop")]
    public partial class DeltailCartShop
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(16)]
        public string IDCart { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string IDProduct { get; set; }

        public DateTime? timeAdd { get; set; }

        public int? soluong { get; set; }

        [StringLength(100)]
        public string img1 { get; set; }

        public double? realCost { get; set; }

        [Column("checked")]
        public bool? _checked { get; set; }

        [StringLength(200)]
        public string nameP { get; set; }

        public virtual AccountCartShop AccountCartShop { get; set; }

        public virtual Product Product { get; set; }
    }
}
