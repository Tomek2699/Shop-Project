using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Account
{
    public class AccountManagerRepository : IAccountManagerRepository
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountManagerRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // Register method
        public async Task<IdentityResult> Register(RegisterModel model)
        {
            var user = new IdentityUser { UserName = model.Login };
            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return result;
            }
            else
            {
                return result;
            }
        }

        // Login method
        public async Task<SignInResult> Login(LoginModel model)
        {
            SignInResult result = await signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
            return result;
        }

        // Logout method
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        // CRUD ACCOUNT METHODS

        // Edit User
        public async Task<IdentityResult> EditUser(IdentityUser user)
        {
            IdentityUser user1 = await FindUser(user.Id);
            user1.UserName = user.UserName;
            IdentityResult result = await userManager.UpdateAsync(user1);

            return result;
        }

        // Delete user
        public async Task<IdentityResult> DeleteUser(string id)
        {
            IdentityResult result = await userManager.DeleteAsync(await FindUser(id));

            return result;
        }

        // Find User
        public async Task<IdentityUser> FindUser(string id)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);

            return user;
        }
        // Find all users method
        public IList<IdentityUser> FindAllUsers()
        {
            return userManager.Users.ToList();
        }
    }
}
