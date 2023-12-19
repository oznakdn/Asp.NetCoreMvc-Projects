using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Models.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "{0} must be greater than 6 characters!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
