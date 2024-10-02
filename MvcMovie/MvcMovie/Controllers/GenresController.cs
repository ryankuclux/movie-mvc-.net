using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Services;

namespace MvcMovie.Controllers
{
    public class GenresController : Controller
    {
        private readonly GenresService _genreService;

        public GenresController(GenresService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _genreService.GetGenres();

            return View(genres);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _genreService.AddGenre(genre);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var genre = await _genreService.GetGenreById(id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _genreService.UpdateGenre(genre);

                return RedirectToAction(nameof(Index));
            }

            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _genreService.DeleteGenre(id);

            return RedirectToAction(nameof(Index));
        }
    }
}