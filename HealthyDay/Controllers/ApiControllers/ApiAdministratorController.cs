using HealthyDay.Models.Account;
using HealthyDay.Models.Account.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Controllers.ApiControllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("ApiAdministrator")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ApiAdministratorController : Controller
    {
        private readonly IAccountManagerRepository accountRepository;
        private readonly IRoleManagerRepository roleRepository;

        public ApiAdministratorController(IAccountManagerRepository accountRepository, IRoleManagerRepository roleRepository)
        {
            this.accountRepository = accountRepository;
            this.roleRepository = roleRepository;
        }

        //CRUD ACCOUNT OPERATIONS

        [HttpGet]
        [Route("FindUser/{id}")]
        public async Task<IdentityUser> EditUser(string id)
        {
            return await accountRepository.FindUser(id);
        }

        [HttpGet]
        [Route("FindUsers")]
        public IList<IdentityUser> UsersManagment()
        {
            return accountRepository.FindAllUsers();
        }

        [HttpPost]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser(IdentityUser user)
        {
            var result = await accountRepository.EditUser(user);
            if (ModelState.IsValid)
            {
                if (result.Succeeded)
                {
                    return new CreatedResult($"/ApiAdministrator", user);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await accountRepository.DeleteUser(id);
            return new CreatedResult($"/ApiAdministrator", $"Udało Ci się usunąć użytkownika o ID: {id}");
        }

        //CRUD ROLE OPERATIONS

        [HttpGet]
        [Route("FindRoles")]
        public IList<IdentityRole> RolesManagment()
        {
            return roleRepository.FindAllRoles();
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await roleRepository.CreateRole(model);

                if (result.Succeeded)
                {
                    return new CreatedResult($"/ApiAdministrator", model);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return BadRequest();


        }

        [HttpGet]
        [Route("UserInRole/{id}")]
        public async Task<RoleModel> UsersInRole(string id)
        {
            return await roleRepository.Find(id);
        }

        [HttpPost]
        [Route("EditRole")]
        public async Task<IActionResult> EditRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                await roleRepository.EditRole(model);
                return new CreatedResult($"/ApiAdministrator", model);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            await roleRepository.DeleteRole(id);
            return new CreatedResult($"/ApiAdministrator", $"Udało Ci się usunąć role o ID: {id}");
        }
    }
}
