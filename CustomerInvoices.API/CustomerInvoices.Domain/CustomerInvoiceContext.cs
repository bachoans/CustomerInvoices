using Microsoft.EntityFrameworkCore;

namespace CustomerInvoices.Domain
{
    public class CustomerInvoiceContext : DbContext
    {
        public CustomerInvoiceContext()
        {
        }

        public CustomerInvoiceContext(DbContextOptions<CustomerInvoiceContext> options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLog> InvoiceLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasOne(x => x.Customer)
                    .WithMany(x => x.Invoices)
                    .HasForeignKey(x => x.CustomerId);
            });

            modelBuilder.Entity<InvoiceLog>(entity =>
            {
                entity.HasOne(x => x.Invoice)
                    .WithMany(x => x.InvoiceLogs)
                    .HasForeignKey(x => x.InvoiceId);
            });

            SeetData(modelBuilder);
        }

        private void SeetData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
              new Customer { Id = 1, Firstname = "Test1", Lastname = "Customer1" },
              new Customer { Id = 2, Firstname = "Test2", Lastname = "Customer2" },
              new Customer { Id = 3, Firstname = "Test3", Lastname = "Customer3" },
              new Customer { Id = 4, Firstname = "Test4", Lastname = "Customer4" },
              new Customer { Id = 5, Firstname = "Test5", Lastname = "Customer5" });
        }
    }
}