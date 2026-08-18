using Xunit.Internal;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden(string diagram)
{
    private readonly List<string> _rows = [.. diagram.Split('\n')];

    private readonly List<string> _students = new List<string>
    {
        "Alice", "Bob", "Charlie", "David", "Eve", "Fred",
        "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"
    }.Order().ToList();

    public IEnumerable<Plant> Plants(string student)
    {
        Console.WriteLine($"ROW 0: {_rows[0]}");
        Console.WriteLine($"ROW 1: {_rows[1]}");

        var studentIndex = _students.IndexOf(student);
        Console.WriteLine($"STUDENT INDEX: {studentIndex}");
        string studentPlants = "";
        var plants = new List<Plant>();
        foreach (var row in _rows)
        {
            studentPlants += row.Substring(studentIndex * 2, 2);
        }

        Console.WriteLine($"STUDENT PLANTS: {studentPlants}");

        foreach (var plant in studentPlants)
        {
            switch (plant)
            {
                case 'G':
                    plants.Add(Plant.Grass);
                    break;
                case 'R':
                    plants.Add(Plant.Radishes);
                    break;
                case 'V':
                    plants.Add(Plant.Violets);
                    break;
                case 'C':
                    plants.Add(Plant.Clover);
                    break;
                default:
                    throw new Exception();
            }
        }

        return plants;
    }
}
