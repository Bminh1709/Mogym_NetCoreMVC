using MOGYM.Enums;
using MOGYM.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class WorkoutSchedule
    {
        [Key]
        public int Id { get; set; }
        public WeekDay DayOfWeek { get; set; }
        public int CurrentWeek { get; set; } = GetCurrentWeek.CurrentWeek();
        public string? Task { get; set; }
        [Required]
        public Trainee Trainee { get; set; }
    }
}
