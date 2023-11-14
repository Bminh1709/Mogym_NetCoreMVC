using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOGYM.Models
{
    public class TrainerModel : UserModel
    {
        public AdminModel? Admin { get; set; }
        public ICollection<TraineeModel>? Trainees { get; set; }
    }
}
