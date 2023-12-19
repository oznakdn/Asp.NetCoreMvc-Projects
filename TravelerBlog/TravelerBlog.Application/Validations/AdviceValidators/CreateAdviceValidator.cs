using FluentValidation;
using TravelerBlog.Core.Dtos.AdviceDtos;

namespace TravelerBlog.Application.Validations.AdviceValidators
{
    public class CreateAdviceValidator:AbstractValidator<CreateAdviceDto>
    {
        public CreateAdviceValidator()
        {
            RuleFor(a => a.UserId).NotNull().NotEmpty();
            RuleFor(a => a.LocationTitle).NotNull().NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(a => a.Description).NotNull().NotEmpty().MinimumLength(10).MaximumLength(300);
        }
    }
}
