using eTickets.Web.Data;
using eTickets.Web.Models.Entities;
using eTickets.Web.Repositories;

namespace eTickets.Web.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext context) : base(context)
        {

        }

        
    }
}
