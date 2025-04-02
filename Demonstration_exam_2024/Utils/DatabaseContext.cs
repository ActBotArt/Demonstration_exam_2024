using System.Data.Entity;
using Demonstration_exam_2024.Models;

namespace Demonstration_exam_2024.Utils
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=partner_system_dbEntities")
        {
            Database.SetInitializer<DatabaseContext>(null);
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Partner>().ToTable("Partners");
            modelBuilder.Entity<Sale>().ToTable("Sales");
            modelBuilder.Entity<Product>().ToTable("Products");

            // Отключаем каскадное удаление
            modelBuilder.Entity<Sale>()
                .HasRequired(s => s.Partner)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.PartnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .HasRequired(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}