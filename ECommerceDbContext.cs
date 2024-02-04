using Microsoft.EntityFrameworkCore;
using eCommerce.Models;

namespace eCommerce.DAL
{
    public class ECommerceDbContext: DbContext
    {
        public ECommerceDbContext()
        {
            
        }
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options):base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=localhost;initial catalog=ByteJanECommerceDb24;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
