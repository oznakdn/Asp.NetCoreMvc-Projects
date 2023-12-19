using eTickets.Web.Data;
using eTickets.Web.Models.Static;
using eTickets.Web.Models.ViewModels;
using eTickets.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Web.Controllers
{

    [Authorize(Roles =UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _movieService.GetAllAsync(x => x.Cinema);
            return View(allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _movieService.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }

        // GET: Movies/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var detailsMovie = await _movieService.GetMovieByIdAsync(id);
            if (detailsMovie == null) return View("NotFound");

            return View(detailsMovie);
        }

        //GET:Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _movieService.GetNewMovieDropdownsValues();
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM newMovieVM)
        {


            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _movieService.GetNewMovieDropdownsValues();
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(newMovieVM);
            }


            await _movieService.AddNewMovieAsync(newMovieVM);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var editMovie = await _movieService.GetMovieByIdAsync(id);

            if (editMovie == null) return View("NotFound");

            var response = new EditMovieVM
            {
                Id = editMovie.Id,
                Name = editMovie.Name,
                Description = editMovie.Description,
                Price = editMovie.Price,
                StartDate=editMovie.StartDate,
                EndDate=editMovie.EndDate,
                ImageUrl = editMovie.ImageUrl,
                MovieCategory = editMovie.MovieCategory,
                CinemaId=editMovie.CinemaId,
                ProducerId=editMovie.ProducerId,
                ActorIds=editMovie.Actors_Movies.Select(x=>x.ActorId).ToList()
            };

            var movieDropdownsData = await _movieService.GetNewMovieDropdownsValues();
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(int id,EditMovieVM editMovieVM)
        {
            if (id != editMovieVM.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _movieService.GetNewMovieDropdownsValues();
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(editMovieVM);
            }

            await _movieService.UpdateMovieAsync(editMovieVM);
            return RedirectToAction(nameof(Index));
        }



    }
}
