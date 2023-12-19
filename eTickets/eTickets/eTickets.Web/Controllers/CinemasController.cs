using eTickets.Web.Data;
using eTickets.Web.Models.Entities;
using eTickets.Web.Models.Static;
using eTickets.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Web.Controllers
{


    [Authorize(Roles =UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _cinemaService.GetAllAsync();
            return View(allCinemas);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            await _cinemaService.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Edit(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null) return View("NotFound");

            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            await _cinemaService.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Delete(int id)
        {
            var result = await _cinemaService.GetByIdAsync(id);
            if (result == null) return View("NotFound");

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var result = await _cinemaService.GetByIdAsync(id);
            if (result == null) return View("NotFound");

            await _cinemaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
