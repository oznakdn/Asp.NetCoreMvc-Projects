using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Domain.Entities
{
    public class Category
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailImagePath { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ICollection<CategoryItem> CategoryItems { get; set; } = new List<CategoryItem>();

        [ForeignKey("CategoryId")]
        public virtual ICollection<UserCategory> UserCategories { get; set; } = new List<UserCategory>();

    }
}
