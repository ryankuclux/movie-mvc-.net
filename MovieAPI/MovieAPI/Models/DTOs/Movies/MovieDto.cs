using MovieAPI.Models.DTOs.Genres;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models.DTOs.Movies
{
    public class MovieDto
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public required string Title { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Range(0, 9999)]
        public int? ReleaseDate { get; set; }

        [Range(0.0, 10.0)]
        public float? Rating { get; set; }

        [MaxLength(500)]
        public string? Poster { get; set; }

        [MaxLength(500)]
        public string? Video { get; set; }

        public int GenreId { get; set; }
        public GenreDto? Genre { get; set; }
    }
}