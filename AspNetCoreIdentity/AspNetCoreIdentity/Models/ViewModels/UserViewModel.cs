using AspNetCoreIdentity.Models.Enums;

namespace AspNetCoreIdentity.Models.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string? Picture { get; set; }
        public string? BirthDate { get; set; }
        public string Gender { get; set; }

    }
}
