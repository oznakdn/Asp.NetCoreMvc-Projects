using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Application.Dtos.MediaTypeDtos
{
    public class CreateMediaTypeDto
    {

        [Required]
        [StringLength(200,MinimumLength =2)]
        public string Title { get; set; }

        [Display(Name ="Thumbnail Image Path")]
        public string ThumbnailImagePath { get; set; }
    }
}
