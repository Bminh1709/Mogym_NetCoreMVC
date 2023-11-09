using MOGYM.Enums;
using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public EmotionalState EmotionalLevel { get; set; }
        public string? Message { get; set; }
        [Required]
        public Branch? Branch { get; set; }
        public Trainer? Trainer { get; set; }

    }
}
