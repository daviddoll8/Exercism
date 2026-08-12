public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2 || outputBase < 2 || inputDigits.Any(d => d < 0 || d >= inputBase))
            throw new ArgumentException();

        var value = 0;
        foreach (var digit in inputDigits)
            value = (value * inputBase) + digit;

        if (value == 0)
            return [0];

        var result = new List<int>();
        while (value > 0)
        {
            result.Add(value % outputBase);
            value /= outputBase;
        }
        result.Reverse();
        return [.. result];
    }
}
