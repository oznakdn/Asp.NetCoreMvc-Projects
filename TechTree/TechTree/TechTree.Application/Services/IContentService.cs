using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Application.Dtos.ContentDtos;

namespace TechTree.Application.Services
{
    public interface IContentService
    {
        Task<ContentDto> Get(int Id);
        Task<IEnumerable<ContentsDto>> GetAll(int Id);
        Task Add(CreateContentDto createContentDto);
        Task Update(UpdateContentDto updateContentDto);
        Task Delete(int Id);
    }
}
