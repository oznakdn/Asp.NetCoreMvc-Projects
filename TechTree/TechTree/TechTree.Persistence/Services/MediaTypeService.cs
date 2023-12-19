using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Application.Dtos.MediaTypeDtos;

namespace TechTree.Persistence.Services
{
    public class MediaTypeService : IMediaTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MediaTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(CreateMediaTypeDto createMediaTypeDto)
        {
            var mediaType = _mapper.Map<MediaType>(createMediaTypeDto);
            await _unitOfWork.MediaType.AddAsync(mediaType);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int Id)
        {
            var mediaType = await _unitOfWork.MediaType.GetAsync(x => x.Id == Id);
            _unitOfWork.MediaType.Delete(mediaType);
            await _unitOfWork.SaveAsync();
        }

        public async Task<MediaTypeDto> Get(int Id)
        {
            var mediaType = await _unitOfWork.MediaType.GetAsync(x => x.Id == Id);
            return _mapper.Map<MediaTypeDto>(mediaType);
        }

        public async Task<List<MediaTypesDto>> GetAll()
        {
            var mediaTypes =await _unitOfWork.MediaType.GetAllAsync();
            var model= _mapper.Map<List<MediaTypesDto>>(mediaTypes);
            return model;
        }

        public async Task<MediaType> GetById(int Id)
        {
            return await _unitOfWork.MediaType.GetAsync(x => x.Id == Id);
        }

        public async Task Update(UpdateMediaTypeDto updateMediaTypeDto)
        {
            var mediaType = await _unitOfWork.MediaType.GetAsync(x => x.Id == updateMediaTypeDto.Id);
            mediaType.Title = updateMediaTypeDto.Title;
            mediaType.ThumbnailImagePath = updateMediaTypeDto.ThumbnailImagePath;
            _unitOfWork.MediaType.Update(mediaType);
            await _unitOfWork.SaveAsync();
        }
    }
}
