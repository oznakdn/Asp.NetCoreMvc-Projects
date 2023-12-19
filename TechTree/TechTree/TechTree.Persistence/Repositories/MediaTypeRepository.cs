using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Persistence.Contexts;

namespace TechTree.Persistence.Repositories
{
    public class MediaTypeRepository : GenericRepository<MediaType>, IMediaTypeRepository
    {
        public MediaTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
