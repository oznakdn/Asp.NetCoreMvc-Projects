using FaturaYonetimSistemi.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYonetimSistemi.Mvc.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class KullaniciFaturaController : Controller
    {
        private readonly IKullaniciFaturaService _kullaniciFaturaService;

        public KullaniciFaturaController(IKullaniciFaturaService kullaniciFaturaService)
        {
            _kullaniciFaturaService = kullaniciFaturaService;
        }

        public IActionResult GetAll(int kullaniciId)
        {
            var kullaniciFaturalar = _kullaniciFaturaService.GetAllKullaniciFatura(kullaniciId);
            return View(kullaniciFaturalar);
        }
    }
}
