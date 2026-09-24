public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category) =>
        category switch
        {
            >= YachtCategory.Ones and <= YachtCategory.Sixes => Count(dice, (int)category),
            YachtCategory.FullHouse => FullHouse(dice),
            YachtCategory.FourOfAKind => FourOfAKind(dice),
            YachtCategory.LittleStraight => Straight(dice, [1, 2, 3, 4, 5]),
            YachtCategory.BigStraight => Straight(dice, [2, 3, 4, 5, 6]),
            YachtCategory.Choice => dice.Sum(),
            YachtCategory.Yacht => Yacht(dice),
            _ => throw new ArgumentException($"Unknown category: {category}", nameof(category))
        };

    private static int Count(int[] dice, int face) => dice.Count(die => die == face) * face;

    private static int FullHouse(int[] dice)
    {
        var groupSizes = dice.GroupBy(die => die)
            .Select(group => group.Count())
            .OrderByDescending(size => size)
            .ToArray();

        return groupSizes.Length == 2 && groupSizes[0] == 3 && groupSizes[1] == 2
            ? dice.Sum()
            : 0;
    }

    private static int FourOfAKind(int[] dice) =>
        dice.GroupBy(die => die)
            .FirstOrDefault(group => group.Count() >= 4)?
            .Key * 4 ?? 0;

    private static int Straight(int[] dice, int[] expected) =>
        dice.Order().SequenceEqual(expected) ? 30 : 0;

    private static int Yacht(int[] dice) => dice.Distinct().Count() == 1 ? 50 : 0;
}
