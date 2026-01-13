using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.UserViewModels
{
    public class RegisterVM
    {
        [Required, MinLength(3), MaxLength(32)]
        public string Fullname { get; set; } = string.Empty;
        [Required, MinLength(3), MaxLength(32)]
        public string Username { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Required, MinLength(8), MaxLength(32), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        
        [Required, MinLength(8), MaxLength(32), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
