using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Application.Dtos.MediaTypeDtos;

namespace TechTree.Application.Services
{
    public interface IMediaTypeService
    {
        Task<List<MediaTypesDto>> GetAll();
        Task<MediaType> GetById(int Id);
        Task<MediaTypeDto> Get(int Id);
        Task Add(CreateMediaTypeDto createMediaTypeDto);
        Task Update(UpdateMediaTypeDto updateMediaTypeDto);
        Task Delete(int Id);
    }
}
