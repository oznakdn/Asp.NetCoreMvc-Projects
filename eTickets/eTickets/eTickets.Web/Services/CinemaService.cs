using eTickets.Web.Data;
using eTickets.Web.Models.Entities;
using eTickets.Web.Repositories;

namespace eTickets.Web.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemaService(AppDbContext context) : base(context) { }
    }
}
