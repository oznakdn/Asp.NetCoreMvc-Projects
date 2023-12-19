using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechTree.Application.MappingProfiles;
using TechTree.Persistence.Contexts;
using TechTree.Persistence.Services;
using TechTree.Persistence.UnitOfWorks;

namespace TechTree.Persistence.Extensions
{
    public static class CustomExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connectionString));

            //services.AddIdentityCore<ApplicationUser>(options =>
            //options.SignIn.RequireConfirmedAccount = false)
            //    //.AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
                

            services.AddAutoMapper(typeof(CategoryProfile));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryItemService, CategoryItemService>();
            services.AddScoped<IMediaTypeService, MediaTypeService>();
            services.AddScoped<IContentService, ContentService>();










        }
    }
}
