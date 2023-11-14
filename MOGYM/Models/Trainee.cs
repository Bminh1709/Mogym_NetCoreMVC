using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOGYM.Models
{
    public class TraineeModel : UserModel
    {
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public string? Note { get; set; }
        public TrainerModel? Trainer { get; set;}
    }
}
