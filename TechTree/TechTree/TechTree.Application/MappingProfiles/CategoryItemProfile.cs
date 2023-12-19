using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Application.Dtos.CategoryItemDtos;

namespace TechTree.Application.MappingProfiles
{
    public class CategoryItemProfile:Profile
    {
        public CategoryItemProfile()
        {
            CreateMap<CategoryItem, CategoryItemsDto>();
            CreateMap<CategoryItem, CategoryItemDto>().ReverseMap();
            CreateMap<CreateCategoryItemDto, CategoryItem>();
        }
    }
}
