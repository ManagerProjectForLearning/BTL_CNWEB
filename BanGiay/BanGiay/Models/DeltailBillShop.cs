namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeltailBillShop")]
    public partial class DeltailBillShop
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(16)]
        public string IDBill { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string IDProduct { get; set; }
    }
}
