using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Account.Role
{
    public class RoleManagerRepository : IRoleManagerRepository
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public RoleManagerRepository(RoleManager<IdentityRole> roleManager,
                                  UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateRole(RoleModel model)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = model.RoleName
            };

            IdentityResult result = await roleManager.CreateAsync(identityRole);

            return result;
        }

        public async Task<IdentityResult> EditRole(RoleModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            role.Name = model.RoleName;
            IdentityResult result = await roleManager.UpdateAsync(role);

            return result;
        }

        public async Task<RoleModel> Find(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            var model = new RoleModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users.ToList())
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return model;
        }

        public async Task<IList<UserRoleModel>> FindUser(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var model = new List<UserRoleModel>();
            foreach (var user in userManager.Users.ToList())
            {
                var userRoleModel = new UserRoleModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleModel.IsSelected = true;
                }
                else
                {
                    userRoleModel.IsSelected = false;
                }

                model.Add(userRoleModel);

            }
            return model;
        }

        public async Task EditUserInRole(IList<UserRoleModel> model, string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);


                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!(model[i].IsSelected) && await userManager.IsInRoleAsync(user, role.Name))
                {
                    await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
            }
        }

        public IList<IdentityRole> FindAllRoles()
        {
            return roleManager.Roles.ToList();
        }
    }
}