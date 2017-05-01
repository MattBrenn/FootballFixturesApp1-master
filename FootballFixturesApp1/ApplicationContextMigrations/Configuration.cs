namespace FootballFixturesApp1.ApplicationContextMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FootballFixturesApp1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"ApplicationContextMigrations";
        }

        protected override void Seed(FootballFixturesApp1.Models.ApplicationDbContext context)
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
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                if(!RoleManager.RoleExists(roleName))
                {
                    roleResult = RoleManager.Create(new IdentityRole(roleName));
                }
            }

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole("30d9acfc-c259-451e-a13a-25fd72e3b383", "Admin");
        }

    }
}
