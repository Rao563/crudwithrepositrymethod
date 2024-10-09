using crudwithrepositrymethod.Entity;
using Microsoft.EntityFrameworkCore;

namespace crudwithrepositrymethod.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public MyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId);
        }

    }
}
