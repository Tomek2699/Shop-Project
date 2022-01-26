using HealthyDay.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.User
{
    public interface IUserRepository
    {
        ProductModel FindProduct(int id);
        IList<ProductModel> FindAllProducts();
    }
}
