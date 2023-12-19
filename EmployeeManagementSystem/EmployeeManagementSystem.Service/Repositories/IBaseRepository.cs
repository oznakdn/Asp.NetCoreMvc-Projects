using EmployeeManagementSystem.Service.Models.Base;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Service.Repositories
{
    public interface IBaseRepository<T> where T:class,IBaseEntity,new()
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperty);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperty);
    }
}
