using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelerBlog.Core.Entity;

namespace TravelerBlog.Domain.Entities
{
    public class Vote:EntityBase
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }
        [Range(1,5)]
        public byte Rating { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
    }
}
