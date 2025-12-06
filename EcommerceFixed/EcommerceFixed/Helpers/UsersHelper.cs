using Microsoft.AspNetCore.Identity;
using EcommerceFixed.Data;
using EcommerceFixed.Models;
using System.Security.Claims;

namespace EcommerceFixed.Helpers
{
    public class UsersHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersHelper(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // MÉTODOS DE INSTANCIA (para inyección de dependencias)
        public ApplicationUser GetCurrentUser()
        {
            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            return _userManager.FindByIdAsync(userId).Result;
        }

        public string GetCurrentUserId()
        {
            return _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
        }

        public bool IsUserAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }

        public string GetUserInitials()
        {
            var user = GetCurrentUser();
            if (user == null) return "U";

            // ✅ CORREGIDO: Calcular initials manualmente
            return !string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName)
                ? $"{user.FirstName[0]}{user.LastName[0]}".ToUpper()
                : user.Email?[0].ToString().ToUpper() ?? "U";
        }

        // MÉTODOS ESTÁTICOS (para compatibilidad con código existente)
        public static ApplicationUser GetUser(ApplicationDbContext context, ClaimsPrincipal userClaim)
        {
            if (userClaim == null || context == null) return null;

            var userId = userClaim.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return null;

            return context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public static string GetUserId(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}