public static class ListOps
{
    public static int Length<T>(List<T> input) => input.Count;

    public static List<T> Reverse<T>(List<T> input) => [.. input.Select(v => v).Reverse()];

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map) => [.. input.Select(i => map(i))];

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate) => [.. input.Where(v => predicate(v))];

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        var acc = start;
        foreach (var value in input)
        {
            acc = func(acc, value);
        }
        return acc;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        var acc = start;
        for (var i = input.Count - 1; i >= 0; i--)
        {
            acc = func(input[i], acc);
        }
        return acc;
    }

    public static List<T> Concat<T>(List<List<T>> input) => [.. input.SelectMany(list => list.Select(v => v))];

    public static List<T> Append<T>(List<T> left, List<T> right) => [.. left.Concat(right)];
}
