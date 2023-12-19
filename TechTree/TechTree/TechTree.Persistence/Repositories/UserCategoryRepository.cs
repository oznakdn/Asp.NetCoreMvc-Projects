using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Persistence.Contexts;

namespace TechTree.Persistence.Repositories
{
    public class UserCategoryRepository : GenericRepository<UserCategory>, IUserCategoryRepository
    {
        public UserCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
