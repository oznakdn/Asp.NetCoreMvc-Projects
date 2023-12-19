using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Application.Dtos.ContentDtos
{
    public class CreateContentDto
    {

        [Required]
        [StringLength(200,MinimumLength =2)]
        public string Title { get; set; }

        [Display(Name ="HTML Content")]
        public string HTMLContent { get; set; }

        [Display(Name ="Video Link")]
        public string VideoLink { get; set; }
        public int CategoryItemId { get; set; }
    }
}
