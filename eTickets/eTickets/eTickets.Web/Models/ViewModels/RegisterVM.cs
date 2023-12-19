using System.ComponentModel.DataAnnotations;

namespace eTickets.Web.Models.ViewModels
{
    public class RegisterVM
    {

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage ="{0} is required!")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password",ErrorMessage ="Password do not match")]
        public string ConfirmPassword{ get; set; }
    }
}
