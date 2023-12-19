using FaturaYonetimSistemi.Shared.Dtos.BlokDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Abstract
{
    public interface IBlokService
    {
        Blok Get(Expression<Func<Blok, bool>> Predicate, params Expression<Func<Blok, object>>[] includeProperty);
        void AddBlok(InsertBlokDto model);
        void UpdateBlok(UpdateBlokDto model);
        Blok SoftDelete(int id);

        List<ListBlokDto> GetAllBlok(Expression<Func<ListBlokDto, bool>> predicate = null);


    }
}
