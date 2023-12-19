using eTickets.Web.Data;
using eTickets.Web.Models.Entities;
using eTickets.Web.Repositories;

namespace eTickets.Web.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
    {
        public ActorService(AppDbContext context) : base(context)
        {
        }
    }
}
