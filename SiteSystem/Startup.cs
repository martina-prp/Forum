using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Ninject;
using Owin;
using SiteSystem.Data;
using SiteSystem.Models;
using System;
using System.Reflection;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(SiteSystem.Startup))]
namespace SiteSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            CreateRoles();
        }

        // Create Administrator role and admin user
        private void CreateRoles()
        {
            SiteSystemDbContext context = new SiteSystemDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            string[] Roles = { "Administrator" };

            foreach (var roleName in Roles)
            {
                var roleExists = roleManager.RoleExists(roleName);
                if (!roleExists)
                {
                    roleManager.Create(new IdentityRole(roleName));
                }
            }

            if (roleManager.RoleExists("Administrator"))
            {
                var user = new ApplicationUser();
                user.UserName = "admin@site.com";
                user.Email = "admin@site.com";

                var userCreateResult = userManager.Create(user, "Admin@57");

                if (userCreateResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrator");
                }
            }
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}
