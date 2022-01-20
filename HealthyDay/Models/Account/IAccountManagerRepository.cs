using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Account
{
    public interface IAccountManagerRepository
    {
        // Register, login and logout
        Task<IdentityResult> Register(RegisterModel model);
        Task<SignInResult> Login(LoginModel model);
        Task Logout();

        //CRUD account
        Task<IdentityResult> EditUser(IdentityUser user);
        Task<IdentityResult> DeleteUser(string id);
        Task<IdentityUser> FindUser(string id);
        IList<IdentityUser> FindAllUsers();
    }
}
