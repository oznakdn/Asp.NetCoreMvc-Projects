using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebMvc.Areas.Customer.Controllers
{

    [Area("Customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
