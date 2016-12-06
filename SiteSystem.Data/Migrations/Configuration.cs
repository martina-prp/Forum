namespace SiteSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SiteSystem.Data.SiteSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SiteSystem.Data.SiteSystemDbContext";
        }

        protected override void Seed(SiteSystem.Data.SiteSystemDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Create Administrator role and admin user;

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
    }
}
