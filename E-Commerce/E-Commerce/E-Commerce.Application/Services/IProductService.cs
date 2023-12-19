
namespace E_Commerce.Application.Services
{
    public interface IProductService
    {
        IEnumerable<ProductswithCategoryVM> GetProductsWithCategory();
        IEnumerable<ProductsVM> GetAll();
        ProductsVM Get(int Id);
        Product GetById(int Id);
        void Add(CreateProductVM createProductVM);
        void Update(UpdateProductVM updateProductVM);
        void Delete(int Id);

    }
}
