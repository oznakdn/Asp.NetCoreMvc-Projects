namespace TravelerBlog.Persistence.Repositories
{
    public class AdviceRepository : RepositoryBase<Advice>, IAdviceRepository
    {
        public AdviceRepository(TravelerBlogDbContext context) : base(context)
        {

        }
    }
}
