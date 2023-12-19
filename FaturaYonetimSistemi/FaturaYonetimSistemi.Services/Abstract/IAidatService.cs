using FaturaYonetimSistemi.Shared.Dtos.AidatDtos;
using FaturaYonetimSistemi.Shared.Entities;
using FaturaYonetimSistemi.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Abstract
{
    public interface IAidatService
    {
        void Insert(InsertAidatDto model);
        void Update(UpdateAidatDto model);
        void SoftDelete(int id);
        void HardDelete(int id);


        Aidat Get(Expression<Func<Aidat, bool>> Predicate, params Expression<Func<Aidat, object>>[] includeProperty);
        Aidat GetById(int id);
        List<Aidat> GetAll(Expression<Func<Aidat, bool>> Predicate = null, params Expression<Func<Aidat, object>>[] includeProperty);
    }
}
