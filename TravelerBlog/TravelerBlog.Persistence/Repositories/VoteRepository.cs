namespace TravelerBlog.Persistence.Repositories
{
    public class VoteRepository : RepositoryBase<Vote>, IVoteRepository
    {
        public VoteRepository(TravelerBlogDbContext context) : base(context)
        {
        }
    }
}
