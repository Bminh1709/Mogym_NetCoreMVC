using MOGYM.Enums;
using MOGYM.Helpers;
using NuGet.Common;
using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class WorkoutScheduleModel
    {
        [Key]
        public int Id { get; set; }
        public WeekDay DayOfWeek { get; set; }
        public int CurrentWeek { get; set; } = DateTimeUtility.GetCurrentWeek();
        public string? Task { get; set; }
        [Required]
        public TraineeModel Trainee { get; set; }
    }
}
