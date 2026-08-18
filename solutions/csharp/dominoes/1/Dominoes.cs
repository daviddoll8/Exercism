public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        if (!dominoes.Any())
            return true;

        var degrees = new Dictionary<int, int>();
        foreach (var domino in dominoes)
        {
            if (!degrees.TryAdd(domino.Item1, 1))
            {
                degrees[domino.Item1]++;
            }

            if (!degrees.TryAdd(domino.Item2, 1))
            {
                degrees[domino.Item2]++;
            }
        }

        foreach (var degree in degrees)
        {
            if (degree.Value % 2 != 0)
                return false;
        }

        var adjacency = new Dictionary<int, HashSet<int>>();

        foreach (var domino in dominoes)
        {
            if (!adjacency.ContainsKey(domino.Item1))
            {
                adjacency.Add(domino.Item1, [domino.Item2]);
            }

            if (!adjacency.ContainsKey(domino.Item2))
            {
                adjacency.Add(domino.Item2, [domino.Item1]);
                continue;
            }
            adjacency[domino.Item2].Add(domino.Item1);
            adjacency[domino.Item1].Add(domino.Item2);
        }

        var start = degrees.First().Key;
        var visited = new HashSet<int>();
        var frontier = new Stack<int>([start]);

        while (frontier.Count > 0)
        {
            var node = frontier.Pop();
            if (visited.Contains(node))
                continue;
            visited.Add(node);
            foreach (var neighbor in adjacency[node])
            {
                frontier.Push(neighbor);
            }
        }

        return visited.Count == degrees.Count;
    }
}
