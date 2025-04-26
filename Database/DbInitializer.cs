using Microsoft.AspNetCore.Identity;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Repositories;

namespace PlayNirvanaTechExam.Database;

public static class DbInitializer
{
    public static async Task Initialize(RepositoryContext context,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        context.Database.EnsureCreated();

        // Check if roles already exist
        if (!context.Roles.Any())
        {
            // Create roles
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Employee"));
            await roleManager.CreateAsync(new IdentityRole("User"));
            await roleManager.CreateAsync(new IdentityRole("Creator"));
            await roleManager.CreateAsync(new IdentityRole("Business"));
        }
        
    }
}