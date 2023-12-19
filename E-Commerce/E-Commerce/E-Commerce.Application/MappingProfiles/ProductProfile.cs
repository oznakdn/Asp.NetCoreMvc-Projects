using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.MappingProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductsVM>();
            CreateMap<Product, ProductswithCategoryVM>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

        }
    }
}
