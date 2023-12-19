using Microsoft.AspNetCore.Mvc;

namespace TravelerBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

       
    }
}