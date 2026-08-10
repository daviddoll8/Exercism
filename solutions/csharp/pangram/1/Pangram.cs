public static class Pangram
{
    public static bool IsPangram(string input)
    {
        var alphabet = new HashSet<char>();

        foreach (var letter in input)
        {
            if (!char.IsLetter(letter))
            {
                continue;
            }

            alphabet.Add(char.ToLower(letter));
        }

        return alphabet.Count == 26;
    }
}
