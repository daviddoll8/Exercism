using System.Text;

public static class House
{
    private static readonly (string name, string action)[] Verses =
    [
        ("house that Jack built", ""),
        ("malt", "lay in"),
        ("rat", "ate"),
        ("cat", "killed"),
        ("dog", "worried"),
        ("cow with the crumpled horn", "tossed"),
        ("maiden all forlorn", "milked"),
        ("man all tattered and torn", "kissed"),
        ("priest all shaven and shorn", "married"),
        ("rooster that crowed in the morn", "woke"),
        ("farmer sowing his corn", "kept"),
        ("horse and the hound and the horn", "belonged to")
    ];

    public static string Recite(int verseNumber)
    {
        var recital = new StringBuilder();
        recital.Append($"This is the {Verses[verseNumber - 1].name}");
        for (int i = verseNumber - 1; i > 0; i--)
        {
            recital.Append($" that {Verses[i].action} the {Verses[i - 1].name}");
        }
        return recital.Append('.').ToString();
    }

    public static string Recite(int startVerse, int endVerse) =>
        string.Join("\n", Enumerable.Range(startVerse, endVerse - startVerse + 1).Select(verse => Recite(verse)));
}
