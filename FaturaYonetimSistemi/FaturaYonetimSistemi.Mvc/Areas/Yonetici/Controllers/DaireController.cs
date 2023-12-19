using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.DaireDtos;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYonetimSistemi.Mvc.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class DaireController : Controller
    {
        private readonly IDaireService _daireService;

        public DaireController(IDaireService daireService)
        {
            _daireService = daireService;
        }

        public IActionResult GetAll()
        {
            var daireler = _daireService.GetAllDaireler();
            return View(daireler);
        }

        public IActionResult Add()
        {
            return View(new InsertDaireDto());
        }

        [HttpPost]
        public IActionResult Add(InsertDaireDto model)
        {
            if(ModelState.IsValid)
            {
                _daireService.AddDaire(model);
                return RedirectToAction("GetAll", "Daire");
            }

            return View(model);
        }

        public IActionResult Update(int id)
        {
            var daire = _daireService.Get(x => x.ID == id);
            var model = new UpdateDaireDto
            {
                Blokid=daire.Blokid,
                DaireNo=daire.DaireNo,
                Kat=daire.Kat,
                Tipi=daire.Tipi,
                BosMu=daire.BosMu,
                AktifMi=daire.AktifMi
                
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateDaireDto model)
        {
            if(ModelState.IsValid)
            {
                _daireService.UpdateDaire(model);
                return RedirectToAction("GetAll");
            }
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            _daireService.SoftDelete(id);
            return RedirectToAction("GetAll");
        }
    }
}
