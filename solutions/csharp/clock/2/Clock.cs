public class Clock : IEquatable<Clock>
{
    public int Hours { get; set; }
    public int Minutes { get; set; }

    public Clock(int hours, int minutes)
    {
        Hours = 0;
        Minutes = 0;

        if (hours < 0)
        {
            Subtract(60 * Math.Abs(hours));
        }
        else if (hours > 0)
        {
            Add(60 * hours);
        }

        if (minutes < 0)
        {
            Subtract(Math.Abs(minutes));
        }
        else if (minutes > 0)
        {
            Add(minutes);
        }
    }

    public Clock Add(int minutesToAdd)
    {
        int hours = minutesToAdd / 60;
        minutesToAdd = minutesToAdd % 60;

        if (Minutes + minutesToAdd >= 60)
        {
            Hours = (Hours + hours + 1) % 24;
        }
        else
        {
            Hours = (Hours + hours) % 24;
        }
        Minutes = (Minutes + minutesToAdd) % 60;

        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        int hours = minutesToSubtract / 60;
        int minutes = minutesToSubtract % 60;

        if (Minutes - minutes < 0)
        {
            Hours = Hours - hours - 1 < 0
                ? 24 - Math.Abs((Hours - hours - 1) % 24)
                : (Hours - hours - 1) % 24;
            Minutes = Minutes - minutes < 0
                ? 60 - Math.Abs(Minutes - minutes)
                : Minutes - minutes;
        }
        else
        {
            Hours = Hours - hours < 0
                ? (24 - Math.Abs((Hours - hours) % 24)) % 24
                : (Hours - hours) % 24;
            Minutes = Minutes - minutes;
        }
        return this;
    }

    public bool Equals(Clock? other) => this.Hours == other.Hours && this.Minutes == other.Minutes;

    public override string ToString() => $"{Hours:D2}:{Minutes:D2}";
}
