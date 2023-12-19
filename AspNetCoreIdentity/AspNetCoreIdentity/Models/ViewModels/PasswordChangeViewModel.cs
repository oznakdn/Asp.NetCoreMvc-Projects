using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Models.ViewModels
{
    public class PasswordChangeViewModel
    {
        [Required]
        [MinLength(6, ErrorMessage = "{0} must be equal or greater than 6 characters!")]
        public string OldPassword { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "{0} must be equal or greater than 6 characters!")]
        public string NewPassword { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "{0} must be equal or greater than 6 characters!")]
        [Compare(nameof(NewPassword),ErrorMessage ="Passwords must be the same!")]
        public string PasswordConfirm { get; set; }

    }
}
