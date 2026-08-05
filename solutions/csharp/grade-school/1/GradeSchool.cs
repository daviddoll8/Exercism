public class GradeSchool
{
    private readonly SortedDictionary<int, SortedSet<string>> _roster = new();
    private readonly HashSet<string> _names = new();

    public bool Add(string student, int grade)
    {
        if (!_names.Add(student))
        {
            return false;
        }
        if (!_roster.TryGetValue(grade, out SortedSet<string>? names))
        {
            names = new SortedSet<string>();
            _roster[grade] = names;
        }
        names.Add(student);
        return true;
    }

    public IEnumerable<string> Roster() => _roster.Values.SelectMany(names => names);

    public IEnumerable<string> Grade(int grade) =>
        !_roster.TryGetValue(grade, out SortedSet<string>? names) ? [] : names;
}
