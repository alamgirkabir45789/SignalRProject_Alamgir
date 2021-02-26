using Microsoft.Owin;
using Owin;
using SignalRProject_Alamgir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(SignalRProject_Alamgir.Startup))]

namespace SignalRProject_Alamgir
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            CreateRolesandUsers();
            app.MapSignalR();

            //GlobalHost.HubPipeline.RequireAuthentication();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            int countRole = context.Roles.Count();
            int countUser = context.Users.Count();

            if (countRole == 0 && countUser == 0)
            {
                Role adminRole = new Role();
                adminRole.Name = "Admin";
                Role userRole = new Role();
                userRole.Name = "User";
                List<Role> roles = new List<Role>();
                roles.Add(adminRole);
                roles.Add(userRole);
                context.Roles.AddRange(roles);

                User adminUser = new User();
                adminUser.UserName = "alamgir";
                adminUser.Password = "123456";
                adminUser.Email = "alamgir@gmail.com";
                adminUser.Active = true;
                context.Users.Add(adminUser);

                UserRole aUserRole = new UserRole();
                aUserRole.User = adminUser;
                aUserRole.Role = adminRole;
                context.UserRoles.Add(aUserRole);

                context.SaveChanges();
            }
        }
    }
}
