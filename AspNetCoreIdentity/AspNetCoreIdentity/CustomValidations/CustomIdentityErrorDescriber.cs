using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.CustomValidations
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError { Code = "InvalidUserName", Description = $"{userName} geçersizdir!" };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError { Code = "DuplicateEmail", Description = $"{email} kullanılmaktadır!" };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError { Code = "PasswordTooShort", Description = $"Şifre en az {length} karakterden oluşmalıdır!" };
        }
    }
}
