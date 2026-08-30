using System.Text;

public class SimpleCipher
{
    public SimpleCipher() => Key = GenerateRandomKey();

    private string GenerateRandomKey()
    {
        var randomKey = new StringBuilder();
        for (int i = 0; i < 100; i++)
        {
            char letter = (char)(Random.Shared.Next(0, 26) + 'a');
            randomKey.Append(letter);
        }
        return randomKey.ToString();
    }

    public SimpleCipher(string key) => Key = key;

    public string Key { get; }

    public string Encode(string plaintext) => Shift(plaintext, +1);

    public string Decode(string ciphertext) => Shift(ciphertext, -1);

    private string Shift(string text, int direction)
    {
        var result = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            var keyShift = Key[i % Key.Length] - 'a';
            var letterShift = (text[i] - 'a' + direction * keyShift + 26) % 26;
            result.Append((char)(letterShift + 'a'));
        }
        return result.ToString();
    }
}
