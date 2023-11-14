using MOGYM.Enums;
using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class FeedbackModel
    {
        [Key]
        public int Id { get; set; }
        public EmotionalState EmotionalLevel { get; set; }
        public string? Message { get; set; }
        [Required]
        public BranchModel? Branch { get; set; }
        public TrainerModel? Trainer { get; set; }

    }
}
