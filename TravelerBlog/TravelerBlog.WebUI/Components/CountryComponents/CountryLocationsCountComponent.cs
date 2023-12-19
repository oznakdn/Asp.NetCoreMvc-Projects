using Microsoft.AspNetCore.Mvc;
using TravelerBlog.Application.Repositories;

namespace TravelerBlog.WebUI.Components.CountryComponents
{
    public class CountryLocationsCountComponent:ViewComponent
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILocationRepository _locationRepository;

        public CountryLocationsCountComponent(ICountryRepository countryRepository, ILocationRepository locationRepository)
        {
            _countryRepository = countryRepository;
            _locationRepository = locationRepository;
        }

        public IViewComponentResult Invoke()
        {
            var countryLocations = _countryRepository.GetAllAsync(false, null, c => c.Locations).Result;
            var locationCount = countryLocations.Select(c => c.Locations.Count);
            ViewBag.locationCount = locationCount.First();
            return View(countryLocations);
        }
    }
}
