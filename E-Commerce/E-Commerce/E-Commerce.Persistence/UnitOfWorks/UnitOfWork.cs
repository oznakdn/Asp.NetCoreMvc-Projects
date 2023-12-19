using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
           
        }

        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;





        public IProductRepository Product => productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Category => categoryRepository ?? new CategoryRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
