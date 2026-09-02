public static class Wordy
{
    public static int Answer(string question)
    {
        var questionArray = question.Split(' ');

        if (!HasValidCommandStart(questionArray))
            throw new ArgumentException();

        if (questionArray.Length == 3)
        {
            return questionArray[2].EndsWith('?')
                ? int.Parse(new string([.. questionArray[2].SkipLast(1)]))
                : throw new ArgumentException();
        }

        return HasValidCommand([.. questionArray.Skip(2)], out int result)
            ? result
            : throw new ArgumentException();
    }

    private static bool HasValidCommand(string[] questionArray, out int result)
    {
        result = 0;
        if (questionArray.Length < 3)
            return false;

        var leftOperand = int.Parse(questionArray[0]);
        var commands = new Queue<string>([.. questionArray.Skip(1)]);
        var commandFlag = true;
        Operation curOperation = Operation.Add;
        while (commands.Any())
        {
            if (commandFlag)
            {
                switch (commands.Dequeue())
                {
                    case "plus":
                        curOperation = Operation.Add;
                        break;
                    case "minus":
                        curOperation = Operation.Subtract;
                        break;
                    case "divided":
                        if (!commands.TryPeek(out var divNext) || divNext != "by")
                            return false;
                        commands.Dequeue();
                        curOperation = Operation.Divide;
                        break;
                    case "multiplied":
                        if (!commands.TryPeek(out var mulNext) || mulNext != "by")
                            return false;
                        commands.Dequeue();
                        curOperation = Operation.Multiply;
                        break;
                    default:
                        return false;
                }

                if (!commands.TryPeek(out _))
                    return false;

                commandFlag = false;
            }
            else
            {
                var value = commands.Dequeue();

                if (!HasValidOperand(value, out int rOperand))
                    return false;

                result = curOperation switch
                {
                    Operation.Add => Add(leftOperand, rOperand),
                    Operation.Subtract => Subtract(leftOperand, rOperand),
                    Operation.Divide => Divide(leftOperand, rOperand),
                    Operation.Multiply => Multiply(leftOperand, rOperand),
                    _ => throw new ArgumentException()
                };
                leftOperand = result;

                if ((value.EndsWith('?') && commands.TryPeek(out _)) || (!value.EndsWith('?') && !commands.TryPeek(out _)))
                    return false;

                if (value.EndsWith('?') && !commands.TryPeek(out _))
                    return true;

                commandFlag = true;
            }
        }
        return false;
    }

    private static bool HasValidOperand(string value, out int rOperand) =>
        value.EndsWith('?') ? int.TryParse(new string([.. value.SkipLast(1)]), out rOperand) : int.TryParse(value, out rOperand);

    private static bool HasValidCommandStart(string[] questionArray) =>
        questionArray.Length >= 3
            && (questionArray[0] == "What" || questionArray[1] == "is")
            && ((questionArray[2].EndsWith('?') && int.TryParse(new string([.. questionArray[2].SkipLast(1)]), out _))
            || int.TryParse(questionArray[2], out _));

    private static int Add(int a, int b) => a + b;
    private static int Subtract(int a, int b) => a - b;
    private static int Divide(int a, int b) => a / b;
    private static int Multiply(int a, int b) => a * b;
}

public enum Operation { Add, Subtract, Multiply, Divide }
