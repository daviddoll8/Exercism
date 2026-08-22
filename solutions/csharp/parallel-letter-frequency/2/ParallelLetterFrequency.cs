using System.Collections.Concurrent;

public static class ParallelLetterFrequency
{
    public static Task<Dictionary<char, int>> Calculate(IEnumerable<string> texts) =>
        Task.FromResult(texts
            .AsParallel()
            .SelectMany(text => text.ToLower())
            .Where(char.IsLetter)
            .GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Count()));
}
