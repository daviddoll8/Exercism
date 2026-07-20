static class Appointment
{
  public static DateTime Schedule(string appointmentDateDescription)
  {
    return DateTime.Parse(appointmentDateDescription);
  }

  public static bool HasPassed(DateTime appointmentDate)
  {
    return DateTime.Now > appointmentDate;
  }

  public static bool IsAfternoonAppointment(DateTime appointmentDate)
  {
    return appointmentDate.TimeOfDay >= new TimeOnly(12, 0).ToTimeSpan() && appointmentDate.TimeOfDay < new TimeOnly(18, 0).ToTimeSpan();
  }

  public static string Description(DateTime appointmentDate)
  {
    return string.Format("You have an appointment on {0}.", appointmentDate.ToString("G"));
  }

  public static DateTime AnniversaryDate()
  {
    if (DateTime.Now.Date > new DateTime(DateTime.Now.Year, 9, 15))
    {
      return new DateTime(DateTime.Now.Year + 1, 9, 15, 0, 0, 0);
    }

    return new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
  }
}
