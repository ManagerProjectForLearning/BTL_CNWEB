namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountCartShop")]
    public partial class AccountCartShop
    {
        [Key]
        [StringLength(16)]
        public string IDCart { get; set; }

        [Required]
        [StringLength(16)]
        public string username { get; set; }

        public int? pInCart { get; set; }

        public double? totalMoney { get; set; }
    }
}
