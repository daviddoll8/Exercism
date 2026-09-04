using Xunit.Internal;

public static class AtbashCipher
{

    private static string Alphabet { get; } = new string("abcdefghijklmnopqrstuvwxyz");

    public static string Encode(string plainValue) =>
        FormatEncoding(plainValue.Where(char.IsLetterOrDigit).Select(EncodeChar));

    private static string FormatEncoding(IEnumerable<char> encodedValues)
    {
        var result = new List<string>();
        var section = new string("");
        foreach (var value in encodedValues)
        {
            if (section.Length == 5)
            {
                result.Add(section);
                section = new string("");
                section += value;
            }
            else
            {
                section += value;
            }
        }

        if (section.Length != 0)
            result.Add(section);

        return string.Join(' ', result);
    }

    private static char EncodeChar(char c)
    {
        if (char.IsDigit(c))
            return c;

        var charIndex = Alphabet.IndexOf(char.ToLower(c));
        return Alphabet.Reverse().ToArray()[charIndex];
    }

    public static string Decode(string encodedValue) =>
        new([.. encodedValue.Where(c => !char.IsWhiteSpace(c)).Select(DecodeChar)]);

    private static char DecodeChar(char c)
    {
        if (char.IsDigit(c))
            return c;

        var charIndex = Alphabet.Reverse().ToArray().IndexOf(c);
        return Alphabet[charIndex];
    }
}
