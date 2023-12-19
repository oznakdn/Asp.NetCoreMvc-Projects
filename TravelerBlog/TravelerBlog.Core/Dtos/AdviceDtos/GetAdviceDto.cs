namespace TravelerBlog.Core.Dtos.AdviceDtos
{
    public class GetAdviceDto
    {
        public Guid Id { get; set; }
        public string LocationTitle { get; set; }
        public DateTime AdviceDate { get; set; } = DateTime.UtcNow;
        public string? PhotoUrl { get; set; }
    }
}
