using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Abstract
{
    public interface IAppUserRepository
    {
        AppUser Insert(AppUser entity);
        AppUser Update(AppUser entity);
        AppUser Delete(int id);
        AppUser Get(Expression<Func<AppUser, bool>> Predicate, params Expression<Func<AppUser, object>>[] includeProperty);
        AppUser GetById(int id);
        List<AppUser> GetAll(Expression<Func<AppUser, bool>> Predicate = null, params Expression<Func<AppUser, object>>[] includeProperty);
    }
}
