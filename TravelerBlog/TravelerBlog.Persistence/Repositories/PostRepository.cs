namespace TravelerBlog.Persistence.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(TravelerBlogDbContext context) : base(context)
        {
        }
    }
}
