using EcommerceFixed.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Models;

namespace EcommerceFixed.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                Console.WriteLine("🎯 SEED: Inicializando base de datos...");

                // Verificar si la base de datos existe, si no, crearla
                var dbCreated = await context.Database.EnsureCreatedAsync();
                Console.WriteLine($"🎯 SEED: Base de datos creada: {dbCreated}");

                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Crear rol Admin si no existe
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    Console.WriteLine("🎯 SEED: Creando rol Admin...");
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    Console.WriteLine("✅ SEED: Rol Admin creado");
                }

                // Crear usuario admin si no existe
                var adminEmail = "admin@urbantrends.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);

                if (adminUser == null)
                {
                    Console.WriteLine("🎯 SEED: Creando usuario admin...");
                    adminUser = new ApplicationUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        FirstName = "Admin",
                        LastName = "User",
                        EmailConfirmed = true,
                        IsActive = true
                    };

                    var result = await userManager.CreateAsync(adminUser, "Admin123!");

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                        Console.WriteLine("✅ SEED: Usuario admin creado exitosamente");
                    }
                    else
                    {
                        Console.WriteLine("❌ SEED: Error creando usuario admin:");
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($" - {error.Description}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ℹ️ SEED: Usuario admin ya existe");
                }

                Console.WriteLine("🎯 SEED: Inicialización completada");
            }
        }
    }
}