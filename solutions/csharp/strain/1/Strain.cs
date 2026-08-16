public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var result = new List<T>();
        for (int i = 0; i < collection.Count(); i++)
        {
            if (predicate(collection.ElementAt(i)))
                result.Add(collection.ElementAt(i));
        }
        return result;
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var result = new List<T>();
        for (int i = 0; i < collection.Count(); i++)
        {
            if (!predicate(collection.ElementAt(i)))
                result.Add(collection.ElementAt(i));
        }
        return result;
    }
}
