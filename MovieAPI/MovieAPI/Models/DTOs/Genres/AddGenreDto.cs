using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models.DTOs.Genres
{
    public class AddGenreDto
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "Name is required!")]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}