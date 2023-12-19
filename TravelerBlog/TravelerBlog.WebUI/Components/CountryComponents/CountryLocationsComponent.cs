using Microsoft.AspNetCore.Mvc;
using TravelerBlog.Application.Repositories;

namespace TravelerBlog.WebUI.Components.CountryComponents
{
    public class CountryLocationsComponent
    {
        private readonly ICountryRepository _countryRepository;

        public CountryLocationsComponent(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        //public IViewComponentResult Invoke()
        //{
        //    var countryLocations = _countryRepository.GetAllAsync(false,null, c => c.Locations);
        //}

    }
}
