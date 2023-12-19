using E_Commerce.Domain.Entities;
using E_Commerce.Domain.ViewModels.CategoryVM;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        public IActionResult Index()
        {
            var categories = _category.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateCategoryVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCategoryVM createCategoryVM)
        {
            if(ModelState.IsValid)
            {
                _category.Add(createCategoryVM);
                return RedirectToAction(nameof(Index));
            }

            return View(createCategoryVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _category.Get(id);
            var categoryVM = new UpdateCategoryVM
            {
                Name=category.Name,
                DisplayOrder=category.DisplayOrder,
            };

            return View(categoryVM);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateCategoryVM updateCategoryVM)
        {
            if(ModelState.IsValid)
            {
                _category.Update(updateCategoryVM);
                return RedirectToAction(nameof(Index));
            }
            return View(updateCategoryVM);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var category = _category.GetCategory(id);
            if(category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(Category category)
        {
            _category.Delete(category);
            TempData["success"] = "Category deleted done!";
            return RedirectToAction(nameof(Index));
        }
    }
}
