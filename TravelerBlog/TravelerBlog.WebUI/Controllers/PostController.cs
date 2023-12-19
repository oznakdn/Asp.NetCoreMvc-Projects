using Microsoft.AspNetCore.Mvc;
using TravelerBlog.Application.Repositories;

namespace TravelerBlog.WebUI.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View();
        }


        //public IActionResult AddPost()
        //{
        //    return PartialView("_AddPostPartial");
        //}

        //[HttpPost]
        //public async Task<IActionResult>AddPost(Post post)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        await _postRepository.AddAsync(post);
        //        return RedirectToAction("GetLocationDetail", new {id = post.LocationId});
        //    }

        //    return PartialView("_AddPostPartial");
        //}
    }
}
