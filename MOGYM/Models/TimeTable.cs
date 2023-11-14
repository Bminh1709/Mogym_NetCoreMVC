using MOGYM.Enums;
using MOGYM.Helpers;
using NuGet.Common;
using System.ComponentModel.DataAnnotations;

namespace MOGYM.Models
{
    public class TimeTableModel
    {
        [Key]
        public int Id { get; set; }
        public WeekDay DayOfWeek { get; set; }
        public MarkedTime MarkedTime { get; set; }
        public int CurrentWeek { get; set; } = DateTimeUtility.GetCurrentWeek();
        public string? Task { get; set; }
        [Required]
        public TrainerModel Trainer { get; set; }
    }
}
