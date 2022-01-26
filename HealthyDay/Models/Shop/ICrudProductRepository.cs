using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Shop
{
    public interface ICrudProductRepository
    {
        ProductModel FindProduct(int id);
        ProductModel AddProduct(ProductModel item);
        ProductModel DeleteProduct(int id);
        ProductModel EditProduct(ProductModel item);
        IList<ProductModel> FindAllProducts();
    }
}
