using System.Linq.Expressions;
using TravelerBlog.Core.Repository;
using TravelerBlog.Domain.Entities;

namespace TravelerBlog.Application.Repositories
{
    public interface ILocationRepository:IRepositoryBase<Location>
    {
        Task<IEnumerable<Location>> GetAllWithIncludeAndThanInclude(bool isChangeTracking,Expression<Func<Location, bool>>predicate = null);
    }
}
