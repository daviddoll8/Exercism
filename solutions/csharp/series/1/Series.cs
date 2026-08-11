public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (numbers.Length < sliceLength || string.IsNullOrEmpty(numbers) || sliceLength <= 0)
            throw new ArgumentException();

        var resultSlices = new List<string>();
        var startIndex = 0;
        var slice = numbers.Take(sliceLength);

        while (slice.Count() == sliceLength)
        {
            resultSlices.Add(new string([.. slice]));
            startIndex++;
            slice = numbers.Skip(startIndex).Take(sliceLength);
        }

        return [.. resultSlices];
    }
}
