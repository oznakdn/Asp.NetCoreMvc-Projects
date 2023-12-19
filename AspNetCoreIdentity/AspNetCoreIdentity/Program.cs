using AspNetCoreIdentity.Context;
using AspNetCoreIdentity.CustomValidations;
using AspNetCoreIdentity.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DbContext configuration
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

// Identity configuration
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequiredUniqueChars = 0;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 6;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    //opt.Lockout.MaxFailedAccessAttempts = 3;
    //opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

})
   .AddPasswordValidator<CustomPasswordValidator>()
   .AddUserValidator<CustomUserValidator>()
   .AddErrorDescriber<CustomIdentityErrorDescriber>()
   .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


// Cookie configuration

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie = new CookieBuilder
    {
        Name = "MyBlog",
        HttpOnly = false,
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.Always
    };
        
    opt.LoginPath = new PathString("/Account/Login");
    opt.LogoutPath = new PathString("/Member/Logout");
    opt.AccessDeniedPath = new PathString("/Member/AccessDenied");
    opt.SlidingExpiration = true;
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
