
namespace TravelerBlog.Persistence.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly TravelerBlogDbContext _context;

        public RepositoryBase(TravelerBlogDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<T>> GetAllAsync(bool isChangeTracking, Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (isChangeTracking)
            {
                query = predicate == null ? query : query.Where(predicate);

                if(includes != null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }
            }
            else
            {
                query = predicate == null ? query : query.Where(predicate).AsNoTracking();
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item).AsNoTracking();
                    }
                }
            }

            return await Task.FromResult(query);
        }

        public async Task<T> GetAsync(bool isChangeTracking, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if(isChangeTracking)
            {
                query = query.Where(predicate);

                if(includes != null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }
            }
            else
            {
                query = query.Where(predicate).AsNoTracking();
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item).AsNoTracking();
                    }
                }

            }

            return await query.FirstOrDefaultAsync();

        }

        public async Task<T> GetByIdAsync(bool isChangeTracking, Guid id)
        {
            var query = _context.Set<T>();

            if(!isChangeTracking)
            {
                query.AsNoTracking();
            }
            return await query.FindAsync(id);
        }

       
    }
}
