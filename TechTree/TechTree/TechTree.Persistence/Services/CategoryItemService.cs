using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Application.Dtos.CategoryItemDtos;

namespace TechTree.Persistence.Services
{
    public class CategoryItemService : ICategoryItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(CreateCategoryItemDto createCategoryItemDto)
        {
            var categoryItem = _mapper.Map<CategoryItem>(createCategoryItemDto);
            await _unitOfWork.CategoryItem.AddAsync(categoryItem);
            await _unitOfWork.SaveAsync();
            
        }
        public async Task Update(UpdateCategoryItemDto updateCategoryItemDto)
        {
            var categoryItem = await _unitOfWork.CategoryItem.GetAsync(x => x.Id == updateCategoryItemDto.Id);
            categoryItem.Title = updateCategoryItemDto.Title;
            categoryItem.Description = updateCategoryItemDto.Description;
            categoryItem.ItemReleasedDate = updateCategoryItemDto.ItemReleasedDate;
            categoryItem.MediaTypeId = updateCategoryItemDto.MediaTypeId;
            categoryItem.CategoryId = updateCategoryItemDto.CategoryId;

            _unitOfWork.CategoryItem.Update(categoryItem);
            await _unitOfWork.SaveAsync();

        }

        public async Task Delete(int Id)
        {
            var categoryItem = await _unitOfWork.CategoryItem.GetAsync(x => x.Id == Id);
            _unitOfWork.CategoryItem.Delete(categoryItem);
            await _unitOfWork.SaveAsync();
        }

        public async Task<CategoryItemDto> Get(int Id)
        {
            var categoryItem = await _unitOfWork.CategoryItem.GetAsync(x => x.Id == Id);
           var categoryItemDto= _mapper.Map<CategoryItemDto>(categoryItem);
            return categoryItemDto;
           
        }

        public async Task<IEnumerable<CategoryItemsDto>> GetAll(int Id)
        {
            var categoryItems= await _unitOfWork.CategoryItem.GetAllAsync(x => x.CategoryId == Id);
            return _mapper.Map<List<CategoryItemsDto>>(categoryItems);
            
        }

        public async Task<IEnumerable<CategoryItemsDto>> GetAll()
        {
            var categoryItems = await _unitOfWork.CategoryItem.GetAllAsync();
            return _mapper.Map<List<CategoryItemsDto>>(categoryItems);
        }

    
    }
}
