public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target < 0) throw new ArgumentException();
        if (target > 0 && target < coins.Min()) throw new ArgumentException();

        return Enumerable.Range(1, target)
            .Aggregate(new Dictionary<int, int[]> { [0] = [] }, UpdateFewestCoinsForChange)
            .GetValueOrDefault(target) ?? throw new ArgumentException();

        Dictionary<int, int[]> UpdateFewestCoinsForChange(Dictionary<int, int[]> current, int subTarget)
        {
            var fewestCoins = FewestCoinsForChange(current, subTarget);
            if (fewestCoins != null)
                current.Add(subTarget, fewestCoins);

            return current;
        }

        int[] FewestCoinsForChange(Dictionary<int, int[]> current, int subTarget) =>
            coins.Where(coin => coin <= subTarget)
            .Select(coin => current.GetValueOrDefault(subTarget - coin)?.Prepend(coin).ToArray())
            .Where(fewestCoins => fewestCoins != null)
            .OrderBy(fewestCoins => fewestCoins.Length)
            .FirstOrDefault();
    }
}
