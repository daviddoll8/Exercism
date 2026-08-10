public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number) =>
        number switch
        {
            <= 0 => throw new ArgumentOutOfRangeException(),
            _ when number < AliquotSum(number) => Classification.Abundant,
            _ when number > AliquotSum(number) => Classification.Deficient,
            _ => Classification.Perfect
        };

    private static int AliquotSum(int number)
    {
        var aliquotSum = 0;
        for (int i = 1; i < number; i++)
        {
            if (number == i)
                break;
            else if (number % i == 0)
                aliquotSum += i;
        }
        return aliquotSum;
    }
}
