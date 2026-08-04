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

  public static string DisplayGermanExchangeStudents(string studentA, string studentB,
    DateTime start, float hours) =>
      string.Format(CultureInfo.GetCultureInfo("de-De"),
        "{0} and {1} have been dating since {2:d} - that's {3:N2} hours",
        studentA, studentB, start, hours);
}
