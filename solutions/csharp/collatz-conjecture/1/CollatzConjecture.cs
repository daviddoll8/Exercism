public static class CollatzConjecture
{
    public static int Steps(int number) => Steps(number, 0);

    public static int Steps(int number, int steps) =>
        number switch
        {
            < 1 => throw new ArgumentOutOfRangeException(),
            1 => steps,
            _ => (number % 2) switch
            {
                0 => Steps(number / 2, steps + 1),
                _ => Steps((number * 3) + 1, steps + 1)
            },
        };
}
