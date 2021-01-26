using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using OnlineShoppingStore.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineShoppingStore.Startup))]
namespace OnlineShoppingStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
            app.MapSignalR();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User 
            //if (!roleManager.RoleExists("Admin"))
            //{

            //    // first we create Admin role
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Admin";
            //    roleManager.Create(role);

            //    //Here we create a Admin super user who will maintain the website				

            //    var user = new ApplicationUser();
            //    user.UserName = "admin";
            //    user.Email = "Admin@gmail.com";

            //    string userPWD = "a1234!";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    //Add default User to Role Admin
            //    if (chkUser.Succeeded)
            //    {
            //        UserManager.AddToRole(user.Id, "Admin");
            //    }
            //}
        }
    }
}
