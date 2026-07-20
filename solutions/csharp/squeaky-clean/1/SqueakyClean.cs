using System.Text;

public static class Identifier
{

  private static bool IsGreekLowercase(char c) =>
    (c >= 'α' && c <= 'ω');

  public static string Clean(string identifier)
  {
    var builder = new StringBuilder();

    for (int i = 0; i < identifier.Length; i++)
    {
      char ch = identifier[i];
      if (Char.IsWhiteSpace(ch))
      {
        builder.Append('_');
      }
      else if (Char.IsControl(ch))
      {
        builder.Append("CTRL");
      }
      else if (ch.Equals('-'))
      {
        if (i + 1 < identifier.Length)
        {
          builder.Append(Char.ToUpper(identifier[i + 1]));
          i++;
        }
      }
      else if (Char.IsLetter(ch) && !IsGreekLowercase(ch))
      {
        builder.Append(ch);
      }
    }

    return builder.ToString();
  }
}
