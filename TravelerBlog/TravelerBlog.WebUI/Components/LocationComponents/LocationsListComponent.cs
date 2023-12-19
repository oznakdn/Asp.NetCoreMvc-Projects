using Microsoft.AspNetCore.Mvc;
using TravelerBlog.Application.Repositories;

namespace TravelerBlog.WebUI.Components.LocationComponents
{
    public class LocationsListComponent:ViewComponent
    {
        private readonly ILocationRepository _locationRepository;

        public LocationsListComponent(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public IViewComponentResult Invoke()
        {
            var locations = _locationRepository.GetAllAsync(false,null,l=>l.LocationPictures).Result;
            var result = locations.ToList();
            return View(result);
        }
    }
}
