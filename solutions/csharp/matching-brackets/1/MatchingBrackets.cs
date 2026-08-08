public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        Stack<char> bracketSymbols = new Stack<char>();

        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case '(' or '{' or '[':
                    bracketSymbols.Push(input[i]);
                    continue;
                case ')':
                    if (bracketSymbols.Count == 0 || bracketSymbols.Pop() != '(')
                        return false;
                    continue;
                case '}':
                    if (bracketSymbols.Count == 0 || bracketSymbols.Pop() != '{')
                        return false;
                    continue;
                case ']':
                    if (bracketSymbols.Count == 0 || bracketSymbols.Pop() != '[')
                        return false;
                    continue;
                default:
                    continue;
            }

        }
        return bracketSymbols.Count == 0;
    }
}
