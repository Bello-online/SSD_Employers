using Microsoft.AspNetCore.Identity;
using SSD_Employers.Models;
using System.Threading.Tasks;

namespace SSD_Employers.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed roles
            string[] roleNames = { "Manager", "Employee" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            string adminUsername = Environment.GetEnvironmentVariable("AdminUsername") 
                ?? throw new InvalidOperationException("AdminUserName environment variable is not set.");
            string adminPassword = Environment.GetEnvironmentVariable("AdminPassword") 
                ?? throw new InvalidOperationException("AdminPassword environment variable is not set.");

            // Seed default Manager user
            if (userManager.FindByNameAsync(adminUsername).Result == null)
            {
                var managerUser = new ApplicationUser
                {
                    UserName = adminUsername,
                    Email = adminUsername,
                    FirstName = "John",
                    LastName = "Doe",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(managerUser,adminPassword);
                await userManager.AddToRoleAsync(managerUser, "Manager");
            }

            string memberUsername = Environment.GetEnvironmentVariable("MemberUsername")
                         ?? throw new InvalidOperationException("MemberUserName environment variable is not set.");
            string memberPassword = Environment.GetEnvironmentVariable("MemberPassword")
                ?? throw new InvalidOperationException("MemberPassword environment variable is not set.");

            // Seed default Employee user
            if (userManager.FindByNameAsync(memberUsername).Result == null)
            {
                var employeeUser = new ApplicationUser
                {
                    UserName = memberUsername,
                    Email = memberUsername,
                    FirstName = "Jane",
                    LastName = "Doe",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(employeeUser, memberPassword);
                await userManager.AddToRoleAsync(employeeUser, "Employee");
            }
        }
    }
}
