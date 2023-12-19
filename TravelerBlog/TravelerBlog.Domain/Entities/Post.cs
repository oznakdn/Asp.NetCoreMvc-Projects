using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelerBlog.Core.Entity;

namespace TravelerBlog.Domain.Entities
{
    public class Post : EntityBase
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; } = DateTime.UtcNow;
        public override bool IsActive { get; set; } = false;
        public DateTime? ApproveDate { get; set; }
        public Guid LocationId { get; set; }
        public string Name { get; set; }
        public string? EmailAddress { get; set; }
        public Location Location { get; set; }

        [NotMapped]
        public override string Description { get; set; }

    }
}
