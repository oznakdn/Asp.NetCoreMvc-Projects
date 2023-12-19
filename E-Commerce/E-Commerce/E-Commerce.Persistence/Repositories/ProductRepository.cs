using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistence.Repositories
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

       
    }
}
