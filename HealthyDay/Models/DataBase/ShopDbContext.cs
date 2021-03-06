using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyDay.Models.Shop;
using HealthyDay.Models.Shop.Category;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HealthyDay.Models.Account;

namespace HealthyDay.Models.DataBase
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CartItemModel> CartItemModels { get; set; }
    }
}
