using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WarehousesProject.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=WareHouseConnection")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ExportPermission> ExportPermissions { get; set; }
        public virtual DbSet<Importer> Importers { get; set; }
        public virtual DbSet<ImportPermission> ImportPermissions { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Item_MeasureUnit> Item_MeasureUnit { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<WarehouseItem> WarehouseItems { get; set; }
        public virtual DbSet<Warhouse> Warhouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<ExportPermission>()
                .Property(e => e.WarhouseName)
                .IsUnicode(false);

            modelBuilder.Entity<ExportPermission>()
                .HasMany(e => e.WarehouseItems)
                .WithMany(e => e.ExportPermissions)
                .Map(m => m.ToTable("ExportedItem").MapLeftKey("PermissionId").MapRightKey("WarehouseItemId"));

            modelBuilder.Entity<Importer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Importer>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Importer>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Importer>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Importer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Importer>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<ImportPermission>()
                .Property(e => e.WarehouseName)
                .IsUnicode(false);

            modelBuilder.Entity<ImportPermission>()
                .HasMany(e => e.WarehouseItems)
                .WithMany(e => e.ImportPermissions)
                .Map(m => m.ToTable("ImportedItem").MapLeftKey("PermissionId").MapRightKey("WarehouseItemId"));

            modelBuilder.Entity<Item>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Item_MeasureUnit)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item_MeasureUnit>()
                .Property(e => e.MeasureUnit)
                .IsUnicode(false);

            modelBuilder.Entity<WarehouseItem>()
                .Property(e => e.WarehouseName)
                .IsUnicode(false);

            modelBuilder.Entity<Warhouse>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Warhouse>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Warhouse>()
                .Property(e => e.Responsible)
                .IsUnicode(false);

            modelBuilder.Entity<Warhouse>()
                .HasMany(e => e.ImportPermissions)
                .WithOptional(e => e.Warhouse)
                .HasForeignKey(e => e.WarehouseName);
        }
    }
}
