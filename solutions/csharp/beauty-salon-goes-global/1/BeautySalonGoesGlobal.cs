using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
  NewYork,
  London,
  Paris
}

public enum AlertLevel
{
  Early,
  Standard,
  Late
}

public static class Appointment
{
  public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

  public static DateTime Schedule(string appointmentDateDescription, Location location)
  {
    var tzi = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneId(location));
    var localTime = DateTime.Parse(appointmentDateDescription);
    return TimeZoneInfo.ConvertTimeToUtc(localTime, tzi);
  }

  private static string GetTimeZoneId(Location location) =>
    location switch
    {
      Location.NewYork => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "Eastern Standard Time" : "America/New_York",
      Location.London => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "GMT Standard Time" : "Europe/London",
      _ => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "W. Europe Standard Time" : "Europe/Paris"
    };

  public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
    alertLevel switch
    {
      AlertLevel.Early => appointment.Subtract(TimeSpan.FromDays(1)),
      AlertLevel.Late => appointment.Subtract(TimeSpan.FromMinutes(30)),
      _ => appointment.Subtract(new TimeSpan(1, 45, 0))
    };

  public static bool HasDaylightSavingChanged(DateTime dt, Location location)
  {
    var tzi = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneId(location));
    return tzi.IsDaylightSavingTime(dt) != tzi.IsDaylightSavingTime(dt.AddDays(-7));
    var datetime = new DateTime(1, 1, 1);
  }

  public static DateTime NormalizeDateTime(string dtStr, Location location) =>
    DateTime.TryParse(dtStr, GetCulture(location), out DateTime result) ? result : new DateTime(1, 1, 1);

  private static CultureInfo GetCulture(Location location) =>
    location switch
    {
      Location.NewYork => new CultureInfo("en-US"),
      Location.Paris => new CultureInfo("fr-FR"),
      _ => new CultureInfo("en-GB"),
    };

}
