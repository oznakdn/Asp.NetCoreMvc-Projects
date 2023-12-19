using Microsoft.AspNetCore.Mvc;
using TravelerBlog.Application.Repositories;

namespace TravelerBlog.WebUI.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCountryDetail(Guid id)
        {
            var country = await _countryRepository.GetAsync(false,c=>c.Id==id,c=>c.FlagPicture);
            return View(country);
        }
    }
}
