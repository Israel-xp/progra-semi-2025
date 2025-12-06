using Newtonsoft.Json;
using EcommerceFixed.Data;
using EcommerceFixed.Models;
using System.Security.Claims;

namespace EcommerceFixed.Helpers
{
    public static class WishlistHelper
    {
        // ✅ MÉTODOS QUE ACEPTAN string userId
        public static void AddToWishlist(Product product, ApplicationDbContext context, string userId)
        {
            if (string.IsNullOrEmpty(userId) || context == null) return;

            List<Product> oldWishlist = GetUserWishlist(userId, context) ?? new List<Product>();

            if (oldWishlist.Any(x => x.Id == product.Id)) return;

            oldWishlist.Add(product);

            var userWishlist = context.UserWishlists.FirstOrDefault(c => c.UserId == userId);

            if (userWishlist != null)
            {
                userWishlist.WishlistDataJSON = JsonConvert.SerializeObject(oldWishlist, Formatting.Indented);
            }
            else
            {
                context.UserWishlists.Add(new UserWishlist()
                {
                    UserId = userId,
                    WishlistDataJSON = JsonConvert.SerializeObject(oldWishlist, Formatting.Indented),
                });
            }

            context.SaveChanges();
        }

        public static void RemoveFromWishlist(Product product, ApplicationDbContext context, string userId)
        {
            if (string.IsNullOrEmpty(userId) || context == null) return;

            var userWishlist = context.UserWishlists.FirstOrDefault(x => x.UserId == userId);
            if (userWishlist == null) return;

            var productsList = JsonConvert.DeserializeObject<List<Product>>(userWishlist.WishlistDataJSON);
            if (productsList != null)
            {
                var productToRemove = productsList.FirstOrDefault(x => x.Id == product.Id);
                if (productToRemove != null)
                {
                    productsList.Remove(productToRemove);
                    userWishlist.WishlistDataJSON = JsonConvert.SerializeObject(productsList, Formatting.Indented);
                    context.SaveChanges();
                }
            }
        }

        public static List<Product> GetUserWishlist(string userId, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(userId)) return new List<Product>();

            try
            {
                var wishlistJson = context.UserWishlists
                    .Where(x => x.UserId == userId)
                    .FirstOrDefault()?.WishlistDataJSON;

                if (!string.IsNullOrEmpty(wishlistJson))
                {
                    return JsonConvert.DeserializeObject<List<Product>>(wishlistJson) ?? new List<Product>();
                }
            }
            catch
            {
                return new List<Product>();
            }

            return new List<Product>();
        }

        public static int GetWishlistItemCount(string userId, ApplicationDbContext context)
        {
            var wishlist = GetUserWishlist(userId, context);
            return wishlist?.Count ?? 0;
        }

        public static bool IsProductInWishlist(int productId, string userId, ApplicationDbContext context)
        {
            var wishlist = GetUserWishlist(userId, context);
            return wishlist?.Any(p => p.Id == productId) ?? false;
        }

        // ✅ MÉTODOS ORIGINALES (para compatibilidad)
        private static string GetUserId(ClaimsPrincipal user)
        {
            return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static void AddToWishlist(Product product, ApplicationDbContext context, ClaimsPrincipal user)
        {
            var userId = GetUserId(user);
            AddToWishlist(product, context, userId);
        }

        public static void RemoveFromWishlist(Product product, ApplicationDbContext context, ClaimsPrincipal user)
        {
            var userId = GetUserId(user);
            RemoveFromWishlist(product, context, userId);
        }

        public static List<Product> GetUserWishlist(ClaimsPrincipal user, ApplicationDbContext context)
        {
            var userId = GetUserId(user);
            return GetUserWishlist(userId, context);
        }

        public static int GetWishlistItemCount(ClaimsPrincipal user, ApplicationDbContext context)
        {
            var userId = GetUserId(user);
            return GetWishlistItemCount(userId, context);
        }

        public static bool IsProductInWishlist(int productId, ClaimsPrincipal user, ApplicationDbContext context)
        {
            var userId = GetUserId(user);
            return IsProductInWishlist(productId, userId, context);
        }
    }
}