public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        var tournamentRepository = new Dictionary<string, Team>();

        using (StreamReader reader = new StreamReader(inStream))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var gameInfo = line.Split(';');
                var winningTeam = gameInfo[0];
                var losingTeam = gameInfo[1];
                var winLossOrDraw = gameInfo[2];
                if (gameInfo.Length != 3)
                {
                    continue;
                }

                if (!tournamentRepository.ContainsKey(winningTeam))
                {
                    tournamentRepository.Add(winningTeam, new Team(winningTeam));
                }

                if (!tournamentRepository.ContainsKey(losingTeam))
                {
                    tournamentRepository.Add(losingTeam, new Team(losingTeam));
                }

                var firstTeam = tournamentRepository[winningTeam];
                var secondTeam = tournamentRepository[losingTeam];

                switch (winLossOrDraw)
                {
                    case "win":
                        firstTeam.MatchesPlayed++;
                        firstTeam.Wins++;
                        firstTeam.Points += 3;
                        secondTeam.MatchesPlayed++;
                        secondTeam.Losses++;
                        break;
                    case "loss":
                        secondTeam.MatchesPlayed++;
                        secondTeam.Wins++;
                        secondTeam.Points += 3;
                        firstTeam.MatchesPlayed++;
                        firstTeam.Losses++;
                        break;
                    default:
                        firstTeam.MatchesPlayed++;
                        firstTeam.Draws++;
                        firstTeam.Points++;
                        secondTeam.MatchesPlayed++;
                        secondTeam.Draws++;
                        secondTeam.Points++;
                        break;
                }
            }
        }

        var orderedTeams = tournamentRepository.Values
            .OrderByDescending(team => team.Points)
            .ThenBy(team => team.Name);

        var lines = new List<string>
        {
            "Team                           | MP |  W |  D |  L |  P"
        };

        foreach (var team in orderedTeams)
        {
            lines.Add($"{team.Name,-31}| {team.MatchesPlayed,2} | {team.Wins,2} | {team.Draws,2} | {team.Losses,2} | {team.Points,2}");
        }

        using (StreamWriter writer = new StreamWriter(outStream, leaveOpen: true))
        {
            writer.Write(string.Join("\n", lines));
            writer.Flush();
        }
    }
}

public class Team(string name)
{
    public string Name { get; set; } = name;
    public int MatchesPlayed { get; set; }
    public int Wins { get; set; }
    public int Draws { get; set; }
    public int Losses { get; set; }
    public int Points { get; set; }

}
