using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelerBlog.Core.Entity;

namespace TravelerBlog.Domain.Entities
{
    public class Advice:EntityBase
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get ; set; }
        public string LocationTitle { get; set; }
        public DateTime AdviceDate { get; set; } = DateTime.UtcNow;
        public string? PhotoUrl { get; set; }
        public string Name { get; set; }
        public string? EmailAddress { get; set; }
    }
}
