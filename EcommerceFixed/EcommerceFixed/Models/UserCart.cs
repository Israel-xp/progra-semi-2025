using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EcommerceFixed.Models
{
    public class UserCart
    {

        [Key]
        [Required]
        public string UserId { get; set; }
        [Required]
        public string CartDataJSON { get; set; }
    }
}
