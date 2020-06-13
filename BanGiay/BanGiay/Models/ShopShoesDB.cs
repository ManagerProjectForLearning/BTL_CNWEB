namespace BanGiay.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopShoesDB : DbContext
    {
        public ShopShoesDB()
            : base("name=ShopShoesDB")
        {
        }

        public virtual DbSet<AccountCartShop> AccountCartShops { get; set; }
        public virtual DbSet<AccountShop> AccountShops { get; set; }
        public virtual DbSet<BrandShoes> BrandShoes { get; set; }
        public virtual DbSet<Categorieshop> Categorieshops { get; set; }
        public virtual DbSet<DeltailBillShop> DeltailBillShops { get; set; }
        public virtual DbSet<DeltailCartShop> DeltailCartShops { get; set; }
        public virtual DbSet<ElecBillShop> ElecBillShops { get; set; }
        public virtual DbSet<MyWebShop> MyWebShops { get; set; }
        public virtual DbSet<PhanQuyenShop> PhanQuyenShops { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ScopeOfUserShop> ScopeOfUserShops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountCartShop>()
                .Property(e => e.IDCart)
                .IsUnicode(false);

            modelBuilder.Entity<AccountCartShop>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<AccountShop>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<AccountShop>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<BrandShoes>()
                .Property(e => e.IDBrand)
                .IsUnicode(false);

            modelBuilder.Entity<DeltailBillShop>()
                .Property(e => e.IDBill)
                .IsUnicode(false);

            modelBuilder.Entity<DeltailBillShop>()
                .Property(e => e.IDProduct)
                .IsUnicode(false);

            modelBuilder.Entity<DeltailCartShop>()
                .Property(e => e.IDCart)
                .IsUnicode(false);

            modelBuilder.Entity<DeltailCartShop>()
                .Property(e => e.IDProduct)
                .IsUnicode(false);

            modelBuilder.Entity<ElecBillShop>()
                .Property(e => e.IDBill)
                .IsUnicode(false);

            modelBuilder.Entity<ElecBillShop>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<MyWebShop>()
                .Property(e => e.phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.IDBrand)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.IDProduct)
                .IsUnicode(false);

            modelBuilder.Entity<ScopeOfUserShop>()
                .Property(e => e.username)
                .IsUnicode(false);
        }
    }
}
