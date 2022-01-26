using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Shop.Category
{
    public interface ICrudCategoryRepository
    {
        CategoryModel FindCategory(int id);
        CategoryModel AddCategory(CategoryModel item);
        CategoryModel DeleteCategory(int id);
        CategoryModel EditCategory(CategoryModel item);
        IList<CategoryModel> FindAllCategories();
        void AddProductToCategory(ProductCategoryModel model);
    }
}
