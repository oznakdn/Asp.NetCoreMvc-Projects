using AspNetCoreIdentity.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Models.ViewModels
{
    public class UserEditViewModel
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string? Picture { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }


    }
}
