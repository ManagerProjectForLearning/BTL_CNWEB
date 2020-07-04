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
        public virtual DbSet<BrandSho> BrandShoes { get; set; }
        public virtual DbSet<Categorieshop> Categorieshops { get; set; }
        public virtual DbSet<DeltailCartShop> DeltailCartShops { get; set; }
        public virtual DbSet<ElecBillShop> ElecBillShops { get; set; }
        public virtual DbSet<MyWebShop> MyWebShops { get; set; }
        public virtual DbSet<PhanQuyenShop> PhanQuyenShops { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<colName> colNames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountCartShop>()
                .Property(e => e.IDCart)
                .IsUnicode(false);

            modelBuilder.Entity<AccountCartShop>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<AccountCartShop>()
                .HasMany(e => e.DeltailCartShops)
                .WithRequired(e => e.AccountCartShop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountShop>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<AccountShop>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<BrandSho>()
                .Property(e => e.IDBrand)
                .IsUnicode(false);

            modelBuilder.Entity<BrandSho>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.BrandSho)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<ElecBillShop>()
                .HasMany(e => e.Products)
                .WithMany(e => e.ElecBillShops)
                .Map(m => m.ToTable("DeltailBillShop").MapLeftKey("IDBill").MapRightKey("IDProduct"));

            modelBuilder.Entity<MyWebShop>()
                .Property(e => e.phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhanQuyenShop>()
                .HasMany(e => e.AccountShops)
                .WithOptional(e => e.PhanQuyenShop)
                .HasForeignKey(e => e.PhanQuyenS);

            modelBuilder.Entity<PhanQuyenShop>()
                .HasMany(e => e.AccountShops1)
                .WithMany(e => e.PhanQuyenShops)
                .Map(m => m.ToTable("ScopeOfUserShop").MapLeftKey("nameQ").MapRightKey("username"));

            modelBuilder.Entity<Product>()
                .Property(e => e.IDBrand)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.IDProduct)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.DeltailCartShops)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
