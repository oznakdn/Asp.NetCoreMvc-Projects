using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Application.Dtos.CategoryDtos
{
    public class CategorywithItemsDto
    {
        public List<Category> Categories { get; set; } = new List<Category>();

        public List<CategoryItem> CategoryItems { get; set; } = new List<CategoryItem>();

    }
}
