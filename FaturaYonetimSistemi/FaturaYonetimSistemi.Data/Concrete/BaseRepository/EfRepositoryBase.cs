using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Data.Context;
using FaturaYonetimSistemi.Shared.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Concrete.BaseRepository
{
    public class EfRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public void AddRange(IEnumerable<TEntity> entities)
        {
            using var context = new AppDbContext();
            context.Set<TEntity>().AddRange(entities);
            context.SaveChanges();
        }

        public TEntity Delete(int id)
        {
            using var context = new AppDbContext();
            var findId = context.Set<TEntity>().Find(id);
            context.Set<TEntity>().Remove(findId);
            context.SaveChanges();
            return findId;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> Predicate, params Expression<Func<TEntity, object>>[] includeProperty)
        {
            using var context = new AppDbContext();
            return context.Set<TEntity>().Where(Predicate).SingleOrDefault();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> Predicate = null, params Expression<Func<TEntity, object>>[] includeProperty)
        {
            using var context = new AppDbContext();
            return Predicate == null ? context.Set<TEntity>().ToList()
                                   : context.Set<TEntity>().Where(Predicate).ToList();
        }

        public TEntity GetById(int id)
        {
            using var context = new AppDbContext();
            return context.Set<TEntity>().Find(id);
        }

        public TEntity Insert(TEntity entity)
        {
            using var context = new AppDbContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            using var context = new AppDbContext();
            context.Set<TEntity>().RemoveRange(entities);
            context.SaveChanges();
           
        }

        public TEntity SoftDelete(int id)
        {
            using var context = new AppDbContext();
            var deletedId = context.Set<TEntity>().Find(id);
            context.Set<TEntity>().Update(deletedId);
            context.SaveChanges();
            return deletedId;
            
        }

        public TEntity Update(TEntity entity)
        {
            using var context = new AppDbContext();
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
            return entity;

        }
    }
}
