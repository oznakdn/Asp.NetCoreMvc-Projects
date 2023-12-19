using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Application.Dtos.MediaTypeDtos;

namespace TechTree.Application.MappingProfiles
{
    public class MediaTypeProfile:Profile
    {
        public MediaTypeProfile()
        {
            CreateMap<MediaType, MediaTypesDto>();
            CreateMap<MediaType, MediaTypeDto>();
            CreateMap<CreateMediaTypeDto, MediaType>();


        }
    }
}
