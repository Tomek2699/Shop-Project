using HealthyDay.Models.DataBase;
using HealthyDay.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopDbContext shopDb;

        public UserRepository(ShopDbContext shopDb)
        {
            this.shopDb = shopDb;
        }

        public ProductModel FindProduct(int id)
        {
            return shopDb.Products.Find(id);
        }

        public IList<ProductModel> FindAllProducts()
        {
            return shopDb.Products.ToList();
        }
    }
}
