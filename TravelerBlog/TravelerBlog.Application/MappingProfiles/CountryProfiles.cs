using AutoMapper;
using TravelerBlog.Core.Dtos.CountryDto;
using TravelerBlog.Domain.Entities;

namespace TravelerBlog.Application.MappingProfiles
{
    public class CountryProfiles:Profile
    {
        public CountryProfiles()
        {
            CreateMap<CreateCountryDto, Country>();
        }
    }
}
