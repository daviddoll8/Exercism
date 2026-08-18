public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes) =>
        !dominoes.Any() || CanChain(dominoes, dominoes.First(), dominoes.First().Item1, dominoes.First().Item2);

    private static bool CanChain(IEnumerable<(int, int)> dominoes, (int, int) lastDomino, int lastNumber, int goal)
    {
        var dominoList = dominoes.ToList();
        dominoList.Remove(lastDomino);

        return !dominoList.Any()
            ? lastNumber == goal
            : dominoList
                .Any(domino => (domino.Item1 == lastNumber || domino.Item2 == lastNumber)
                    && CanChain(dominoList, domino, domino.Item1 == lastNumber ? domino.Item2 : domino.Item1, goal));
    }
}
