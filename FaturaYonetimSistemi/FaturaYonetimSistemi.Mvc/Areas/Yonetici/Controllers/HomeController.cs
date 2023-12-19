using Microsoft.AspNetCore.Mvc;

namespace FaturaYonetimSistemi.Mvc.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }


        // Yönetici Girişi Bu Kontrollerda yapılacak
        public IActionResult Login()
        {
            return View();
        }
    }
}
