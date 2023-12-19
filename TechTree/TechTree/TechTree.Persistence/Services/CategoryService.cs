using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _unitOfWork.Category.AddAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var category = await _unitOfWork.Category.GetAsync(x => x.Id ==id);
            _unitOfWork.Category.Delete(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<CategoryDto> Get(int id)
        {
            var category = await _unitOfWork.Category.GetAsync(x => x.Id == id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoriesDto>> GetAll()
        {
            var categories = await _unitOfWork.Category.GetAllAsync();
            return _mapper.Map<List<CategoriesDto>>(categories);

        }

        public async Task<CategorywithItemsDto> GetCategoryWithItems(int Id)
        {
            var categorywithItems = await _unitOfWork.Category.GetAllAsync(x => x.Id == Id, y => y.CategoryItems);
            var categoryWithItemsDto = new CategorywithItemsDto();
            categoryWithItemsDto.Categories = categorywithItems.ToList();
            return categoryWithItemsDto;
          
        }

        public async Task Update(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _unitOfWork.Category.GetAsync(x => x.Id == updateCategoryDto.Id);
            //category = _mapper.Map<Category>(updateCategoryDto);
            category.Title = updateCategoryDto.Title;
            category.Description = updateCategoryDto.Description;
            category.ThumbnailImagePath = updateCategoryDto.ThumbnailImagePath;

            _unitOfWork.Category.Update(category);
            await _unitOfWork.SaveAsync();
        }
    }
}
