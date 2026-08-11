public static class ResistorColorTrio
{
    public enum ColorCodes
    {
        Black, Brown, Red, Orange,
        Yellow, Green, Blue,
        Violet, Grey, White
    }

    public static string Label(string[] colors)
    {
        var colorValue =
            ((int)Enum.Parse<ColorCodes>(colors[0], true) * 10) +
            (int)Enum.Parse<ColorCodes>(colors[1], true);
        var thirdColorMultiplier = Math.Pow(10, (int)Enum.Parse<ColorCodes>(colors[2], true));
        var ohmValue = colorValue * thirdColorMultiplier;
        var metricPrefix = GetMetricPrefix(CountZeros(ohmValue));
        var colorResult = GetColorResult(ohmValue, colorValue, metricPrefix);

        return $"{colorResult} {metricPrefix}ohms";
    }

    private static string GetColorResult(double ohmValue, int colorValue, string metricPrefix) =>
        metricPrefix switch
        {
            "giga" => colorValue.ToString(),
            "kilo" => new string([.. ohmValue.ToString().SkipLast(3)]),
            "mega" => new string([.. ohmValue.ToString().SkipLast(6)]),
            _ => ohmValue.ToString()
        };

    private static int CountZeros(double ohmValue) =>
        ohmValue.ToString().Count(c => c == '0');

    private static string GetMetricPrefix(int numZeros) =>
        numZeros switch
        {
            _ when numZeros >= 9 => "giga",
            _ when numZeros >= 6 => "mega",
            _ when numZeros >= 3 => "kilo",
            _ => ""
        };
}
