public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        var result = new Dictionary<string, int>();
        var curWord = "";

        for (var i = 0; i < phrase.Length; i++)
        {
            if (char.IsLetterOrDigit(phrase[i]))
            {
                curWord += char.ToLowerInvariant(phrase[i]);
            }
            else if (phrase[i] == '\'')
            {
                if ((i + 1 >= phrase.Length || !char.IsLetterOrDigit(phrase[i + 1])))
                {
                    if (curWord != "")
                    {
                        if (result.ContainsKey(curWord))
                            result[curWord]++;
                        else
                            result.Add(curWord, 1);
                    }
                    curWord = "";
                }
                else if (curWord != "")
                    curWord += char.ToLowerInvariant(phrase[i]);
            }
            else
            {
                if (curWord != "")
                {
                    if (result.ContainsKey(curWord))
                        result[curWord]++;
                    else
                        result.Add(curWord, 1);
                }
                curWord = "";
            }
        }

        if (curWord != "")
        {
            if (result.ContainsKey(curWord))
                result[curWord]++;
            else
                result.Add(curWord, 1);
        }

        return result;
    }

}
