using E_Commerce.Domain.Entities;
using E_Commerce.Domain.ViewModels.ProductVM;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _product;
        private readonly ICategoryService _category;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductService product, ICategoryService category, IWebHostEnvironment hostEnvironment)
        {
            _product = product;
            _category = category;
            _hostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            var products = _product.GetAll();
            return View(products);
        }

        public IActionResult ProductsWithCategory()
        {
            var productsWithCategory = _product.GetProductsWithCategory();
            return View(productsWithCategory);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = _category.GetAll();
            return View(new CreateProductVM());
        }

        [HttpPost]
        public IActionResult Create(CreateProductVM createProductVM)
        {
            //var product = new Product();
            if(ModelState.IsValid)
            {
                #region Other road
                //string fileName = string.Empty;
                //var file = createProductVM.ImageFile;
                //if(file!=null)
                //{
                //    string uploadPath = Path.Combine(_hostEnvironment.WebRootPath, "img");
                //    fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                //    string filePath = Path.Combine(uploadPath, fileName);

                //    if(product.ImageUrl!=null)
                //    {
                //        var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, product.ImageUrl.TrimStart('\\'));
                //        if (System.IO.File.Exists(oldImagePath))
                //        {
                //            System.IO.File.Delete(oldImagePath);
                //        }
                //    }

                //    using (var stream=new FileStream(filePath,FileMode.Create))
                //    {
                //        file.CopyTo(stream);
                //    }
                //    product.ImageUrl = @"\img\" + fileName;
                #endregion

                _product.Add(createProductVM);
                return RedirectToAction(nameof(ProductsWithCategory));
            }

            ViewBag.categories = _category.GetAll();
            return View(new CreateProductVM());

        }

       [HttpGet]
       public IActionResult Update(int Id)
        {
            var product = _product.Get(Id);
            var updateProductVm = new UpdateProductVM
            {
                Name=product.Name,
                Description=product.Description,
                Price=product.Price,
            };

            ViewBag.categories = _category.GetAll();
            return View(updateProductVm);
        }

        [HttpPost]
        public IActionResult Update(UpdateProductVM updateProductVM)
        {
            if(ModelState.IsValid)
            {
                _product.Update(updateProductVM);
                return RedirectToAction(nameof(ProductsWithCategory));
            }

            ViewBag.categories = _category.GetAll();
            return View(updateProductVM);

        }

        public IActionResult Delete(int Id)
        {
            var product = _product.GetById(Id);
            _product.Delete(product.Id);
            return RedirectToAction(nameof(ProductsWithCategory));
        }




    }
}
