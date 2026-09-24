public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        var result = new Dictionary<string, int>();
        var curWord = "";

        void AddWord()
        {
            if (curWord.Length > 0)
                result[curWord] = result.GetValueOrDefault(curWord) + 1;
            curWord = "";
        }

        for (var i = 0; i < phrase.Length; i++)
        {
            var c = phrase[i];
            if (char.IsLetterOrDigit(c))
            {
                curWord += char.ToLowerInvariant(c);
            }
            else if (c == '\'' && curWord.Length > 0 && i + 1 < phrase.Length && char.IsLetterOrDigit(phrase[i + 1]))
            {
                curWord += c;
            }
            else
            {
                AddWord();
            }
        }

        AddWord();

        return result;
    }
}
