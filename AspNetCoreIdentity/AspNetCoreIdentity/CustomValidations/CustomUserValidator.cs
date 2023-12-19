using AspNetCoreIdentity.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.CustomValidations
{
    public class CustomUserValidator : IUserValidator<AppUser>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            string[] digits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            List<IdentityError> errors = new List<IdentityError>();

            foreach (var item in digits)
            {
                if (user.UserName[0].ToString()== item)
                {
                    errors.Add(new IdentityError { Code = "UsernameContainsFirstLetterHasNumber", Description = "Username's first character cannot contain a number!"});
                }
            }

            if (errors.Count == 0)
            {
                return await Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return await Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

        }
    }
}
