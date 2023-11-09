using System.Globalization;

namespace MOGYM.Helpers
{
    public static class GetCurrentWeek
    {
        public static int CurrentWeek()
        {
            // Create a CultureInfo object for the Vietnamese culture
            CultureInfo vietnameseCulture = new CultureInfo("vi-VN");

            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Get the calendar specific to the Vietnamese culture
            Calendar vietnameseCalendar = vietnameseCulture.Calendar;

            // Get the week of the year
            int weekOfYear = vietnameseCalendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

            return weekOfYear;
        }
    }
}
