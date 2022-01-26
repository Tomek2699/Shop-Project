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
        public IActionResult ProductsList()
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
            return View();
        }
    }
}
