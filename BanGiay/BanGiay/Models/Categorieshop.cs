namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categorieshop")]
    public partial class Categorieshop
    {
        [Key]
        [StringLength(100)]
        public string nameC { get; set; }
    }
}
