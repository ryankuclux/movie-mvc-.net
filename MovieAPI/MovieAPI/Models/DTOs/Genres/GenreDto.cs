using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models.DTOs.Genres
{
    public class GenreDto
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
