using FaturaYonetimSistemi.OdemeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FaturaYonetimSistemi.OdemeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HesapController : ControllerBase
    {
        private readonly FakeData _fakeData;

        public HesapController(FakeData fakeData)
        {
            _fakeData = fakeData;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var hesaplar = _fakeData.hesaplar.ToList();
            return Ok(hesaplar);
        }
    }
}
