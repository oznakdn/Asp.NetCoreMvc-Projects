using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechTree.Application.Dtos.MediaTypeDtos;
using TechTree.Application.Services;

namespace TechTree.Presentation.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class MediaTypeController : Controller
    {
        private readonly IMediaTypeService _service;

        public MediaTypeController(IMediaTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult>  Index()
        {
            var result =await _service.GetAll();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult>Details(int Id)
        {
            var result = await _service.Get(Id);
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new CreateMediaTypeDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Add(CreateMediaTypeDto createMediaTypeDto)
        {
            if(ModelState.IsValid)
            {
                await _service.Add(createMediaTypeDto);
                return RedirectToAction(nameof(Index));
            }

            return View(createMediaTypeDto);
        }

        [HttpGet]
        public async Task<IActionResult>Update(int Id)
        {
            var mediaType = await _service.GetById(Id);
            var updateMediaType = new UpdateMediaTypeDto
            {
                Title=mediaType.Title,
                ThumbnailImagePath=mediaType.ThumbnailImagePath
            };
            return View(updateMediaType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Update(UpdateMediaTypeDto updateMediaTypeDto)
        {
            if(ModelState.IsValid)
            {
                await _service.Update(updateMediaTypeDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateMediaTypeDto);
        }

        public async Task<IActionResult>Delete(int Id)
        {
            await _service.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
