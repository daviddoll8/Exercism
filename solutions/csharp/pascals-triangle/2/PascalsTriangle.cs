public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var triangle = new List<List<int>>();

        for (int i = 0; i < rows; i++)
        {
            var row = new List<int>();
            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    row.Add(1);
                }
                else
                {
                    row.Add(triangle[i - 1][j - 1] + triangle[i - 1][j]);
                }
            }
            triangle.Add(row);
        }
        return triangle;
    }
}
