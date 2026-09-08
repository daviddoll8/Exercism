using System.Text;

public static class OcrNumbers
{
    private static readonly Dictionary<int, List<string>> Digits = new()
    {
        [0] = [" _ ", "| |", "|_|", "   "],
        [1] = ["   ", "  |", "  |", "   "],
        [2] = [" _ ", " _|", "|_ ", "   "],
        [3] = [" _ ", " _|", " _|", "   "],
        [4] = ["   ", "|_|", "  |", "   "],
        [5] = [" _ ", "|_ ", " _|", "   "],
        [6] = [" _ ", "|_ ", "|_|", "   "],
        [7] = [" _ ", "  |", "  |", "   "],
        [8] = [" _ ", "|_|", "|_|", "   "],
        [9] = [" _ ", "|_|", " _|", "   "]
    };

    public static string Convert(string input)
    {
        var rows = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        if (rows.Length % 4 != 0 || !rows.All(row => row.Length % 3 == 0))
            throw new ArgumentException();

        var results = new List<string>();
        foreach (var band in rows.Chunk(4).ToArray())
        {
            var bandResult = new StringBuilder();
            for (var c = 0; c < band[0].Length; c += 3)
            {
                var cell = Enumerable.Range(0, 4).Select(r => band[r].Substring(c, 3)).ToList();
                var match = Digits.FirstOrDefault(kv => kv.Value.SequenceEqual(cell));
                bandResult.Append(match.Value is null ? "?" : match.Key);
            }
            results.Add(bandResult.ToString());
        }
        return string.Join(",", results);
    }
}
