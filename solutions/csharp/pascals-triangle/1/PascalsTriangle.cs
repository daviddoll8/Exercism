public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var resultRows = new List<List<int>>();
        var previousRow = new List<int>();
        for (int i = 1; i <= rows; i++)
        {
            if (i == 1)
            {
                resultRows.Add([1]);
                previousRow = resultRows[0];
                continue;
            }
            resultRows.Add(GenerateTriangleRow(i, previousRow));
            previousRow = resultRows[i - 1];
        }
        return resultRows;
    }

    private static List<int> GenerateTriangleRow(int currRow, List<int> previousRow)
    {
        var resultRow = new List<int>();
        var leftIndex = 0;
        var rightIndex = 1;
        for (int i = 0; i < currRow; i++)
        {
            if (i == 0 || i == currRow - 1)
            {
                resultRow.Add(1);
                continue;
            }
            resultRow.Add(previousRow[leftIndex] + previousRow[rightIndex]);
            leftIndex++;
            rightIndex++;
        }

        return resultRow;
    }
}
