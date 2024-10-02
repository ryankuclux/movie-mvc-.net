using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models.DTOs.Genres;
using MovieAPI.Models.Entities;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly MoviesDbContext _dbContext;

        public GenresController(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _dbContext.Genres
                .OrderByDescending(m => m.Id)
                .ToListAsync();

            return Ok(genres);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetGenresById(int id)
        {
            var genre = await _dbContext.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(AddGenreDto addGenreDto)
        {
            var genreEntity = new Genre()
            {
                Name = addGenreDto.Name,
                Description = addGenreDto.Description
            };

            await _dbContext.Genres.AddAsync(genreEntity);
            await _dbContext.SaveChangesAsync();

            return Ok(genreEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateGenre(int id, UpdateGenreDto updateGenreDto)
        {
            var genre = await _dbContext.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            genre.Name = updateGenreDto.Name;
            genre.Description = updateGenreDto.Description;

            await _dbContext.SaveChangesAsync();

            return Ok(genre);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _dbContext.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            _dbContext.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}