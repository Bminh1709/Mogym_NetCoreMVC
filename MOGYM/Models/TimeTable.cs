using MOGYM.Enums;
using MOGYM.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class TimeTable
    {
        [Key]
        public int Id { get; set; }
        public WeekDay DayOfWeek { get; set; }
        public MarkedTime MarkedTime { get; set; }
        public int CurrentWeek { get; set; } = GetCurrentWeek.CurrentWeek();
        public string? Task { get; set; }
        [Required]
        public Trainer Trainer { get; set; }
    }
}
