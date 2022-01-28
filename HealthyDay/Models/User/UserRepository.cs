using HealthyDay.Models.DataBase;
using HealthyDay.Models.Shop;
using Microsoft.AspNetCore.Identity;
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

        public CartItemModel AddProductToCart(int id)
        {
            var item = shopDb.Products.Find(id);
            var item2 = new CartItemModel()
            {
                ProductId = id,
                ProductModel = item
            };
            var product = shopDb.CartItemModels.Add(item2).Entity;
            item.Amount -= 1;
            shopDb.Products.Update(item);
            shopDb.SaveChanges();
            return product;
        }

        public IList<ProductModel> FindProductInCart()
        {
            var item = shopDb.CartItemModels.ToList();
            var item2 = new List<ProductModel>();
            foreach(var items in item)
            {
                var product = shopDb.Products.Find(items.ProductId);
                product.CartId = items.CartId;
                item2.Add(product);
            }
            return item2;

        }

        public void ClearCart()
        {
            var item = shopDb.CartItemModels.ToList();
            shopDb.CartItemModels.RemoveRange(item);
            shopDb.SaveChanges();
        }

        public void DeleteProductFromCart(int id)
        {
            var product = shopDb.CartItemModels.Find(id);
            shopDb.CartItemModels.Remove(product);
            shopDb.SaveChanges();

        }

    }
}
