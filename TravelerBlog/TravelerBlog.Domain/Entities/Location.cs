using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TravelerBlog.Core.Entity;

namespace TravelerBlog.Domain.Entities
{
    public class Location : EntityBase
    {


        public Location()
        {
            Posts = new HashSet<Post>();
            LocationPictures = new HashSet<LocationPicture>();
            Votes = new HashSet<Vote>();

        }

        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }
        public string LocationName { get; set; }
        public Guid CountryId { get; set; }
        public string City { get; set; }
        public string? Ditrict { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<LocationPicture> LocationPictures { get; set; }
        public ICollection<Vote> Votes { get; set; }
        public Country Country { get; set; }

    }
}
