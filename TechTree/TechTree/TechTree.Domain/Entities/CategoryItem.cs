using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Domain.Entities
{
    public class CategoryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //[DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime ItemReleasedDate { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public int MediaTypeId { get; set; }
        public MediaType MediaType { get; set; }

    }
}
