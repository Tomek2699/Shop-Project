using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyDay.Models.Shop;
using HealthyDay.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HealthyDay.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ProductsList(string id)
        {

            return View(userRepository.FindAllProducts());
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult DetailsProduct(int id)
        {
            return View(userRepository.FindProduct(id));
        }

        [HttpGet]
        public IActionResult ShoppingBasket()
        {
            return View(userRepository.FindProductInCart());
        }

        [HttpGet]
        public IActionResult AddProductToCart(int id)
        {
            userRepository.AddProductToCart(id);
            return View("ProductsList", userRepository.FindAllProducts());
        }

        [HttpGet]
        public IActionResult DeleteProductFromCart(int id)
        {
            userRepository.DeleteProductFromCart(id);
            return View("ShoppingBasket", userRepository.FindProductInCart());
        }
    }
}
