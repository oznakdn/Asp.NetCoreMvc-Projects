using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelerBlog.Core.Entity;

namespace TravelerBlog.Domain.Entities
{
    public class FlagPicture:EntityBase
    {
        [Key,ForeignKey("Country")]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Country Country { get; set; }
        public override string? Description { get; set; }

    }
}
