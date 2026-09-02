public static class Wordy
{
    public static int Answer(string question)
    {
        var tokens = question.Split(' ');

        return !HasValidCommandStart(tokens) || !HasValidCommand([.. tokens.Skip(2)], out int result)
            ? throw new ArgumentException()
            : result;
    }

    private static bool HasValidCommand(string[] tokens, out int result)
    {
        if (!TryParseNumber(tokens[0], out result))
            return false;

        var commands = new Queue<string>([.. tokens.Skip(1)]);
        Operation curOperation = Operation.Add;

        while (commands.Any())
        {
            var op = commands.Dequeue();
            if (op is "divided" or "multiplied")
            {
                if (!commands.TryPeek(out var next) || next != "by")
                    return false;
                commands.Dequeue();
            }

            curOperation = op switch
            {
                "plus" => Operation.Add,
                "minus" => Operation.Subtract,
                "divided" => Operation.Divide,
                "multiplied" => Operation.Multiply,
                _ => throw new ArgumentException()
            };

            if (!commands.TryPeek(out _))
                return false;

            var value = commands.Dequeue();
            if (!TryParseNumber(value, out int rightOperand))
                return false;

            result = curOperation switch
            {
                Operation.Add => result + rightOperand,
                Operation.Subtract => result - rightOperand,
                Operation.Divide => result / rightOperand,
                _ => result * rightOperand
            };

            var isLast = value.EndsWith('?');
            var more = commands.TryPeek(out _);
            if (isLast == more)
                return false;
            if (isLast)
                return true;
        }

        return true;
    }

    private static bool HasValidCommandStart(string[] tokens) =>
        tokens.Length >= 3
            && (tokens[0] == "What" || tokens[1] == "is")
            && TryParseNumber(tokens[2], out _);

    private static bool TryParseNumber(string token, out int value) =>
        int.TryParse(token.EndsWith('?') ? token[..^1] : token, out value);
}

public enum Operation { Add, Subtract, Multiply, Divide }
