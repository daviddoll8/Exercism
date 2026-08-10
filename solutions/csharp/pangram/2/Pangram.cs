public static class Pangram
{
    public static bool IsPangram(string input) =>
        input.ToLower()
            .Where(char.IsLetter)
            .GroupBy(c => c)
            .Count() == 26;
}
