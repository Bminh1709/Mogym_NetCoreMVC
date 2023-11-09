using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class Trainer : User
    {
        public Branch? Branch { get; set; }
        public ICollection<Trainee>? Trainees { get; set; }
    }
}
