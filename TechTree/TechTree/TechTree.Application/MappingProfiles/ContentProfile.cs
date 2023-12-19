using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Application.Dtos.ContentDtos;

namespace TechTree.Application.MappingProfiles
{
    public class ContentProfile:Profile
    {
        public ContentProfile()
        {
            CreateMap<Content, ContentDto>();
            CreateMap<Content, ContentsDto>();
            CreateMap<CreateContentDto, Content>();
  

        }
    }
}
