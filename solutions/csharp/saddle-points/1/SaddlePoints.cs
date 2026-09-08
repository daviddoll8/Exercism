public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var result = new List<(int, int)>();
        for (var r = 0; r < matrix.GetLength(0); r++)
        {
            for (var c = 0; c < matrix.GetLength(1); c++)
            {
                if (IsGoodTree(matrix, r, c))
                    result.Add(new(r + 1, c + 1));
            }
        }
        return result;
    }

    private static bool IsGoodTree(int[,] matrix, int row, int col)
    {
        for (var r = 0; r < matrix.GetLength(0); r++)
        {
            if (matrix[r, col] < matrix[row, col])
                return false;
        }

        for (var c = 0; c < matrix.GetLength(1); c++)
        {
            if (matrix[row, c] > matrix[row, col])
                return false;
        }
        return true;
    }
}
