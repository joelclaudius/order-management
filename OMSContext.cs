using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace WpfApp
{
    internal class OMSContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Shopper> Shoppers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your database connection string here
            optionsBuilder.UseSqlServer("YourConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings if needed
            modelBuilder.Entity<Product>().ToTable("Products"); // Maps the Product entity to the "Products" table in the database
            modelBuilder.Entity<Product>().HasKey(p => p.IdProduct); // Specifies the primary key for the Product entity
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("ProductName"); // Specifies the column name for the ProductName property

            modelBuilder.Entity<Shopper>().ToTable("Shoppers");
            modelBuilder.Entity<Shopper>().HasKey(s => s.IdShopper);
            modelBuilder.Entity<Shopper>().Property(s => s.Email).HasColumnName("EmailAddress");

            modelBuilder.Entity<Basket>().ToTable("Baskets");
            modelBuilder.Entity<Basket>().HasKey(b => b.IdBasket);
            modelBuilder.Entity<Basket>().HasOne(b => b.Shopper)
                                           .WithMany(s => s.Baskets)
                                           .HasForeignKey(b => b.IdShopper); // Establishes a one-to-many relationship between Basket and Shopper

            modelBuilder.Entity<BasketItem>().ToTable("BasketItems");
            modelBuilder.Entity<BasketItem>().HasKey(bi => bi.IdBasketItem);
            modelBuilder.Entity<BasketItem>().HasOne(bi => bi.Product)
                                              .WithMany()
                                              .HasForeignKey(bi => bi.IdProduct); // Establishes a one-to-many relationship between BasketItem and Product
            modelBuilder.Entity<BasketItem>().HasOne(bi => bi.Basket)
                                              .WithMany(b => b.BasketItems)
                                              .HasForeignKey(bi => bi.IdBasket); // Establishes a one-to-many relationship between BasketItem and Basket
        }

    }
}

