using HealthyDay.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Controllers.ApiControllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("ApiAccount")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ApiAccountController : Controller
    {
        private readonly IAccountManagerRepository repository;

        public ApiAccountController(IAccountManagerRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.Register(model);

                var user = new LoginModel
                {
                    Login = model.Login,
                };

                if (result.Succeeded)
                {
                    return new CreatedResult($"/api/{user.Login}", $"{user.Login} udało Ci się zarejestrować i zalogować!");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.Login(model);

                if (result.Succeeded)
                {
                    return new CreatedResult($"/api/{model.Login}", $"{model.Login} udało Ci się zalogować!");
                }

                ModelState.AddModelError(string.Empty, "Nieprawidłowy Login lub Hasło");
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await repository.Logout();
            return new CreatedResult($"/api/logged_out", "Wylogowałeś się!");
        }
    }
}
