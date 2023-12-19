using eTickets.Web.Models.Base;
using eTickets.Web.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Web.Models.Entities
{
    public class Cinema:IEntityBase
    {
        public int Id { get; set; }

        [Display(Name ="Cinema Logo")]
        [Required(ErrorMessage ="Cinema logo is required!")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required!")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Cineme name must be between 3 and 50 chars!")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        public List<Movie> Movies { get; set; }


    }
}
