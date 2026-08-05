public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        var cipherText = text.ToCharArray();

        for (int i = 0; i < text.Length; i++)
        {
            if (!Char.IsLetter(text[i]))
                continue;

            cipherText[i] = Char.IsUpper(text[i]) switch
            {
                true => (char)((text[i] - 'A' + shiftKey) % 26 + 'A'),
                _ => (char)((text[i] - 'a' + shiftKey) % 26 + 'a'),
            };
        }

        return new string(cipherText);
    }
}
