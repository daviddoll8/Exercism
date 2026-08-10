public enum Classification
{
    Perfect = 0,
    Abundant = 1,
    Deficient = -1
}

public static class PerfectNumbers
{
    public static Classification Classify(int number) =>
        (Classification)Enumerable.Range(1, number - 1).Where(i => number % i == 0).Sum().CompareTo(number);
}
