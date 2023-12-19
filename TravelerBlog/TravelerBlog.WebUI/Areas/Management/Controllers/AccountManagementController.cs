using Microsoft.AspNetCore.Mvc;

namespace TravelerBlog.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    public class AccountManagementController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("AddCountry", "Country");
        }
    }
}
