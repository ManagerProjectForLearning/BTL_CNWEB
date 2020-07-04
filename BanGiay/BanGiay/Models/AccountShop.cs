namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountShop")]
    public partial class AccountShop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountShop()
        {
            AccountCartShops = new HashSet<AccountCartShop>();
            PhanQuyenShops = new HashSet<PhanQuyenShop>();
        }

        [Key]
        [StringLength(25)]
        public string username { get; set; }

        [Required]
        [StringLength(25)]
        public string pass { get; set; }

        [StringLength(100)]
        public string fullName { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(1000)]
        public string feedBack { get; set; }

        [StringLength(100)]
        public string img { get; set; }

        public DateTime? dateCreate { get; set; }

        public int? productBuy { get; set; }

        [StringLength(16)]
        public string PhanQuyenS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountCartShop> AccountCartShops { get; set; }

        public virtual PhanQuyenShop PhanQuyenShop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyenShop> PhanQuyenShops { get; set; }
    }
}
