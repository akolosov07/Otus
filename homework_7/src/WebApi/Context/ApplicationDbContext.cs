using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);

            modelBuilder.HasSequence<int>("CustomerNumbers")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.Entity<Customer>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("nextval('\"CustomerNumbers\"')");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
