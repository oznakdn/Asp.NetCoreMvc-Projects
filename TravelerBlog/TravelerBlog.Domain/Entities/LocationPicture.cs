using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TravelerBlog.Core.Entity;

namespace TravelerBlog.Domain.Entities
{
    public class LocationPicture:EntityBase
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public override string? Description { get; set; }


    }
}
