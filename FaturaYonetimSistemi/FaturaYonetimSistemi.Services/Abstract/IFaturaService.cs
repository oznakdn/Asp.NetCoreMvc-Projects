using FaturaYonetimSistemi.Shared.Dtos.FaturaDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Abstract
{
    public interface IFaturaService
    {
        List<ListFaturaDto> GetAllFaturalar();
        Fatura Get(Expression<Func<Fatura, bool>> Predicate, params Expression<Func<Fatura, object>>[] includeProperty);
        void Add(InsertFaturaDto model);
        void Update(UpdateFaturaDto model);
        Fatura SoftDelete(int id);

    }
}
