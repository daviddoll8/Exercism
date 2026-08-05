public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var nucleotideCount = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };
        for (int i = 0; i < sequence.Length; i++)
        {
            if (!nucleotideCount.ContainsKey(sequence[i]))
            {
                throw new ArgumentException();
            }
            else
            {
                nucleotideCount[sequence[i]]++;
            }
        }
        return nucleotideCount;
    }
}
