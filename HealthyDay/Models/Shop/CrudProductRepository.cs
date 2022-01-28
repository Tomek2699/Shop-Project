using HealthyDay.Models.DataBase;
using HealthyDay.Models.Shop.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Shop
{
    public class CrudProductRepository : ICrudProductRepository
    {
        private readonly ShopDbContext shopDb;

        public CrudProductRepository(ShopDbContext shopDb)
        {
            this.shopDb = shopDb;
        }

        public ProductModel FindProduct(int id)
        {
            var product = shopDb.Products.Find(id);
            return product;
        }

        public ProductModel AddProduct(ProductModel item)
        {
            item.Date = DateTime.Today;
            var product = shopDb.Products.Add(item).Entity;
            shopDb.SaveChanges();
            return product;
        }

        public ProductModel DeleteProduct(int id)
        {
            var product = shopDb.Products.Remove(FindProduct(id)).Entity;
            shopDb.SaveChanges();
            return product;
        }

        public ProductModel EditProduct(ProductModel item)
        {
            item.Date = DateTime.Today;
            var product = shopDb.Products.Update(item).Entity;
            shopDb.SaveChanges();
            return product;
        }

        public IList<ProductModel> FindAllProducts()
        {
            return shopDb.Products.ToList();
        }
    }
}
