public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        string[] words = phrase.Split(
            new[] { ' ', '-' },
            StringSplitOptions.RemoveEmptyEntries);
        List<char> acronym = new();
        var result = "";
        foreach (var word in words)
        {
            foreach (var character in word)
            {
                if (!char.IsLetter(character))
                {
                    continue;
                }
                acronym.Add(char.ToUpper(character));
                break;
            }
        }

        foreach (var character in acronym)
        {
            result += character;
        }
        return result;
    }
}
