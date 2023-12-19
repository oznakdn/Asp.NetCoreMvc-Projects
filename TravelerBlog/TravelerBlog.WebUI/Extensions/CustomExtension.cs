using FluentValidation;
using TravelerBlog.Application.Repositories;
using TravelerBlog.Application.Validations.AdviceValidators;
using TravelerBlog.Application.Validations.CountryVaidators;
using TravelerBlog.Core.Dtos.AdviceDtos;
using TravelerBlog.Core.Dtos.CountryDto;
using TravelerBlog.Persistence.Repositories;

namespace TravelerBlog.WebUI.Extensions
{
    public static class CustomExtension
    {
        public static IServiceCollection AddIocContainer(this IServiceCollection services)
        {
            services.AddScoped<IAdviceRepository, AdviceRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IPostRepository, PostRepository>();



            return services;
        }

        public static IServiceCollection AddFluentValidationContainer (this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateAdviceDto>, CreateAdviceValidator>();
            services.AddScoped<IValidator<CreateCountryDto>, CreateCountryValidator>();
            return services;
        }
       

    }
}
