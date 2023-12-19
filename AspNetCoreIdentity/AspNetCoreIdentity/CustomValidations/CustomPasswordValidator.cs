using AspNetCoreIdentity.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.CustomValidations
{
    public class CustomPasswordValidator : IPasswordValidator<AppUser>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                if(!user.Email.Contains(user.UserName))
                {
                    errors.Add(new IdentityError { Code = "PasswordContainsUsername", Description = "Password cannot contain username!" });

                }
            }

            if (password.ToLower().Contains("123456"))
            {
                errors.Add(new IdentityError { Code = "PasswordContainsConsecutiveNumber", Description = "Password cannot contain consecutive number!" });
            }

            if(password.ToLower().Contains(user.Email.ToLower()))
            {
                errors.Add(new IdentityError { Code = "PasswordContainsEmail", Description = "Password cannot contain email!" });

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
