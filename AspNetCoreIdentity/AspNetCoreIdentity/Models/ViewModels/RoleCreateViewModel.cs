using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Models.ViewModels
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage ="{0} is required!")]
        public string Name { get; set; }

    }
}
