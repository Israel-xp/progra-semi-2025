using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceFixed.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceFixed.Pages.Profile
{
    public class EditModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public EditModel(UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _environment = environment;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Nombre")]
            public string FirstName { get; set; }

            [Display(Name = "Apellido")]
            public string LastName { get; set; }

            [Display(Name = "Foto de Perfil")]
            public IFormFile? ProfilePictureFile { get; set; }

            public string? ProfilePicture { get; set; }

            [Display(Name = "Fecha de Nacimiento")]
            [DataType(DataType.Date)]
            public DateTime? DateOfBirth { get; set; }

            [Display(Name = "Dirección de Envío")]
            public string? ShippingAddress { get; set; }

            [Display(Name = "Ciudad")]
            public string? City { get; set; }

            [Display(Name = "Provincia/Estado")]
            public string? State { get; set; }

            [Display(Name = "Código Postal")]
            public string? PostalCode { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePicture = user.ProfilePicture,
                DateOfBirth = user.DateOfBirth,
                ShippingAddress = user.ShippingAddress,
                City = user.City,
                State = user.State,
                PostalCode = user.PostalCode
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Actualizar los campos del usuario
            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.DateOfBirth = Input.DateOfBirth;
            user.ShippingAddress = Input.ShippingAddress;
            user.City = Input.City;
            user.State = Input.State;
            user.PostalCode = Input.PostalCode;

            // Manejar la subida de la imagen de perfil
            if (Input.ProfilePictureFile != null && Input.ProfilePictureFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "profiles");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(Input.ProfilePictureFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Input.ProfilePictureFile.CopyToAsync(fileStream);
                }

                user.ProfilePicture = "/uploads/profiles/" + uniqueFileName;
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["success"] = "Perfil actualizado correctamente.";
                return RedirectToPage();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}