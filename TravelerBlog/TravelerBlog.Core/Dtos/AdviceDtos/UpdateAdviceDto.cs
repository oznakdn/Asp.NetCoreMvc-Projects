using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerBlog.Core.Dtos.AdviceDtos
{
    public class UpdateAdviceDto
    {
        public Guid Id { get; set; }
        public string LocationTitle { get; set; }
        public DateTime AdviceDate { get; set; } = DateTime.UtcNow;
        public string? PhotoUrl { get; set; }
    }
}
