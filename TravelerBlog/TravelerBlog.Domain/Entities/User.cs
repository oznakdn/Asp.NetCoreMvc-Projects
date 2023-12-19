using Microsoft.AspNetCore.Identity;

namespace TravelerBlog.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
