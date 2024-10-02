using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Services;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesService _movieService;

        public MoviesController(MoviesService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetMovies();

            return View(movies);
        }

        public async Task<IActionResult> Add()
        {
            var genres = await _movieService.GetGenres();
            ViewBag.Genres = genres ?? [];

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddMovie(movie);

                return RedirectToAction(nameof(Index));
            }

            var genres = await _movieService.GetGenres();
            ViewBag.Genres = genres ?? [];

            return View(movie);
        }

        public async Task<IActionResult> Update(int id)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            var genres = await _movieService.GetGenres();
            ViewBag.Genres = genres ?? [];

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _movieService.UpdateMovie(movie);

                return RedirectToAction(nameof(Index));
            }

            var genres = await _movieService.GetGenres();
            ViewBag.Genres = genres ?? [];

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.DeleteMovie(id);

            return RedirectToAction(nameof(Index));
        }
    }
}