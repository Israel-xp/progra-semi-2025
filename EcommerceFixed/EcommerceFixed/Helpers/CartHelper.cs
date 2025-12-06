using Newtonsoft.Json;
using EcommerceFixed.Data;
using EcommerceFixed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EcommerceFixed.Helpers
{
    public static class CartHelper
    {
        public static List<CartItem> DeserializeCartData(string cartDataJSON)
        {
            if (string.IsNullOrEmpty(cartDataJSON) || cartDataJSON.Trim() == "" || cartDataJSON.Trim() == "[]")
                return new List<CartItem>();

            try
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(cartDataJSON) ?? new List<CartItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing cart data: {ex.Message}");
                return new List<CartItem>();
            }
        }

        public static string SerializeCartData(List<CartItem> cartData)
        {
            return JsonConvert.SerializeObject(cartData, Formatting.Indented);
        }

        private static UserCart GetUserCart(string userId, ApplicationDbContext context)
        {
            return context.UserCarts.FirstOrDefault(uc => uc.UserId == userId);
        }

        private static UserCart GetOrCreateUserCart(string userId, ApplicationDbContext context)
        {
            var userCart = GetUserCart(userId, context);
            if (userCart == null)
            {
                userCart = new UserCart
                {
                    UserId = userId,
                    CartDataJSON = "[]"
                };
                context.UserCarts.Add(userCart);
                context.SaveChanges();
            }
            return userCart;
        }

        // ✅ MÉTODOS QUE ACEPTAN string userId
        public static List<Product> GetGroupedCartItemsDb(string userId, ApplicationDbContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(userId)) return new List<Product>();

                var userCart = GetUserCart(userId, context);
                if (userCart == null || string.IsNullOrEmpty(userCart.CartDataJSON) || userCart.CartDataJSON.Trim() == "[]")
                    return new List<Product>();

                var cartData = DeserializeCartData(userCart.CartDataJSON);
                if (cartData == null || !cartData.Any())
                    return new List<Product>();

                var productIds = cartData.Select(item => item.ProductId).Distinct().ToList();
                var products = context.Products.Where(p => productIds.Contains(p.Id)).ToList();

                // Asignar cantidades usando reflexión
                foreach (var product in products)
                {
                    var cartItem = cartData.FirstOrDefault(item => item.ProductId == product.Id);
                    if (cartItem != null)
                    {
                        var cartQuantityProperty = product.GetType().GetProperty("CartQuantity");
                        if (cartQuantityProperty != null && cartQuantityProperty.CanWrite)
                        {
                            cartQuantityProperty.SetValue(product, cartItem.Quantity);
                        }
                    }
                }

                return products.Where(p => p != null).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting cart items: {ex.Message}");
                return new List<Product>();
            }
        }

        public static decimal GetCartTotalDb(string userId, ApplicationDbContext context)
        {
            try
            {
                var cartProducts = GetGroupedCartItemsDb(userId, context);
                return cartProducts.Where(p => p != null).Sum(p =>
                {
                    decimal price = p.Price;
                    var priceAfterDiscountProperty = p.GetType().GetProperty("PriceAfterDiscount");

                    if (priceAfterDiscountProperty != null)
                    {
                        var priceAfterDiscount = priceAfterDiscountProperty.GetValue(p);
                        if (priceAfterDiscount != null && decimal.TryParse(priceAfterDiscount.ToString(), out decimal discountedPrice))
                        {
                            price = discountedPrice;
                        }
                    }

                    int quantity = 1;
                    var cartQuantityProperty = p.GetType().GetProperty("CartQuantity");
                    if (cartQuantityProperty != null)
                    {
                        var cartQuantity = cartQuantityProperty.GetValue(p);
                        if (cartQuantity != null && int.TryParse(cartQuantity.ToString(), out int qty))
                        {
                            quantity = qty;
                        }
                    }

                    return price * quantity;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating cart total: {ex.Message}");
                return 0;
            }
        }

        public static (bool success, string message) AddToCartDb(Product product, ApplicationDbContext context, string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                    return (false, "❌ Usuario no autenticado");

                var productInDb = context.Products.Find(product.Id);
                if (productInDb == null)
                    return (false, "❌ Producto no encontrado");

                if (productInDb.Quantity <= 0)
                    return (false, "❌ Producto agotado");

                var userCart = GetOrCreateUserCart(userId, context);
                var cartData = DeserializeCartData(userCart.CartDataJSON);

                var existingItem = cartData.FirstOrDefault(item => item.ProductId == product.Id);
                int currentQuantity = existingItem?.Quantity ?? 0;

                if (currentQuantity + 1 > productInDb.Quantity)
                {
                    if (productInDb.Quantity == 0)
                        return (false, "❌ Producto agotado");
                    else if (currentQuantity >= productInDb.Quantity)
                        return (false, $"⚠️ Ya tienes la cantidad máxima disponible ({productInDb.Quantity} unidades)");
                    else
                        return (false, $"⚠️ Solo puedes agregar {productInDb.Quantity - currentQuantity} unidad(es) más");
                }

                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    cartData.Add(new CartItem { ProductId = product.Id, Quantity = 1 });
                }

                userCart.CartDataJSON = SerializeCartData(cartData);
                context.SaveChanges();

                return (true, $"✅ {productInDb.Name} agregado al carrito");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding to cart: {ex.Message}");
                return (false, "❌ Error al agregar al carrito");
            }
        }

        public static (bool success, string message) RemoveFromCartDb(Product product, ApplicationDbContext context, string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                    return (false, "Usuario no autenticado");

                var userCart = GetUserCart(userId, context);
                if (userCart == null)
                    return (false, "Carrito no encontrado");

                var cartData = DeserializeCartData(userCart.CartDataJSON);
                var existingItem = cartData.FirstOrDefault(item => item.ProductId == product.Id);

                if (existingItem != null)
                {
                    if (existingItem.Quantity > 1)
                    {
                        existingItem.Quantity--;
                    }
                    else
                    {
                        cartData.Remove(existingItem);
                    }

                    userCart.CartDataJSON = SerializeCartData(cartData);
                    context.SaveChanges();
                    return (true, "Producto actualizado en el carrito");
                }

                return (false, "Producto no encontrado en el carrito");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing from cart: {ex.Message}");
                return (false, "Error al remover del carrito");
            }
        }

        public static (bool success, string message) RemoveAllFromCartDb(Product product, ApplicationDbContext context, string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                    return (false, "Usuario no autenticado");

                var userCart = GetUserCart(userId, context);
                if (userCart == null)
                    return (false, "Carrito no encontrado");

                var cartData = DeserializeCartData(userCart.CartDataJSON);
                int removedCount = cartData.RemoveAll(item => item.ProductId == product.Id);

                if (removedCount > 0)
                {
                    userCart.CartDataJSON = SerializeCartData(cartData);
                    context.SaveChanges();
                    return (true, "Producto removido del carrito");
                }

                return (false, "Producto no encontrado en el carrito");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing all from cart: {ex.Message}");
                return (false, "Error al remover del carrito");
            }
        }

        public static (bool success, string message) ClearCartDb(string userId, ApplicationDbContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                    return (false, "Usuario no autenticado");

                var userCart = GetUserCart(userId, context);
                if (userCart != null)
                {
                    userCart.CartDataJSON = "[]";
                    context.SaveChanges();
                    return (true, "Carrito limpiado exitosamente");
                }
                return (true, "Carrito ya estaba vacío");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing cart: {ex.Message}");
                return (false, "Error al limpiar el carrito");
            }
        }

        public static int GetCartItemsCountDb(string userId, ApplicationDbContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(userId)) return 0;

                var userCart = GetUserCart(userId, context);
                if (userCart == null || string.IsNullOrEmpty(userCart.CartDataJSON) || userCart.CartDataJSON.Trim() == "[]")
                    return 0;

                var cartData = DeserializeCartData(userCart.CartDataJSON);
                return cartData?.Sum(item => item.Quantity) ?? 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting cart count: {ex.Message}");
                return 0;
            }
        }

        public static bool IsProductInCart(int productId, string userId, ApplicationDbContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(userId)) return false;

                var userCart = GetUserCart(userId, context);
                if (userCart == null || string.IsNullOrEmpty(userCart.CartDataJSON) || userCart.CartDataJSON.Trim() == "[]")
                    return false;

                var cartData = DeserializeCartData(userCart.CartDataJSON);
                return cartData?.Any(item => item.ProductId == productId) ?? false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking product in cart: {ex.Message}");
                return false;
            }
        }

        public static int GetProductQuantityInCart(int productId, string userId, ApplicationDbContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(userId)) return 0;

                var userCart = GetUserCart(userId, context);
                if (userCart == null || string.IsNullOrEmpty(userCart.CartDataJSON) || userCart.CartDataJSON.Trim() == "[]")
                    return 0;

                var cartData = DeserializeCartData(userCart.CartDataJSON);
                return cartData?.FirstOrDefault(item => item.ProductId == productId)?.Quantity ?? 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting product quantity: {ex.Message}");
                return 0;
            }
        }

        // ✅ MÉTODOS ORIGINALES (para compatibilidad)
        private static string GetUserId(ClaimsPrincipal user)
        {
            return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static List<Product> GetGroupedCartItemsDb(ClaimsPrincipal user, ApplicationDbContext context)
        {
            var userId = GetUserId(user);
            return GetGroupedCartItemsDb(userId, context);
        }

        public static decimal GetCartTotalDb(ClaimsPrincipal user, ApplicationDbContext context)
        {
            var userId = GetUserId(user);
            return GetCartTotalDb(userId, context);
        }

        public static (bool success, string message) AddToCartDb(Product product, ApplicationDbContext context, ClaimsPrincipal user)
        {
            var userId = GetUserId(user);
            return AddToCartDb(product, context, userId);
        }

        public static (bool success, string message) RemoveFromCartDb(Product product, ApplicationDbContext context, ClaimsPrincipal user)
        {
            var userId = GetUserId(user);
            return RemoveFromCartDb(product, context, userId);
        }

        public static (bool success, string message) RemoveAllFromCartDb(Product product, ApplicationDbContext context, ClaimsPrincipal user)
        {
            var userId = GetUserId(user);
            return RemoveAllFromCartDb(product, context, userId);
        }

        public static (bool success, string message) ClearCartDb(ClaimsPrincipal user, ApplicationDbContext context)
        {
            var userId = GetUserId(user);
            return ClearCartDb(userId, context);
        }

        public static int GetCartItemsCountDb(ClaimsPrincipal user, ApplicationDbContext context)
        {
            var userId = GetUserId(user);
            return GetCartItemsCountDb(userId, context);
        }

        public static bool IsProductInCart(int productId, ClaimsPrincipal user, ApplicationDbContext context)
        {
            var userId = GetUserId(user);
            return IsProductInCart(productId, userId, context);
        }

        public static int GetProductQuantityInCart(int productId, ClaimsPrincipal user, ApplicationDbContext context)
        {
            var userId = GetUserId(user);
            return GetProductQuantityInCart(productId, userId, context);
        }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}