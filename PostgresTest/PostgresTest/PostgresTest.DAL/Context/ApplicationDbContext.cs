using Microsoft.EntityFrameworkCore;
using PostgresTest.DAL.Entities;

namespace PostgresTest.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>()
                .HasKey(bc => new { bc.CustomerID, bc.ProductID });
            modelBuilder.Entity<Purchase>()
                .HasOne(bc => bc.Customer)
                .WithMany(b => b.Purchases)
                .HasForeignKey(bc => bc.CustomerID);
            modelBuilder.Entity<Purchase>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.Purchases)
                .HasForeignKey(bc => bc.ProductID);


            modelBuilder.HasSequence<int>("CustomerNumbers")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.Entity<Customer>()
                        .Property(o => o.CustomerID)
                        .HasDefaultValueSql("nextval('\"CustomerNumbers\"')");

            modelBuilder.HasSequence<int>("ProductNumbers")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.Entity<Product>()
                        .Property(o => o.ProductID)
                        .HasDefaultValueSql("nextval('\"ProductNumbers\"')");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

    }
}
