using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyDay.Models.Account;
using Microsoft.AspNetCore.Mvc;


namespace HealthyDay.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManagerRepository repository;

        public AccountController(IAccountManagerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await repository.Register(model);
                
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await repository.Login(model);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Nieprawidłowy Login lub Hasło");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await repository.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
