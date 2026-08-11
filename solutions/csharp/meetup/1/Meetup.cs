using Xunit.Sdk;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    public int Month { get; set; }
    public int Year { get; set; }

    public Meetup(int month, int year)
    {
        Month = month;
        Year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule) =>
        schedule switch
        {
            Schedule.Teenth => DayFromTeenthOfMonth(dayOfWeek),
            Schedule.Last => DayFromEndOfMonth(dayOfWeek),
            _ => DayFromStartOfMonth(dayOfWeek, schedule)

        };

    private DateTime DayFromTeenthOfMonth(DayOfWeek dayOfWeek)
    {
        var startDate = new DateTime(Year, Month, 13);

        while (startDate.Day <= 19)
        {
            if (startDate.DayOfWeek == dayOfWeek)
                break;
            startDate = startDate.AddDays(1);
        }
        return startDate;
    }

    private DateTime DayFromEndOfMonth(DayOfWeek dayOfWeek)
    {
        var daysInMonth = DateTime.DaysInMonth(Year, Month);
        var startDate = new DateTime(Year, Month, daysInMonth);

        while (startDate.Day >= 1)
        {
            if (startDate.DayOfWeek == dayOfWeek)
                break;
            startDate = startDate.AddDays(-1);
        }

        return startDate;
    }

    private DateTime DayFromStartOfMonth(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var startDate = new DateTime(Year, Month, 1);

        while (startDate.Day < DateTime.DaysInMonth(Year, Month))
        {
            if (startDate.DayOfWeek == dayOfWeek)
                break;
            startDate = startDate.AddDays(1);
        }

        return startDate.AddDays(Math.Abs(1 - (int)schedule) * 7);
    }
}
