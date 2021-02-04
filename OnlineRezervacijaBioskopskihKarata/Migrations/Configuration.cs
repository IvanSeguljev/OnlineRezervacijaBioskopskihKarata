namespace OnlineRezervacijaBioskopskihKarata.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineRezervacijaBioskopskihKarata.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineRezervacijaBioskopskihKarata.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineRezervacijaBioskopskihKarata.Models.ApplicationDbContext context)
        {
            if (!(context.Users.Any(u => u.UserName == "administrator")))
            {
                Console.WriteLine("Seeding admin user");
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "admin@gmail.com", PhoneNumber = "12345678911", Email = "administratoradmin" };
                userManager.Create(userToInsert, "12345Abcd.");
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
