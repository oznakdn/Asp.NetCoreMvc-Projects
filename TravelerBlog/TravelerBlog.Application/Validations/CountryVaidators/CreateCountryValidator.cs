using FluentValidation;
using TravelerBlog.Core.Dtos.CountryDto;

namespace TravelerBlog.Application.Validations.CountryVaidators
{
    public class CreateCountryValidator:AbstractValidator<CreateCountryDto>
    {
        public CreateCountryValidator()
        {
            RuleFor(c => c.CountryName).NotEmpty().NotNull();
            RuleFor(c => c.Description).NotEmpty().NotNull().MinimumLength(20).MaximumLength(300);

        }
    }
}
