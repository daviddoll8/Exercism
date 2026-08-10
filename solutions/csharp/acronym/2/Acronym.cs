public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        string[] words = phrase.Split(
            new[] { ' ', '-' },
            StringSplitOptions.RemoveEmptyEntries);
        var result = "";
        foreach (var word in words)
        {
            foreach (var character in word)
            {
                if (!char.IsLetter(character))
                {
                    continue;
                }
                result += character.ToString().ToUpper();
                break;
            }
        }

        return result;
    }
}
