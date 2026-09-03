using Xunit.Internal;
public enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

public class RobotSimulator(Direction direction, int x, int y)
{
    public Direction Direction { get; private set; } = direction;
    public int X { get; private set; } = x;
    public int Y { get; private set; } = y;

    public void Move(string instructions) => instructions.ForEach(MoveRobot);

    public void MoveRobot(char instruction)
    {
        switch (instruction)
        {
            case 'R':
                ChangeDirectionRight();
                break;
            case 'L':
                ChangeDirectionLeft();
                break;
            case 'A':
                Advance();
                break;
        }
    }

    private Direction ChangeDirectionRight() =>
        Direction == Direction.West ? Direction = Direction.North : ++Direction;

    private Direction ChangeDirectionLeft() =>
        Direction == Direction.North ? Direction = Direction.West : --Direction;

    public int Advance() => Direction switch
    {
        Direction.North => Y++,
        Direction.East => X++,
        Direction.South => Y--,
        Direction.West => X--,
        _ => throw new IndexOutOfRangeException()
    };
}
