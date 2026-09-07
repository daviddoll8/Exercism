public static class ListOps
{
    public static int Length<T>(List<T> input) => input.Count;

    public static List<T> Reverse<T>(List<T> input) => [.. input.Select(v => v).Reverse()];

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map) => [.. input.Select(map)];

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate) => [.. input.Where(predicate)];

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func) => input.Aggregate(start, func);

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func) =>
        Enumerable.Reverse(input).Aggregate(start, (acc, x) => func(x, acc));

    public static List<T> Concat<T>(List<List<T>> input) => [.. input.SelectMany(list => list.Select(v => v))];

    public static List<T> Append<T>(List<T> left, List<T> right) => [.. left.Concat(right)];
}
