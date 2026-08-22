using System.Collections.Concurrent;

public static class ParallelLetterFrequency
{
    public static Task<Dictionary<char, int>> Calculate(IEnumerable<string> texts)
    {
        return Task.Run(() =>
        {
            var result = new Dictionary<char, int>();
            var partialResults = new ConcurrentBag<Dictionary<char, int>>();
            Parallel.ForEach(texts, text =>
            {
                var textResult = new Dictionary<char, int>();
                foreach (var letter in text)
                {
                    if (char.IsLetter(letter))
                    {
                        var lowerCase = char.ToLower(letter);
                        if (textResult.ContainsKey(lowerCase))
                            textResult[lowerCase]++;
                        else
                            textResult.Add(lowerCase, 1);
                    }

                }
                partialResults.Add(textResult);
            });

            foreach (var res in partialResults)
            {
                foreach (var kvp in res)
                {
                    if (result.ContainsKey(kvp.Key))
                        result[kvp.Key] += kvp.Value;
                    else
                        result.Add(kvp.Key, kvp.Value);
                }
            }

            return result;
        });
    }
}
