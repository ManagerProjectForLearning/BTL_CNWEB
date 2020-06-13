namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ElecBillShop")]
    public partial class ElecBillShop
    {
        [Key]
        [StringLength(16)]
        public string IDBill { get; set; }

        [Required]
        [StringLength(25)]
        public string username { get; set; }

        public DateTime? dateCreat { get; set; }

        public int? pInBill { get; set; }

        public double? totalMoney { get; set; }
    }
}
