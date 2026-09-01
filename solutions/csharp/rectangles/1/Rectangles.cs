public static class Rectangles
{
    public static int Count(string[] rows)
    {
        if (!rows.Any() || rows.Length <= 1)
            return 0;

        int count = 0;
        for (var r1 = 0; r1 < rows.Length - 1; r1++)
        {
            for (var r2 = r1 + 1; r2 < rows.Length; r2++)
            {
                for (var c1 = 0; c1 < rows[r1].Length; c1++)
                {
                    for (var c2 = c1 + 1; c2 < rows[r2].Length; c2++)
                    {
                        var candidates = new List<char>()
                        {
                            rows[r1][c1], rows[r1][c2], rows[r2][c1], rows[r2][c2]
                        };

                        if (candidates.All(c => c == '+') && HasHorizontalLine(rows, r1, c1, c2) && HasHorizontalLine(rows, r2, c1, c2)
                            && HasVerticalLine(rows, c1, r1, r2) && HasVerticalLine(rows, c2, r1, r2))
                        {
                            count++;
                        }
                    }
                }
            }
        }
        return count;
    }

    private static bool HasHorizontalLine(string[] rows, int r, int c1, int c2)
    {
        if (c2 - c1 == 1)
            return true;
        foreach (var ch in rows[r][(c1 + 1)..c2])
        {
            if (ch != '+' && ch != '-')
                return false;
        }
        return true;
    }

    private static bool HasVerticalLine(string[] rows, int c, int r1, int r2)
    {
        if (r2 - r1 == 1)
            return true;
        for (var i = r1 + 1; i <= r2 - 1; i++)
        {
            if (rows[i][c] != '|' && rows[i][c] != '+')
                return false;
        }
        return true;
    }
}
