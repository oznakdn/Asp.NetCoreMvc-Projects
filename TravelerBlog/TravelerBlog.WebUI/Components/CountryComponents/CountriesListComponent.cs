using Microsoft.AspNetCore.Mvc;
using TravelerBlog.Application.Repositories;

namespace TravelerBlog.WebUI.Components.CountryComponents
{
    public class CountriesListComponent : ViewComponent
    {
        private readonly ICountryRepository countryRepositorcy;

        public CountriesListComponent(ICountryRepository countryRepositorcy)
        {
            this.countryRepositorcy = countryRepositorcy;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var coutries =await countryRepositorcy.GetAllAsync(false);
            var result =await coutries.ToListAsync();
            return View(result);
        }
    }
}
