using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Domain.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HTMLContent { get; set; }
        public string VideoLink { get; set; }
        public CategoryItem CategoryItem { get; set; }
        public int CategoryItemId { get; set; }
        
        [NotMapped]
        public int CategoryId { get; set; }
    }
}
