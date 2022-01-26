using HealthyDay.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Shop.Category
{
    public class CrudCategoryRepository : ICrudCategoryRepository
    {
        private readonly ShopDbContext shopDb;

        public CrudCategoryRepository(ShopDbContext shopDb)
        {
            this.shopDb = shopDb;
        }

        public CategoryModel FindCategory(int id)
        {
            var product = shopDb.Categories.Find(id);
            return product;
        }

        public CategoryModel AddCategory(CategoryModel item)
        {
            var product = shopDb.Categories.Add(item).Entity;
            shopDb.SaveChanges();
            return product;
        }

        public CategoryModel DeleteCategory(int id)
        {
            var product = shopDb.Categories.Remove(FindCategory(id)).Entity;
            shopDb.SaveChanges();
            return product;
        }

        public CategoryModel EditCategory(CategoryModel item)
        {
            var product = shopDb.Categories.Update(item).Entity;
            shopDb.SaveChanges();
            return product;
        }

        public IList<CategoryModel> FindAllCategories()
        {
            return shopDb.Categories.ToList();
        }

        public void AddProductToCategory(ProductCategoryModel model)
        {
            var product = shopDb.Products.Find(model.ProductId);
            var category = shopDb.Categories.Find(model.CategoryId);
            product.Categories.Add(category);
            shopDb.SaveChanges();

        }
    }
}
