
namespace TechTree.Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoriesDto>> GetAll();
        Task<CategorywithItemsDto> GetCategoryWithItems(int Id);
        Task<CategoryDto> Get(int id);
        Task Add(CreateCategoryDto createCategoryDto);
        Task Update(UpdateCategoryDto updateCategoryDto);
        Task Delete(int id);
    }
}
