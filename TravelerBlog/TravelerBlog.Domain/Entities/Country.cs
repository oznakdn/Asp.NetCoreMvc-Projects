using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelerBlog.Core.Entity;

namespace TravelerBlog.Domain.Entities
{
    public class Country : EntityBase
    {
        public Country()
        {
            Locations = new HashSet<Location>();
        }

        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }
        public string CountryName { get; set; }
        public FlagPicture FlagPicture { get; set; }
       
        public ICollection<Location> Locations { get; set; }

        [NotMapped]
        public override bool IsActive { get => base.IsActive; set => base.IsActive = value; }



    }
}
