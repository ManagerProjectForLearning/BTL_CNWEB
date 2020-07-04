namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BrandSho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BrandSho()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(16)]
        public string IDBrand { get; set; }

        [StringLength(200)]
        public string nameB { get; set; }

        [StringLength(100)]
        public string logo { get; set; }

        public int? sale { get; set; }

        public int? numberP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
