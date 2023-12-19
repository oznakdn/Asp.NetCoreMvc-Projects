using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using TravelerBlog.Application.Repositories;

namespace TravelerBlog.WebUI.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IPostRepository _postRepository;

        public LocationController(ILocationRepository locationRepository, IPostRepository postRepository)
        {
            _locationRepository = locationRepository;
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetLocationDetail(Guid id)
        {
            ViewBag.locationId = id;
            var location = await _locationRepository.GetAsync(false, x => x.Id == id, l => l.LocationPictures, l => l.Country);
            var locationPosts = await _postRepository.GetAllAsync(false, x => x.LocationId == id && x.IsActive, p => p.Location);
            ViewBag.PostList = await locationPosts.ToListAsync();
            return View(location);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocationPost(Post post)
        {


            post.IsActive = true;
            var result = await _postRepository.AddAsync(post);
            return Json(result);

        }


        //public async Task<JsonResult> GetLocationPosts(Guid id)
        //{
        //    var locationPosts = await _postRepository.GetAllAsync(false, x => x.LocationId == id && x.IsActive, p=>p.Location);
        //    //var result = JsonConvert.SerializeObject(locationPosts);
        //    var result = await locationPosts.ToListAsync();
        //    return Json(result);

        //}
    }
}
