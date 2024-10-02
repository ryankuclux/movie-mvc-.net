using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models.DTOs.Movies
{
    public class UpdateMovieDto
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "Title is required!")]
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
    }
}