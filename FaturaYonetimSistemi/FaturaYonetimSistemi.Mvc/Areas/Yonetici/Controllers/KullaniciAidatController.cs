using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciAidatDto;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYonetimSistemi.Mvc.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class KullaniciAidatController : Controller
    {
        private readonly IKullaniciAidatService _kullaniciAidatService;

        public KullaniciAidatController(IKullaniciAidatService kullaniciAidatService)
        {
            _kullaniciAidatService = kullaniciAidatService;
        }

        public IActionResult GetAll(int id)
        {
            var kullaniciAidat = _kullaniciAidatService.GetAllKullaniciAidatlar(id);
            return View(kullaniciAidat);
        }

        public IActionResult Add()
        {
            return View(new InsertKullaniciAidatDto());
        }

        [HttpPost]
        public IActionResult Add(InsertKullaniciAidatDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _kullaniciAidatService.AddKullaniciAidat(model);
                    return RedirectToAction("GetAll");
                }
                return View(model);
            }
            catch
            {

                return RedirectToAction("GetAll");
            }
           
        }

        public IActionResult Update(int Id)
        {
            var kullaniciAidat = _kullaniciAidatService.Get(x => x.ID==Id);
            var model = new UpdateKullaniciAidatDto
            {
                KullaniciId=kullaniciAidat.KullaniciId,
                AidatId = kullaniciAidat.AidatId,
                OdendiMi = kullaniciAidat.OdendiMi,
                OdenmeTarihi = kullaniciAidat.OdenmeTarihi,
                AktifMi = kullaniciAidat.AktifMi
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateKullaniciAidatDto model)
        {
            if(ModelState.IsValid)
            {
                _kullaniciAidatService.UpdateKullaniciAidat(model);
                return RedirectToAction("GetAll");
            }

            return View(model);

        }

        public IActionResult Delete(int id)
        {
            _kullaniciAidatService.SoftDelete(id);
            return RedirectToAction("GetAll");
        }
    }
}
