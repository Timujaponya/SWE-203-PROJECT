using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels
{
    public class EditViewModel
    {
        // User ID
        [Required]
        public string? Id { get; set; }

        // Full name of the user
        public string? FullName { get; set; }

        // Email address of the user
        [EmailAddress]
        public string? Email { get; set; }

        // Password for the user account
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        // Confirmation of the password
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parola eşleşmiyor.")]
        public string? ConfirmPassword { get; set; }

        // List of selected roles for the user
        public IList<string>? SelectedRoles { get; set; }
    }
}
