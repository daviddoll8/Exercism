public static class ResistorColor
{
    private static readonly Dictionary<int, string> ResistorColors = new()
    {
        [0] = "black",
        [1] = "brown",
        [2] = "red",
        [3] = "orange",
        [4] = "yellow",
        [5] = "green",
        [6] = "blue",
        [7] = "violet",
        [8] = "grey",
        [9] = "white"
    };

    public static int ColorCode(string color) =>
        ResistorColors.Where(colors => colors.Value == color).FirstOrDefault().Key;

    public static string[] Colors() =>
        ResistorColors.Values.ToArray();

}
