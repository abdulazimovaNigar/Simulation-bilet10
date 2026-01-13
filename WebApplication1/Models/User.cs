using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class User : IdentityUser
    {
        /* public int Id { get; set; }

         [Required, MinLength(3), MaxLength(32)]

         [Required, EmailAddress]
         public string Email { get; set; }
         public string Password { get; set; }
 */

        [Required, MinLength(8), MaxLength(20)]
        public string Fullname { get; set; }
    }
}
