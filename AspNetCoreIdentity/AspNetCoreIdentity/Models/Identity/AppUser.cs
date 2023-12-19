using AspNetCoreIdentity.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.Models.Identity
{
    public class AppUser:IdentityUser<Guid>
    {
        public string City { get; set; }
        public string? Picture { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
    }
}
