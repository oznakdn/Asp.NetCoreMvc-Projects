using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciDtos;
using FaturaYonetimSistemi.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYonetimSistemi.Mvc.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class KullaniciController : Controller
    {
        private readonly IKullaniciService _kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        public IActionResult GetAll()
        {
            var kullanicilar = _kullaniciService.GetAllKullanicilar();
            return View(kullanicilar);
        }

        public IActionResult GetDetail(int id)
        {
            var kullanici = _kullaniciService.GetDetailKullanici(id);
            return View(kullanici);
        }

        public IActionResult Add()
        {
            return View(new InsertKullaniciDto());
        }
        [HttpPost]
        public IActionResult Add(InsertKullaniciDto model)
        {
            if(ModelState.IsValid)
            {
                _kullaniciService.AddKullanici(model);
                return RedirectToAction("GetAll");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var kullanici = _kullaniciService.Get(x => x.ID == id);
            var model = new UpdateKullaniciDto
            {
                Ad=kullanici.Ad,
                Soyad=kullanici.Soyad,
                TCNo=kullanici.TCNo,
                Fotograf=kullanici.Fotograf,
                Email=kullanici.Email,
                Telefon=kullanici.Telefon,
                Arac=kullanici.Arac,
                Plaka=kullanici.Plaka,
                DaireId=kullanici.DaireId,
                AktifMi=kullanici.AktifMi
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(UpdateKullaniciDto model)
        {
            if(ModelState.IsValid)
            {
                _kullaniciService.UpdateKullanici(model);
                return RedirectToAction("GetAll");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _kullaniciService.SoftDelete(id);
            return RedirectToAction("GetAll");
        }

        
    }
}
