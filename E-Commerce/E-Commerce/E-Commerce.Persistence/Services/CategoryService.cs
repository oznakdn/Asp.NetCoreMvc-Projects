using AutoMapper;
using E_Commerce.Domain.ViewModels.CategoryVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Services
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

        public void Add(CreateCategoryVM createCategoryVM)
        {
            var category = _mapper.Map<Category>(createCategoryVM);
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
        }

        public void Delete(Category category)
        {
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
        }

        public CategoriesVM Get(int id)
        {
            var category = _unitOfWork.Category.Get(x => x.Id == id);
            return _mapper.Map<CategoriesVM>(category);
        }

        public IEnumerable<CategoriesVM> GetAll()
        {
            var categories = _unitOfWork.Category.GetAll();
            return _mapper.Map<List<CategoriesVM>>(categories);
        }

        public Category GetCategory(int? id)
        {
            var category = _unitOfWork.Category.Get(x => x.Id == id);
            return category;
        }

        public void Update(UpdateCategoryVM updateCategoryVM)
        {
            var category = _unitOfWork.Category.Get(x => x.Id == updateCategoryVM.Id);
            category.Name = updateCategoryVM.Name;
            category.DisplayOrder = updateCategoryVM.DisplayOrder;
            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
        }
    }
}
