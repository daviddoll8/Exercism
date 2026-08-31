using System.Text;

public static class CryptoSquare
{
    public static string Ciphertext(string plaintext)
    {
        var normalizedText = new string([.. plaintext.ToLower().Where(char.IsLetterOrDigit)]);
        if (string.IsNullOrEmpty(normalizedText))
            return "";

        var (rows, columns) = GetRowsAndColumns(1, 1, normalizedText);
        var rectangleText = ConvertTextIntoRectangle(rows, columns, normalizedText);
        return RectangleToCipher(rectangleText, rows, columns);
    }

    private static string RectangleToCipher(List<string> rectangleText, int rows, int columns)
    {
        var cipherText = new StringBuilder();
        for (int col = 0; col < columns; col++)
        {
            for (var row = 0; row < rows; row++)
                cipherText.Append(rectangleText[row].ElementAt(col));
            if (col < columns - 1)
                cipherText.Append(' ');
        }
        return cipherText.ToString();
    }

    private static (int rows, int columns) GetRowsAndColumns(int rows, int columns, string normalizedText)
    {
        var numRows = rows;
        var numColumns = columns;
        while (numRows * numColumns < normalizedText.Length)
        {
            if (numRows == numColumns)
                numColumns++;
            else if (numColumns > numRows)
                numRows++;
        }
        return (numRows, numColumns);
    }

    private static List<string> ConvertTextIntoRectangle(int rows, int columns, string normalizedText)
    {
        var rectangleText = new List<string>();

        for (var rowIndex = 1; rowIndex < rows; rowIndex++)
            rectangleText.Add(normalizedText.Substring(columns * (rowIndex - 1), columns));

        var lastRow = normalizedText[((rows - 1) * columns)..];
        rectangleText.Add(lastRow.PadRight(columns));

        return rectangleText;
    }
}
