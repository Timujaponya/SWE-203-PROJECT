using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels
{
    public class CreateViewModel
    {
        // Full name of the user
        [Required]
        public string FullName { get; set; } = string.Empty;

        // Username of the user
        [Required]
        public string UserName { get; set; } = string.Empty;

        // Email address of the user
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Password for the user account
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        // Confirmation of the password
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Parola eşleşmiyor.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
