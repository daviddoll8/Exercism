using System.Text.RegularExpressions;

public static class Bob
{
    public static string Response(string statement) =>
        statement switch
        {
            _ when IsUpperAndQuestion(statement) => "Calm down, I know what I'm doing!",
            _ when IsSilence(statement) => "Fine. Be that way!",
            _ when IsQuestion(statement) => "Sure.",
            _ when IsUpperCase(statement) => "Whoa, chill out!",
            _ => "Whatever."
        };

    private static bool IsQuestion(string statement) => statement.Trim().EndsWith('?');

    private static bool IsUpperCase(string statement) =>
        statement.Any(char.IsLetter) && statement.ToUpper() == statement;

    private static bool IsUpperAndQuestion(string statement) => IsQuestion(statement) && IsUpperCase(statement);

    private static bool IsSilence(string statement) => string.IsNullOrWhiteSpace(statement);
}
