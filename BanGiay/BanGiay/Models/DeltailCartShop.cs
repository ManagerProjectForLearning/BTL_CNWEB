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
    }
}
