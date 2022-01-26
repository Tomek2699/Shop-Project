using HealthyDay.Models.Account;
using HealthyDay.Models.Account.Role;
using HealthyDay.Models.DataBase;
using HealthyDay.Models.Shop;
using HealthyDay.Models.Shop.Category;
using HealthyDay.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Identity Data Base
            services.AddDbContext<AccountDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IdentityDb"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AccountDbContext>();

            // Shop Data Base
            services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ShopDb"));
            });

            // Transients
            services.AddTransient<IAccountManagerRepository, AccountManagerRepository>();
            services.AddTransient<IRoleManagerRepository, RoleManagerRepository>();
            services.AddTransient<ICrudProductRepository, CrudProductRepository>();
            services.AddTransient<ICrudCategoryRepository, CrudCategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Policy
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                  .RequireAuthenticatedUser()
                                  .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlDataContractSerializerFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}