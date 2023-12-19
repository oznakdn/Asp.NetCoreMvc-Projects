using FaturaYonetimSistemi.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYonetimSistemi.Mvc.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciService _kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        public IActionResult Index(int id)
        {
           var kullanici= _kullaniciService.GetDetailKullanici(id);
            return View(kullanici);
        }
    }
}
