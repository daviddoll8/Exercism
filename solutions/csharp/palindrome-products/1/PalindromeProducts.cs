public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor)
            throw new ArgumentException();


        var factorList = new List<(int, int)>();
        var bestValue = int.MinValue;

        for (var i = maxFactor; i >= minFactor; i--)
        {
            for (var k = i; k >= minFactor; k--)
            {
                var product = i * k;
                if (IsPalindrome(i * k))
                {
                    if (product > bestValue)
                    {
                        bestValue = product;
                        factorList.Clear();
                        factorList.Add((k, i));
                    }
                    else if (product == bestValue)
                    {
                        factorList.Add((k, i));
                    }
                }
            }
        }

        return bestValue == int.MinValue ? throw new ArgumentException() : new(bestValue, factorList);
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor)
            throw new ArgumentException();

        var factorList = new List<(int, int)>();
        var bestValue = int.MaxValue;

        for (var i = minFactor; i <= maxFactor; i++)
        {
            for (var k = i; k <= maxFactor; k++)
            {
                var product = i * k;

                if (IsPalindrome(i * k))
                {
                    if (product < bestValue)
                    {
                        bestValue = product;
                        factorList.Clear();
                        factorList.Add((i, k));
                    }
                    else if (product == bestValue)
                    {
                        factorList.Add((i, k));
                    }
                }
            }
        }

        return bestValue == int.MaxValue ? throw new ArgumentException() : new(bestValue, factorList);
    }

    private static bool IsPalindrome(int value) => new string([.. value.ToString().Reverse()]) == value.ToString();
}
