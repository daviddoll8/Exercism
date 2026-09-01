using System.Text;
public static class CryptoSquare
{
    public static string Ciphertext(string plaintext)
    {
        var normalizedText = new string([.. plaintext.ToLower().Where(char.IsLetterOrDigit)]);
        var textLength = normalizedText.Length;
        if (textLength == 0)
            return "";

        var columns = (int)Math.Ceiling(Math.Sqrt(textLength));
        var rows = (int)Math.Ceiling((double)textLength / columns);
        var cipherText = new StringBuilder((rows * columns) + columns - 1);

        for (var col = 0; col < columns; col++)
        {
            for (var row = 0; row < rows; row++)
            {
                var index = (row * columns) + col;
                cipherText.Append(index < textLength ? normalizedText[index] : ' ');
            }
            if (col < columns - 1)
                cipherText.Append(' ');
        }

        return cipherText.ToString();
    }
}
