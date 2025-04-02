using System.Data.Entity;
using Demonstration_exam_2024.Models;

namespace Demonstration_exam_2024.Utils
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=partner_system_dbEntities")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Partner>()
                .HasMany(p => p.Sales)
                .WithRequired(s => s.Partner)
                .HasForeignKey(s => s.PartnerId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Sales)
                .WithRequired(s => s.Product)
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<ProductType>()
                .HasMany(pt => pt.Products)
                .WithRequired(p => p.ProductType)
                .HasForeignKey(p => p.ProductTypeId);
        }
    }
}