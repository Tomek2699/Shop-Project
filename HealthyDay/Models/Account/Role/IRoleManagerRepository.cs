using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Account.Role
{
    public interface IRoleManagerRepository
    {
        Task<IdentityResult> CreateRole(RoleModel model);
        Task<IdentityResult> EditRole(RoleModel model);
        Task<RoleModel> Find(string id);
        Task<IList<UserRoleModel>> FindUser(string id);
        Task EditUserInRole(IList<UserRoleModel> model, string id);
        IList<IdentityRole> FindAllRoles();
    }
}
