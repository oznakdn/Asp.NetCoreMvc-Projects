using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Shared.Dtos.BlokDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Abstract
{
    public interface IBlokRepository:IRepository<Blok>
    {
        List<ListBlokDto> GetAllBlok(Expression<Func<ListBlokDto, bool>>predicate=null);

    }
}
