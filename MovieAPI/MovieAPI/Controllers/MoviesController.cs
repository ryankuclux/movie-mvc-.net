using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models.DTOs.Genres;
using MovieAPI.Models.DTOs.Movies;
using MovieAPI.Models.Entities;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbContext _dbContext;

        public MoviesController(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _dbContext.Movies
                .Include(m => m.Genre)
                .OrderByDescending(m => m.Id)
                .ToListAsync();

            var movieDtoS = movies.
                Select(m => new MovieDto 
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    ReleaseDate = m.ReleaseDate,
                    Rating = m.Rating,
                    Poster = m.Poster,
                    Video = m.Video,
                    GenreId = m.GenreId,
                    Genre = new GenreDto
                    { 
                        Name = m.Genre!.Name,
                    }
                })
                .ToList();

            return Ok(movieDtoS);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _dbContext.Movies
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var movieDto = new MovieDto
            {
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Rating = movie.Rating,
                Poster = movie.Poster,
                Video = movie.Video,
                GenreId = movie.GenreId,
                Genre = new GenreDto
                {
                    Name = movie.Genre!.Name,
                }
            };

            return Ok(movieDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieDto addMovieDto)
        {
            var movieEntity = new Movie()
            {
                Title = addMovieDto.Title,
                Description = addMovieDto.Description,
                ReleaseDate = addMovieDto.ReleaseDate,
                Rating = addMovieDto.Rating,
                Poster = addMovieDto.Poster,
                Video = addMovieDto.Video,
                GenreId = addMovieDto.GenreId
            };

            await _dbContext.Movies.AddAsync(movieEntity);
            await _dbContext.SaveChangesAsync();

            return Ok(movieEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateMovie(int id, UpdateMovieDto updateMovieDto)
        {
            var movie = await _dbContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = updateMovieDto.Title;
            movie.Description = updateMovieDto.Description;
            movie.ReleaseDate = updateMovieDto.ReleaseDate;
            movie.Rating = updateMovieDto.Rating;
            movie.Poster = updateMovieDto.Poster;
            movie.Video = updateMovieDto.Video;
            movie.GenreId = updateMovieDto.GenreId;

            await _dbContext.SaveChangesAsync();

            return Ok(movie);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}