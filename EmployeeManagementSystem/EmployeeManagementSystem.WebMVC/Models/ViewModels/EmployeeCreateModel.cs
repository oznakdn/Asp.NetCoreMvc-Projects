using EmployeeManagementSystem.WebMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.WebMVC.Models.ViewModels
{
    public class EmployeeCreateModel
    {

        [Required(ErrorMessage ="First name is a required field!")]
        [Display(Name ="First name")]
        public string Firstname { get; set; }


        [Required(ErrorMessage = "Last name is a required field!")]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Gender is a required field!")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Photo is a required field!")]
        [Display(Name = "Photo Url")]
        public string PhotoUrl { get; set; }

        [Required(ErrorMessage = "Department is a required field!")]
        public Department Department { get; set; }

        [Required(ErrorMessage = "Start date is a required field!")]
        public DateTime StartDate { get; set; }
    }
}
