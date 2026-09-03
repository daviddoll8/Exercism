public class DndCharacter
{
    public int Strength { get; } = Ability();
    public int Dexterity { get; } = Ability();
    public int Constitution { get; } = Ability();
    public int Intelligence { get; } = Ability();
    public int Wisdom { get; } = Ability();
    public int Charisma { get; } = Ability();
    public int Hitpoints { get; }

    public DndCharacter() => Hitpoints = 10 + Modifier(Constitution);

    public static int Modifier(int score) => (int)Math.Floor((double)(score - 10) / 2);

    public static int Ability()
    {
        var diceRolls = new List<int>();
        for (int i = 0; i < 4; i++)
            diceRolls.Add(Random.Shared.Next(1, 7));
        return diceRolls.Order().Skip(1).Sum();
    }

    public static DndCharacter Generate() => new();
}
