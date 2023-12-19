using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Application.Dtos.UserDtos
{
    public class RegisterDto
    {

        [Required]
        [StringLength(30,MinimumLength =3)]
        [Display(Name ="Name")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name ="Surname")]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(200,MinimumLength =5)]
        [Display(Name ="Address")]
        public string Address1 { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Country")]
        public string Address2 { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

    }
}
