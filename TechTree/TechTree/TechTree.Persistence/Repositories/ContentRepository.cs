using TechTree.Persistence.Contexts;

namespace TechTree.Persistence.Repositories
{
    public class ContentRepository : GenericRepository<Content>, IContentRepository
    {
        public ContentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
