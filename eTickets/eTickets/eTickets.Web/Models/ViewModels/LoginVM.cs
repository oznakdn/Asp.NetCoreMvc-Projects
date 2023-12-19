using System.ComponentModel.DataAnnotations;

namespace eTickets.Web.Models.ViewModels
{
    public class LoginVM
    {

        [Required(ErrorMessage ="{0} is required!")]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
