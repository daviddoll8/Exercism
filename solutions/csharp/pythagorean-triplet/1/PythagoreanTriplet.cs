public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        for (int i = 1; i < sum / 3; i++)
        {
            var numerator = Math.Pow(sum, 2) - (2 * sum * i);
            var denominator = 2 * (sum - i);

            if (numerator % denominator != 0)
            {
                continue;
            }

            int b = (int)(numerator / denominator);
            var c = sum - i - b;
            if (IsValidTriplet(i, b, c))
            {
                yield return (i, b, c);
            }
        }
    }

    private static bool IsValidTriplet(int a, double b, double c) =>
        a < b && b < c && ((a * a) + (b * b)) == c * c;
}
