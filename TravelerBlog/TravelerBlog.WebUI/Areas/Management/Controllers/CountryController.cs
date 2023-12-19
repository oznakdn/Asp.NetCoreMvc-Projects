using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using TravelerBlog.Application.Repositories;
using TravelerBlog.Core.Dtos.CountryDto;

namespace TravelerBlog.WebUI.Areas.Management.Controllers
{

    [Area("Management")]
    public class CountryController : Controller
    {

        private readonly ICountryRepository _countryRepository;
        private readonly IValidator<CreateCountryDto> _validator;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IValidator<CreateCountryDto> validator, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _validator = validator;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCountry()
        {
            return View(new CreateCountryDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(CreateCountryDto createCountry)
        {
            ValidationResult result = await _validator.ValidateAsync(createCountry);

            Country country = new()
            {
                CountryName = createCountry.CountryName,
                Description = createCountry.Description
            };

            if (!result.IsValid)
            {
                result.AddState(this.ModelState);
                return View(nameof(Index), createCountry);
            }

            var countryMapping = _mapper.Map<Country>(createCountry);
            await _countryRepository.AddAsync(countryMapping);
            return RedirectToAction(nameof(Index));
        }
    }
}
