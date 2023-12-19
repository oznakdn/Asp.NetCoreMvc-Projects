using Microsoft.AspNetCore.Mvc;
using TravelerBlog.Application.Repositories;

namespace TravelerBlog.WebUI.Components.LocationComponents
{
    public class LocationHeaderListComponent:ViewComponent
    {
        private readonly ILocationRepository _locationRepository;

        public LocationHeaderListComponent(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IViewComponentResult>InvokeAsync()
        {
            var locations = await _locationRepository.GetAllAsync(false);
            var result = await locations.OrderBy(x => x.LocationName).ToListAsync();
            return View(result);
        }
    }
}
