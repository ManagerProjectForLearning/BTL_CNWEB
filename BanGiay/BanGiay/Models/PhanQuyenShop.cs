namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanQuyenShop")]
    public partial class PhanQuyenShop
    {
        [Key]
        [StringLength(16)]
        public string nameQ { get; set; }
    }
}
