public class Anagram(string baseWord)
{
    public string BaseWord { get; set; } = baseWord.ToLower();
    private Dictionary<char, int> BaseWordCount { get; } = baseWord.ToLower().GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var matches = new List<string>();
        foreach (var match in potentialMatches)
        {
            if (match.Length != BaseWord.Length || match.ToLower() == BaseWord)
                continue;

            var matchCount = match.ToLower().GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            if (!matchCount.Except(BaseWordCount).Any())
                matches.Add(match);
        }
        return [.. matches];
    }
}
