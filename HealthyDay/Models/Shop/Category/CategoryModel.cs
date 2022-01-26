using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Shop.Category
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            this.Products = new HashSet<ProductModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę kategorii")]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<ProductModel> Products { get; set; }

    }
}
