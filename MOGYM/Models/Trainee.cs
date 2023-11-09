using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class Trainee : User
    {
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public string? Note { get; set; }
        public Trainer? Trainer { get; set;}
        public Branch? Branch { get; set; }
    }
}
