using Sprache;

public static class Forth
{
    public abstract record Token;
    public sealed record Number(int Value) : Token;
    public sealed record Word(string Name) : Token;
    public sealed record Definition(string Name, Token[] Body) : Token;

    private static readonly HashSet<string> BuiltIns = new(StringComparer.OrdinalIgnoreCase)
    {
        "+", "-", "*", "/", "dup", "drop", "swap", "over"
    };

    public static string Evaluate(string[] instructions)
    {
        var stack = new Stack<int>();
        var definitions = new Dictionary<string, Token[]>(StringComparer.OrdinalIgnoreCase);

        foreach (var instruction in instructions)
        {
            foreach (var token in ForthParser.Instruction.Parse(instruction))
            {
                switch (token)
                {
                    case Number n:
                        stack.Push(n.Value);
                        break;

                    case Word w:
                        Execute(w, stack, definitions);
                        break;

                    case Definition d:
                        if (int.TryParse(d.Name, out _))
                            throw new InvalidOperationException("Cannot redefine a number.");

                        definitions[d.Name] = Expand(d.Body, definitions);
                        break;
                }
            }
        }

        return string.Join(" ", stack.Reverse());
    }

    private static void Execute(Word word, Stack<int> stack, Dictionary<string, Token[]> definitions)
    {
        if (definitions.TryGetValue(word.Name, out var body))
        {
            foreach (var token in body)
            {
                switch (token)
                {
                    case Number n:
                        stack.Push(n.Value);
                        break;
                    case Word w:
                        Execute(w, stack, definitions);
                        break;
                }
            }
        }
        else if (BuiltIns.Contains(word.Name))
        {
            Apply(word.Name, stack);
        }
        else
        {
            throw new InvalidOperationException($"Undefined word: {word.Name}");
        }
    }

    private static Token[] Expand(Token[] body, Dictionary<string, Token[]> definitions)
    {
        var expanded = new List<Token>();

        foreach (var token in body)
        {
            switch (token)
            {
                case Number:
                    expanded.Add(token);
                    break;
                case Word w when definitions.TryGetValue(w.Name, out var existing):
                    expanded.AddRange(existing);
                    break;
                case Word when BuiltIns.Contains(((Word)token).Name):
                    expanded.Add(token);
                    break;
                default:
                    throw new InvalidOperationException($"Undefined word: {token}");
            }
        }

        return expanded.ToArray();
    }

    private static void Apply(string name, Stack<int> stack)
    {
        switch (name.ToLowerInvariant())
        {
            case "+":
                stack.Push(Pop(stack) + Pop(stack));
                break;

            case "-":
                var subtrahend = Pop(stack);
                var minuend = Pop(stack);
                stack.Push(minuend - subtrahend);
                break;

            case "*":
                stack.Push(Pop(stack) * Pop(stack));
                break;

            case "/":
                var divisor = Pop(stack);
                var dividend = Pop(stack);
                stack.Push(dividend / divisor);
                break;

            case "dup":
                var value = Pop(stack);
                stack.Push(value);
                stack.Push(value);
                break;

            case "drop":
                Pop(stack);
                break;

            case "swap":
                var first = Pop(stack);
                var second = Pop(stack);
                stack.Push(first);
                stack.Push(second);
                break;

            case "over":
                var top = Pop(stack);
                var under = Pop(stack);
                stack.Push(under);
                stack.Push(top);
                stack.Push(under);
                break;
        }
    }

    private static int Pop(Stack<int> stack) =>
        stack.Count == 0 ? throw new InvalidOperationException("Stack underflow.") : stack.Pop();
}

public static class ForthParser
{
    private static readonly Parser<string> WordText =
        Parse.Regex(@"\S+").Token();

    private static readonly Parser<Forth.Token> NumberToken =
        Parse.Regex(@"-?\d+").Token().Select(s => (Forth.Token)new Forth.Number(int.Parse(s)));

    private static readonly Parser<Forth.Token> WordToken =
        from w in WordText
        where w != ";"
        select (Forth.Token)new Forth.Word(w);

    private static readonly Parser<Forth.Token> SingleToken =
        NumberToken.Or(WordToken);

    private static readonly Parser<Forth.Token> Definition =
        from _ in Parse.Char(':').Token()
        from name in WordText
        from body in SingleToken.Many()
        from __ in Parse.Char(';').Token()
        select (Forth.Token)new Forth.Definition(name, body.ToArray());

    public static readonly Parser<Forth.Token[]> Instruction =
        Definition.Select(d => new[] { d })
            .Or(SingleToken.Many().Select(list => list.ToArray()));
}
