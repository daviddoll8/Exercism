using System.Globalization;

public static class HighSchoolSweethearts
{
  public static string DisplaySingleLine(string studentA, string studentB) =>
    $"{studentA,29} ♡ {studentB,-29}";

  public static string DisplayBanner(string studentA, string studentB)
  {
    var displayBanner = @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**" + string.Format("{0,11} +  {1,-10}**", studentA, studentB);
    displayBanner += @"
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
    ";
    Console.WriteLine("HERE:");
    Console.Write(displayBanner);
    return displayBanner;
  }

  public static string DisplayGermanExchangeStudents(string studentA
      , string studentB, DateTime start, float hours)
  {
    var dateFormat = start.ToString("d", CultureInfo.GetCultureInfo("de-DE"));
    var hourFormat = hours.ToString("N2", CultureInfo.GetCultureInfo("de-DE"));
    return $"{studentA} and {studentB} have been dating since {dateFormat} - that's {hourFormat} hours";
  }
}
