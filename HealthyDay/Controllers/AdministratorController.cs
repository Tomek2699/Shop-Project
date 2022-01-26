using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyDay.Models.Account;
using HealthyDay.Models.Account.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace HealthyDay.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> EditUser(IdentityUser user)
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

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View("./Role/CreateRole");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await roleRepository.CreateRole(model);

                if(result.Succeeded)
                {
                    return View("./Role/RolesManagment", roleRepository.FindAllRoles());
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View("./Role/CreateRole", model);
            
            
        }

        [HttpGet]
        public async  Task<IActionResult> UsersInRole(RoleModel model)
        {
            return View("./Role/UsersInRole", await roleRepository.Find(model.Id));
        }

        [HttpGet]
        public async Task<IActionResult> UserInRole(string id)
        {
            ViewBag.id = id;

            return View("./Role/EditUsersInRole", await roleRepository.FindUsersInRole(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(IList<UserRoleModel> model, string id)
        {
            await roleRepository.EditUsersInRole(model, id);
            return View("./Role/UsersInRole", await roleRepository.Find(id));
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            return View("./Role/EditRole", await roleRepository.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                await roleRepository.EditRole(model);
                return View("./Role/RolesManagment", roleRepository.FindAllRoles());
            }

            return View("./Role/EditRole", await roleRepository.Find(model.Id));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            await roleRepository.DeleteRole(id);
            return View("./Role/RolesManagment", roleRepository.FindAllRoles());
        }
    }
}
