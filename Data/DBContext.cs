using EcommerceFull.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceFull.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fav_Prod>(entity =>
            {
                entity.HasKey(fp => new { fp.ProductID, fp.FavoritesID });

                entity.HasOne(fp => fp.Product)
                    .WithOne(p => p.FP)
                    .HasForeignKey<Fav_Prod>(p => p.ProductID);

                entity.HasOne(fp => fp.Favorite)
                    .WithOne(f => f.FP)
                    .HasForeignKey<Fav_Prod>(fp => fp.FavoritesID);
            });

            modelBuilder.Entity<Cart_Prod>(entity =>
            {
                entity.HasKey(cp => new { cp.CartID, cp.ProductID });

                entity.HasOne(cp => cp.Product)
                    .WithOne(p => p.CP)
                    .HasForeignKey<Cart_Prod>(p => p.ProductID);

                entity.HasOne(cp => cp.Cart)
                    .WithOne(c => c.CP)
                    .HasForeignKey<Cart_Prod>(cp => cp.CartID);
            });

            modelBuilder.Entity<Sold_Prod>(entity =>
            {
                entity.HasKey(sp => new { sp.SoldID, sp.ProductID });

                entity.HasOne(sp => sp.Product)
                    .WithOne(p => p.SP)
                    .HasForeignKey<Sold_Prod>(p => p.ProductID);

                entity.HasOne(sp => sp.Sold)
                    .WithOne(c => c.SP)
                    .HasForeignKey<Sold_Prod>(sp => sp.SoldID);
            });
        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<FavoritesModel> Favorites { get; set; }
        public DbSet<Fav_Prod> Fav_Prods { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<Cart_Prod> Cart_Prods { get; set; }
        public DbSet<SoldModel> Solds { get; set; }
        public DbSet<Sold_Prod> Sold_Prods { get; set; }
    }
}
