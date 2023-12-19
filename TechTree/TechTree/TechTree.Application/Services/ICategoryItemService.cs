using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Application.Dtos.CategoryItemDtos;

namespace TechTree.Application.Services
{
    public interface ICategoryItemService
    {
        Task<IEnumerable<CategoryItemsDto>> GetAll(int Id);
        Task<IEnumerable<CategoryItemsDto>> GetAll();
        Task<CategoryItemDto> Get(int Id);
        Task Add(CreateCategoryItemDto createCategoryItemDto);
        Task Update(UpdateCategoryItemDto updateCategoryItemDto);
        Task Delete(int Id);
    }
}
