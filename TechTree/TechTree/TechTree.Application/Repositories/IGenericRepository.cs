using System.Linq.Expressions;

namespace TechTree.Application.Repositories
{
    public interface IGenericRepository<T> where T:class,new()
    {
        IQueryable<T> GetAll();
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        T Delete(T entity);


    }
}
