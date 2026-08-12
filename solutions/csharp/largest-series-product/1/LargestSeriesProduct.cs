public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (span == 0)
            return 1;

        if (span < 0 || !digits.All(char.IsDigit) || digits.Length < span)
            throw new ArgumentException();

        var substrings = Enumerable.Range(0, digits.Length - span + 1)
            .Select(i => digits.Substring(i, span));

        var products = substrings.Max(s =>
            s.Select(c => (int)char.GetNumericValue(c)).Aggregate((curr, next) => curr * next));


        return products;
    }
}
