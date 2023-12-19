using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.MappingProfiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoriesVM>();
            CreateMap<CreateCategoryVM, Category>();
            CreateMap<UpdateCategoryVM, Category>();

        }
    }
}
