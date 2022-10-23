using Microsoft.EntityFrameworkCore;
using efcore3.Models;

namespace efcore3.Data
{
    public class ProductStoreContext : DbContext
    {
        public ProductStoreContext(DbContextOptions<ProductStoreContext> options)
         : base(options) { }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .ToTable("Category")
                        .HasKey(cat => cat.Id);
            modelBuilder.Entity<Category>()
                        .Property(cat => cat.Id)
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .UseIdentityColumn(1)
                        .IsRequired();
            modelBuilder.Entity<Category>()
                        .Property(cat => cat.Name)
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(200)
                        .IsRequired();
            modelBuilder.Entity<Product>()
                        .ToTable("Product")
                        .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                        .HasOne<Category>(p => p.Category)
                        .WithMany(p => p.Products)
                        .HasForeignKey(p => p.Id);
            modelBuilder.Entity<Product>()
                        .Property(p => p.Id)
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .UseIdentityColumn(1)
                        .IsRequired();
            modelBuilder.Entity<Product>()
                        .Property(p => p.Name)
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(100)
                        .IsRequired();
            modelBuilder.Entity<Product>()
                        .Property(p => p.Manufacture)
                        .HasColumnName("Manufacture")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500);
            modelBuilder.Entity<Product>()
                        .Property(p => p.Id)
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .IsRequired();

            modelBuilder.Entity<Category>()
                        .HasData(new Category
                        {
                            Id = 1,
                            Name = "laptop"
                        });
            modelBuilder.Entity<Product>()
                        .HasData(new Product
                        {
                            Id = 1,
                            Name = "ROG something",
                            Category_id = 1,
                            Manufacture = "ASUS"
                        });
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
    }
}