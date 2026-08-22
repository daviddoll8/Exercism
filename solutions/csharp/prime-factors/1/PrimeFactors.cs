public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        if (number < 2)
            return [];

        var divisor = 2;
        var result = new List<long>();
        while (number != 1)
        {
            if (number % divisor == 0)
            {
                result.Add(divisor);
                number /= divisor;
            }
            else
            {
                divisor++;
            }
        }
        return [.. result];
    }
}
