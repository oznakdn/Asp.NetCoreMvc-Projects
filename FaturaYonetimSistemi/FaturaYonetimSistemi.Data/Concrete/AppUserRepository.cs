using FaturaYonetimSistemi.Data.Abstract;
using FaturaYonetimSistemi.Data.Context;
using FaturaYonetimSistemi.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Concrete
{
    public class AppUserRepository:IAppUserRepository
    {
        public AppUser Delete(int id)
        {
            using var context = new AppDbContext();
            var findId = context.Set<AppUser>().Find(id);
            context.Set<AppUser>().Remove(findId);
            context.SaveChanges();
            return findId;
        }

        public AppUser Get(Expression<Func<AppUser, bool>> Predicate, params Expression<Func<AppUser, object>>[] includeProperty)
        {
            using var context = new AppDbContext();
            return context.Set<AppUser>().Where(Predicate).Include(includeProperty.ToString()).SingleOrDefault();
        }

        public List<AppUser> GetAll(Expression<Func<AppUser, bool>> Predicate = null, params Expression<Func<AppUser, object>>[] includeProperty)
        {
            using var context = new AppDbContext();
            return Predicate == null ? context.Set<AppUser>().Include(includeProperty.ToString()).ToList()
                                   : context.Set<AppUser>().Include(includeProperty.ToString()).Where(Predicate).ToList();
        }

        public AppUser GetById(int id)
        {
            using var context = new AppDbContext();
            return context.Set<AppUser>().Find(id);
        }

        public AppUser Insert(AppUser entity)
        {
            using var context = new AppDbContext();
            context.Set<AppUser>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public AppUser Update(AppUser entity)
        {
            using var context = new AppDbContext();
            context.Set<AppUser>().Update(entity);
            context.SaveChanges();
            return entity;

        }
    }
}
