public static class CryptoSquare
{
    public static string Ciphertext(string plaintext)
    {
        var normalizedText = plaintext.ToLower().Where(char.IsLetterOrDigit);
        var size = normalizedText.Count();
        if (size == 0)
            return string.Empty;

        var columns = (int)Math.Ceiling(Math.Sqrt(size));
        var rows = (int)Math.Ceiling((double)size / columns);

        return string.Join(" ", Enumerable.Range(0, columns)
            .Select(col => string.Concat(normalizedText.Skip(col).Where((_, index) => index % columns == 0)).PadRight(rows)));
    }
}
