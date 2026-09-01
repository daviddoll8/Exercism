using System.Text;
public static class FoodChain
{
    private record VerseDetails(string Name, string Action);
    private static ILookup<int, VerseDetails> Verses { get; } = new[]
    {
        new {Id = 1, Name = "fly", Action = "I don't know why she swallowed the fly. Perhaps she'll die." },
        new {Id = 2, Name = "spider", Action = "It wriggled and jiggled and tickled inside her." },
        new {Id = 3, Name = "bird", Action = "How absurd to swallow a bird!" },
        new {Id = 4, Name = "cat", Action = "Imagine that, to swallow a cat!" },
        new {Id = 5, Name = "dog", Action = "What a hog, to swallow a dog!" },
        new {Id = 6, Name = "goat", Action = "Just opened her throat and swallowed a goat!" },
        new {Id = 7, Name = "cow", Action = "I don't know how she swallowed a cow!" },
        new {Id = 8, Name = "horse", Action = "She's dead, of course!" }
    }.ToLookup(x => x.Id, x => new VerseDetails(x.Name, x.Action));

    private const string Opener = "I know an old lady who swallowed a";
    public static string Recite(int verseNumber)
    {
        var lyrics = new StringBuilder();

        lyrics.AppendLine($"{Opener} {Verses[verseNumber].First().Name}.");

        if (verseNumber == 1 || verseNumber == 8)
        {
            lyrics.Append($"{Verses[verseNumber].First().Action}");
            return lyrics.ToString();
        }

        lyrics.AppendLine($"{Verses[verseNumber].First().Action}");

        for (var i = verseNumber; i >= 2; i--)
        {
            var verseName = Verses[i].First().Name;
            var lastVerse = Verses[i - 1].First().Name;
            var birdAction = new string([.. Verses[2].First().Action.Skip(3)]);

            if (i == 3)
                lyrics.AppendLine($"She swallowed the {verseName} to catch the {lastVerse} that {birdAction}");
            else
                lyrics.AppendLine($"She swallowed the {verseName} to catch the {lastVerse}.");
        }
        lyrics.Append($"{Verses[1].First().Action}");

        return lyrics.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var lyrics = new StringBuilder();
        for (var i = startVerse; i <= endVerse; i++)
        {
            if (i == endVerse)
                lyrics.Append(Recite(i));
            else
                lyrics.AppendLine(Recite(i) + '\n');
        }
        return lyrics.ToString();
    }
}
