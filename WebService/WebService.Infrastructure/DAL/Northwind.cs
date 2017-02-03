using System.Data.Entity;

namespace WebService.Infrastructure.DAL
{
    public partial class Northwind : DbContext
    {
        public Northwind()
            : base("name=Northwind")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerID)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.CustomerID)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);
        }
    }
}
