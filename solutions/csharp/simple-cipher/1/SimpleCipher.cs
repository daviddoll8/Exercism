using System.Text;

public class SimpleCipher
{
    public SimpleCipher()
    {
        Key = GenerateRandomKey();
    }

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

    public SimpleCipher(string key)
    {
        Key = key;
    }

    public string Key
    {
        get;
    }

    public string Encode(string plaintext)
    {
        var keyIndex = 0;
        var encoding = new StringBuilder();
        foreach (var letter in plaintext)
        {
            var textShift = letter - 'a';
            char encodedLetter = (char)(((Key[keyIndex] - 'a' + textShift) % 26) + 'a');
            encoding.Append(encodedLetter);

            if (keyIndex + 1 == Key.Length)
                keyIndex = 0;
            else
                keyIndex++;
        }
        return encoding.ToString();
    }

    public string Decode(string ciphertext)
    {
        var keyIndex = 0;
        var decoding = new StringBuilder();
        foreach (var letter in ciphertext)
        {
            if (letter < Key[keyIndex])
            {
                decoding.Append((char)((letter - Key[keyIndex]) + 26 + 'a'));
            }
            else //can safely just subract the letters to get the orginal
            {
                decoding.Append((char)(letter - Key[keyIndex] + 'a'));
            }

            if (keyIndex + 1 == Key.Length)
                keyIndex = 0;
            else
                keyIndex++;
        }
        return decoding.ToString();
    }
}
