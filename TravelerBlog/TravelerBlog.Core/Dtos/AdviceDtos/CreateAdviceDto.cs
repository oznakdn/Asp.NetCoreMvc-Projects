namespace TravelerBlog.Core.Dtos.AdviceDtos
{
    public class CreateAdviceDto
    {
        public string LocationTitle { get; set; }
        public DateTime AdviceDate { get; set; } = DateTime.UtcNow;
        public string? PhotoUrl { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }

    }
}
