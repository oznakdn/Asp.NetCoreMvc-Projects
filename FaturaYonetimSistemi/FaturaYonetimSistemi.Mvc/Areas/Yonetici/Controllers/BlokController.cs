using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.BlokDtos;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYonetimSistemi.Mvc.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class BlokController : Controller
    {

        private readonly IBlokService _blokService;
        public BlokController(IBlokService blokService)
        {
            _blokService = blokService;
        }

        public IActionResult GetAll()
        {
            var bloklar = _blokService.GetAllBlok();
            return View(bloklar);
        }

        public IActionResult Add()
        {
            return View(new InsertBlokDto());
        }

        [HttpPost]
        public IActionResult Add(InsertBlokDto model)
        {
            if(ModelState.IsValid)
            {
                _blokService.AddBlok(model);
                return RedirectToAction("GetAll");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var blok = _blokService.Get(x => x.ID == id);
            var model = new UpdateBlokDto
            {
                BlokAdi=blok.BlokAdi,
                ToplamDaire=blok.ToplamDaire,
                AktifMi=blok.AktifMi
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateBlokDto model)
        {
            if(ModelState.IsValid)
            {
                _blokService.UpdateBlok(model);
                return RedirectToAction("GetAll");
            }
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            _blokService.SoftDelete(id);
            return RedirectToAction("GetAll");
        }
    }
}
