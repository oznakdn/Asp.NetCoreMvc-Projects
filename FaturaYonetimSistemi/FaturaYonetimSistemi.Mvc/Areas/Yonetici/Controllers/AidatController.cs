using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.AidatDtos;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYonetimSistemi.Mvc.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class AidatController : Controller
    {
        private readonly IAidatService _aidatService;

        public AidatController(IAidatService aidatService)
        {
            _aidatService = aidatService;
        }

        public IActionResult GetAllAidat()
        {
            var aidatlar = _aidatService.GetAll();
            return View(aidatlar);
        }


        public IActionResult AddAidat()
        {
            return View(new InsertAidatDto());
        }

        [HttpPost]
        public IActionResult AddAidat(InsertAidatDto model)
        {
            if (ModelState.IsValid)
            {
                _aidatService.Insert(model);
                return RedirectToAction("GetAllAidat");

            }
            return View(model);
        }

        public IActionResult UpdateAidat(int id)
        {

            var aidat = _aidatService.Get(x => x.ID == id);
            var model = new UpdateAidatDto
            {
                Donem = aidat.Donem,
                Tutar = aidat.Tutar,
                SonOdemeTarihi = aidat.SonOdemeTarihi,
                Aciklama = aidat.Aciklama,
                AktifMi = aidat.AktifMi
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateAidat(UpdateAidatDto model)
        {
            var aidat = _aidatService.Get(x => x.ID == model.ID);
            if (ModelState.IsValid)
            {
                aidat.Donem = model.Donem;
                aidat.Tutar = model.Tutar;
                aidat.SonOdemeTarihi = model.SonOdemeTarihi;
                aidat.Aciklama = model.Aciklama;
                aidat.AktifMi = model.AktifMi;
                _aidatService.Update(model);
                return RedirectToAction("GetAllAidat", "Aidat");
            }
            return View(model);

        }

        public IActionResult DeleteAidatGet(int id)
        {
            var aidat = _aidatService.Get(x => x.ID == id);
            return View(aidat);
        }

        [HttpPost]
        public IActionResult DeleteAidat(int id)
        {
           
            _aidatService.SoftDelete(id);
            return RedirectToAction("GetAllAidat");
        }
    }
}
