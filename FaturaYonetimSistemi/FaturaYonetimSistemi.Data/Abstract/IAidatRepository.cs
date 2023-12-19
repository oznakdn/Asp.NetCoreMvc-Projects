using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Abstract
{
    public interface IAidatRepository:IRepository<Aidat>
    {
        IEnumerable<Aidat> GetAllAidat(Expression<Func<Aidat,bool>>predicate=null);
    }
}
