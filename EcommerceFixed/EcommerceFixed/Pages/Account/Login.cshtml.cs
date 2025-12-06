using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceFixed.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceFixed.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string ReturnUrl { get; set; } = "/";

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            public bool RememberMe { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
            Console.WriteLine($"🔐 LOGIN: Intentando login para {Input.Email}");

            if (!ModelState.IsValid)
            {
                TempData["error"] = "Por favor, corrige los errores.";
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, false);

            if (result.Succeeded)
            {
                Console.WriteLine($"✅ LOGIN EXITOSO: {Input.Email}");
                _logger.LogInformation("Usuario {Email} inició sesión.", Input.Email);
                return LocalRedirect(ReturnUrl);
            }

            Console.WriteLine($"❌ LOGIN FALLIDO: {Input.Email}");
            TempData["error"] = "Email o contraseña incorrectos.";
            return Page();
        }
    }
}