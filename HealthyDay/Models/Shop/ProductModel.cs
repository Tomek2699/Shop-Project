using HealthyDay.Models.Shop.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Shop
{
    public class ProductModel
    {
        public ProductModel()
        {
            this.Categories = new HashSet<CategoryModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę produktu")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać opis produktu")]
        [MaxLength(500)]
        [MinLength(10, ErrorMessage = "Opis powinien mieć conajmniej 10 znaków")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proszę podać cene")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Proszę podać ilość produktów")]
        public int Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public ICollection<CategoryModel> Categories { get; set; }
        public ICollection<CartItemModel> CartItemModels { get; set; }
    }
}
