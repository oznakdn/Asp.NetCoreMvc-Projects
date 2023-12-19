using EmployeeManagementSystem.Service.Data;
using EmployeeManagementSystem.Service.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Service.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity, new()
    {

        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperty)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (includeProperty is not null)
            {
                foreach (var item in includeProperty)
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperty)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includeProperty is not null)
            {
                foreach (var item in includeProperty)
                {
                    query = query.Include(item);
                }
            }

            return await query.Where(predicate).SingleOrDefaultAsync();
        }

        public async Task<T> RemoveAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            EntityEntry entry = _context.Entry<T>(entity);
            entry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            EntityEntry entry = _context.Entry<T>(entity);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
