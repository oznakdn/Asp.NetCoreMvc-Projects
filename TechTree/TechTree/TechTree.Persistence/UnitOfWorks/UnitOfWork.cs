using TechTree.Persistence.Contexts;
using TechTree.Persistence.Repositories;

namespace TechTree.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {


        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        private readonly CategoryRepository categoryRepository;
        private readonly CategoryItemRepository categoryItemRepository;
        private readonly ContentRepository contentRepository;
        private readonly MediaTypeRepository mediaTypeRepository;
        private readonly UserCategoryRepository userCategoryRepository;





        public ICategoryRepository Category => categoryRepository ?? new CategoryRepository(_context);
        public ICategoryItemRepository CategoryItem => categoryItemRepository ?? new CategoryItemRepository(_context);
        public IContentRepository Content => contentRepository ?? new ContentRepository(_context);
        public IMediaTypeRepository MediaType => mediaTypeRepository ?? new MediaTypeRepository(_context);
        public IUserCategoryRepository UserCategory => userCategoryRepository ?? new UserCategoryRepository(_context);




        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
