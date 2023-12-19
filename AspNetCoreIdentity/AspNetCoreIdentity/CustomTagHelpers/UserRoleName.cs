using AspNetCoreIdentity.Models.Identity;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCoreIdentity.CustomTagHelpers
{

    [HtmlTargetElement("td", Attributes = "user-roles")]
    public class UserRoleName : TagHelper
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRoleName(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HtmlAttributeName("user-roles")]
        public string UserId { get; set; }


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            AppUser user = await _userManager.FindByIdAsync(UserId);

            var userRoles = await _userManager.GetRolesAsync(user);

            string html = string.Empty;

            userRoles.ToList().ForEach(x =>
            {
                html += $"<span class='badge'> {x} </span>";
            });

            output.Content.SetContent(html);
        }

    }
}
