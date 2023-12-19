using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Application.Dtos.ContentDtos;

namespace TechTree.Persistence.Services
{
    
    public class ContentService : IContentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(CreateContentDto createContentDto)
        {
            var content = _mapper.Map<Content>(createContentDto);
            await _unitOfWork.Content.AddAsync(content);
            await _unitOfWork.SaveAsync();

        }

        public async Task Delete(int Id)
        {
            var content =await _unitOfWork.Content.GetAsync(x => x.Id == Id);
            _unitOfWork.Content.Delete(content);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ContentDto> Get(int Id)
        {
            var content = await _unitOfWork.Content.GetAsync(x => x.Id == Id);
            return _mapper.Map<ContentDto>(content);
        }

        public async Task<IEnumerable<ContentsDto>> GetAll(int Id)
        {
            var contents = await _unitOfWork.Content.GetAllAsync(x => x.CategoryItemId == Id);
            return _mapper.Map<List<ContentsDto>>(contents);
        }

        public async Task Update(UpdateContentDto updateContentDto)
        {
            var content = await _unitOfWork.Content.GetAsync(x => x.Id == updateContentDto.Id);
            content.Title = updateContentDto.Title;
            content.HTMLContent = updateContentDto.HTMLContent;
            content.VideoLink = updateContentDto.VideoLink;
            content.CategoryItemId = updateContentDto.CategoryItemId;

            _unitOfWork.Content.Update(content);
            await _unitOfWork.SaveAsync();
        }
    }
}
