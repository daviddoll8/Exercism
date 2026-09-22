public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor)
            throw new ArgumentException();

        var bestValue = FindLargestPalindromeProduct(minFactor, maxFactor);
        return bestValue is null
            ? throw new ArgumentException()
            : (bestValue.Value, GetFactors(bestValue.Value, minFactor, maxFactor));
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor)
            throw new ArgumentException();

        var bestValue = FindSmallestPalindromeProduct(minFactor, maxFactor);
        return bestValue is null
            ? throw new ArgumentException()
            : (bestValue.Value, GetFactors(bestValue.Value, minFactor, maxFactor));
    }

    private static int? FindLargestPalindromeProduct(int minFactor, int maxFactor)
    {
        var bestValue = 0;
        var found = false;

        for (var i = maxFactor; i >= minFactor; i--)
        {
            if (found && i * maxFactor <= bestValue)
                break;

            for (var k = maxFactor; k >= i; k--)
            {
                var product = i * k;

                if (found && product <= bestValue)
                    break;

                if (IsPalindrome(product))
                {
                    bestValue = product;
                    found = true;
                    break;
                }
            }
        }

        return found ? bestValue : null;
    }

    private static int? FindSmallestPalindromeProduct(int minFactor, int maxFactor)
    {
        var bestValue = 0;
        var found = false;

        for (var i = minFactor; i <= maxFactor; i++)
        {
            if (found && i * i >= bestValue)
                break;

            for (var k = i; k <= maxFactor; k++)
            {
                var product = i * k;

                if (found && product >= bestValue)
                    break;

                if (IsPalindrome(product))
                {
                    bestValue = product;
                    found = true;
                }
            }
        }

        return found ? bestValue : null;
    }

    private static List<(int, int)> GetFactors(int value, int minFactor, int maxFactor)
    {
        var factors = new List<(int, int)>();
        var start = Math.Max(minFactor, (int)Math.Ceiling((double)value / maxFactor));

        for (var a = start; a * a <= value; a++)
        {
            if (value % a == 0)
                factors.Add((a, value / a));
        }

        return factors;
    }

    private static bool IsPalindrome(int value) => new string([.. value.ToString().Reverse()]) == value.ToString();
}
