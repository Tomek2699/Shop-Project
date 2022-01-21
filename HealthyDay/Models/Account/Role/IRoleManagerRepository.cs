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
        Task<IdentityResult> DeleteRole(string id);
        Task<IList<UserRoleModel>> FindUsersInRole(string id);
        Task EditUsersInRole(IList<UserRoleModel> model, string id);
        Task<RoleModel> Find(string id);
        IList<IdentityRole> FindAllRoles();
    }
}
