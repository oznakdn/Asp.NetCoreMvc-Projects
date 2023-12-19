using System.Linq.Expressions;
using TravelerBlog.Core.Entity;

namespace TravelerBlog.Core.Repository
{
    public interface IRepositoryBase<T> where T:EntityBase
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<T>DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);


        Task<IQueryable<T>> GetAllAsync(bool isChangeTracking, Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(bool isChangeTracking, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(bool isChangeTracking, Guid id);




    }
}
