using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOGYM.Models
{
    public class AdminModel : UserModel
    {
        public ICollection<TrainerModel>? Trainers { get; set; }
    }
}
