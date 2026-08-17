public static class Sieve
{
    public static int[] Primes(int limit)
    {
        var markedList = new Dictionary<int, bool>();
        for (int i = 2; i <= limit; i++)
        {
            markedList.Add(i, false);
        }

        foreach (var num in markedList)
        {
            if (!num.Value)
            {
                MarkMultiplesOf(num.Key, markedList);
            }
        }
        return [.. markedList.Where(kvp => !kvp.Value).Select(kvp => kvp.Key)];
    }

    private static void MarkMultiplesOf(int num, Dictionary<int, bool> markedList) =>
        markedList.Where(kvp => kvp.Key > num && kvp.Key % num == 0).ToList().ForEach(kvp => markedList[kvp.Key] = true);
}
