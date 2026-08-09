public static class MatchingBrackets
{
    private static readonly Dictionary<char, char> BracketPairs = new()
    {
        [')'] = '(',
        [']'] = '[',
        ['}'] = '{'
    };

    public static bool IsPaired(string input)
    {

        var bracketSymbols = new Stack<char>();

        foreach (var symbol in input)
        {
            if (symbol is '(' or '[' or '{')
            {
                bracketSymbols.Push(symbol);
            }
            else if (BracketPairs.TryGetValue(symbol, out var matching))
            {
                if (bracketSymbols.Count == 0 || bracketSymbols.Pop() != matching)
                    return false;
            }
        }

        return bracketSymbols.Count == 0;
    }
}
