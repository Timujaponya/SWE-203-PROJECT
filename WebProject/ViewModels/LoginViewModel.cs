using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels
{
    public class LoginViewModel
    {
        // Email address of the user
        [EmailAddress]
        public string Email { get; set; } = null!;

        // Password for the user account
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        // Remember me option for the login
        public bool RememberMe { get; set; } = true;
    }
}
