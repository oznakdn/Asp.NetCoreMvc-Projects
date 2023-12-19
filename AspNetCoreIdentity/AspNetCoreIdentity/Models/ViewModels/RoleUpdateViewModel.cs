

using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Models.ViewModels
{
    public class RoleUpdateViewModel
    {
        [Required(ErrorMessage ="{0} is required!")]
        public string Name { get; set; }
    }
}
