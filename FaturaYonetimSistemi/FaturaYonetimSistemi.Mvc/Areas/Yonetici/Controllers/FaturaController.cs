using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.FaturaDtos;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYonetimSistemi.Mvc.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class FaturaController : Controller
    {
        private readonly IFaturaService _faturaService;

        public FaturaController(IFaturaService faturaService)
        {
            _faturaService = faturaService;
        }

        public IActionResult GetAll()
        {
            var faturalar = _faturaService.GetAllFaturalar();
            return View(faturalar);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(InsertFaturaDto model)
        {
            if(ModelState.IsValid)
            {
                _faturaService.Add(model);
                return RedirectToAction("GetAll");
            }
            return View(model);

        }

        public IActionResult Update(int id)
        {
            var fatura = _faturaService.Get(x => x.ID == id);
            var model = new UpdateFaturaDto
            {
                FaturaAdi=fatura.FaturaAdi,
                Tutar=fatura.Tutar,
                SonOdemeTarihi=fatura.SonOdemeTarihi,
                Aciklama=fatura.Aciklama,
                AktifMi=fatura.AktifMi
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateFaturaDto model)
        {
            if(ModelState.IsValid)
            {
                _faturaService.Update(model);
                return RedirectToAction("GetAll");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _faturaService.SoftDelete(id);
            return RedirectToAction("GetAll");
        }
    }
}
