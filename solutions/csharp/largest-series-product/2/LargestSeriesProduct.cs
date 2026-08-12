public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) =>
        span == 0 ? 1
        : span < 0 || !digits.All(char.IsDigit) || digits.Length < span ? throw new ArgumentException()
        : Enumerable.Range(0, digits.Length - span + 1)
            .Select(i => digits.Substring(i, span))
            .Max(s => s
                .Select(c => (int)char.GetNumericValue(c))
                .Aggregate((curr, next) => curr * next));
}
