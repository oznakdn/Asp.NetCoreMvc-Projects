using FaturaYonetimSistemi.Data.Abstract;
using FaturaYonetimSistemi.Data.Concrete.BaseRepository;
using FaturaYonetimSistemi.Data.Context;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Concrete
{
    public class AidatRepository : EfRepositoryBase<Aidat>, IAidatRepository
    {
        public IEnumerable<Aidat> GetAllAidat(Expression<Func<Aidat, bool>> predicate = null)
        {
            using var context = new AppDbContext();
            return predicate is null ? context.Set<Aidat>().ToList()
                                     : context.Set<Aidat>().Where(predicate).ToList();
        }
    }
}
