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
            YachtCategory.Ones => Count(dice, (int)YachtCategory.Ones),
            YachtCategory.Twos => Count(dice, (int)YachtCategory.Twos),
            YachtCategory.Threes => Count(dice, (int)YachtCategory.Threes),
            YachtCategory.Fours => Count(dice, (int)YachtCategory.Fours),
            YachtCategory.Fives => Count(dice, (int)YachtCategory.Fives),
            YachtCategory.Sixes => Count(dice, (int)YachtCategory.Sixes),
            YachtCategory.FullHouse => FullHouse(dice),
            YachtCategory.FourOfAKind => SameFace(dice, category),
            YachtCategory.LittleStraight => Straight(dice, category),
            YachtCategory.BigStraight => Straight(dice, category),
            YachtCategory.Choice => dice.Sum(),
            YachtCategory.Yacht => SameFace(dice, category),
            _ => throw new ArgumentException()
        };

    private static int SameFace(int[] dice, YachtCategory category)
    {
        if (category == YachtCategory.FourOfAKind)
        {
            var group = dice.GroupBy(x => x).FirstOrDefault(g => g.Count() >= 4);
            return (group?.Take(4).Sum()) ?? 0;
        }
        else if (category == YachtCategory.Yacht && dice.All(x => x == dice[0]))
        {
            return 50;
        }
        else
        {
            return 0;
        }
    }

    private static int Straight(int[] dice, YachtCategory category) =>
        category switch
        {
            YachtCategory.LittleStraight => dice.Order().SequenceEqual([1, 2, 3, 4, 5]) ? 30 : 0,
            YachtCategory.BigStraight => dice.Order().SequenceEqual([2, 3, 4, 5, 6]) ? 30 : 0,
            _ => throw new ArgumentException()
        };

    private static int FullHouse(int[] dice)
    {
        var grouped = dice.GroupBy(d => d).Select(g => g.ToArray()).ToArray();
        return grouped.GetLength(0) != 2
            || ((grouped[0].Length != 2 || grouped[1].Length != 3) && (grouped[0].Length != 3 || grouped[1].Length != 2))
            ? 0
            : dice.Sum();
    }

    private static int Count(int[] dice, int numToCount) => dice.Where(roll => roll == numToCount).Sum();
}

