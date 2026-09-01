using System.Text;
public static class FlowerField
{
    public static string[] Annotate(string[] input)
    {
        var flowerField = new List<string>();

        for (var row = 0; row < input.Length; row++)
        {
            var rowResult = new StringBuilder();
            for (var col = 0; col < input[row].Length; col++)
            {
                if (input[row][col] == '*')
                {
                    rowResult.Append('*');
                }
                else
                {
                    var adjacentFlowers = CalculateAdjacentFlowers(input, row, col);
                    if (adjacentFlowers == 0)
                        rowResult.Append(' ');
                    else
                        rowResult.Append(adjacentFlowers);
                }
            }
            flowerField.Add(rowResult.ToString());
        }

        return [.. flowerField];
    }

    private static int CalculateAdjacentFlowers(string[] input, int row, int col)
    {
        var adjacentFlowers = 0;
        for (var dr = -1; dr <= 1; dr++)
        {
            for (var dc = -1; dc <= 1; dc++)
            {
                if (dr == 0 && dc == 0)
                    continue;

                var r = row + dr;
                var c = col + dc;
                if (r >= 0 && r < input.Length && c >= 0 && c < input[r].Length && input[r][c] == '*')
                    adjacentFlowers++;
            }
        }
        return adjacentFlowers;
    }
}
