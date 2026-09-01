public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target < 0)
            throw new ArgumentException();

        if (target == 0)
            return [];

        int[] fewest = new int[target + 1];
        int[] used = new int[target + 1];
        fewest[0] = 0;
        for (var v = 1; v <= target; v++)
        {
            int best = int.MaxValue;
            foreach (var coin in coins)
            {
                if (coin > v)
                    continue;

                if (fewest[v - coin] == int.MaxValue)
                    continue;

                if (fewest[v - coin] + 1 < best)
                {
                    best = fewest[v - coin] + 1;
                    used[v] = coin;
                }
            }
            fewest[v] = best;
        }

        if (fewest[target] == int.MaxValue)
            throw new ArgumentException();

        var result = new List<int>();
        for (int v = target; v > 0; v -= used[v])
        {
            result.Add(used[v]);
        }
        return [.. result];
    }
}
