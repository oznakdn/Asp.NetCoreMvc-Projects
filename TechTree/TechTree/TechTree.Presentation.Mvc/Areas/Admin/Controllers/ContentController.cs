using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechTree.Application.Dtos.ContentDtos;
using TechTree.Application.Services;

namespace TechTree.Presentation.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ContentController : Controller
    {
        private readonly IContentService _service;
        private readonly ICategoryItemService _categoryItemService;

        public ContentController(IContentService service, ICategoryItemService categoryItemService)
        {
            _service = service;
            _categoryItemService = categoryItemService;
        }

        public async Task<IActionResult> Index(int Id)
        {
            ViewBag.categoryItemId = Id;
            var content = await _service.GetAll(Id);
            if(content!=null)
            {
                return View(content);

            }
            return RedirectToAction(nameof(Add), new {Id= ViewBag.categoryItemId});
        }

        [HttpGet]
        public IActionResult Add(int Id)
        {
            return View(new CreateContentDto() { CategoryItemId=Id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Add(CreateContentDto createContentDto)
        {
            if(ModelState.IsValid)
            {
                await _service.Add(createContentDto);
                return RedirectToAction(nameof(Index), new { Id = createContentDto.CategoryItemId });
            }
            return View(createContentDto);
        }

        [HttpGet]
        public async Task<IActionResult>Update(int Id)
        {
            var content = await _service.Get(Id);
            var updateContentDto = new UpdateContentDto
            {
                Title=content.Title,
                HTMLContent=content.HTMLContent,
                VideoLink=content.VideoLink,
                CategoryItemId=content.CategoryItemId
            };
            ViewBag.categoryItem = await _categoryItemService.GetAll();
            return View(updateContentDto);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateContentDto updateContentDto)
        {
            if(ModelState.IsValid)
            {
                await _service.Update(updateContentDto);
                return RedirectToAction(nameof(Index), new { Id = updateContentDto.CategoryItemId });
            }
            ViewBag.categoryItem = await _categoryItemService.GetAll();
            return View(updateContentDto);

        }

        public async Task<IActionResult>Delete(int Id)
        {
            await _service.Delete(Id);
            return RedirectToAction(nameof(Index), new { Id = ViewBag.categoryItemId });
        }
    }
}
