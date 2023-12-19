using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Models.ViewModels
{
    public class PasswordResetConfirmViewModel
    {
        [Required]
        [MinLength(6, ErrorMessage = "{0} must be greater than 6 characters!")]
        public string NewPassword { get; set; }
    }
}
