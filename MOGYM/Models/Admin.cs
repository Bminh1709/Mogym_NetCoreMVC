using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class Admin : User
    {
        public Branch? Branch { get; set; }
        public ICollection<Trainer>? Trainers { get; set; }
    }
}
