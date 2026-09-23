public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        var normalized = new string([.. number.Where(c => c != '-')]);

        if (!NormalizedValid(normalized))
            return false;

        var index = 10;
        var isbnResult = 0;
        foreach (var num in normalized)
        {
            isbnResult += num == 'X' ? 10 * index : (int)char.GetNumericValue(num) * index;
            index--;
        }

        return isbnResult % 11 == 0;
    }

    private static bool NormalizedValid(string normalized) =>
        normalized.Length == 10
        && normalized.SkipLast(1).All(char.IsDigit)
        && (char.IsDigit(normalized[^1]) || normalized[^1] == 'X');
}
