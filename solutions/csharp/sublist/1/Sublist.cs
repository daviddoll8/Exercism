public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable => (list1, list2) switch
        {
            _ when list1.SequenceEqual(list2) => SublistType.Equal,
            _ when list1.Count > list2.Count && IsSublist(list2, list1) => SublistType.Superlist,
            _ when list1.Count < list2.Count && IsSublist(list1, list2) => SublistType.Sublist,
            _ => SublistType.Unequal
        };

    private static bool IsSublist<T>(List<T> small, List<T> big) where T : IComparable =>
        Enumerable.Range(0, big.Count - small.Count + 1).Any(i => big.Skip(i).Take(small.Count).SequenceEqual(small));
}
