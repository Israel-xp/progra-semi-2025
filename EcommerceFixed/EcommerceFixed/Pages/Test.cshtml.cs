using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceFixed.Models;

namespace EcommerceFixed.Pages
{
    public class TestModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TestModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostTestRegisterAsync()
        {
            try
            {
                var testUser = new ApplicationUser
                {
                    UserName = "test@test.com",
                    Email = "test@test.com",
                    FirstName = "Test",
                    LastName = "User",
                    EmailConfirmed = true,
                    IsActive = true
                };

                // Eliminar usuario si existe
                var existingUser = await _userManager.FindByEmailAsync("test@test.com");
                if (existingUser != null)
                {
                    await _userManager.DeleteAsync(existingUser);
                }

                var result = await _userManager.CreateAsync(testUser, "123");

                if (result.Succeeded)
                {
                    TempData["message"] = "✅ REGISTRO EXITOSO - Usuario 'test@test.com' creado";
                }
                else
                {
                    TempData["message"] = $"❌ ERROR: {string.Join(", ", result.Errors.Select(e => e.Description))}";
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = $"💥 EXCEPCIÓN: {ex.Message}";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostTestLoginAsync()
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync("test@test.com", "123", false, false);

                if (result.Succeeded)
                {
                    TempData["message"] = "✅ LOGIN EXITOSO - Sesión iniciada";
                }
                else
                {
                    TempData["message"] = $"❌ LOGIN FALLIDO - Result: {result}";
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = $"💥 EXCEPCIÓN: {ex.Message}";
            }

            return Page();
        }
    }
}