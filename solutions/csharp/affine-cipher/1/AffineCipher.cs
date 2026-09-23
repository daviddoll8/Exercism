using System.Text;

public static class AffineCipher
{
    public static string Encode(string plainText, int a, int b) =>
        IsCoprime(a, 26) ? EncodeText(plainText, a, b) : throw new ArgumentException();

    private static string EncodeText(string plainText, int a, int b)
    {
        var normalizedText = plainText.ToLower().Where(char.IsLetterOrDigit);
        var encodedText = new StringBuilder();

        foreach (var letter in normalizedText)
        {
            if (char.IsDigit(letter))
            {
                encodedText.Append(letter);
                continue;
            }

            var i = letter - 'a';
            var encodedLetter = (char)(((a * i) + b) % 26 + 'a');
            encodedText.Append(encodedLetter);
        }

        return string.Join(" ", encodedText.ToString().Chunk(5).Select(chunk => new string(chunk)));
    }

    public static string Decode(string cipheredText, int a, int b) =>
        IsCoprime(a, 26) ? DecodeText(cipheredText, a, b) : throw new ArgumentException();

    private static string DecodeText(string cipheredText, int a, int b)
    {
        var normalizedText = cipheredText.ToLower().Where(char.IsLetterOrDigit);
        var modularInverse = FindModularInverse(a);
        var decodedText = new StringBuilder();
        foreach (var letter in normalizedText)
        {
            if (char.IsDigit(letter))
            {
                decodedText.Append(letter);
                continue;
            }

            var y = letter - 'a';
            var decodedLetter = (char)(((modularInverse * (y - b)) % 26 + 26) % 26 + 'a');
            decodedText.Append(decodedLetter);
        }

        return decodedText.ToString();
    }

    private static int FindModularInverse(int a) => Enumerable.Range(1, 25).First(i => (a * i) % 26 == 1);

    private static bool IsCoprime(int a, int v)
    {
        while (v != 0)
        {
            var temp = v;
            v = a % v;
            a = temp;
        }
        return a == 1;
    }
}
