public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix) =>
        from r in Enumerable.Range(0, matrix.GetLength(0))
        from c in Enumerable.Range(0, matrix.GetLength(1))
        where matrix[r, c] == Enumerable.Range(0, matrix.GetLength(1)).Max(col => matrix[r, col])
        where matrix[r, c] == Enumerable.Range(0, matrix.GetLength(0)).Min(row => matrix[row, c])
        select (r + 1, c + 1);
}
