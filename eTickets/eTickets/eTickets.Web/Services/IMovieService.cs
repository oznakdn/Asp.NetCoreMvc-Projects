using eTickets.Web.Models.Entities;
using eTickets.Web.Models.ViewModels;
using eTickets.Web.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Web.Services
{
    public interface IMovieService:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM movieVM);
        Task UpdateMovieAsync(EditMovieVM movieVM);

    }
}
