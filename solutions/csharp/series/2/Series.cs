public static class Series
{
    public static string[] Slices(string numbers, int sliceLength) =>
        sliceLength > numbers.Length || sliceLength <= 0
            ? throw new ArgumentException()
            : [.. Enumerable.Range(0, numbers.Length - sliceLength + 1)
              .Select(index => numbers.Substring(index, sliceLength))];
}
