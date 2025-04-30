using System.Data.Entity;

namespace Demonstration_exam_2024.Models
{
    public class PartnerSystemContext : DbContext
    {
        public PartnerSystemContext()
            : base("name=PartnerSystemConnection")
        {
            // Отключаем LazyLoading, чтобы избежать проблем с навигационными свойствами
            this.Configuration.LazyLoadingEnabled = false;
            // Включаем отслеживание прокси
            this.Configuration.ProxyCreationEnabled = true;
        }

        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<PartnerType> PartnerTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SalesHistory> SalesHistory { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Конфигурация для Partner
            modelBuilder.Entity<Partner>()
                .Property(e => e.TotalSalesAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Partner>()
                .Property(e => e.Discount)
                .HasPrecision(5, 2);

            // Конфигурация для Product
            modelBuilder.Entity<Product>()
                .Property(e => e.MinPrice)
                .HasPrecision(18, 2);

            // Конфигурация для SalesHistory
            modelBuilder.Entity<SalesHistory>()
                .Property(e => e.TotalAmount)
                .HasPrecision(18, 2);

            // Настройка связей
            modelBuilder.Entity<Partner>()
                .HasRequired(p => p.PartnerType)
                .WithMany()
                .HasForeignKey(p => p.TypeID);

            modelBuilder.Entity<SalesHistory>()
                .HasRequired(s => s.Partner)
                .WithMany()
                .HasForeignKey(s => s.PartnerID);

            modelBuilder.Entity<SalesHistory>()
                .HasRequired(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.ProductID);

            base.OnModelCreating(modelBuilder);
        }
    }
}