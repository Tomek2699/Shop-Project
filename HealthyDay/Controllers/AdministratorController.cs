using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyDay.Models.Account;
using HealthyDay.Models.Account.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace HealthyDay.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IAccountManagerRepository accountRepository;
        private readonly IRoleManagerRepository roleRepository;

        public AdministratorController(IAccountManagerRepository accountRepository, IRoleManagerRepository roleRepository)
        {
            this.accountRepository = accountRepository;
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult ManagmentPanel()
        {
            return View();
        }

        //CRUD ACCOUNT OPERATIONS

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            return View(await accountRepository.FindUser(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditUserConfirm(IdentityUser user)
        {
            var result = await accountRepository.EditUser(user);
            if(ModelState.IsValid)
            {
                if(result.Succeeded)
                {
                    return View("UsersManagment", accountRepository.FindAllUsers());
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View("EditUser", user);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await accountRepository.DeleteUser(id);
            return View("UsersManagment", accountRepository.FindAllUsers());
        }

        [HttpGet]
        public IActionResult UsersManagment()
        {
            var result = accountRepository.FindAllUsers();
            return View(result);
        }

        //CRUD ROLE OPERATIONS

        [HttpGet]
        public IActionResult RolesManagment()
        {
            return View("./Role/RolesManagment", roleRepository.FindAllRoles());
        }
    }
}
