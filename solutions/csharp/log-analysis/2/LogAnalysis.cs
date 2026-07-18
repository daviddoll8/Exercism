public static class LogAnalysis
{
  // TODO: define the 'SubstringAfter()' extension method on the `string` type
  public static string SubstringAfter(this string str, string delimiter) =>
    str[(str.IndexOf(delimiter) + delimiter.Length)..];

  // TODO: define the 'SubstringBetween()' extension method on the `string` type
  public static string SubstringBetween(this string str, string delimiter1, string delimiter2) =>
    str[(str.IndexOf(delimiter1) + delimiter1.Length)..str.IndexOf(delimiter2)];

  // TODO: define the 'Message()' extension method on the `string` type
  public static string Message(this string str) =>
    str.SubstringAfter(": ");

  // TODO: define the 'LogLevel()' extension method on the `string` type
  public static string LogLevel(this string str) =>
    str.SubstringBetween("[", "]");
}
