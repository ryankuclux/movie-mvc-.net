using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Fullname is required!")]
        public required string FullName { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "Email is required!")]
        public required string Email { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Username is required!")]
        public required string Username { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "Password is required!")]
        public required string Password { get; set; }

        [MaxLength(50)]
        public string? Role { get; set; }
    }
}