using System.Text.RegularExpressions;

public class LogParser
{
  public bool IsValidLine(string text) =>
    Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");
  // text switch
  // {
  //   _ when Regex.IsMatch(text, @"^\[TRC\]") => true,
  //   _ when Regex.IsMatch(text, @"^\[DBG\]") => true,
  //   _ when Regex.IsMatch(text, @"^\[INF\]") => true,
  //   _ when Regex.IsMatch(text, @"^\[WRN\]") => true,
  //   _ when Regex.IsMatch(text, @"^\[ERR\]") => true,
  //   _ when Regex.IsMatch(text, @"^\[FTL\]") => true,
  //   _ => false
  // };

  public string[] SplitLogLine(string text) => Regex.Split(text, @"<[*^=-]*>");

  public int CountQuotedPasswords(string lines) =>
    Regex.Matches(lines, "\"[^\"]*\\bpassword\\b[^\"]*\"", RegexOptions.IgnoreCase | RegexOptions.Multiline).Count;

  public string RemoveEndOfLineText(string line) => Regex.Replace(line, "end-of-line[0-9]*", "", RegexOptions.IgnoreCase);

  public string[] ListLinesWithPasswords(string[] lines)
  {
    const string pattern = @"(?<badMatch>password\w+)";
    List<string> parsedLines = new List<string>();
    foreach (var line in lines)
    {
      Match m = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
      if (m.Success)
      {
        var badMatchResult = $"{m.Groups["badMatch"]}: {line}";
        parsedLines.Add(badMatchResult);
      }
      else
      {
        var noMatchResult = $"--------: {line}";
        parsedLines.Add(noMatchResult);
      }
    }
    return parsedLines.ToArray();
  }
}
