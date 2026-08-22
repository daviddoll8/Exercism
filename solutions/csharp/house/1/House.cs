using System.Text;

public static class House
{
    private static readonly Dictionary<int, string> VerseName = new()
    {
        [1] = "house that Jack built",
        [2] = "malt",
        [3] = "rat",
        [4] = "cat",
        [5] = "dog",
        [6] = "cow with the crumpled horn",
        [7] = "maiden all forlorn",
        [8] = "man all tattered and torn",
        [9] = "priest all shaven and shorn",
        [10] = "rooster that crowed in the morn",
        [11] = "farmer sowing his corn",
        [12] = "horse and the hound and the horn"
    };
    private static readonly Dictionary<int, string> VerseAction = new()
    {
        [1] = "lay in",
        [2] = "ate",
        [3] = "killed",
        [4] = "worried",
        [5] = "tossed",
        [6] = "milked",
        [7] = "kissed",
        [8] = "married",
        [9] = "woke",
        [10] = "kept",
        [11] = "belonged to"
    };

    public static string Recite(int verseNumber)
    {
        var recital = new StringBuilder();
        recital.Append($"This is the {VerseName[verseNumber]}");
        for (int i = verseNumber - 1; i > 0; i--)
        {
            recital.Append($" that {VerseAction[i]} the {VerseName[i]}");
        }
        return recital.Append('.').ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var recital = new StringBuilder();
        for (int i = startVerse; i <= endVerse; i++)
        {
            if (i == endVerse)
            {
                recital.Append(Recite(i));
            }
            else
            {
                recital.AppendLine(Recite(i));
            }
        }
        return recital.ToString();
    }
}
