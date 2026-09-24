using System.Text;

public static class TwelveDays
{
    private static readonly string[] VerseActions =
    [
        "a Partridge in a Pear Tree",
        "two Turtle Doves",
        "three French Hens",
        "four Calling Birds",
        "five Gold Rings",
        "six Geese-a-Laying",
        "seven Swans-a-Swimming",
        "eight Maids-a-Milking",
        "nine Ladies Dancing",
        "ten Lords-a-Leaping",
        "eleven Pipers Piping",
        "twelve Drummers Drumming"
    ];

    public static string Recite(int verseNumber) =>
        $"On the {NumToString(verseNumber)} day of Christmas my true love gave to me: {VerseEnding(verseNumber)}";

    public static string Recite(int startVerse, int endVerse)
    {
        var result = new StringBuilder();
        for (var i = startVerse; i <= endVerse; i++)
        {
            if (i == endVerse)
                result.Append(Recite(i));
            else
                result.Append($"{Recite(i)}\n");
        }
        return result.ToString();
    }

    private static string VerseEnding(int verseNumber)
    {
        if (verseNumber == 1)
            return $"{VerseActions[verseNumber - 1]}.";

        var verseResult = new StringBuilder();
        for (var i = verseNumber - 1; i >= 0; i--)
        {
            if (i == 0)
                verseResult.Append($"and {VerseActions[i]}.");
            else
                verseResult.Append($"{VerseActions[i]}, ");
        }
        return verseResult.ToString();
    }

    private static string NumToString(int verseNumber) => verseNumber switch
    {
        1 => "first",
        2 => "second",
        3 => "third",
        4 => "fourth",
        5 => "fifth",
        6 => "sixth",
        7 => "seventh",
        8 => "eighth",
        9 => "ninth",
        10 => "tenth",
        11 => "eleventh",
        12 => "twelfth",
        _ => throw new ArgumentException()
    };
}
