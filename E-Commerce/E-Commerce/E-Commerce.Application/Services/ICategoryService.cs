using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoriesVM> GetAll();
        CategoriesVM Get(int id);
        Category GetCategory(int? id);
        void Add(CreateCategoryVM createCategoryVM);
        void Update(UpdateCategoryVM updateCategoryVM);
        void Delete(Category category);

    }
}
