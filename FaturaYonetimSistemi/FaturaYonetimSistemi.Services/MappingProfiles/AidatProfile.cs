using AutoMapper;
using FaturaYonetimSistemi.Shared.Dtos.AidatDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.MappingProfiles
{
    public class AidatProfile:Profile
    {
        public AidatProfile()
        {
            CreateMap<InsertAidatDto, Aidat>();
            CreateMap<UpdateAidatDto, Aidat>();
            CreateMap<Aidat, ListAidatDto>();
            CreateMap<Aidat, DetailAidatDto>();
        }
    }
}
