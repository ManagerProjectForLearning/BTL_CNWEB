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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountCartShop()
        {
            DeltailCartShops = new HashSet<DeltailCartShop>();
        }

        [Key]
        [StringLength(16)]
        public string IDCart { get; set; }

        [StringLength(25)]
        public string username { get; set; }

        public int? pInCart { get; set; }

        public double? totalMoney { get; set; }

        public virtual AccountShop AccountShop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeltailCartShop> DeltailCartShops { get; set; }
        private List<DeltailCartShop> listP = new List<DeltailCartShop>();
        public List<DeltailCartShop> ListP { get; set; }
    }
}
