public static class SquareRoot
{
    public static int Root(int number)
    {
        var result = 0;
        while ((result + 1) * (result + 1) <= number)
            result++;
        return result;
    }
}
