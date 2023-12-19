using FaturaYonetimSistemi.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Abstract.BaseRepository
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T Insert(T entity);
        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
        T Update(T entity);
        T Delete(int id);
        T SoftDelete(int id);
        T Get(Expression<Func<T, bool>> Predicate, params Expression<Func<T, object>>[] includeProperty);
        T GetById(int id);
        List<T> GetAll(Expression<Func<T, bool>> Predicate = null, params Expression<Func<T, object>>[] includeProperty);
    }
}
