namespace TravelerBlog.Persistence.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(TravelerBlogDbContext context) : base(context)
        {
        }
    }
}
