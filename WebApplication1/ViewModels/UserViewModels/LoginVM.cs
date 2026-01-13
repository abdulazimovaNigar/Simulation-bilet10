using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.UserViewModels
{
    public class LoginVM
    {
        [Required, EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Required, MinLength(8), MaxLength(32)]
        public string Password { get; set; } = string.Empty;

    }
}
