namespace TravelerBlog.Core.Dtos.AdviceDtos
{
    public class GetAdvicesDto
    {
        public string LocationTitle { get; set; }
        public DateTime AdviceDate { get; set; } = DateTime.UtcNow;
        public string? PhotoUrl { get; set; }
    }
}
