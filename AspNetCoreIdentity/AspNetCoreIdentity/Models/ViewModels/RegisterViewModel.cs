using AspNetCoreIdentity.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(6,ErrorMessage ="{0} must be greater than 6 characters!")]
        public string Password { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string? Picture { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }


    }
}
