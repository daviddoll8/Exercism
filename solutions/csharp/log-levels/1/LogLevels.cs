static class LogLine
{
  public static string Message(string logLine)
  {
    return logLine[(logLine.IndexOf(":") + 1)..].Trim();
  }

  public static string LogLevel(string logLine)
  {
    if (logLine.Contains("ERROR"))
    {
      return "error";
    }
    else if (logLine.Contains("WARNING"))
    {
      return "warning";
    }
    else
    {
      return "info";
    }
  }

  public static string Reformat(string logLine)
  {
    string message = Message(logLine);
    string logLevel = LogLevel(logLine);

    return $"{message} ({logLevel})";
  }
}
