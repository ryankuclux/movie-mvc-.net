using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Services;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoviesService _movieService;

        public HomeController(MoviesService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetMovies();

            return View(movies);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public async Task<IActionResult> Search(string searchBar)
        {
            if (string.IsNullOrWhiteSpace(searchBar))
            {
                return View("Index", new List<Movie>());
            }

            var movies = await _movieService.GetMovies();

            var results = movies?
                .Where(m => m.Title.Contains(searchBar, StringComparison.CurrentCultureIgnoreCase))
                .ToList();

            return View("index", results);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            var movies = await _movieService.GetMovies();

            var relatedMovies = movies?
            .Where(m => m.GenreId == movie.GenreId && m.Id != movie.Id)
            .ToList();

            movie.RelatedMovies = relatedMovies;

            return View(movie);
        }
    }
}