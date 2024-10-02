using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Name is required!")]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}