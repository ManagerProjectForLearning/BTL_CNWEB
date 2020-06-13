namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MyWebShop")]
    public partial class MyWebShop
    {
        [Key]
        [StringLength(100)]
        public string logo { get; set; }

        [StringLength(100)]
        public string addressC { get; set; }

        [StringLength(10)]
        public string phone { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(100)]
        public string fbLink { get; set; }

        [StringLength(100)]
        public string insLink { get; set; }

        [StringLength(100)]
        public string twLink { get; set; }

        [StringLength(1000)]
        public string introduce { get; set; }
    }
}
