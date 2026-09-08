public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix) =>
        Enumerable.Range(0, matrix.GetLength(0))
            .SelectMany(r => Enumerable.Range(0, matrix.GetLength(1)), (r, c) => new { r, c })
            .Where(x => matrix[x.r, x.c] == Enumerable.Range(0, matrix.GetLength(1)).Max(col => matrix[x.r, col]))
            .Where(x => matrix[x.r, x.c] == Enumerable.Range(0, matrix.GetLength(0)).Min(row => matrix[row, x.c]))
            .Select(x => (x.r + 1, x.c + 1));
}
