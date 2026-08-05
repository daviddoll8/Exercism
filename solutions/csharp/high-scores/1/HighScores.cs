public class HighScores
{
    private List<int> scores;

    public HighScores(List<int> list) => scores = list;

    public List<int> Scores() => scores;

    public int Latest() => Scores().Last();

    public int PersonalBest() => Scores().Max();

    public List<int> PersonalTopThree() => Scores().OrderDescending().Take(3).ToList();
}
