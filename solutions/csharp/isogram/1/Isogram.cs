public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var letters = new HashSet<char>();

        foreach (var letter in word)
        {

            if (char.IsWhiteSpace(letter) || letter == '-')
                continue;

            if (!letters.Add(char.ToLower(letter)))
                return false;
        }
        return true;
    }
}
