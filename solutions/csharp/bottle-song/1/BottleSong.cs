using System.Collections.Generic;
using System.Text;

public static class BottleSong
{
    private static readonly Dictionary<int, string> NumberMapping = new()
    {
        [0] = "no",
        [1] = "One",
        [2] = "Two",
        [3] = "Three",
        [4] = "Four",
        [5] = "Five",
        [6] = "Six",
        [7] = "Seven",
        [8] = "Eight",
        [9] = "Nine",
        [10] = "Ten",
    };

    private static string GetBottleTag(int bottlesIndex) =>
        bottlesIndex == 1 ? "bottle" : "bottles";

    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        var bottlesSong = new List<string>();
        var bottlesIndex = startBottles;

        for (int i = takeDown; i > 0; i--)
        {
            bottlesSong.Add($"{NumberMapping[bottlesIndex]} green {GetBottleTag(bottlesIndex)} hanging on the wall,");
            bottlesSong.Add($"{NumberMapping[bottlesIndex]} green {GetBottleTag(bottlesIndex)} hanging on the wall,");
            bottlesSong.Add("And if one green bottle should accidentally fall,");
            bottlesSong.Add($"There'll be {NumberMapping[bottlesIndex - 1].ToLower()} green {GetBottleTag(bottlesIndex - 1)} hanging on the wall.");
            bottlesIndex--;
            if (takeDown > 1 && i != 1)
                bottlesSong.Add("");
        }

        return bottlesSong;
    }
}
