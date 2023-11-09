using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "Không tên";

        [Required, EmailAddress]
        public required string Gmail { get; set; }

        [Required, MinLength(8)]
        public required string Password { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Avatar { get; set; }
    }

}
