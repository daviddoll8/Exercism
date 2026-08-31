public class Anagram(string baseWord)
{
    public string BaseWord { get; set; } = baseWord.ToLower();

    public string[] FindAnagrams(string[] potentialMatches) =>
        [.. potentialMatches.Where(match => match.ToLower() != BaseWord && BaseWord.Order().SequenceEqual(match.ToLower().Order()))];
}
