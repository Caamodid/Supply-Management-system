using Application.Authentication;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class IdentitySeed
    {
        public static async Task SeedRolesAndUsersAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            AppDbContext context)
        {
            Console.WriteLine("🚀 Starting Identity seeding...");

            // 1️⃣ Define roles
            var roles = new[]
            {
                new ApplicationRole { Name = "Administrator" },
                new ApplicationRole { Name = "Admin" },
                new ApplicationRole { Name = "Manager" },
                new ApplicationRole { Name = "User" }
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                    var result = await roleManager.CreateAsync(role);
                    if (result.Succeeded)
                        Console.WriteLine($"✅ Role '{role.Name}' created.");
                    else
                        Console.WriteLine($"❌ Failed to create role '{role.Name}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }

            await context.SaveChangesAsync();

            // 2️⃣ Add permissions to SuperAdmin
            var superAdminRole = await roleManager.Roles.FirstOrDefaultAsync(r => r.Name == "SuperAdmin");
            if (superAdminRole != null && !await context.RolePermissions.AnyAsync(rp => rp.RoleId == superAdminRole.Id))
            {
                context.RolePermissions.AddRange(new[]
                {
                    new RolePermission { RoleId = superAdminRole.Id, Permission = "All.Access" },
                    new RolePermission { RoleId = superAdminRole.Id, Permission = "Users.Manage" },
                    new RolePermission { RoleId = superAdminRole.Id, Permission = "Roles.Manage" },
                    new RolePermission { RoleId = superAdminRole.Id, Permission = "Projects.FullControl" },
                    new RolePermission { RoleId = superAdminRole.Id, Permission = "Employees.FullControl" }
                });
                Console.WriteLine("🧩 Permissions assigned to Administrator.");
            }

            // 3️⃣ Add permissions to Admin
            var adminRole = await roleManager.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            if (adminRole != null && !await context.RolePermissions.AnyAsync(rp => rp.RoleId == adminRole.Id))
            {
                context.RolePermissions.AddRange(new[]
                {
                    new RolePermission { RoleId = adminRole.Id, Permission = "Users.View" },
                    new RolePermission { RoleId = adminRole.Id, Permission = "Employees.View" },
                    new RolePermission { RoleId = adminRole.Id, Permission = "Projects.View" },
                    new RolePermission { RoleId = adminRole.Id, Permission = "Projects.Edit" }
                });
                Console.WriteLine("Permissions assigned to Admin.");
            }

            await context.SaveChangesAsync();

            // 4️⃣ Create Administrator user
            var superEmail = AppCredentials.Email;       // from static class
            var superPassword = AppCredentials.Password; // from static class

            if (string.IsNullOrWhiteSpace(superEmail) || string.IsNullOrWhiteSpace(superPassword))
            {
                Console.WriteLine("AppCredentials not configured for Administrator.");
            }
            else
            {
                var superAdminUser = await userManager.FindByEmailAsync(superEmail);
                if (superAdminUser == null)
                {
                    var newAdministrator = new ApplicationUser
                    {
                        Email = superEmail,
                        UserName = superEmail,
                        EmailConfirmed = true,
                        FirstName = "System",
                        LastName = "Administrator"
                    };

                    var createResult = await userManager.CreateAsync(newAdministrator, superPassword);
                    if (!createResult.Succeeded)
                    {
                        Console.WriteLine($"Failed to create Administrator: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(newAdministrator, "Administrator");
                        Console.WriteLine("Administrator user created and assigned to 'Administrator' role.");
                    }
                }
                else
                {
                    Console.WriteLine("Administrator user already exists.");
                }
            }

            // 5️⃣ Create Admin user
            var adminEmail = "admin@example.com";
            var adminPassword = "Admin@123";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var newAdmin = new ApplicationUser
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "Kahiye",
                    LastName = "Said"
                };

                var createAdminResult = await userManager.CreateAsync(newAdmin, adminPassword);
                if (!createAdminResult.Succeeded)
                {
                    Console.WriteLine($"Failed to create Admin: {string.Join(", ", createAdminResult.Errors.Select(e => e.Description))}");
                }
                else
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                    Console.WriteLine("Admin user created and assigned to 'Admin' role.");
                }
            }
            else
            {
                Console.WriteLine("Admin user already exists.");
            }

            // 6️⃣ Save all changes
            await context.SaveChangesAsync();

            Console.WriteLine("Identity seeding completed successfully.");
        }
    }
}
