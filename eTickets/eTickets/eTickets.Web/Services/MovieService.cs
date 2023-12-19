using eTickets.Web.Data;
using eTickets.Web.Models.Entities;
using eTickets.Web.Models.ViewModels;
using eTickets.Web.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Web.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM movieVM)
        {
            var newMovie = new Movie
            {
                Name = movieVM.Name,
                Description = movieVM.Description,
                Price = movieVM.Price,
                ImageUrl = movieVM.ImageUrl,
                CinemaId = movieVM.CinemaId,
                StartDate = movieVM.StartDate,
                EndDate = movieVM.EndDate,
                MovieCategory = movieVM.MovieCategory,
                ProducerId = movieVM.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            // Add Movie Actors
            foreach (var actorId in movieVM.ActorIds)
            {
                var newActorMovie = new Actor_Movie
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };

                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();

        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            return movieDetails;


        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM
            {

                Actors = await _context.Actors.OrderBy(x => x.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(x => x.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(x => x.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(EditMovieVM movieVM)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == movieVM.Id);
            if (dbMovie != null)
            {

                dbMovie.Name = movieVM.Name;
                dbMovie.Description = movieVM.Description;
                dbMovie.Price = movieVM.Price;
                dbMovie.ImageUrl = movieVM.ImageUrl;
                dbMovie.CinemaId = movieVM.CinemaId;
                dbMovie.StartDate = movieVM.StartDate;
                dbMovie.EndDate = movieVM.EndDate;
                dbMovie.MovieCategory = movieVM.MovieCategory;
                dbMovie.ProducerId = movieVM.ProducerId;

                await _context.SaveChangesAsync();
            }

            // Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(x => x.MovieId == movieVM.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();



            // Add Movie Actors
            foreach (var actorId in movieVM.ActorIds)
            {
                var newActorMovie = new Actor_Movie
                {
                    MovieId = movieVM.Id,
                    ActorId = actorId
                };

                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
