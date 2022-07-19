

using ASM.SHARE.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASM.SHARE
{
    public class ShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products {get;set;}

        public DbSet<Category> Categories {get;set;}

        public DbSet<Cart> Carts {get;set;}
        public DbSet<CartDetail> CartDetails {get;set;}


        public ShopContext(DbContextOptions<ShopContext> options) : base(options) {} 

    
    }
}