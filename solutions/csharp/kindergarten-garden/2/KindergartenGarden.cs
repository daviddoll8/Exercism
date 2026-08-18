using Xunit.Internal;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public class KindergartenGarden(string diagram)
{
    private readonly List<string> _rows = [.. diagram.Split('\n')];

    private readonly List<string> _students = new List<string>
    {
        "Alice", "Bob", "Charlie", "David", "Eve", "Fred",
        "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"
    }.Order().ToList();

    public IEnumerable<Plant> Plants(string student) =>
        _rows.SelectMany(row => row.Substring(_students.IndexOf(student) * 2, 2))
            .Select(letter => (Plant)(int)letter);
}
