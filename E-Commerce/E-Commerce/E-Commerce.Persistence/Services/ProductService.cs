using AutoMapper;
using E_Commerce.Domain.ViewModels.ProductVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(CreateProductVM createProductVM)
        {

            var filePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../E-Commerce.WebMvc/wwwroot/img"));
            var fileName = Path.Combine(filePath, createProductVM.ImageFile.FileName);
            var stream = new FileStream(fileName, FileMode.Create);
            createProductVM.ImageFile.CopyTo(stream);


            var product = new Product
            {
                Name = createProductVM.Name,
                Description=createProductVM.Description,
                Price=createProductVM.Price,
                ImageUrl=createProductVM.ImageFile.FileName,
                CategoryId=createProductVM.CategoryId
            };

            _unitOfWork.Product.Add(product);
            _unitOfWork.Save();
        }

        public void Delete(int Id)
        {
            var product = _unitOfWork.Product.Get(x => x.Id == Id);
            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
        }

        public ProductsVM Get(int Id)
        {
            var product= _unitOfWork.Product.Get(x => x.Id == Id);
            return _mapper.Map<ProductsVM>(product);
        }

        public IEnumerable<ProductsVM> GetAll()
        {
            var products = _unitOfWork.Product.GetAll();
            return _mapper.Map<List<ProductsVM>>(products);
        }

        public Product GetById(int Id)
        {
            return _unitOfWork.Product.Get(x => x.Id == Id);
        }

        public IEnumerable<ProductswithCategoryVM> GetProductsWithCategory()
        {
            var productsWithCategory = _unitOfWork.Product.GetAll(includeProperties:"Category");
            return _mapper.Map<List<ProductswithCategoryVM>>(productsWithCategory);
        }

        public void Update(UpdateProductVM updateProductVM)
        {
            var product = _unitOfWork.Product.Get(x => x.Id == updateProductVM.Id);
            product.Name = updateProductVM.Name;
            product.Description = updateProductVM.Description;
            product.Price = updateProductVM.Price;
            product.ImageUrl = updateProductVM.ImageFile.FileName;
            product.CategoryId = updateProductVM.CategoryId;

            _unitOfWork.Product.Update(product);
            _unitOfWork.Save();
        }
    }
}
