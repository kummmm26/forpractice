using Microsoft.EntityFrameworkCore;
using eCommerceWebApp.Model;

namespace eCommerceWebApp.Dal
{

public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext()
    {

    }
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartDetail> CartDetails { get; set; }
    public DbSet<Invoice> Invoices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=AP-0ZTYJWSJJG66\\KUMKUMVERMA;Initial Catalog=ByteJanECommerceWebAppDb24;Trusted_Connection=true;TrustServerCertificate=true;");
        }
    }
}
}