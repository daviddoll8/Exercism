public static class Darts
{
    public static int Score(double x, double y) =>
        (x, y) switch
        {
            _ when (x * x) + (y * y) <= 1 => 10,
            _ when (x * x) + (y * y) <= 25 => 5,
            _ when (x * x) + (y * y) <= 100 => 1,
            _ => 0
        };
}
