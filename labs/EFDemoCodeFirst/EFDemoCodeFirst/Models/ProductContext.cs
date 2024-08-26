using Microsoft.EntityFrameworkCore;

namespace EFDemoCodeFirst.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set;}
    }
}
