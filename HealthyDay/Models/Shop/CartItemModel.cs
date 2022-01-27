using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Shop
{
    public class CartItemModel : IdentityUser
    {
        [Key]
        public int CartId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ProductModel ProductModel { get; set; }

    }
}
