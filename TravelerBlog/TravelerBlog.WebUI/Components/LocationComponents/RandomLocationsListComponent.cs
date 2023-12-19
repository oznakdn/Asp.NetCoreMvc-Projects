using Microsoft.AspNetCore.Mvc;
using TravelerBlog.Application.Repositories;

namespace TravelerBlog.WebUI.Components.LocationComponents
{
    public class RandomLocationsListComponent : ViewComponent
    {
        private readonly ILocationRepository _locationRepository;

        public RandomLocationsListComponent(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var locations =await _locationRepository.GetAllAsync(false,null,l=>l.Posts,l=>l.LocationPictures);
            var result =await locations.OrderBy(l => l.Posts.Count).Take(3).ToListAsync();
            return View(result);

        }
    }
}
