public class Matrix(string input)
{
    public int[][] InputMatrix { get; set; } =
        [.. input.Split('\n').Select(s => s.Split(' ').Select(int.Parse).ToArray())];

    public int[] Row(int row) => [.. InputMatrix[row - 1]];

    public int[] Column(int col) => [.. InputMatrix.Select((_, index) => InputMatrix[index][col - 1]).ToArray()];
}
