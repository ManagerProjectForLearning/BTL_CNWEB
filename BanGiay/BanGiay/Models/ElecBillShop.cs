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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ElecBillShop()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(16)]
        public string IDBill { get; set; }

        [Required]
        [StringLength(25)]
        public string username { get; set; }

        public DateTime? dateCreat { get; set; }

        public int? pInBill { get; set; }

        public double? totalMoney { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        private List<DeltailCartShop> listP = new List<DeltailCartShop>();
        public List<DeltailCartShop> ListP { get; set; }
    }
}
