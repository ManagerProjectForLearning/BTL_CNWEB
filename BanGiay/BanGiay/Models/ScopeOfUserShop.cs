namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScopeOfUserShop")]
    public partial class ScopeOfUserShop
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(25)]
        public string username { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string nameQ { get; set; }
    }
}
