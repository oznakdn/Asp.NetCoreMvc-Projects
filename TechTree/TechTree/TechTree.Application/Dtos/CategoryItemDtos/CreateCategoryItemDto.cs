using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Application.Dtos.CategoryItemDtos
{
    public class CreateCategoryItemDto
    {

        [Required]
        [StringLength(200,MinimumLength =2)]
        public string Title { get; set; }

        [Display(Name ="Released Date")]
        public DateTime ItemReleasedDate { get; set; }
        public string Description { get; set; }


        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Plsease select a valid item from the {0} dropdown list")]
        [Display(Name ="Media Type")]
        public int MediaTypeId { get; set; }
    }
}
