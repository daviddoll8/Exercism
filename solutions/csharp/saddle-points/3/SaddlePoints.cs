public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix) =>
        Enumerable.Range(0, matrix.GetLength(0))
            .SelectMany(r => Enumerable.Range(0, matrix.GetLength(1)), (r, c) => new { r, c })
            .Where(x => matrix[x.r, x.c] == Enumerable.Range(0, matrix.GetLength(1)).Max(col => matrix[x.r, col]))
            .Where(x => matrix[x.r, x.c] == Enumerable.Range(0, matrix.GetLength(0)).Min(row => matrix[row, x.c]))
            .Select(x => (x.r + 1, x.c + 1));
    // from r in Enumerable.Range(0, matrix.GetLength(0))
    // from c in Enumerable.Range(0, matrix.GetLength(1))
    // where matrix[r, c] == Enumerable.Range(0, matrix.GetLength(1)).Max(col => matrix[r, col])
    // where matrix[r, c] == Enumerable.Range(0, matrix.GetLength(0)).Min(row => matrix[row, c])
    // select (r + 1, c + 1);
}
